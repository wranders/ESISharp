using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Model.Object
{
    public class SsoToken
    {
        private string _AccessToken;
        private string _TokenType;
        private string _RefreshToken;
        private DateTime _Expires;

        public string AccessToken { get => _AccessToken; set => _AccessToken = value; }
        public string TokenType { get => _TokenType; set => _TokenType = value; }
        public string RefreshToken { get => _RefreshToken; set => _RefreshToken = value; }
        public DateTime Expires { get => _Expires; set => _Expires = value; }

        internal SsoToken(string accesstoken, string tokentype, string expires)
        {
            AccessToken = accesstoken;
            TokenType = tokentype;
            Expires = DateTime.UtcNow.AddSeconds(int.Parse(expires) - 10);
        }

        internal SsoToken(string accesstoken, string tokentype, string expires, string refreshtoken)
            : this(accesstoken, tokentype, expires)
        {
            RefreshToken = refreshtoken;
        }
    }
}
