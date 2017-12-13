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
        private int _CharacterID;
        private string _CharacterName;
        private string _TokenType;
        private string _CharacterOwnerHash;
        private DateTime _Expires;
        private IEnumerable<ESISharp.Sso.Scopes.Scope> _Scopes;

        public int CharacterID { get => _CharacterID; set => _CharacterID = value; }
        public string CharacterName { get => _CharacterName; set => _CharacterName = value; }
        public string TokenType { get => _TokenType; set => _TokenType = value; }
        public string CharacterOwnerHash { get => _CharacterOwnerHash; set => _CharacterOwnerHash = value; }
        public DateTime Expires { get => _Expires; set => _Expires = value; }
        public IEnumerable<ESISharp.Sso.Scopes.Scope> Scopes { get => _Scopes; set => _Scopes = value; }
    }
}
