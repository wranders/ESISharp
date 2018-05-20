using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.Model.Object
{
    public class Fitting
    {
        private string _Name;
        private string _Description;
        private int _ShipTypeID;
        private IEnumerable<FittingItem> _Items;

        [JsonProperty(PropertyName = "name")]
        public string Name { get => _Name; set => _Name = value; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get => _Description; set => _Description = value; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeID { get => _ShipTypeID; set => _ShipTypeID = value; }

        [JsonProperty(PropertyName = "items")]
        public IEnumerable<FittingItem> Items { get => _Items; set => _Items = value; }

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
