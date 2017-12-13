using System;
using System.Collections.Generic;
using System.Text;

namespace ESISharp.Model.Object
{
    public class EsiRequestPath : List<string>
    {
        public override string ToString()
        {
            return new StringBuilder().Append("/").Append(String.Join("/", ToArray())).Append("/").ToString();
        }
    }
}
