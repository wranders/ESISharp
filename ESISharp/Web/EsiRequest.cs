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
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => string.Concat(string.Concat(BaseUrl, Route.Value), string.Concat(Path, "?datasource=" + DataSource.Value));

        internal EsiRequest(EveSwagger es, string path)
        {
            Route = es.Route;
            Path = path;
            DataSource = es.DataSource;
        }

        internal string Get()
        {
            Task<string> Response = GetAsync(RequestUrl);
            Response.Wait();
            return Response.Result;
        }

        internal string Get(object args)
        {
            string ArgString = Utils.ConstructUrlArgs(args);
            string ArgumentRequest = string.Concat(RequestUrl, ArgString);
            Task<string> Response = GetAsync(ArgumentRequest);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }

        internal string Post(object data)
        {
            Task<string> Response = PostAsync(RequestUrl, data);
            Response.Wait();
            return Response.Result;
        }

        private async Task<string> PostAsync(string url, object data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string JsonString = JsonConvert.SerializeObject(data);
                HttpContent PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage Response = await client.PostAsync(url, PostData);
                return await Response.Content.ReadAsStringAsync();
            }
        }
    }
}
