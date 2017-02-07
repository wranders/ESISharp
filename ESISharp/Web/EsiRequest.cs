using System.Text;
using System.Threading.Tasks;
using ESISharp.Enumerations;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ESISharp.Web
{
    internal class EsiRequest
    {
        private readonly EveSwagger.Public SwaggerObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiRequest(EveSwagger es, string path)
        {
            SwaggerObject = (EveSwagger.Public)es;
            Route = SwaggerObject.Route;
            Path = path;
            DataSource = SwaggerObject.DataSource;
        }

        internal string Get()
        {
            var Response = GetAsync(RequestUrl);
            Response.Wait();
            return Response.Result;
        }

        internal string Get(object args)
        {
            var ArgString = Utils.ConstructUrlArgs(args);
            var ArgumentRequest = string.Concat(RequestUrl, ArgString);
            var Response = GetAsync(ArgumentRequest);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> GetAsync(string url)
        {
            var response = await SwaggerObject.QueryClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        internal string Post(object data)
        {
            var Response = PostAsync(RequestUrl, data);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> PostAsync(string url, object data)
        {
            SwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await SwaggerObject.QueryClient.PostAsync(url, PostData);
            return await Response.Content.ReadAsStringAsync();
        }
    }
}
