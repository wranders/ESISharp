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
        private readonly EveSwagger.Authenticated SwaggerObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiAuthRequest(EveSwagger es, string path)
        {
            SwaggerObject = (EveSwagger.Authenticated)es;
            Route = SwaggerObject.Route;
            Path = path;
            DataSource = SwaggerObject.DataSource;
        }

        private bool VerifyCredentials()
        {
            if (SwaggerObject.SSO.AuthToken == null && SwaggerObject.SSO.ImplicitToken == null)
            {
                SwaggerObject.SSO.Authorize();
                return true;
            }
            else
            {
                if (!SwaggerObject.SSO.RequestedScopes.Contains(Scope.None) || SwaggerObject.SSO.ReauthorizeScopes) {
                    SwaggerObject.SSO.Authorize();
                    return true;
                }

                if (!SwaggerObject.SSO.IsTokenValid())
                {
                    SwaggerObject.SSO.RefreshAccessToken();
                    return true;
                }
            }
            return true;
        }

        private string ActiveAccessToken()
        {
            if (SwaggerObject.SSO.AuthToken != null || SwaggerObject.SSO.ImplicitToken != null)
            {
                if(SwaggerObject.SSO.GrantType == OAuthGrant.Authorization)
                {
                    return SwaggerObject.SSO.AuthToken.AccessToken;
                }
                else
                {
                    return SwaggerObject.SSO.ImplicitToken.AccessToken;
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

        internal string Get(object args)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(args);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = GetAsync(ArgumentRequest);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> GetAsync(string url)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await SwaggerObject.QueryClient.GetAsync(url);
            return await Response.Content.ReadAsStringAsync();
        }

        internal string Post(object data)
        {
            while (VerifyCredentials())
            {
                var Response = PostAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Post(object data, object args)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(args);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PostAsync(ArgumentRequest, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PostAsync(string url, object data)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await SwaggerObject.QueryClient.PostAsync(url, PostData);
            return await Response.Content.ReadAsStringAsync();
        }

        internal string Put(object data)
        {
            while (VerifyCredentials())
            {
                var Response = PutAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Put(object data, object args)
        {
            while (VerifyCredentials())
            {
                var ArgString = Utils.ConstructUrlArgs(args);
                var ArgumentRequest = string.Concat(RequestUrl, ArgString);
                var Response = PutAsync(ArgumentRequest, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PutAsync(string url, object data)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(data);
            var PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await SwaggerObject.QueryClient.PutAsync(url, PutData);
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

        internal string Delete(object data)
        {
            while (VerifyCredentials())
            {
                var Response = DeleteAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> DeleteAsync(string url)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Response = await SwaggerObject.QueryClient.DeleteAsync(url);
            return await Response.Content.ReadAsStringAsync();
        }

        private async Task<string> DeleteAsync(string url, object data)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(data);
            var Message = new HttpRequestMessage(HttpMethod.Delete, url);
            Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response =  await SwaggerObject.QueryClient.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead);
            return await Response.Content.ReadAsStringAsync();
        }
    }
}
