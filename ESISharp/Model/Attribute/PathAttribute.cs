using ESISharp.Enumeration;
using System;

namespace ESISharp.Model.Attribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal class PathAttribute : System.Attribute
    {
        internal readonly string Path;
        internal readonly WebMethods Method;

        internal PathAttribute(string path, WebMethods method)
        {
            Path = path;
            Method = method;
        }
    }
}
