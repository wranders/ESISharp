using ESISharp.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace ESISharp
{
    /// <summary>SSO Authentication Settings</summary>
    public partial class Sso
    {
        internal string ClientID;
        internal string SecretKey;
        internal string RefreshToken;

        internal string AuthRouterFileDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal string AuthRouterFileName = "EveSSOAuthRouter";
        internal string CallbackProtocol = "eveosso";
        internal List<Scope> AuthorizedScopes = new List<Scope>() { Scope.None };
        internal List<Scope> RequestedScopes = new List<Scope>() { Scope.None };
        internal bool ReauthorizeScopes = false;

        internal string AuthRouterFilePath => Path.Combine(AuthRouterFileDirectory, AuthRouterFileName + ".exe");
        internal string CallbackUrl => string.Concat(CallbackProtocol, @"://");
        internal string ScopesUrl => string.Join(" ", RequestedScopes.Select(s => s.Value));

        internal AuthToken AuthToken;
        internal ImplicitToken ImplicitToken;
        internal OAuthGrant GrantType = OAuthGrant.Implicit;

        private static HttpClient SsoClient = new HttpClient();

        private readonly object AuthLock = new object();

        internal Sso(string AppClientID)
        {
            ClientID = AppClientID;
        }

        internal Sso(string AppClientID, string AppSecretKey)
        {
            ClientID = AppClientID;
            SecretKey = AppSecretKey;
        }

        /// <summary>Set Application Client ID</summary>
        /// <param name="AppClientID">(String) Client ID</param>
        public void SetClientID(string AppClientID)
        {
            ClientID = AppClientID;
        }

        /// <summary>Set Application Secret Key</summary>
        /// <param name="AppSecretKey">(String) Secret Key</param>
        public void SetSecretKey(string AppSecretKey)
        {
            SecretKey = AppSecretKey;
        }

        /// <summary>Set Application Client ID and Secret Key</summary>
        /// <param name="AppClientID">(String) Client ID</param>
        /// <param name="AppSecretKey">(String) Secret Key</param>
        public void SetApplicationCredentials(string AppClientID, string AppSecretKey)
        {
            ClientID = AppClientID;
            SecretKey = AppSecretKey;
        }

        /// <summary>Set the Refresh Token</summary>
        /// <param name="Token">(String) Refresh Token</param>
        public void SetRefreshToken(string Token)
        {
            RefreshToken = Token;
        }

        /// <summary>Set the Callback protocol for the Auth Router</summary>
        /// <param name="Protocol">(String) Protocol</param>
        public void SetCallbackProtocol(string Protocol)
        {
            CallbackProtocol = Protocol;
        }

        /// <summary>Set directory location of the Auth Router application</summary>
        /// <param name="DirectoryPath">(String)</param>
        public void SetAuthRouterFileDirectory(string DirectoryPath)
        {
            AuthRouterFileDirectory = DirectoryPath;
        }

        /// <summary>Set the file name of the Auth Router application</summary>
        /// <param name="Filename">(String) File Name</param>
        public void SetAuthRouterFileName(string Filename)
        {
            AuthRouterFileName = Filename;
        }

        /// <summary>Set the SSO token Type (Authentication or Implicit)</summary>
        /// <param name="Grant">(OAuthGrant) Grant Type</param>
        public void SetGrantType(OAuthGrant Grant)
        {
            GrantType = Grant;
        }

        /// <summary>Add a Scope to Request</summary>
        /// <param name="NewScope">(Scope) New Scope</param>
        public void AddScope(Scope NewScope)
        {
            List<Scope> LocalRequestedScopes = RequestedScopes;
            List<Scope> LocalAuthorizedScopes = AuthorizedScopes;
            if (LocalRequestedScopes.Contains(NewScope))
                return;
            if (LocalAuthorizedScopes.Contains(NewScope))
                return;
            if (LocalRequestedScopes.Contains(Scope.None))
                LocalRequestedScopes.Remove(Scope.None);
            LocalRequestedScopes.Add(NewScope);
            RequestedScopes = LocalRequestedScopes;
        }

        /// <summary>Add multiple Scopes to Request</summary>
        /// <param name="NewScopes">(Scope List) New Scopes</param>
        public void AddScope(List<Scope> NewScopes)
        {
            foreach (Scope NewScope in NewScopes)
            {
                AddScope(NewScope);
            }
        }

        /// <summary>Remove a Scope</summary>
        /// <param name="OldScope">(Scope) Scope to remove</param>
        public void RemoveScope(Scope OldScope)
        {
            List<Scope> LocalRequestedScopes = RequestedScopes;
            List<Scope> LocalAuthorizedScopes = AuthorizedScopes;
            if (LocalRequestedScopes.Contains(OldScope))
                LocalRequestedScopes.Remove(OldScope);
            if (LocalAuthorizedScopes.Contains(OldScope))
            {
                LocalAuthorizedScopes.Remove(OldScope);
                LocalRequestedScopes = LocalRequestedScopes.Union(LocalAuthorizedScopes).ToList();
                ReauthorizeScopes = true;
            }
            if (LocalRequestedScopes.Count < 1)
                LocalRequestedScopes.Add(Scope.None);
            RequestedScopes = LocalRequestedScopes;
        }

        /// <summary>Remove multiple scopes</summary>
        /// <param name="OldScopes">(Scope List) Scopes to remove</param>
        public void RemoveScope(List<Scope> OldScopes)
        {
            foreach (Scope OldScope in OldScopes)
            {
                RemoveScope(OldScope);
            }
        }

        /// <summary>Remove all scopes, Requested and Authorized</summary>
        public void RemoveAllScopes()
        {
            RequestedScopes = new List<Scope>() { Scope.None };
            AuthorizedScopes = new List<Scope>() { Scope.None };
            ReauthorizeScopes = true;
        }

        /// <summary>Clear all Requested Scopes</summary>
        public void ClearRequestedScopes()
        {
            RequestedScopes = new List<Scope>() { Scope.None };
        }

        /// <summary>Get currently Requested Scopes</summary>
        /// <returns>(Scope List) Requested Scopes</returns>
        public List<Scope> GetRequestedScopes()
        {
            return RequestedScopes;
        }

        /// <summary>Get currently Authorized Scopes</summary>
        /// <returns>(Scope List) Authorized Scopes</returns>
        public List<Scope> GetAuthorizedScopes()
        {
            return AuthorizedScopes;
        }

        /// <summary>Get the Refresh Token (Only available if using Authorization Grant Type)</summary>
        /// <returns>(String) Refresh Token</returns>
        public string GetRefreshToken()
        {
            if (AuthToken == null) return string.Empty;
            return AuthToken.RefreshToken;
        }

        /// <summary>Force authorization immediately rather than waiting until it is needed</summary>
        /// <returns>(Boolean) Success or failure</returns>
        public bool ForceAuthorization()
        {
            while(VerifyCredentials())
            {
                return (AuthToken != null || ImplicitToken != null) && IsTokenValid();
            }
            return false;
        }
    }

    internal class ImplicitToken
    {
        internal string AccessToken;
        internal string TokenType;
        internal DateTime Expires;

        internal ImplicitToken(string accesstoken, string tokentype, string tokenexpiresin)
        {
            AccessToken = accesstoken;
            TokenType = tokentype;
            Expires = DateTime.UtcNow.AddSeconds(int.Parse(tokenexpiresin) - 10);
        }
    }

    internal class AuthToken
    {
        internal string AccessToken;
        internal string TokenType;
        internal string RefreshToken;
        internal DateTime Expires;

        internal AuthToken(string accesstoken, string tokentype, string refreshtoken, int tokenexpiresin)
        {
            AccessToken = accesstoken;
            TokenType = tokentype;
            RefreshToken = refreshtoken;
            Expires = DateTime.UtcNow.AddSeconds(tokenexpiresin - 10);
        }
    }
}
