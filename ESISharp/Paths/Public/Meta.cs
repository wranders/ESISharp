using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Meta : ApiPath
    {
        internal Meta(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest Headers()
        {
            var path = new EsiRequestPath { "..", "headers" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest Ping()
        {
            var path = new EsiRequestPath { "..", "ping." }; // Period is added so that a trailing slash is not added
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest Status()
        {
            var path = new EsiRequestPath { "..", "status.json" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest Verify(string accesstoken)
        {
            var path = new EsiRequestPath { "..", "verify" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["token"] = accesstoken
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }

        public EsiRequest Versions()
        {
            var path = new EsiRequestPath { "..", "versions" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
