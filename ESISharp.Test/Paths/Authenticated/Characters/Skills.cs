using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Authenticated.Characters
{
    public class Skills : PathTest
    {
        [Property("AuthedCharacters", "Skills")]
        [Test]
        public void GetAttributes()
        {
            var a = Authenticated.Characters.Skills.GetAttributes(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Skills")]
        [Test]
        public void GetSkillQueue()
        {
            var a = Authenticated.Characters.Skills.GetSkillQueue(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }

        [Property("AuthedCharacters", "Skills")]
        [Test]
        public void GetSkills()
        {
            var a = Authenticated.Characters.Skills.GetSkills(GetCharacterId()).Execute();
            Assert.True(a.Code == HttpStatusCode.OK);
        }
    }
}
