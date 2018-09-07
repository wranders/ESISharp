using System.Net;

namespace ESISharp.Model.Object
{
    public class EsiResponse
    {
        public string Body { get; }
        public HttpStatusCode Code { get; }
        public EsiContentHeaders ContentHeaders { get; }
        public EsiResponseHeaders ResponseHeaders { get; }
        public bool IsCached { get; internal set; }

        internal EsiResponse(string body, HttpStatusCode code)
        {
            Body = body;
            Code = code;
        }

        internal EsiResponse(string body, HttpStatusCode code, EsiContentHeaders contentheaders, EsiResponseHeaders responseheaders)
        {
            Body = body;
            Code = code;
            ContentHeaders = contentheaders;
            ResponseHeaders = responseheaders;
        }
    }
}
