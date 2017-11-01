using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath
{
    /// <summary>Public Routes paths</summary>
    public class Routes
    {
        protected ESIEve EasyObject;

        internal Routes(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID)
        {
            return GetRoute(OriginID, DestinationID, new int[] { }, new int[] { });
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32) System to Avoid</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, int Avoid)
        {
            return GetRoute(OriginID, DestinationID, new int[] { Avoid }, new int[] { });
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32 List) Systems to Avoid</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, IEnumerable<int> Avoid)
        {
            return GetRoute(OriginID, DestinationID, Avoid, new int[] { });
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32) System to Avoid</param>
        /// <param name="Connection">(Int32) System to Connect</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, int Avoid, int Connection)
        {
            return GetRoute(OriginID, DestinationID, new int[] { Avoid }, new int[] { Connection });
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32 List) Systems to Avoid</param>
        /// <param name="Connection">(Int32) System to Connect</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, IEnumerable<int> Avoid, int Connection)
        {
            return GetRoute(OriginID, DestinationID, Avoid, new int[] { Connection });
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32) System to Avoid</param>
        /// <param name="Connections">(Int32 List) Systems to Connect</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, int Avoid, IEnumerable<int> Connections)
        {
            return GetRoute(OriginID, DestinationID, new int[] { Avoid }, Connections);
        }

        /// <summary>Get Systems Along a Route</summary>
        /// <param name="OriginID">(Int32) Origin System ID</param>
        /// <param name="DestinationID">(Int32) Destination System ID</param>
        /// <param name="Avoid">(Int32 List) Systems to Avoid</param>
        /// <param name="Connections">(Int32 List) Systems to Connect</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetRoute(int OriginID, int DestinationID, IEnumerable<int> Avoid, IEnumerable<int> Connections)
        {
            var Path = $"/route/{OriginID.ToString()}/{DestinationID.ToString()}/";
            var Data = new
            {
                avoid = (Avoid != null && Avoid.Any()) ? Avoid : null,
                connections = (Connections != null && Connections.Any()) ? Connections : null
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.Get, Data);
        }
    }

    /// <summary>Public and Authenticated Routes paths</summary>
    public class AuthRoutes : Routes
    {
        internal AuthRoutes(ESIEve EasyEve) : base(EasyEve)
        {
            EasyObject = EasyEve;
        }
    }
}
