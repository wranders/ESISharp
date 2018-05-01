using ESISharp.Enumeration;
using ESISharp.Model.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Sso
{
    public class Client
    {
        internal string _ClientID;
        internal string _SecretKey;
        internal string _RefreshToken;

        internal string _AuthorizerFileDirectory;
        internal string _AuthorizerFileName;
        internal string _CallbackPath;
        internal string _CallbackProtocol;
        internal List<Scopes.Scope> _ScopesAuthorized;
        internal List<Scopes.Scope> _ScopesRequested;
        internal bool _ScopesReauthorize;
        internal SsoToken _Token;
        internal OAuthGrant _GrantType;

        public string AuthorizerFileDirectory => _AuthorizerFileDirectory;
        public string AuthorizerFileName => _AuthorizerFileName;
        public string AuthorizerFilePath => Path.Combine(_AuthorizerFileDirectory, _AuthorizerFileName + ".exe");
        public string CallbackPath => _CallbackPath;
        public string CallbackProtocol => _CallbackProtocol;
        public string CallbackUrl => string.Concat(_CallbackProtocol, @"://", _CallbackPath);
        public List<Scopes.Scope> ScopesAuthorized => _ScopesAuthorized;
        public List<Scopes.Scope> ScopesRequested => _ScopesRequested;
        public bool ScopesReathorize => _ScopesReauthorize;
        public string ScopesUrl => string.Join(" ", _ScopesRequested.Select(s => s.Value));
        public SsoToken Token => _Token;
        public OAuthGrant GrantType => _GrantType;

        internal HttpClient _HttpClient;
        internal readonly object _SsoLock;

        private readonly Registry _Registry;

        public Registry Registry => _Registry;

        private Client()
        {
            _AuthorizerFileDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _AuthorizerFileName = "SsoAuthorizer";
            _CallbackPath = "callback/";
            _CallbackProtocol = "eveauth-all";
            _ScopesAuthorized = new List<Scopes.Scope>() { Scopes.Scope.None };
            _ScopesRequested = new List<Scopes.Scope>() { Scopes.Scope.None };
            _ScopesReauthorize = false;
            _GrantType = OAuthGrant.Implicit;

            _HttpClient = new HttpClient();
            _SsoLock = new object();

            _Registry = new Registry(this);

            _HttpClient
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Client(string clientid) : this()
        {
            _ClientID = clientid;
        }

        public Client(string clientid, string secretkey) : this()
        {
            _ClientID = clientid;
            _SecretKey = secretkey;
        }

        public void SetClientId(string clientid) => _ClientID = clientid;

        public void SetSecretKey(string secretkey) => _SecretKey = secretkey;

        public void SetAppCredentials(string clientid, string secretkey)
        {
            _ClientID = clientid;
            _SecretKey = secretkey;
        }

        public void SetRefreshToken(string token) => _RefreshToken = token;

        public void SetAuthorizerFileDirectory(string path) => _AuthorizerFileDirectory = path;

        public void SetAuthorizerFileName(string name) => _AuthorizerFileName = name;

        public void SetCallbackPath(string path) => _CallbackPath = path;

        public void SetCallbackProtocol(string protocol) => _CallbackProtocol = protocol;

        public void SetGrantType(OAuthGrant grant) => _GrantType = grant;

        public void AddScope(Scopes.Scope scope)
        {
            List<Scopes.Scope> reqScopes = _ScopesRequested;
            List<Scopes.Scope> autScopes = _ScopesAuthorized;
            if (reqScopes.Contains(scope))
                return;
            if (autScopes.Contains(scope))
                return;
            if (reqScopes.Contains(Scopes.Scope.None))
                reqScopes.Remove(Scopes.Scope.None);
            reqScopes.Add(scope);
            _ScopesRequested = reqScopes;
        }

        public void AddScope(IEnumerable<Scopes.Scope> scopes)
        {
            foreach (Scopes.Scope scope in scopes)
                AddScope(scope);
        }

        public void RemoveScope(Scopes.Scope scope)
        {
            List<Scopes.Scope> reqScopes = _ScopesRequested;
            List<Scopes.Scope> autScopes = _ScopesAuthorized;
            if (reqScopes.Contains(scope))
                reqScopes.Remove(scope);
            if (autScopes.Contains(scope))
            {
                autScopes.Remove(scope);
                reqScopes = reqScopes.Union(autScopes).ToList();
                _ScopesReauthorize = true;
            }
            if (reqScopes.Count < 1)
                reqScopes.Add(Scopes.Scope.None);
            _ScopesRequested = reqScopes;
        }

        public void RemoveScope(IEnumerable<Scopes.Scope> scopes)
        {
            foreach (Scopes.Scope scope in scopes)
                RemoveScope(scope);
        }

        public void RemoveAllScopes()
        {
            _ScopesRequested = new List<Scopes.Scope>() { Scopes.Scope.None };
            _ScopesAuthorized = new List<Scopes.Scope>() { Scopes.Scope.None };
            _ScopesReauthorize = true;
        }

        public void ClearRequestedScopes()
        {
            _ScopesRequested = new List<Scopes.Scope>() { Scopes.Scope.None };
            _ScopesReauthorize = false;
        }

        public List<Scopes.Scope> GetRequestedScopes() => _ScopesRequested;

        public List<Scopes.Scope> GetAuthorizedScopes() => _ScopesAuthorized;

        public string GetRefreshToken()
        {
            if (_Token == null)
                return string.Empty;
            return _Token.RefreshToken;
        }
    }
}
