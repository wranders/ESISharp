using ESISharp.Enumeration;
using Newtonsoft.Json;

namespace ESISharp.Model.Object
{
    public class FittingItem
    {
        [JsonProperty(PropertyName = "type_id")]
        public int TypeID { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public int Flag { get; set; }

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
