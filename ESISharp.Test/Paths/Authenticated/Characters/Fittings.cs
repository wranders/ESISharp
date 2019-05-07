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
                    new FittingItem(520, 1, FittingFlag.Low0), // Gyrostabilizer I
                    new FittingItem(520, 1, FittingFlag.Low1), // Gyrostabilizer I
                    new FittingItem(520, 1, FittingFlag.Low2), // Gyrostabilizer I
                    new FittingItem(1973, 1, FittingFlag.Med0), // Sensor Booster I
                    new FittingItem(1973, 1, FittingFlag.Med1), // Sensor Booster I
                    new FittingItem(563, 1, FittingFlag.High0), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High1), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High2), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High3), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High4), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High5), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High6), // Light Ion Blaster I
                    new FittingItem(563, 1, FittingFlag.High7), // Light Ion Blaster I
                    new FittingItem(31538, 1, FittingFlag.Rig0), // Small Hybrid Collision Accelerator I
                    new FittingItem(31538, 1, FittingFlag.Rig1), // Small Hybrid Collision Accelerator I
                    new FittingItem(222, 960, FittingFlag.Cargo), // Antimatter Charge S
                    new FittingItem(29011, 2, FittingFlag.Cargo), // Scan Resolution Script
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
