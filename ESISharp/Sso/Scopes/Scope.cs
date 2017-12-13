using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Sso.Scopes
{
    public sealed partial class Scope : Model.Abstract.FakeEnumerator
    {
        internal static readonly Dictionary<string, Scope> Lookup = new Dictionary<string, Scope>();

        internal Scope(string value) : base(value)
        {
            if (value != string.Empty)
            {
                Lookup.Add(value, this);
            }
        }

        public static readonly IEnumerable<Scope> All = typeof(Scope).GetNestedTypes().SelectMany(x => x.GetFields()).Select(x => (Scope)x.GetValue(null)).ToList();
        public static readonly Scope None = new Scope(string.Empty);
    }
}
