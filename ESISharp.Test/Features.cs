using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Runtime.Caching;

namespace ESISharp.Test
{
    public class Features : PathTest
    {
        [Test]
        public void Cache()
        {
            var m = new MemoryCache("CacheTest");
            Public.CacheEnable(m);
            var rgo = Public.Characters.GetInformation(91105772).Execute();
            var rgt = Public.Characters.GetInformation(91105772).Execute();
            Public.CacheDisable();
            var rgth = Public.Characters.GetInformation(91105772).Execute();
            var ci = m.Count();
            Public.CacheDestroy();
            var rgf = Public.Characters.GetInformation(91105772).Execute();

            Assert.Multiple(() =>
            {
                Assert.True(HttpStatusCode.OK == rgo.Code);
                Assert.True(rgt.IsCached);
                Assert.True(HttpStatusCode.OK == rgth.Code);
                Assert.True(!rgth.IsCached);
                Assert.True(ci > 0);
                Assert.IsNull(Public.EsiCache);
                Assert.True(HttpStatusCode.OK == rgf.Code);
            });
        }

        [Test]
        public void AlternateRoute()
        {
            var d = Public.Alliances.GetAll().Route(Route.Development).Execute();
            var dt = Public.Alliances.GetAll().Route("dev").Execute();
            Assert.Multiple(() =>
            {
                Assert.True(d.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Route Enum:    ---\n" +
                    "-------------------------\n" +
                    d.Code.ToString() + "\n" +
                    d.Body.ToString() + "\n" +
                    "-------------------------\n");
                Assert.True(dt.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Route String:    ---\n" +
                    "---------------------------\n" +
                    dt.Code.ToString() + "\n" +
                    dt.Body.ToString() + "\n" +
                    "---------------------------\n");
            });
        }

        [Test]
        public void AlternateDataSource()
        {
            var t = Public.Alliances.GetAll().DataSource(DataSource.Tranquility).Execute();
            var s = Public.Alliances.GetAll().DataSource(DataSource.Singularity).Execute();
            Assert.Multiple(() =>
            {
                Assert.True(t.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Tranquility:    ---\n" +
                    "--------------------------\n" +
                    t.Code.ToString() + "\n" +
                    t.Body.ToString() + "\n" +
                    "--------------------------\n");
                Assert.True(s.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Singularity:    ---\n" +
                    "--------------------------\n" +
                    s.Code.ToString() + "\n" +
                    s.Body.ToString() + "\n" +
                    "--------------------------\n");
            });
        }

        [Test]
        public void DefaultRoute()
        {
            Public.SetRoute(Route.Development);
            var d = Public.Alliances.GetAll().Execute();
            Public.SetRoute(Route.Latest);
            var l = Public.Alliances.GetAll().Execute();
            Assert.Multiple(() =>
            {
                Assert.True(d.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Development:    ---\n" +
                    "--------------------------\n" +
                    d.Code.ToString() + "\n" +
                    d.Body.ToString() + "\n" +
                    "--------------------------\n");
                Assert.True(l.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Latest:    ---\n" +
                    "---------------------\n" +
                    l.Code.ToString() + "\n" +
                    l.Body.ToString() + "\n" +
                    "---------------------\n");
            });
        }

        [Test]
        public void DefaultDataSource()
        {
            Public.SetDataSource(DataSource.Singularity);
            var s = Public.Alliances.GetAll().Execute();
            Public.SetDataSource(DataSource.Tranquility);
            var t = Public.Alliances.GetAll().Execute();
            Assert.Multiple(() =>
            {
                Assert.True(s.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Singularity:    ---\n" +
                    "--------------------------\n" +
                    s.Code.ToString() + "\n" +
                    s.Body.ToString() + "\n" +
                    "--------------------------\n");
                Assert.True(t.Code == HttpStatusCode.OK, "\n\n" +
                    "---    Tranquility:    ---\n" +
                    "--------------------------\n" +
                    t.Code.ToString() + "\n" +
                    t.Body.ToString() + "\n" +
                    "--------------------------\n");
            });
        }
    }
}
