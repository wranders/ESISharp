using System;

namespace ESISharp.CacheUtility
{
    internal static class Time
    {
        private static readonly DateTime UnixTimeEpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        internal static DateTime UnixTimeToDateTime(double UnixTime)
        {
            return UnixTimeEpochUtc.Add(TimeSpan.FromSeconds(UnixTime));
        }

        internal static double DateTimeToUnixTime(DateTime DateTime)
        {
            return (DateTime - UnixTimeEpochUtc).TotalSeconds;
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
