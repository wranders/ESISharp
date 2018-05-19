using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Model.Object
{
    public class Fitting
    {
        private string _Name;
        private string _Description;
        private int _ShipTypeID;
        private IEnumerable<FittingItem> _Items;

        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int ShipTypeID { get => _ShipTypeID; set => _ShipTypeID = value; }
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
