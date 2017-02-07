using ESISharp.Enumerations;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp
{
    /// <summary>
    /// SSO Authentication Operations
    /// </summary>
    public partial class Sso
    {
        internal void Authorize()
        {
            if (ClientID == null) return;

            if(RefreshToken != null && GrantType == OAuthGrant.Authorization && !ReauthorizeScopes)
            {
                RefreshAccessToken(RefreshToken);
                return;
            }

            List<Scope> LocalRequestedScopes = RequestedScopes;

            StringBuilder SsoUrl = new StringBuilder();
            SsoUrl.Append("https://login.eveonline.com/oauth/authorize?");
            if (GrantType == OAuthGrant.Authorization && SecretKey != null)
            {
                SsoUrl.Append("&response_type=code");
            }
            else
            {
                SsoUrl.Append("&response_type=token");

            }
            SsoUrl.Append("&state=" + State);
            SsoUrl.Append("&redirect_uri=" + CallbackUrl);
            SsoUrl.Append("&client_id=" + ClientID);
            SsoUrl.Append("&scope=" + ScopesUrl);

            System.Diagnostics.Process.Start(SsoUrl.ToString());

            NamedPipeServerStream Server = new NamedPipeServerStream("ESISharpAuth");
            StreamReader Reader = new StreamReader(Server);
            Server.WaitForConnection();
            string AuthRouterReply = Reader.ReadLine();
            Server.WaitForPipeDrain();
            Server.Disconnect();
            Server.Close();

            Dictionary<string, string> ReplyArguments = ParseReplyArguments(AuthRouterReply);

            if(GrantType == OAuthGrant.Authorization && SecretKey != null)
            {
                string AuthCode;
                ReplyArguments.TryGetValue("code", out AuthCode);
                string AccessTokenResponse = GetAccessToken(AuthCode);
                while(!string.IsNullOrEmpty(AccessTokenResponse))
                {
                    AccessToken Token = JsonConvert.DeserializeObject<AccessToken>(AccessTokenResponse);
                    AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
                    GrantType = OAuthGrant.Authorization;
                    if(!LocalRequestedScopes.Contains(Scope.None))
                    {
                        AuthorizedScopes = LocalRequestedScopes;
                        ClearRequestedScopes();
                    }
                    break;
                }
            }
            else
            {
                string ImplicitAccessToken;
                string ImplicitTokenType;
                string ImplicitTokenExpiresIn;

                ReplyArguments.TryGetValue("access_token", out ImplicitAccessToken);
                ReplyArguments.TryGetValue("token_type", out ImplicitTokenType);
                ReplyArguments.TryGetValue("expires_in", out ImplicitTokenExpiresIn);
                ImplicitToken = new ImplicitToken(ImplicitAccessToken, ImplicitTokenType, ImplicitTokenExpiresIn);
                GrantType = OAuthGrant.Implicit;
                if (!LocalRequestedScopes.Contains(Scope.None))
                {
                    AuthorizedScopes = LocalRequestedScopes;
                    ClearRequestedScopes();
                }
            }
        }

        private Dictionary<string, string> ParseReplyArguments(string RouterReply)
        {
            Dictionary<string, string> Output = new Dictionary<string, string>();
            string ReplyHeaderChar;
            if (GrantType == OAuthGrant.Implicit) { ReplyHeaderChar = @"#"; } else { ReplyHeaderChar = @"?"; }
            string UrlHeader = CallbackProtocol + @":///" + ReplyHeaderChar;
            var ReplyArgs = from Match in RouterReply.Split(new string[] { UrlHeader }, StringSplitOptions.None).Where(m => m.Contains('='))
                            .SelectMany(p => p.Split('&'))
                            where Match.Contains('=')
                            select new KeyValuePair<string, string>(Match.Split('=')[0], Match.Split('=')[1]);
            ReplyArgs.ToList().ForEach(kvp => Output.Add(kvp.Key, kvp.Value));
            return Output;
        }

        private string GetAccessToken(string AuthCode)
        {
            Task<string> GetAccessTokenTask = SsoPost(
                new Uri("https://login.eveonline.com/oauth/token"),
                "Basic",
                Base64Encode(ClientID + ":" + SecretKey),
                "application/json",
                "authorization_code",
                "code",
                AuthCode);
            GetAccessTokenTask.Wait();
            return GetAccessTokenTask.Result;
        }

        internal void RefreshAccessToken()
        {
            Task<string> GetAccessTokenTask = SsoPost(
                new Uri("https://login.eveonline.com/oauth/token"),
                "Basic",
                Base64Encode(ClientID + ":" + SecretKey),
                "application/json",
                "refresh_token",
                "refresh_token",
                AuthToken.RefreshToken);
            GetAccessTokenTask.Wait();
            AccessToken Token = JsonConvert.DeserializeObject<AccessToken>(GetAccessToken(GetAccessTokenTask.Result));
            AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
        }

        internal void RefreshAccessToken(string RefreshToken)
        {
            Task<string> GetAccessTokenTask = SsoPost(
                new Uri("https://login.eveonline.com/oauth/token"),
                "Basic",
                Base64Encode(ClientID + ":" + SecretKey),
                "application/json",
                "refresh_token",
                "refresh_token",
                RefreshToken);
            GetAccessTokenTask.Wait();
            AccessToken Token = JsonConvert.DeserializeObject<AccessToken>(GetAccessTokenTask.Result);
            AuthToken = new AuthToken(Token.access_token, Token.token_type, Token.refresh_token, Token.expires_in);
        }

        private async Task<string> SsoPost(Uri Uri, string AuthType, string AuthHeader, string AcceptType, string Grant, string CodeType, string Code)
        {
            using (HttpClient Client = new HttpClient())
            {
                string ResponseString;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthType, AuthHeader);
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptType));
                HttpResponseMessage Response = await Client.PostAsync(Uri, new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", Grant),
                        new KeyValuePair<string, string>(CodeType, Code)
                    }));
                ResponseString = await Response.Content.ReadAsStringAsync();
                return ResponseString;
            }
        }

        private string Base64Encode(string PlainText)
        {
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
            return Convert.ToBase64String(PlainTextBytes);
        }

        internal bool IsTokenValid()
        {
            DateTime Expires;
            int TimeDifference;
            if (GrantType == OAuthGrant.Authorization)
            { Expires = AuthToken.Expires; }
            else
            { Expires = ImplicitToken.Expires; }
            TimeDifference = DateTime.Compare(Expires, DateTime.UtcNow);
            if (TimeDifference < 0)
            { return false; }
            else
            { return true; }
        }

        internal void CreateRegistryKeys()
        {
            string Protocol = CallbackProtocol;
            string RouterCommand = @"""" + @AuthRouterFilePath + @""" ""%1""";

            RegistryKey ProtocolRoot = Registry.ClassesRoot.CreateSubKey(Protocol);
            ProtocolRoot.SetValue("", "URL:Eve Online SSO Protocol");
            ProtocolRoot.SetValue("URL Protocol", "");

            RegistryKey DefaultIcon = ProtocolRoot.CreateSubKey("DefaultIcon");
            DefaultIcon.SetValue("", AuthRouterFileName + ".exe,1");

            RegistryKey Shell = ProtocolRoot.CreateSubKey("Shell");
            RegistryKey Open = Shell.CreateSubKey("Open");
            RegistryKey Command = Open.CreateSubKey("Command");
            Command.SetValue("", RouterCommand);
        }

        /// <summary>
        /// Verify information of the callback protocol.
        /// <para/>Key will be create if it doesn't exist, or overwritten if there is an error.
        /// </summary>
        public void VerifyCallbackProtocolRegistyKey()
        {
            string Protocol = CallbackProtocol;
            string RouterCommand = @"""" + @AuthRouterFilePath + @""" ""%1""";
            RegistryKey ProtocolRoot = Registry.ClassesRoot.OpenSubKey(Protocol);

            if (ProtocolRoot == null)
            {
                CreateRegistryKeys();
            }
            else
            {
                try
                {
                    RegistryKey DefaultIconKey = ProtocolRoot.OpenSubKey("DefaultIcon");
                    RegistryKey ShellKey = ProtocolRoot.OpenSubKey("Shell");
                    RegistryKey OpenKey = ShellKey.OpenSubKey("Open");
                    RegistryKey CommandKey = OpenKey.OpenSubKey("Command");

                    if (DefaultIconKey == null || ShellKey == null || OpenKey == null || CommandKey == null)
                    { CreateRegistryKeys(); return; }

                    bool ProtocolRootValue = ProtocolRoot.GetValue("") != null;
                    bool DefaultIconValue = DefaultIconKey.GetValue("") != null;
                    bool CommandValue = CommandKey.GetValue("") != null;

                    if (!ProtocolRootValue && !DefaultIconValue && !CommandValue)
                    { CreateRegistryKeys(); return; }

                    if (CommandKey.GetValue("").ToString() != RouterCommand)
                        CreateRegistryKeys();
                }
                catch (NullReferenceException)
                {
                    CreateRegistryKeys();
                }
            }
        }

        internal class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
        }
    }
}
