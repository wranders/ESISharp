using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESISharp.Web
{
    public class EsiRequest
    {
        private delegate Task<EsiResponse> RequestMethodDelegate();

        private readonly UriBuilder Url;
        private readonly EsiRequestPath Path;
        private readonly NameValueCollection Query;
        private Route PathRoute;

        private string RequestUrl
        {
            get
            {
                Url.Path = PathRoute.Value + Path;
                Url.Query = Query.ToString();
                return Url.ToString();
            }
        }

        private readonly EsiConnection EsiConnection;
        private readonly RequestMethodDelegate RequestMethod;
        private readonly Access Access;
        private readonly string DataBody;

        private readonly Cache _Cache;

        private readonly string _CredentialErrorMessage = JsonConvert.SerializeObject(new { error = "ESISharp - There was an error with the supplied credentials." });

        internal EsiRequest(EsiConnection esiconnection, EsiRequestPath path, WebMethods method)
        {
            EsiConnection = esiconnection;
            Path = path;
            PathRoute = esiconnection.Route;
            Url = new UriBuilder
            {
                Scheme = "https",
                Host = "esi.evetech.net"
            };
            Query = HttpUtility.ParseQueryString(Url.Query);
            Query["datasource"] = esiconnection.DataSource.Value;
            if (esiconnection is Public)
                Access = Access.Public;
            else
                Access = Access.Authenticated;
            switch (method)
            {
                case WebMethods.GET:
                    RequestMethod = new RequestMethodDelegate(GetAsync);
                    break;
                case WebMethods.POST:
                    RequestMethod = new RequestMethodDelegate(PostAsync);
                    break;
                case WebMethods.PUT:
                    RequestMethod = new RequestMethodDelegate(PutAsync);
                    break;
                case WebMethods.DELETE:
                    RequestMethod = new RequestMethodDelegate(DeleteAsync);
                    break;
            }
            _Cache = new Cache();
        }

        internal EsiRequest(EsiConnection esiconnection, EsiRequestPath path, WebMethods method, EsiRequestData data) : this(esiconnection, path, method)
        {
            if (data.Query != null)
            {
                foreach (KeyValuePair<string, dynamic> q in data.Query)
                {
                    if (q.Value == null)
                        continue;
                    Query[q.Key] = Utility.GetPropertyValue(q.Value);
                }
            }

            if (data.BodyKvp != null && data.Body != null)
            {
                // TODO: Create Invalid Data Exception
            }
            else if (data.BodyKvp == null && data.Body == null)
            {
                DataBody = string.Empty;
            }
            else
            {
                if (data.BodyKvp != null)
                {
                    DataBody = JsonConvert.SerializeObject(data.BodyKvp);
                }
                if (data.Body != null)
                {
                    DataBody = JsonConvert.SerializeObject(data.Body);
                }
            }
        }

        public EsiRequest Route(Route route)
        {
            PathRoute = route;
            return this;
        }

        public EsiRequest Route(string route)
        {
            PathRoute = new Route(route);
            return this;
        }

        public EsiRequest DataSource(DataSource datasource)
        {
            Query["datasource"] = datasource.Value;
            return this;
        }

        public EsiResponse Execute() => ExecuteAsync().Result;

        public async Task<EsiResponse> ExecuteAsync() => await RequestMethod().ConfigureAwait(false);

        private string VerifyCredentialsAndGetAccessToken(EsiConnection connection)
        {
            Authenticated authed = (Authenticated)connection;
            var a = authed.Sso.Authentication.VerifyCredentials();
            if (!a)
                return string.Empty;
            return authed.Sso.Client.Token != null ? authed.Sso.Client.Token.AccessToken : string.Empty;
        }

        private async Task<EsiResponse> GetAsync()
        {
            var url = RequestUrl;
            EsiConnection connection;
            if (Access == Access.Public)
            {
                connection = (Public)EsiConnection;
            }
            else
            {
                connection = (Authenticated)EsiConnection;
                string token = VerifyCredentialsAndGetAccessToken(connection);
                if (token == string.Empty)
                    return new EsiResponse(_CredentialErrorMessage, System.Net.HttpStatusCode.BadRequest);
                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            if (connection.UseCache)
            {
                HttpResponseMessage r;
                var hash = _Cache.HashRequest(WebMethods.GET.ToString(), url);
                var entitytag = _Cache.GetETag(connection, hash);
                if (entitytag != null)
                {
                    connection.QueryClient.DefaultRequestHeaders.Add("If-None-Match", entitytag);
                    r = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                        => await connection.QueryClient.GetAsync(url).ConfigureAwait(false)).ConfigureAwait(false);
                    return await _Cache.GetCacheItem(connection, entitytag, r);
                }
                else
                {
                    r = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                        => await connection.QueryClient.GetAsync(url).ConfigureAwait(false)).ConfigureAwait(false);
                    var rb = await r.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var er = new EsiResponse(rb, r.StatusCode, new EsiContentHeaders(r.Content.Headers), new EsiResponseHeaders(r.Headers));
                    _Cache.SetCacheItem(connection, hash, r, er);
                    return er;
                }

            }

            var response = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                => await connection.QueryClient.GetAsync(url).ConfigureAwait(false)).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiContentHeaders(response.Content.Headers), new EsiResponseHeaders(response.Headers));
        }

        private async Task<EsiResponse> PostAsync()
        {
            var url = RequestUrl;
            EsiConnection connection;
            if (Access == Access.Public)
            {
                connection = (Public)EsiConnection;
            }
            else
            {
                connection = (Authenticated)EsiConnection;
                string token = VerifyCredentialsAndGetAccessToken(connection);
                if (token == string.Empty)
                    return new EsiResponse(_CredentialErrorMessage, System.Net.HttpStatusCode.BadRequest);
                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var postdata = new StringContent(DataBody, Encoding.UTF8, "application/json");

            if (connection.UseCache)
            {
                HttpResponseMessage r;
                var hash = _Cache.HashRequest(WebMethods.POST.ToString(), url);
                var entitytag = _Cache.GetETag(connection, hash);
                if (entitytag != null)
                {
                    connection.QueryClient.DefaultRequestHeaders.Add("If-None-Match", entitytag);
                    r = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                        => await connection.QueryClient.PostAsync(url, postdata).ConfigureAwait(false)).ConfigureAwait(false);
                    return await _Cache.GetCacheItem(connection, entitytag, r);
                }
                else
                {
                    r = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                        => await connection.QueryClient.PostAsync(url, postdata).ConfigureAwait(false)).ConfigureAwait(false);
                    var rb = await r.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var er = new EsiResponse(rb, r.StatusCode, new EsiContentHeaders(r.Content.Headers), new EsiResponseHeaders(r.Headers));
                    _Cache.SetCacheItem(connection, hash, r, er);
                    return er;
                }
            }

            var response = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                => await connection.QueryClient.PostAsync(url, postdata).ConfigureAwait(false)).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiContentHeaders(response.Content.Headers), new EsiResponseHeaders(response.Headers));
        }

        private async Task<EsiResponse> PutAsync()
        {
            var url = RequestUrl;
            EsiConnection connection;
            if (Access == Access.Public)
            {
                connection = (Public)EsiConnection;
            }
            else
            {
                connection = (Authenticated)EsiConnection;
                string token = VerifyCredentialsAndGetAccessToken(connection);
                if (token == string.Empty)
                    return new EsiResponse(_CredentialErrorMessage, System.Net.HttpStatusCode.BadRequest);
                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var putdata = new StringContent(DataBody, Encoding.UTF8, "application/json");
            var response = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                => await connection.QueryClient.PutAsync(url, putdata).ConfigureAwait(false)).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiContentHeaders(response.Content.Headers), new EsiResponseHeaders(response.Headers));
        }

        private async Task<EsiResponse> DeleteAsync()
        {
            var url = RequestUrl;
            EsiConnection connection;
            if (Access == Access.Public)
            {
                connection = (Public)EsiConnection;
            }
            else
            {
                connection = (Authenticated)EsiConnection;
                string token = VerifyCredentialsAndGetAccessToken(connection);
                if (token == string.Empty)
                    return new EsiResponse(_CredentialErrorMessage, System.Net.HttpStatusCode.BadRequest);
                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await EsiConnection.HttpResiliencePolicy.ExecuteAsync(async ()
                => await connection.QueryClient.DeleteAsync(url).ConfigureAwait(false)).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiContentHeaders(response.Content.Headers), new EsiResponseHeaders(response.Headers));
        }
    }
}
