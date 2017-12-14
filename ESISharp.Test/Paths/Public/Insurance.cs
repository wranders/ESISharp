using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class Insurance : PathTest
    {
#pragma warning disable S1144

        static object[] Languages =
        {
            new object[] { Language.English },
            new object[] { Language.German },
            new object[] { Language.French },
            new object[] { Language.Russian },
            new object[] { Language.Japanese },
            new object[] { Language.Chinese },
        };

#pragma warning restore

        [Property("Public", "Insurance")]
        [Test]
        public void GetPrices()
        {
            var r = Public.Insurance.GetPrices().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Insurance")]
        [Test, TestCaseSource("Languages")]
        public void GetPrices(Language language)
        {
            var r = Public.Insurance.GetPrices(language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
