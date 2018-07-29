using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Model.Object
{
    public class SsoToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }

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
