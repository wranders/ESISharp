using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    internal class EsiRequestData
    {
        private Dictionary<string, dynamic> _Query;
        private Dictionary<string, dynamic> _BodyKvp;
        private dynamic _Body;

        internal Dictionary<string, dynamic> Query { get => _Query; set => _Query = value; }
        internal Dictionary<string, dynamic> BodyKvp { get => _BodyKvp; set => _BodyKvp = value; }
        internal dynamic Body { get => _Body; set => _Body = value; }
    }
}
