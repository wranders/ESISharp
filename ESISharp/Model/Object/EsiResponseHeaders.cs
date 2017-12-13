using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ESISharp.Model.Object
{
    public class EsiResponseHeaders
    {
        public string ContentType { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Expires { get; private set; }
        public DateTime LastModified { get; private set; }
        public int Pages { get; private set; }
        public string Warning { get; private set; }

        internal EsiResponseHeaders(HttpResponseHeaders responseheaders)
        {
            if (responseheaders.TryGetValues("Content-Type", out IEnumerable<string> outContentType))
                ContentType = outContentType.First();

            if (responseheaders.TryGetValues("Date", out IEnumerable<string> outDate))
                Date = DateTime.Parse(outDate.First());

            if (responseheaders.TryGetValues("Expires", out IEnumerable<string> outExpires))
                Expires = DateTime.Parse(outExpires.First());

            if (responseheaders.TryGetValues("Last-Modified", out IEnumerable<string> outLastModified))
                LastModified = DateTime.Parse(outLastModified.First());

            if (responseheaders.TryGetValues("X-Pages", out IEnumerable<string> outPages))
                Pages = int.Parse(outPages.First());

            if (responseheaders.TryGetValues("Warning", out IEnumerable<string> outWarning))
                Warning = outWarning.First();
        }
    }
}
