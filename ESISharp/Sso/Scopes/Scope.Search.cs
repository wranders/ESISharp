using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Search
        {
            public static readonly Scope SearchStructures = new Scope("esi-search.search_structures.v1");
        }
    }
}
