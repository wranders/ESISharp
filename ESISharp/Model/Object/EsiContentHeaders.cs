using System;
using System.Collections.Generic;
using System.Globalization;
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
                Expires = CheckTimeZone(outExpires.First());

            if (contentheaders.TryGetValues("Last-Modified", out IEnumerable<string> outLastModified))
                LastModified = CheckTimeZone(outLastModified.First());
        }

        private DateTime CheckTimeZone(string time)
        {
            if (time.Substring(time.Length - 3) == "UTC")
                return DateTime.ParseExact(time,
                    "ddd, dd MMM yyyy HH:mm:ss UTC",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal
                );
            else
                return DateTime.Parse(time);
        }
    }
}
