using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ESISharp.Model.Object
{
    public class EsiContentHeaders
    {
        public string ContentType { get; }
        public DateTime Expires { get; }
        public DateTime LastModified { get; }

        internal EsiContentHeaders(HttpContentHeaders contentheaders)
        {
            if (contentheaders.TryGetValues("Content-Type", out IEnumerable<string> outContentType))
                ContentType = outContentType.First();

            if (contentheaders.TryGetValues("Expires", out IEnumerable<string> outExpires))
                Expires = DateTime.Parse(outExpires.First());

            if (contentheaders.TryGetValues("Last-Modified", out IEnumerable<string> outLastModified))
                LastModified = DateTime.Parse(outLastModified.First());
        }
    }
}
