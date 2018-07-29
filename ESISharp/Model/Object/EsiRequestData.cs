using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    internal class EsiRequestData
    {
        internal Dictionary<string, dynamic> Query { get; set; }
        internal Dictionary<string, dynamic> BodyKvp { get; set; }
        internal dynamic Body { get; set; }
    }
}
