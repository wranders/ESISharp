using ESISharp.Enumerations;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Web
{
    /// <summary>Fluent ESI Request Object</summary>
    public class EsiRequest
    {
        private readonly string BaseUrl = "https://esi.evetech.net";
        private readonly string Path;
        private Route PathRoute;
        private DataSource PathDataSource;
        private string RequestUrl => $"{BaseUrl}/{PathRoute.Value}{Path}?datasource={PathDataSource.Value}";

        private readonly ESIEve EasyObject;
        private delegate Task<EsiResponse> RequestMethodDelegate(params object[] Data);
        private readonly RequestMethodDelegate RequestMethod;
        private readonly object[] Data;

        private readonly string CredentialErrorMessage = JsonConvert.SerializeObject(new { error = "ESISharp - There was an error with the supplied credentials." });

        internal EsiRequest(ESIEve EsiObject, string RequestPath, EsiWebMethod Method, params object[] RequestData)
        {
            EasyObject = EsiObject;
            Path = RequestPath;
            Data = RequestData;
            PathRoute = EasyObject.Route;
            PathDataSource = EasyObject.DataSource;

            switch(Method)
            {
                case EsiWebMethod.Get:
                    RequestMethod = new RequestMethodDelegate(GetAsync);
                    break;
                case EsiWebMethod.Post:
                    RequestMethod = new RequestMethodDelegate(PostAsync);
                    break;
                case EsiWebMethod.AuthGet:
                    RequestMethod = new RequestMethodDelegate(AuthGetAsync);
                    break;
                case EsiWebMethod.AuthPost:
                    RequestMethod = new RequestMethodDelegate(AuthPostAsync);
                    break;
                case EsiWebMethod.AuthPut:
                    RequestMethod = new RequestMethodDelegate(AuthPutAsync);
                    break;
                case EsiWebMethod.AuthDelete:
                    RequestMethod = new RequestMethodDelegate(AuthDeleteAsync);
                    break;
            }
        }

        /// <summary>Change the Route of the Current Request</summary>
        /// <param name="Route">(Route) Route</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Route(Route Route)
        {
            PathRoute = Route;
            return this;
        }

        /// <summary>Change the Route of the Current Request</summary>
        /// <param name="Route">(String) Route</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest Route(string Route)
        {
            PathRoute = new Route(Route);
            return this;
        }

        /// <summary>Change the Data Source Server of the current Request</summary>
        /// <param name="DataSource">(DataSource) Data Source Server</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DataSource(DataSource DataSource)
        {
            PathDataSource = DataSource;
            return this;
        }

        /// <summary>Execute the ESI Request</summary>
        /// <returns>EsiResponse</returns>
        public EsiResponse Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>Asynchronous Execution of the ESI Request</summary>
        /// <returns>EsiResponse</returns>
        public async Task<EsiResponse> ExecuteAsync()
        {
            return await RequestMethod(Data).ConfigureAwait(false);
        }

        private async Task<EsiResponse> GetAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            if(RequestData != null && RequestData.Length != 0)
            {
                var ArgString = Utils.ConstructUrlArgs(RequestData[0]);
                Url = string.Concat(Url, ArgString);
            }
            
            var Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await EasyObject.QueryClient.GetAsync(Url).ConfigureAwait(false)).ConfigureAwait(false);
            var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
        }

        private async Task<EsiResponse> PostAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            var JsonString = JsonConvert.SerializeObject(RequestData[0]);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await EasyObject.QueryClient.PostAsync(Url, PostData).ConfigureAwait(false)).ConfigureAwait(false);
            var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
        }

        private string ActiveAccessToken()
        {
            var AuthObject = (ESIEve.Authenticated)EasyObject;
            if(AuthObject.SSO.AuthToken != null || AuthObject.SSO.ImplicitToken != null)
            {
                if(AuthObject.SSO.GrantType == OAuthGrant.Authorization)
                {
                    return AuthObject.SSO.AuthToken.AccessToken;
                }
                else
                {
                    return AuthObject.SSO.ImplicitToken.AccessToken;
                }
            }
            return string.Empty;
        }

        private async Task<EsiResponse> AuthGetAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            var AuthObject = (ESIEve.Authenticated)EasyObject;

            if (RequestData != null && RequestData.Length != 0)
            {
                var ArgString = Utils.ConstructUrlArgs(RequestData[0]);
                Url = string.Concat(Url, ArgString);
            }

            while(AuthObject.SSO.VerifyCredentials())
            {
                AuthObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await AuthObject.QueryClient.GetAsync(Url).ConfigureAwait(false)).ConfigureAwait(false);
                var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
            }
            return new EsiResponse(CredentialErrorMessage, HttpStatusCode.BadRequest);
        }

        private async Task<EsiResponse> AuthPostAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            var AuthObject = (ESIEve.Authenticated)EasyObject;

            if(RequestData.Length == 2)
            {
                var ArgString = Utils.ConstructUrlArgs(RequestData[1]);
                Url = string.Concat(Url, ArgString);
            }

            while (AuthObject.SSO.VerifyCredentials())
            {
                AuthObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var JsonString = JsonConvert.SerializeObject(RequestData[0]);
                var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                var Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await AuthObject.QueryClient.PostAsync(Url, PostData).ConfigureAwait(false)).ConfigureAwait(false);
                var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
            }
            return new EsiResponse(CredentialErrorMessage, HttpStatusCode.BadRequest);
        }

        private async Task<EsiResponse> AuthPutAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            var AuthObject = (ESIEve.Authenticated)EasyObject;

            if(RequestData.Length == 2)
            {
                var ArgString = Utils.ConstructUrlArgs(RequestData[1]);
                Url = string.Concat(Url, ArgString);
            }

            while(AuthObject.SSO.VerifyCredentials())
            {
                AuthObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var JsonString = JsonConvert.SerializeObject(RequestData[0]);
                var PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                var Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await AuthObject.QueryClient.PutAsync(Url, PutData).ConfigureAwait(false)).ConfigureAwait(false);
                var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
            }
            return new EsiResponse(CredentialErrorMessage, HttpStatusCode.BadRequest);
        }

        private async Task<EsiResponse> AuthDeleteAsync(params object[] RequestData)
        {
            var Url = RequestUrl;
            var AuthObject = (ESIEve.Authenticated)EasyObject;

            while(AuthObject.SSO.VerifyCredentials())
            {
                HttpResponseMessage Response;
                AuthObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());

                if(RequestData != null && RequestData.Length != 0)
                {
                    var JsonString = JsonConvert.SerializeObject(RequestData[0]);
                    var Message = new HttpRequestMessage(HttpMethod.Delete, Url);
                    Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                    Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await AuthObject.QueryClient.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)).ConfigureAwait(false);
                    var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
                }
                else
                {
                    Response = await EasyObject.HttpResiliencePolicy.ExecuteAsync(async () => await AuthObject.QueryClient.DeleteAsync(Url).ConfigureAwait(false)).ConfigureAwait(false);
                    var ResponseBody = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return new EsiResponse(ResponseBody, Response.StatusCode, new EsiResponseHeaders(Response.Headers));
                }
            }
            return new EsiResponse(CredentialErrorMessage, HttpStatusCode.BadRequest);
        }
    }
}
