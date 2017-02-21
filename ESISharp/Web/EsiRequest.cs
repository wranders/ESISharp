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
        private readonly ESIEve EasyObject;
        private readonly string BaseUrl = "https://esi.tech.ccp.is";
        private readonly Route Route;
        private readonly string Path;
        private readonly DataSource DataSource;
        private string RequestUrl => $"{BaseUrl}{Route.Value}{Path}?datasource={DataSource.Value}";

        internal EsiRequest(ESIEve EsiObject, string RequestPath)
        {
            EasyObject = EsiObject;
            Route = EasyObject.Route;
            Path = RequestPath;
            DataSource = EasyObject.DataSource;
        }

        internal string Get()
        {
            var Response = GetAsync(RequestUrl);
            return Response.Result;
        }

        internal string Get(object QueryArguments)
        {
            var ArgString = Utils.ConstructUrlArgs(QueryArguments);
            var ArgumentRequest = string.Concat(RequestUrl, ArgString);
            var Response = GetAsync(ArgumentRequest);
            return Response.Result;
        }

        private async Task<string> GetAsync(string Url)
        {
            EasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", EasyObject.UserAgent);
            var response = await EasyObject.QueryClient.GetAsync(Url).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        internal string Post(object Data)
        {
            var Response = PostAsync(RequestUrl, Data);
            return Response.Result;
        }

        private async Task<string> PostAsync(string Url, object Data)
        {
            EasyObject.QueryClient.DefaultRequestHeaders.Add("User-Agent", EasyObject.UserAgent);
            EasyObject.QueryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var JsonString = JsonConvert.SerializeObject(Data);
            var PostData = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var Response = await EasyObject.QueryClient.PostAsync(Url, PostData).ConfigureAwait(false);
            return await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
