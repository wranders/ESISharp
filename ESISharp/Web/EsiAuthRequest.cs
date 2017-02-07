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
        private readonly EveSwagger.Authenticated ESI;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiAuthRequest(EveSwagger es, string path)
        {
            ESI = (EveSwagger.Authenticated)es;
            Route = ESI.Route;
            Path = path;
            DataSource = ESI.DataSource;
        }

        private bool VerifyCredentials()
        {
            if (ESI.SSO.AuthToken == null && ESI.SSO.ImplicitToken == null)
            {
                ESI.SSO.Authorize();
                return true;
            }
            else
            {
                if (!ESI.SSO.RequestedScopes.Contains(Scope.None) || ESI.SSO.ReauthorizeScopes) {
                    ESI.SSO.Authorize();
                    return true;
                }

                if (!ESI.SSO.IsTokenValid())
                {
                    ESI.SSO.RefreshAccessToken();
                    return true;
                }
            }
            return true;
        }

        private string ActiveAccessToken()
        {
            if (ESI.SSO.AuthToken != null || ESI.SSO.ImplicitToken != null)
            {
                if(ESI.SSO.GrantType == OAuthGrant.Authorization)
                {
                    return ESI.SSO.AuthToken.AccessToken;
                }
                else
                {
                    return ESI.SSO.ImplicitToken.AccessToken;
                }
            }
            return string.Empty;
        }

        internal string Get()
        {
            while (VerifyCredentials())
            {
                Task<string> Response = GetAsync(RequestUrl);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Get(object args)
        {
            while (VerifyCredentials())
            {
                string ArgString = Utils.ConstructUrlArgs(args);
                string ArgumentRequest = string.Concat(RequestUrl, ArgString);
                Task<string> Response = GetAsync(ArgumentRequest);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = await client.GetAsync(url);
                return await Response.Content.ReadAsStringAsync();
            }
        }

        internal string Post(object data)
        {
            while (VerifyCredentials())
            {
                Task<string> Response = PostAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Post(object data, object args)
        {
            while (VerifyCredentials())
            {
                string ArgString = Utils.ConstructUrlArgs(args);
                string ArgumentRequest = string.Concat(RequestUrl, ArgString);
                Task<string> Response = PostAsync(ArgumentRequest, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PostAsync(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string JsonString = JsonConvert.SerializeObject(data);
                HttpContent PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await client.PostAsync(url, PostData);
                return await Response.Content.ReadAsStringAsync();
            }
        }

        internal string Put(object data)
        {
            while (VerifyCredentials())
            {
                Task<string> Response = PutAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Put(object data, object args)
        {
            while (VerifyCredentials())
            {
                string ArgString = Utils.ConstructUrlArgs(args);
                string ArgumentRequest = string.Concat(RequestUrl, ArgString);
                Task<string> Response = PutAsync(ArgumentRequest, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> PutAsync(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string JsonString = JsonConvert.SerializeObject(data);
                HttpContent PutData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await client.PutAsync(url, PutData);
                return await Response.Content.ReadAsStringAsync();
            }
        }

        internal string Delete()
        {
            while (VerifyCredentials())
            {
                Task<string> Response = DeleteAsync(RequestUrl);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        internal string Delete(object data)
        {
            while (VerifyCredentials())
            {
                Task<string> Response = DeleteAsync(RequestUrl, data);
                Response.Wait();
                return Response.Result;
            }
            return string.Empty;
        }

        private async Task<string> DeleteAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = await client.DeleteAsync(url);
                return await Response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> DeleteAsync(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ActiveAccessToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string JsonString = JsonConvert.SerializeObject(data);
                HttpRequestMessage Message = new HttpRequestMessage(HttpMethod.Delete, url);
                Message.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage Response =  await client.SendAsync(Message, HttpCompletionOption.ResponseHeadersRead);
                return await Response.Content.ReadAsStringAsync();
            }
        }
    }
}
