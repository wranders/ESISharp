namespace ESISharp.Enumeration
{
    public class FittingFlag :Model.Abstract.FakeEnumerator
    {
        internal FittingFlag(string value) : base(value) { }

        public static readonly FittingFlag Low0 = new FittingFlag("LoSlot0");
        public static readonly FittingFlag Low1 = new FittingFlag("LoSlot1");
        public static readonly FittingFlag Low2 = new FittingFlag("LoSlot2");
        public static readonly FittingFlag Low3 = new FittingFlag("LoSlot3");
        public static readonly FittingFlag Low4 = new FittingFlag("LoSlot4");
        public static readonly FittingFlag Low5 = new FittingFlag("LoSlot5");
        public static readonly FittingFlag Low6 = new FittingFlag("LoSlot6");
        public static readonly FittingFlag Low7 = new FittingFlag("LoSlot7");

        public static readonly FittingFlag Med0 = new FittingFlag("MedSlot0");
        public static readonly FittingFlag Med1 = new FittingFlag("MedSlot1");
        public static readonly FittingFlag Med2 = new FittingFlag("MedSlot2");
        public static readonly FittingFlag Med3 = new FittingFlag("MedSlot3");
        public static readonly FittingFlag Med4 = new FittingFlag("MedSlot4");
        public static readonly FittingFlag Med5 = new FittingFlag("MedSlot5");
        public static readonly FittingFlag Med6 = new FittingFlag("MedSlot6");
        public static readonly FittingFlag Med7 = new FittingFlag("MedSlot7");

        public static readonly FittingFlag High0 = new FittingFlag("HiSlot0");
        public static readonly FittingFlag High1 = new FittingFlag("HiSlot1");
        public static readonly FittingFlag High2 = new FittingFlag("HiSlot2");
        public static readonly FittingFlag High3 = new FittingFlag("HiSlot3");
        public static readonly FittingFlag High4 = new FittingFlag("HiSlot4");
        public static readonly FittingFlag High5 = new FittingFlag("HiSlot5");
        public static readonly FittingFlag High6 = new FittingFlag("HiSlot6");
        public static readonly FittingFlag High7 = new FittingFlag("HiSlot7");

        public static readonly FittingFlag Rig0 = new FittingFlag("RigSlot0");
        public static readonly FittingFlag Rig1 = new FittingFlag("RigSlot1");
        public static readonly FittingFlag Rig2 = new FittingFlag("RigSlot2");

        public static readonly FittingFlag SubSystem0 = new FittingFlag("SubSystemSlot0");
        public static readonly FittingFlag SubSystem1 = new FittingFlag("SubSystemSlot1");
        public static readonly FittingFlag SubSystem2 = new FittingFlag("SubSystemSlot2");
        public static readonly FittingFlag SubSystem3 = new FittingFlag("SubSystemSlot3");

        public static readonly FittingFlag DroneBay = new FittingFlag("DroneBay");
        public static readonly FittingFlag FighterBay = new FittingFlag("FighterBay");
        public static readonly FittingFlag Cargo = new FittingFlag("Cargo");

        public static readonly FittingFlag StructureService0 = new FittingFlag("ServiceSlot0");
        public static readonly FittingFlag StructureService1 = new FittingFlag("ServiceSlot1");
        public static readonly FittingFlag StructureService2 = new FittingFlag("ServiceSlot2");
        public static readonly FittingFlag StructureService3 = new FittingFlag("ServiceSlot3");
        public static readonly FittingFlag StructureService4 = new FittingFlag("ServiceSlot4");
        public static readonly FittingFlag StructureService5 = new FittingFlag("ServiceSlot5");
        public static readonly FittingFlag StructureService6 = new FittingFlag("ServiceSlot6");
        public static readonly FittingFlag StructureService7 = new FittingFlag("ServiceSlot7");
    }
}
