using ESISharp.Enumeration;
using ESISharp.Model.Object;
using ESISharp.Sso.Scopes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESISharp.Sso
{
    public class Authentication
    {
        private readonly Main _Main;
        private readonly UriBuilder _AuthUrl;
        private readonly UriBuilder _TokenUrl;
        private readonly UriBuilder _VerifyUrl;

        internal Authentication(Main main)
        {
            _Main = main;
            var loginUrl = new UriBuilder
            {
                Scheme = "https",
                Host = "login.eveonline.com"
            };
            _AuthUrl = new UriBuilder(loginUrl.Uri)
            {
                Path = "v2/oauth/authorize"
            };
            _TokenUrl = new UriBuilder(loginUrl.Uri)
            {
                Path = "v2/oauth/token"
            };
            _VerifyUrl = new UriBuilder(loginUrl.Uri)
            {
                Path = "oauth/verify"
            };
        }

        internal async Task<bool> Authorize()
        {
            if (_Main._ClientId == null)
                return false;

            if (_Main._RefreshToken != null &&
                _Main.Client.GrantType == OAuthGrant.Authorization &&
                !_Main.Client.ScopesReathorize)
            {
                return RefreshAccessToken(_Main._RefreshToken).Result;
            }

            var localScopesRequested = _Main.Client.ScopesRequested;
            var pipeName = Guid.NewGuid().ToString();

            var authUrl = GetSsoAuthUrl(pipeName);

            Process.Start(authUrl);

            // TODO: Make NamedPipes Async
            var server = new NamedPipeServerStream(pipeName);
            var reader = new StreamReader(server);
            server.WaitForConnection();
            var authRelayReply = reader.ReadLine();
            server.WaitForPipeDrain();
            server.Disconnect();
            server.Close();

            var authRelayReplyArguments = ParseAuthRelayReplyArguments(authRelayReply);

            if (_Main.Client.GrantType == OAuthGrant.Authorization && _Main._SecretKey != null)
            {
                var parse = await ParseAuthToken(authRelayReplyArguments, localScopesRequested);

                if (!parse)
                    return false;
                else
                    return true;
            }
            else
            {
                if (!ParseImplicitToken(authRelayReplyArguments, localScopesRequested))
                    return false;
                else
                    return true;
            }
        }

        private string GetSsoAuthUrl(string state)
        {
            var ssoBuilder = _AuthUrl;
            var query = HttpUtility.ParseQueryString(ssoBuilder.Query);
            if (_Main.Client.GrantType == OAuthGrant.Authorization &&
                _Main._SecretKey != null)
            {
                query["response_type"] = "code";
            }
            else
            {
                query["response_type"] = "token";
            }
            query["state"] = state;
            query["redirect_uri"] = _Main.Client.CallbackUrl;
            query["client_id"] = _Main._ClientId;
            query["scope"] = _Main.Client.ScopesUrl;
            ssoBuilder.Query = query.ToString();
            return ssoBuilder.ToString();
        }

        private Dictionary<string, string> ParseAuthRelayReplyArguments(string reply)
        {
            var output = new Dictionary<string, string>();
            var replyHeaderChar = string.Empty;

            if (_Main.Client.GrantType == OAuthGrant.Implicit)
                replyHeaderChar = @"#";
            else
                replyHeaderChar = @"?";

            var urlHeader = _Main.Client.CallbackUrl + replyHeaderChar;
            var replyArgs = reply.Split(new string[] { urlHeader }, StringSplitOptions.None)
                .SelectMany(p => p.Split('&'))
                .Where(m => m.Contains('='))
                .Select(m => new KeyValuePair<string, string>(m.Split('=')[0], m.Split('=')[1]));
            replyArgs.ToList().ForEach(kvp => output.Add(kvp.Key, kvp.Value));
            return output;
        }

        private async Task<bool> ParseAuthToken(Dictionary<string, string> args, List<Scope> scopes)
        {
            var a = args.TryGetValue("code", out string code);

            if (!a)
                return false;

            var response = await GetAccessToken(code).ConfigureAwait(false);
            var token = JsonConvert.DeserializeObject<SsoAccessToken>(response);
            _Main.Client._Token = new SsoToken(token.AccessToken, token.TokenType, token.ExpiresIn, token.RefreshToken);
            _Main.Client._GrantType = OAuthGrant.Authorization;
            if (!scopes.Contains(Scope.None))
            {
                _Main.Client._ScopesAuthorized = scopes;
                _Main.Client.ClearRequestedScopes();
            }

            return true;
        }

        private bool ParseImplicitToken(Dictionary<string, string> args, List<Scope> scopes)
        {
            var a = args.TryGetValue("access_token", out string accessToken);
            var b = args.TryGetValue("token_type", out string tokenType);
            var c = args.TryGetValue("expires_in", out string expiresIn);

            if (!a || !b || !c)
                return false;

            _Main.Client._Token = new SsoToken(accessToken, tokenType, expiresIn);
            _Main.Client._GrantType = OAuthGrant.Implicit;
            if (!scopes.Contains(Scope.None))
            {
                _Main.Client._ScopesAuthorized = scopes;
                _Main.Client.ClearRequestedScopes();
            }

            return true;
        }

        private async Task<string> GetAccessToken(string authCode)
        {
            var task = await SsoPost(
                "authorization_code",
                "code",
                authCode
                ).ConfigureAwait(false);
            return task;
        }

        private async Task<bool> RefreshAccessToken()
        {
            return await RefreshAccessToken(string.Empty);
        }

        private async Task<bool> RefreshAccessToken(string refreshtoken)
        {
                var token = refreshtoken != string.Empty ? refreshtoken : _Main.Client.Token.RefreshToken;
                var task = await SsoPost(
                    "refresh_token",
                    "refresh_token",
                    token
                    );
                var accessToken = JsonConvert.DeserializeObject<SsoAccessToken>(task);
                _Main.Client._Token = new SsoToken(accessToken.AccessToken, accessToken.TokenType, accessToken.ExpiresIn, accessToken.RefreshToken);
                return true;
        }

        private async Task<string> SsoPost(string grant, string codetype, string code)
        {
            string responseString = string.Empty;
            _Main.Client._HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(_Main._ClientId + ":" + _Main._SecretKey));
            var response = await _Main.Client._HttpClient.PostAsync(_TokenUrl.Uri, new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", grant),
                new KeyValuePair<string, string>(codetype, code)
            })).ConfigureAwait(false);
            responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseString;
        }

        private string Base64Encode(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        internal bool IsTokenValid()
        {
            return _Main.Client.Token.Expires > DateTime.UtcNow;
        }

        internal bool VerifyCredentials()
        {
            return VerifyCredentials(false);
        }

        internal bool VerifyCredentials(bool force)
        {
            lock (_Main.Client._SsoLock)
            {
                if (force)
                {
                    _Main.Client._ScopesReauthorize = force;
                }

                if (_Main.Client.Token == null)
                    return Authorize().Result;
                else
                {
                    if (_Main.Client.ScopesRequested.Contains(Scope.None) || _Main.Client.ScopesReathorize)
                        return Authorize().Result;

                    if (!IsTokenValid())
                        return RefreshAccessToken().Result;
                }
            }
            return true;
        }

        public SsoTokenVerification VerifyToken() => VerifyTokenAsync().Result;

        public async Task<SsoTokenVerification> VerifyTokenAsync()
        {
            string responseString = string.Empty;
            string accessToken = _Main.Client._Token.AccessToken;
            _Main.Client._HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _Main.Client._HttpClient.GetAsync(_VerifyUrl.Uri);
            responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SsoTokenVerification>(responseString);
        }
    }
}
