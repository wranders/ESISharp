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

        internal EsiRequest(EsiConnection esiconnection, EsiRequestPath path, WebMethods method)
        {
            EsiConnection = esiconnection;
            Path = path;
            PathRoute = esiconnection.Route;
            Url = new UriBuilder
            {
                Scheme = "https",
                Host = "esi.tech.ccp.is"
            };
            Query = HttpUtility.ParseQueryString(Url.Query);
            Query["datasource"] = esiconnection.DataSource.Value;
            Access = esiconnection.Access;
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
        }

        internal EsiRequest(EsiConnection esiconnection, EsiRequestPath path, WebMethods method, EsiRequestData data) : this(esiconnection, path, method)
        {
            if (data.Query != null)
            {
                foreach (KeyValuePair<string, dynamic> q in data.Query)
                {
                    Query[q.Key] = Utility.GetPropertyValue(q.Value);
                }
            }

            if (data.BodyKvp != null && data.Body != null)
            {
                // TODO: Create Invalid Data Exception
            }
            else if (data.BodyKvp != null || data.Body != null)
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

                // TODO: Impliment Token verification here.

                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "PLACEHOLDER"); // TODO: Method to retrieve active access token
            }

            var response = await connection.QueryClient.GetAsync(url).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiResponseHeaders(response.Headers));
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

                // TODO: Impliment Token verification here.

                connection.QueryClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "PLACEHOLDER"); // TODO: Method to retrieve active access token
            }

            var postdata = new StringContent(DataBody, Encoding.UTF8, "application/json");
            var response = await connection.QueryClient.PostAsync(url, postdata).ConfigureAwait(false);
            var responsebody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(responsebody, response.StatusCode, new EsiResponseHeaders(response.Headers));
        }

        private async Task<EsiResponse> PutAsync()
        {
            throw new NotImplementedException();
        }

        private async Task<EsiResponse> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
