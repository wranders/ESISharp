using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ESISharp.Model.Object
{
    public class EsiResponseHeaders
    {
        public string CacheControl { get; }
        public DateTime Date { get; }
        public string ETag { get; }
        public int Pages { get; }
        public string Warning { get; }

        internal EsiResponseHeaders(HttpResponseHeaders responseheaders)
        {
            if (responseheaders.TryGetValues("Cache-Control", out IEnumerable<string> outCacheControl))
                CacheControl = outCacheControl.First();

            if (responseheaders.TryGetValues("Date", out IEnumerable<string> outDate))
                Date = DateTime.Parse(outDate.First());

            if (responseheaders.TryGetValues("ETag", out IEnumerable<string> outETag))
                ETag = outETag.First().Trim('"');

            if (responseheaders.TryGetValues("X-Pages", out IEnumerable<string> outPages))
                Pages = int.Parse(outPages.First());

            if (responseheaders.TryGetValues("Warning", out IEnumerable<string> outWarning))
                Warning = outWarning.First();
        }
    }
}
