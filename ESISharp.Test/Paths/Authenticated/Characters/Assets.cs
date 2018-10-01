using ESISharp.Test.Model.Abstract;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Assets : PathTest
    {
        private long itemOne;
        private long itemTwo;
        private List<long> itemList;

        private void PopulateItems()
        {
            if (itemOne != 0 && itemTwo != 0 && itemList.Count == 0) return;

            var rand = new Random();
            var r = Authenticated.Characters.Assets.GetAll(GetCharacterId()).Execute();
            var b = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(r.Body);
            var c = b.Count;
            var io = b[rand.Next(0, c - 1)];
            var it = b[rand.Next(0, c - 1)];
            itemOne = io["item_id"];
            itemTwo = it["item_id"];
            itemList = new List<long>() { itemOne, itemTwo };
        }

        [Property("AuthedCharacters", "Assets")]
        [Test]
        public void GetAll()
        {
            var a = Authenticated.Characters.Assets.GetAll(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [TestCase(2)]
        [TestCase(3)]
        public void GetAll(int page)
        {
            var a = Authenticated.Characters.Assets.GetAll(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [Test]
        public void GetLocations()
        {
            PopulateItems();
            var a = Authenticated.Characters.Assets.GetLocations(GetCharacterId(), itemOne).Execute();
            var b = Authenticated.Characters.Assets.GetLocations(GetCharacterId(), itemList).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
            Assert.True(b.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Assets")]
        [Test]
        public void GetNames()
        {
            PopulateItems();
            var a = Authenticated.Characters.Assets.GetNames(GetCharacterId(), itemOne).Execute();
            var b = Authenticated.Characters.Assets.GetNames(GetCharacterId(), itemList).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
            Assert.True(b.Code == HttpStatusCode.OK);
        }
    }
}
