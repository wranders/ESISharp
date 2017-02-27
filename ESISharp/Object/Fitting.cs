using System.Collections.Generic;
using System.Linq;
using ESISharp.Enumerations;

namespace ESISharp.Object
{
    /// <summary>Object representing a Ship Fitting</summary>
    public class Fitting
    {
        /// <summary>Fitting Name</summary>
        public string Name { get; }
        /// <summary>Fitting Description</summary>
        public string Description { get; }
        /// <summary>Fitting Ship Type ID</summary>
        public int ShipTypeID { get; }
        /// <summary>List of Items in a Fitting </summary>
        public List<FittingItem> Items { get; }

        /// <summary>Create a new Empty Ship Fitting</summary>
        /// <param name="FittingName"></param>
        /// <param name="FittingDescription"></param>
        /// <param name="FittingShipTypeID"></param>
        public Fitting(string FittingName, string FittingDescription, int FittingShipTypeID)
        {
            Name = FittingName;
            Description = FittingDescription;
            ShipTypeID = FittingShipTypeID;
            Items = new List<FittingItem>();
        }

        /// <summary>Create a new Ship Fitting</summary>
        /// <param name="FittingName">(String) Fitting Name</param>
        /// <param name="FittingDescription">(String) Fitting Description</param>
        /// <param name="FittingShipTypeID">(Int32) Ship Type ID</param>
        /// <param name="FittingItems">(FittingItem List) Fitting Items</param>
        public Fitting(string FittingName, string FittingDescription, int FittingShipTypeID, IEnumerable<FittingItem> FittingItems)
        {
            Name = FittingName;
            Description = FittingDescription;
            ShipTypeID = FittingShipTypeID;
            Items = FittingItems.ToList();
        }

        /// <summary>Create a new Ship Fitting</summary>
        /// <param name="FittingName">(String) Fitting Name</param>
        /// <param name="FittingDescription">(String) Fitting Description</param>
        /// <param name="FittingShipTypeID">(Int32) Ship Type ID</param>
        /// <param name="FittingItem">(FittingItem) Fitting Item</param>
        public Fitting(string FittingName, string FittingDescription, int FittingShipTypeID, FittingItem FittingItem)
        {
            Name = FittingName;
            Description = FittingDescription;
            ShipTypeID = FittingShipTypeID;
            Items = new List<FittingItem>() { FittingItem };
        }
    }

    /// <summary>Object representing and Fitting Item</summary>
    public class FittingItem
    {
        /// <summary>Item Type ID</summary>
        public int TypeID { get; }
        /// <summary>Item Quantity</summary>
        public int Quantity { get; }
        /// <summary>Item Location Flag</summary>
        public int Flag { get; }

        /// <summary>Create a new Fitting Item</summary>
        /// <param name="ItemTypeID">(Int32) Item Type ID</param>
        /// <param name="ItemQuantity">(Int32) Item Quantity</param>
        /// <param name="ItemFlag">(FittingFlag) Item Location Flag</param>
        public FittingItem(int ItemTypeID, int ItemQuantity, FittingFlag ItemFlag)
        {
            TypeID = ItemTypeID;
            Quantity = ItemQuantity;
            Flag = ItemFlag.Value;
        }

        /// <summary>Create a new Fitting Item</summary>
        /// <param name="ItemTypeID">(Int32) Item Type ID</param>
        /// <param name="ItemQuantity">(Int32) Item Quantity</param>
        /// <param name="ItemFlag">(Int32) Item Location Flag</param>
        public FittingItem(int ItemTypeID, int ItemQuantity, int ItemFlag)
        {
            TypeID = ItemTypeID;
            Quantity = ItemQuantity;
            Flag = ItemFlag;
        }
    }
}
