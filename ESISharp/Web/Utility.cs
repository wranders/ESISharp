using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Web
{
    internal static class Utility
    {
        internal static string GetPropertyValue(object property)
        {
            if (property is IEnumerable && !(property is string))
            {
                if (property is IEnumerable<bool>)
                {
                    return string.Join(",", (property as IEnumerable<bool>));
                }
                else if (property is IEnumerable<decimal>)
                {
                    return string.Join(",", (property as IEnumerable<decimal>));
                }
                else if (property is IEnumerable<double>)
                {
                    return string.Join(",", (property as IEnumerable<double>));
                }
                else if (property is IEnumerable<float>)
                {
                    return string.Join(",", (property as IEnumerable<float>));
                }
                else if (property is IEnumerable<int>)
                {
                    return string.Join(",", (property as IEnumerable<int>));
                }
                else if (property is IEnumerable<long>)
                {
                    return string.Join(",", (property as IEnumerable<long>));
                }
                else if (property is IEnumerable<short>)
                {
                    return string.Join(",", (property as IEnumerable<short>));
                }
                else if (property is IEnumerable<string>)
                {
                    return string.Join(",", (property as IEnumerable<string>));
                }
                return null;
            }
            else
            {
                return property.ToString();
            }
        }
    }
}