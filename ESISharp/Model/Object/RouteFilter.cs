using System;
using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    public class RouteFilter
    {
        public List<int> Avoid { get; set; }
        public List<RouteConnection> Connections { get; set; }
    }
}
