using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.Paths.Authenticated
{
    public class UserInterface : ApiPath
    {
        internal UserInterface(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest SetWaypoint(int destinationid)
            => SetWaypoint(destinationid, false, false);

        public EsiRequest SetWaypoint(int destinationid, bool addtobeginning)
            => SetWaypoint(destinationid, addtobeginning, false);

        [Path("/ui/autopilot/waypoint/", WebMethods.POST)]
        public EsiRequest SetWaypoint(int destinationid, bool addtobeginning, bool clearotherwaypoints)
        {
            var path = new EsiRequestPath { "ui", "autopilot", "waypoint" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["add_to_beginning"] = addtobeginning,
                    ["clear_other_waypoints"] = clearotherwaypoints,
                    ["destination_id"] = destinationid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/ui/openwindow/contract/", WebMethods.POST)]
        public EsiRequest OpenContractWindow(int contractid)
        {
            var path = new EsiRequestPath { "ui", "openwindow", "contract" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["contract_id"] = contractid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/ui/openwindow/information/", WebMethods.POST)]
        public EsiRequest OpenInformationWindow(int targetid)
        {
            var path = new EsiRequestPath { "ui", "openwindow", "information" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["target_id"] = targetid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/ui/openwindow/marketdetails/", WebMethods.POST)]
        public EsiRequest OpenMarketDetailsWindow(int typeid)
        {
            var path = new EsiRequestPath { "ui", "openwindow", "marketdetails" };
            var data = new EsiRequestData
            {
                Query = new Dictionary<string, dynamic>
                {
                    ["type_id"] = typeid
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/ui/openwindow/newmail/", WebMethods.POST)]
        public EsiRequest OpenNewMailWindow(EveMail mail)
        {
            var path = new EsiRequestPath { "ui", "openwindow", "newmail" };
            var data = new EsiRequestData
            {
                Body = mail
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }
    }
}
