using System.Collections.Generic;
using System.Text;

namespace ESISharp.Model.Object
{
    public class EsiRequestPath : List<string>
    {
        public override string ToString()
        {
            var str = new StringBuilder().Append("/").Append(string.Join("/", ToArray()));

            if (!this[Count - 1].Contains("."))
                return str.Append("/").ToString();
            else
                return str.ToString().TrimEnd('.');
        }
    }
}
