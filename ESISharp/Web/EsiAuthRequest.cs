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
        private readonly EveSwagger.Authenticated AuthenticatedSwaggerObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiAuthRequest(EveSwagger SwaggerObject, string RequestPath)
        {
            AuthenticatedSwaggerObject = (EveSwagger.Authenticated)SwaggerObject;
            Route = AuthenticatedSwaggerObject.Route;
            Path = RequestPath;
            DataSource = AuthenticatedSwaggerObject.DataSource;
        }

        private bool VerifyCredentials()
        {
            if (AuthenticatedSwaggerObject.SSO.AuthToken == null && AuthenticatedSwaggerObject.SSO.ImplicitToken == null)
            {
                AuthenticatedSwaggerObject.SSO.Authorize();
                return true;
            }
            else
            {
                if (!AuthenticatedSwaggerObject.SSO.RequestedScopes.Contains(Scope.None) || AuthenticatedSwaggerObject.SSO.ReauthorizeScopes) {
                    AuthenticatedSwaggerObject.SSO.Authorize();
                    return true;
                }

                if (!AuthenticatedSwaggerObject.SSO.IsTokenValid())
                {
                    AuthenticatedSwaggerObject.SSO.RefreshAccessToken();
                    return true;
                }
            }
            return true;
        }

        private string ActiveAccessToken()
        {
            if (AuthenticatedSwaggerObject.SSO.AuthToken != null || AuthenticatedSwaggerObject.SSO.ImplicitToken != null)
            {
                if(AuthenticatedSwaggerObject.SSO.GrantType == OAuthGrant.Authorization)
                {
                    return AuthenticatedSwaggerObject.SSO.AuthToken.AccessToken;
                }
                else
                {
                    return AuthenticatedSwaggerObject.SSO.ImplicitToken.AccessToken;
                }
            }
            return string.Empty;
        }

        internal string Get()
        {
            while (VerifyCredentials())
            {
                var Response = GetAsync(RequestUrl);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Get(object QueryArguments)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = GetAsync(ArgumentRequest);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> GetAsync(string Url)
        {
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await AuthenticatedSwaggerObject.QueryClient.GetAsync(Url);
            return await Response.Content.ReadAsStringAsync();
        }

        internal string Post(object Data)
        {
            while (VerifyCredentials())
            {
                var Response = PostAsync(RequestUrl, Data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Post(object Data, object QueryArguments)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PostAsync(ArgumentRequest, Data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PostAsync(string Url, object Data)
        {
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await AuthenticatedSwaggerObject.QueryClient.PostAsync(Url, PostData);
            return await Response.Content.ReadAsStringAsync();
        }

        internal string Put(object Data)
        {
            while (VerifyCredentials())
            {
                var Response = PutAsync(RequestUrl, Data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Put(object Data, object QueryArguments)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(QueryArguments);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PutAsync(ArgumentRequest, Data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PutAsync(string Url, object Data)
        {
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await AuthenticatedSwaggerObject.QueryClient.PutAsync(Url, PutData);
            return await Response.Content.ReadAsStringAsync();
        }

        internal string Delete()
        {
            while (VerifyCredentials())
            {
                var Response = DeleteAsync(RequestUrl);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Delete(object Data)
        {
            while (VerifyCredentials())
            {
                var Response = DeleteAsync(RequestUrl, Data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> DeleteAsync(string Url)
        {
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await AuthenticatedSwaggerObject.QueryClient.DeleteAsync(Url);
            return await Response.Content.ReadAsStringAsync();
        }

        private async Task<string> DeleteAsync(string Url, object Data)
        {
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            AuthenticatedSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var Message = new HttpRequestMessage(HttpMethod.Delete, Url);
            Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response =  await AuthenticatedSwaggerObject.QueryClient.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead);
            return await Response.Content.ReadAsStringAsync();
        }
    }
}
