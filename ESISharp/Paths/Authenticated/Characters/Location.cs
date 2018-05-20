using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Location : ApiPath
    {
        internal Location(EsiConnection esiconnection) : base(esiconnection) { }

        [Path("/characters/{character_id}/location/", WebMethods.GET)]
        public EsiRequest GetLocation(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "location" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/online/", WebMethods.GET)]
        public EsiRequest GetOnlineStatus(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "online" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        [Path("/characters/{character_id}/ship/", WebMethods.GET)]
        public EsiRequest GetCurrentShip(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "ship" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
