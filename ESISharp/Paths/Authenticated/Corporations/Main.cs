using ESISharp.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Corporations
{
    public class Main : Public.Corporations
    {
        private readonly Assets _Assets;
        private readonly Bookmarks _Bookmarks;
        private readonly Contacts _Contacts;
        private readonly Contracts _Contracts;

        public Assets Assets => _Assets;
        public Bookmarks Bookmarks => _Bookmarks;
        public Contacts Contacts => _Contacts;
        public Contracts Contracts => _Contracts;

        internal Main(EsiConnection esiconnection) : base(esiconnection)
        {
            _Assets = new Assets(esiconnection);
            _Bookmarks = new Bookmarks(esiconnection);
            _Contacts = new Contacts(esiconnection);
            _Contracts = new Contracts(esiconnection);
        }
    }
}
