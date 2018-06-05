using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Test
{
    public class Features : PathTest
    {
        [Test]
        public void Cache()
        {
            var m = new MemoryCache("CacheTest");
            Public.CacheEnable(m);
            var rgo = Public.Characters.GetNames(91105772).Execute();
            var rgt = Public.Characters.GetNames(91105772).Execute();
            Public.CacheDisable();
            var rgth = Public.Characters.GetNames(91105772).Execute();
            var ci = m.Count();
            Public.CacheDestroy();
            var rgf = Public.Characters.GetNames(91105772).Execute();

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
            var ro = Public.Alliances.GetAll().Route(Route.Development).Execute();
            var rt = Public.Alliances.GetAll().Route("dev").Execute();
            Assert.Multiple(() =>
            {
                Assert.True(ro.Code == HttpStatusCode.OK);
                Assert.True(rt.Code == HttpStatusCode.OK);
            });
        }

        [Test]
        public void AlternateDataSource()
        {
            var ro = Public.Alliances.GetAll().DataSource(DataSource.Tranquility).Execute();
            var rt = Public.Alliances.GetAll().DataSource(DataSource.Singularity).Execute();
            Assert.Multiple(() =>
            {
                Assert.True(ro.Code == HttpStatusCode.OK);
                Assert.True(rt.Code == HttpStatusCode.OK);
            });
        }

        [Test]
        public void DefaultRoute()
        {
            Public.SetRoute(Route.Development);
            var a = Public.Alliances.GetAll().Execute();
            Public.SetRoute(Route.Latest);
            Assert.True(HttpStatusCode.OK == a.Code);
        }

        [Test]
        public void DefaultDataSource()
        {
            Public.SetDataSource(DataSource.Singularity);
            var a = Public.Alliances.GetAll().Execute();
            Public.SetDataSource(DataSource.Tranquility);
            Assert.True(HttpStatusCode.OK == a.Code);
        }
    }
}
