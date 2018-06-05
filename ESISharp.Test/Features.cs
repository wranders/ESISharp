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
            var r = Public.Characters.GetNames(91105772).Execute();
            var s = Public.Characters.GetNames(91105772).Execute();

            Assert.Multiple(() =>
            {
                Assert.True(HttpStatusCode.OK == r.Code);
                Assert.True(s.IsCached);
            });
        }
    }
}
