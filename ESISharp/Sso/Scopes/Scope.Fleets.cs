using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Fleets
        {
            public static readonly Scope ReadFleet = new Scope("esi-fleets.read_fleet.v1");
            public static readonly Scope WriteFleet = new Scope("esi-fleets.write_fleet.v1");
        }
    }
}
