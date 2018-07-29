using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Model.Object
{
    public class SsoTokenVerification
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public string TokenType { get; set; }
        public string CharacterOwnerHash { get; set; }
        public DateTime Expires { get; set; }
        public IEnumerable<Sso.Scopes.Scope> Scopes { get; set; }
    }
}
