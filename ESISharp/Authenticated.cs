using ESISharp.Enumeration;
using ESISharp.Sso;

namespace ESISharp
{
    public class Authenticated : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Authenticated;

        public Controller Sso;

        private Authenticated() : base()
        {

        }

        public Authenticated(string clientid) : this()
        {
            Sso = new Controller(clientid);
        }

        public Authenticated(string clientid, string secretkey) : this()
        {
            Sso = new Controller(clientid, secretkey);
        }
    }
}
