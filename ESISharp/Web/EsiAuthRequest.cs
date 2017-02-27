using ESISharp.Enumerations;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Web
{
    internal class EsiAuthRequest
    {
        private readonly ESIEve.Authenticated AuthenticatedEasyObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => $"{BaseUrl}{Route.Value}{Path}?datasource={DataSource.Value}";

        internal EsiAuthRequest(ESIEve EsiObject, string RequestPath)
        {
            AuthenticatedEasyObject = (ESIEve.Authenticated)EsiObject;
            Route = AuthenticatedEasyObject.Route;
            Path = RequestPath;
            DataSource = AuthenticatedEasyObject.DataSource;
        }

        private string ActiveAccessToken()
        {
            if (AuthenticatedEasyObject.SSO.AuthToken != null || AuthenticatedEasyObject.SSO.ImplicitToken != null)
            {
                if(AuthenticatedEasyObject.SSO.GrantType == OAuthGrant.Authorization)
                {
                    return AuthenticatedEasyObject.SSO.AuthToken.AccessToken;
                }
                else
                {
                    return AuthenticatedEasyObject.SSO.ImplicitToken.AccessToken;
                }
            }
            return string.Empty;
        }

        internal async Task<string> GetAsync()
        {
            return await GetAsync(null).ConfigureAwait(false);
        }

        internal async Task<string> GetAsync(object QueryArguments)
        {
            var Url = RequestUrl;
            if(QueryArguments != null)
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                Url = string.Concat(Url, ArgString);
            }

            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var Response = await AuthenticatedEasyObject.QueryClient.GetAsync(Url).ConfigureAwait(false);
                return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }

        internal async Task<string> PostAsync(object Data)
        {
            return await PostAsync(Data, null).ConfigureAwait(false);
        }

        internal async Task<string> PostAsync(object Data, object QueryArguments)
        {
            var Url = RequestUrl;
            if (QueryArguments != null)
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                Url = string.Concat(Url, ArgString);
            }

            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var JsonString = JsonConvert.SerializeObject(Data);
                var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                var Response = await AuthenticatedEasyObject.QueryClient.PostAsync(Url, PostData).ConfigureAwait(false);
                return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }

        internal async Task<string> PutAsync(object Data)
        {
            return await PutAsync(Data, null).ConfigureAwait(false);
        }

        internal async Task<string> PutAsync(object Data, object QueryArguments)
        {
            var Url = RequestUrl;
            if (QueryArguments != null)
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                Url = string.Concat(Url, ArgString);
            }

            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var JsonString = JsonConvert.SerializeObject(Data);
                var PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                var Response = await AuthenticatedEasyObject.QueryClient.PutAsync(Url, PutData).ConfigureAwait(false);
                return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }

        internal async Task<string> DeleteAsync()
        {
            var Url = RequestUrl;

            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var Response = await AuthenticatedEasyObject.QueryClient.DeleteAsync(Url).ConfigureAwait(false);
                return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }

        internal async Task<string> DeleteAsync(object Data)
        {
            var Url = RequestUrl;
            
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                var JsonString = JsonConvert.SerializeObject(Data);
                var Message = new HttpRequestMessage(HttpMethod.Delete, Url);
                Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                var Response = await AuthenticatedEasyObject.QueryClient.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return string.Empty;
        }
    }
}
