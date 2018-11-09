using ESISharp.Enumeration;
using ESISharp.Model.Object;
using ESISharp.Test.Model.Abstract;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Fittings : PathTest
    {
#pragma warning disable S1144, S3459, CS0649

        static readonly object[] CreateFitting_TestOne =
        {
            new object[] { new Fitting("ESI_Test", 
                "ESI Created Fitting", 
                16240, // Catalyst
                new List<FittingItem> {
                    new FittingItem(520, 1, FittingFlag.LowSlot0), // Gyrostabilizer I
                    new FittingItem(520, 1, FittingFlag.LowSlot1), // Gyrostabilizer I
                    new FittingItem(520, 1, FittingFlag.LowSlot2), // Gyrostabilizer I
                    new FittingItem(1973, 1, FittingFlag.MidSlot0), // Sensor Booster I
                    new FittingItem(1973, 1, FittingFlag.MidSlot1), // Sensor Booster I
                    new FittingItem(563, 1, FittingFlag.HighSlot0), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot1), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot2), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot3), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot4), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot5), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot6), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.HighSlot7), // Light Ion Blaster I
                    new FittingItem(31538, 1, FittingFlag.RigSlot0), // Small Hybrid Collision Accelerator I
                    new FittingItem(31538, 1, FittingFlag.RigSlot1), // Small Hybrid Collision Accelerator I
                    new FittingItem(222, 960, FittingFlag.Loaded), // Antimatter Charge S
                    new FittingItem(29011, 2, FittingFlag.Loaded), // Scan Resolution Script
                }) }
        };

        private class FittingResponse
        {
            public int fitting_id;
        }

#pragma warning restore

        [Property("AuthedCharacters", "Fittings")]
        [Test]
        public void GetAll()
        {
            var a = Authenticated.Characters.Fittings.GetAll(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Fittings")]
        [Test, TestCaseSource("CreateFitting_TestOne")]
        public void CreateDelete(Fitting fitting)
        {
            var a = Authenticated.Characters.Fittings.Create(GetCharacterId(), fitting).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var id = JsonConvert.DeserializeObject<FittingResponse>(a.Body).fitting_id;
            var b = Authenticated.Characters.Fittings.Delete(GetCharacterId(), id).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
        }
    }
}
