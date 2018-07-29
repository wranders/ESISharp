using ESISharp.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Alliances
{
    public class Main : Public.Alliances
    {
        public Contacts Contacts { get; }

        internal Main(EsiConnection esiconnection) : base(esiconnection)
        {
            Contacts = new Contacts(esiconnection);
        }
    }
}
