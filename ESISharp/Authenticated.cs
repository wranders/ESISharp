using ESISharp.Enumeration;
using ESISharp.Sso;

namespace ESISharp
{
    public class Authenticated : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Authenticated;

        private Authenticated() : base()
        {

        }

        public Authenticated(string clientid) : this()
        {

        }

        public Authenticated(string clientid, string secretkey) : this()
        {

        }
    }
}
