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

        internal string Get()
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var Response = GetAsync(RequestUrl);
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Get(object QueryArguments)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = GetAsync(ArgumentRequest);
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> GetAsync(string Url)
        {
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", AuthenticatedEasyObject.UserAgent);
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await AuthenticatedEasyObject.QueryClient.GetAsync(Url).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        internal string Post(object Data)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var Response = PostAsync(RequestUrl, Data);
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Post(object Data, object QueryArguments)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PostAsync(ArgumentRequest, Data);
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PostAsync(string Url, object Data)
        {
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", AuthenticatedEasyObject.UserAgent);
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await AuthenticatedEasyObject.QueryClient.PostAsync(Url, PostData).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        internal string Put(object Data)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var Response = PutAsync(RequestUrl, Data);
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Put(object Data, object QueryArguments)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PutAsync(ArgumentRequest, Data);
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PutAsync(string Url, object Data)
        {
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", AuthenticatedEasyObject.UserAgent);
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await AuthenticatedEasyObject.QueryClient.PutAsync(Url, PutData).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        internal string Delete()
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var Response = DeleteAsync(RequestUrl);
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Delete(object Data)
        {
            while (AuthenticatedEasyObject.SSO.VerifyCredentials())
            {
                var Response = DeleteAsync(RequestUrl, Data);
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> DeleteAsync(string Url)
        {
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", AuthenticatedEasyObject.UserAgent);
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await AuthenticatedEasyObject.QueryClient.DeleteAsync(Url).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private async Task<string> DeleteAsync(string Url, object Data)
        {
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", AuthenticatedEasyObject.UserAgent);
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedEasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var Message = new HttpRequestMessage(HttpMethod.Delete, Url);
            Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response =  await AuthenticatedEasyObject.QueryClient.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
