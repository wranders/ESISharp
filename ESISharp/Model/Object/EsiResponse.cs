using System.Net;

namespace ESISharp.Model.Object
{
    public class EsiResponse
    {
        public string Body { get; private set; }
        public HttpStatusCode Code { get; private set; }
        public EsiResponseHeaders Headers { get; private set; }

        internal EsiResponse(string body, HttpStatusCode code)
        {
            Body = body;
            Code = code;
        }

        internal EsiResponse(string body, HttpStatusCode code, EsiResponseHeaders headers)
        {
            Body = body;
            Code = code;
            Headers = headers;
        }
    }
}
