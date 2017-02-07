using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Collections;

namespace ESISharp.Web
{
    internal static class Utils
    {
        internal static string ConstructUrlArgs(object data)
        {
            var properties = data.GetType()
                             .GetProperties()
                             .Where(p => p.GetValue(data, null) != null && GetPropertyValue(p.GetValue(data, null)) != null)
                             .Select(p => $"{ p.Name }={ WebUtility.HtmlEncode(GetPropertyValue(p.GetValue(data))) }");
            return $"&{string.Join("&", properties)}";
        }

        private static string GetPropertyValue(object value)
        {
            if (value is IEnumerable && !(value is string))
            {
                if (value is IEnumerable<bool>) { return string.Join(",", (value as IEnumerable<bool>)); }
                else if (value is IEnumerable<decimal>) { return string.Join(",", (value as IEnumerable<decimal>)); }
                else if (value is IEnumerable<double>) { return string.Join(",", (value as IEnumerable<double>)); }
                else if (value is IEnumerable<float>) { return string.Join(",", (value as IEnumerable<float>)); }
                else if (value is IEnumerable<int>) { return string.Join(",", (value as IEnumerable<int>)); }
                else if (value is IEnumerable<long>) { return string.Join(",", (value as IEnumerable<long>)); }
                else if (value is IEnumerable<short>) { return string.Join(",", (value as IEnumerable<short>)); }
                else if (value is IEnumerable<string>) { return string.Join(",", (value as IEnumerable<string>)); }
                return null;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
