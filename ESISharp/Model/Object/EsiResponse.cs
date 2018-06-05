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

        internal EsiResponse(string body, HttpStatusCode code, EsiContentHeaders contentheaders, EsiResponseHeaders responseheaders)
        {
            Body = body;
            Code = code;
            ContentHeaders = contentheaders;
            ResponseHeaders = responseheaders;
        }
    }
}
