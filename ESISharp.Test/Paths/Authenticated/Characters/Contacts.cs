using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Contacts : PathTest
    {
        [Property("AuthedCharacters", "Contacts")]
        [Test]
        public void GetContacts()
        {
            var a = Authenticated.Characters.Contacts.GetContacts(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetContacts(int page)
        {
            var a = Authenticated.Characters.Contacts.GetContacts(GetCharacterId(), page).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Contacts")]
        [Test]
        public void GetLabels()
        {
            var a = Authenticated.Characters.Contacts.GetLabels(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(2112424022)]
        public void AddEditDelete_One(int contactid)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(new int[] { 2112424022 })]
        public void AddEditDelete_One(IEnumerable<int> contactid)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(2112424022, 128)]
        public void AddEditDelete_Two(int contactid, int labelid)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, labelid).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, labelid).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(new int[] { 2112424022 }, 128)]
        public void AddEditDelete_Two(IEnumerable<int> contactid, int labelid)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, labelid).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, labelid).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(2112424022, true)]
        public void AddEditDelete_Three(int contactid, bool watched)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, watched).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, watched).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(new int[] { 2112424022 }, true)]
        public void AddEditDelete_Three(IEnumerable<int> contactid, bool watched)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, watched).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, watched).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(2112424022, 128, true)]
        public void AddEditDelete_Four(int contactid, int labelid, bool watched)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, labelid, watched).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, labelid, watched).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Contacts")]
        [TestCase(new int[] { 2112424022 }, 128, true)]
        public void AddEditDelete_Four(IEnumerable<int> contactid, int labelid, bool watched)
        {
            var a = Authenticated.Characters.Contacts
                .AddContacts(GetCharacterId(), contactid, 5, labelid, watched).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var b = Authenticated.Characters.Contacts
                .EditContacts(GetCharacterId(), contactid, 10, labelid, watched).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Contacts
                .DeleteContact(GetCharacterId(), contactid).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
        }
    }
}
