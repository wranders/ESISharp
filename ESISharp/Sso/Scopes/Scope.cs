using Newtonsoft.Json;
using System;
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

    public class ScopesSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jsonValueList = reader.Value.ToString().Split(' ');
            var scopesList = (existingValue as IEnumerable<Scope> ?? new List<Scope>());

            scopesList = Scope.Lookup.Where(l => jsonValueList.Contains(l.Key)).Select(s => s.Value).ToList();
            if (scopesList.Count() == 0)
            {
                scopesList = new List<Scope>() { Scope.None };
            }

            return scopesList;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
