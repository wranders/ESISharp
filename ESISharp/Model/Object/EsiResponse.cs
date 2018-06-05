using System.Net;

namespace ESISharp.Model.Object
{
    public class EsiResponse
    {
        public string Body { get; private set; }
        public HttpStatusCode Code { get; private set; }
        public EsiContentHeaders ContentHeaders { get; private set; }
        public EsiResponseHeaders ResponseHeaders { get; private set; }
        public bool IsCached { get; internal set; }

        internal EsiResponse(string body, HttpStatusCode code)
        {
            Body = body;
            Code = code;
        }

        internal EsiResponse(string body, HttpStatusCode code, EsiContentHeaders contentheaders)
        {
            Body = body;
            Code = code;
            ContentHeaders = contentheaders;
        }

        internal EsiResponse(string body, HttpStatusCode code, EsiResponseHeaders responseheaders)
        {
            Body = body;
            Code = code;
            ResponseHeaders = responseheaders;
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
