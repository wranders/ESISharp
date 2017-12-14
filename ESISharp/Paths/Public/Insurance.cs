using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Public
{
    public class Insurance : ApiPath
    {
        internal Insurance(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetPrices()
        {
            return GetPrices(Language.English);
        }

        [Path("/insurance/prices/", WebMethods.GET)]
        public EsiRequest GetPrices(Language language)
        {
            var path = new EsiRequestPath { "insurance", "prices" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["language"] = language.Value
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
        }
    }
}
