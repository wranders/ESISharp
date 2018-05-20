using ESISharp.Enumeration;
using Newtonsoft.Json;

namespace ESISharp.Model.Object
{
    public class FittingItem
    {
        private int _TypeID;
        private int _Quantity;
        private int _Flag;

        [JsonProperty(PropertyName = "type_id")]
        public int TypeID { get => _TypeID; set => _TypeID = value; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get => _Quantity; set => _Quantity = value; }

        [JsonProperty(PropertyName = "flag")]
        public int Flag { get => _Flag; set => _Flag = value; }

        public FittingItem(int typeid, int quantity, int flag)
        {
            TypeID = typeid;
            Quantity = quantity;
            Flag = flag;
        }

        public FittingItem(int typeid, int quantity, FittingFlag flag) 
            : this(typeid, quantity, (int)flag.Value) { }
    }
}
