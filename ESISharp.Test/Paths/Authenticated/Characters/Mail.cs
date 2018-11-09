using ESISharp.Enumeration;
using ESISharp.Model.Object;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Mail : PathTest
    {
        [Property("AuthedCharacters", "Mail")]
        [Test]
        public void GetHeaders()
        {
            var a = Authenticated.Characters.Mail.GetHeaders(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [TestCase(1)]
        public void GetHeaders(int label)
        {
            var a = Authenticated.Characters.Mail.GetHeaders(GetCharacterId(), label).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [TestCase(new int[] { 1 })]
        public void GetHeaders(IEnumerable<int> label)
        {
            var a = Authenticated.Characters.Mail.GetHeaders(GetCharacterId(), label).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [TestCase(1, 99999999)]
        public void GetHeaders(int label, int lastmailid)
        {
            var a = Authenticated.Characters.Mail.GetHeaders(GetCharacterId(), label, lastmailid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [TestCase(new int[] { 1 }, 99999999)]
        public void GetHeaders(IEnumerable<int> label, int lastmailid)
        {
            var a = Authenticated.Characters.Mail.GetHeaders(GetCharacterId(), label, lastmailid).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [Test]
        public void SendGetUpdateDeleteMail()
        {
            var mail = new EveMail(
                "This is a test message.",
                "ESI Test",
                new EveMailRecipient(GetCharacterId(), MailRecipientType.Character)
                );
            var a = Authenticated.Characters.Mail.SendMail(GetCharacterId(), mail).Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var aid = int.Parse(a.Body);
            var b = Authenticated.Characters.Mail.GetContents(GetCharacterId(), aid).Execute();
            Assert.True(b.Code == HttpStatusCode.OK);
            var c = Authenticated.Characters.Mail.UpdateMail(GetCharacterId(), aid, 1, true).Execute();
            Assert.True(c.Code == HttpStatusCode.NoContent);
            var d = Authenticated.Characters.Mail.UpdateMail(GetCharacterId(), aid, new int[] { 1, 2 }, false).Execute();
            Assert.True(d.Code == HttpStatusCode.NoContent);
            var e = Authenticated.Characters.Mail.DeleteMail(GetCharacterId(), aid).Execute();
            Assert.True(e.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Mail")]
        [Test]
        public void GetLabelsAndUnread()
        {
            var a = Authenticated.Characters.Mail.GetLabelsAndUnread(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Mail")]
        [Test]
        public void CreateDeleteLabel()
        {
            var a = Authenticated.Characters.Mail.CreateLabel(GetCharacterId(), "Test").Execute();
            Assert.True(a.Code == HttpStatusCode.Created);
            var aid = int.Parse(a.Body);
            var b = Authenticated.Characters.Mail.DeleteLabel(GetCharacterId(), aid).Execute();
            Assert.True(b.Code == HttpStatusCode.NoContent);
            var c = Authenticated.Characters.Mail.CreateLabel(GetCharacterId(), "TestColor", MailLabelColor.RedOrange).Execute();
            Assert.True(c.Code == HttpStatusCode.Created);
            var cid = int.Parse(c.Body);
            var d = Authenticated.Characters.Mail.DeleteLabel(GetCharacterId(), cid).Execute();
            Assert.True(d.Code == HttpStatusCode.NoContent);
        }

        [Property("AuthedCharacters", "Mail")]
        [Test]
        public void GetMailingLists()
        {
            var a = Authenticated.Characters.Mail.GetMailingLists(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
