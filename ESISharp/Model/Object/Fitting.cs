using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Model.Object
{
    public class Fitting
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeID { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IEnumerable<FittingItem> Items { get; set; }

        public Fitting(string name, string description, int shipttypeid)
        {
            Name = name;
            Description = description;
            ShipTypeID = shipttypeid;
            Items = new List<FittingItem>();
        }

        public Fitting(string name, string description, int shiptypeid, FittingItem item) 
            : this(name, description, shiptypeid)
        {
            Items = new List<FittingItem>() { item };
        }

        public Fitting(string name, string description, int shiptypeid, IEnumerable<FittingItem> items)
            : this(name, description, shiptypeid)
        {
            Items = items.ToList();
        }
    }
}
