using System;
using System.Globalization;

namespace ESISharp.CacheUtility
{
    internal static class Time
    {
        internal static string GetUtcUnixTime()
        {
            var UtcTime = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            return (UtcTime.Days * 24 * 60 * 60 + UtcTime.Hours * 60 * 60 + UtcTime.Minutes * 60 + UtcTime.Seconds).ToString("G", CultureInfo.InvariantCulture);
        }

        internal static DateTime UnixTimeToDateTime(string UnixTime)
        {
            var UnixTimeEpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double UnixTimeSeconds;
            if (double.TryParse(UnixTime, out UnixTimeSeconds))
            {
                return UnixTimeEpochUtc.AddSeconds(UnixTimeSeconds);
            }
            else
            {
                return UnixTimeEpochUtc;
            }
        }
    }

    internal static class Encoding
    {
        internal static string Base64Encode(string PlainText)
        {
            var PlainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
            return Convert.ToBase64String(PlainTextBytes);
        }

        internal static string Base64Decode(string EncodedText)
        {
            var EncodedTextBytes = Convert.FromBase64String(EncodedText);
            return System.Text.Encoding.UTF8.GetString(EncodedTextBytes);
        }
    }
}
