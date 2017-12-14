using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;

namespace ESISharp.Paths.Public
{
    public class Killmails : ApiPath
    {
        internal Killmails(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/killmails/{killmail_id}/{killmail_hash}/", WebMethods.GET)]
        public EsiRequest GetKillmail(int killmailid, string killmailhash)
        {
            var path = new EsiRequestPath { "killmails", killmailid.ToString(), killmailhash };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
