using System;

namespace ESISharp.Model.Object
{
    public class RouteConnection : Tuple<int, int>
    {
        public RouteConnection(int item1, int item2) : base(item1, item2) { }
    }
}
