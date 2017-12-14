using System;
using System.Collections.Generic;

namespace ESISharp.Model.Object
{
    public class RouteFilter
    {
        private List<int> _Avoid;
        private List<RouteConnection> _Connections;

        public List<int> Avoid { get => _Avoid; set => _Avoid = value; }
        public List<RouteConnection> Connections { get => _Connections; set => _Connections = value; }
    }
}
