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
        private readonly EveSwagger.Public PublicSwaggerObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiRequest(EveSwagger SwaggerObject, string RequestPath)
        {
            PublicSwaggerObject = (EveSwagger.Public)SwaggerObject;
            Route = PublicSwaggerObject.Route;
            Path = RequestPath;
            DataSource = PublicSwaggerObject.DataSource;
        }

        internal string Get()
        {
            var Response = GetAsync(RequestUrl);
            Response.Wait();
            return Response.Result;
        }

        internal string Get(object QueryArguments)
        {
            var ArgString = Utils.ConstructUrlArgs(QueryArguments);
            var ArgumentRequest = string.Concat(RequestUrl, ArgString);
            var Response = GetAsync(ArgumentRequest);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> GetAsync(string Url)
        {
            var response = await PublicSwaggerObject.QueryClient.GetAsync(Url);
            return await response.Content.ReadAsStringAsync();
        }

        internal string Post(object Data)
        {
            var Response = PostAsync(RequestUrl, Data);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> PostAsync(string Url, object Data)
        {
            PublicSwaggerObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await PublicSwaggerObject.QueryClient.PostAsync(Url, PostData);
            return await Response.Content.ReadAsStringAsync();
        }
    }
}
