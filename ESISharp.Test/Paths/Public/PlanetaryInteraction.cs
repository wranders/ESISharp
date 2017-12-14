using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System;
using System.Net;

namespace ESISharp.Test.Paths.Public
{
    public class PlanetaryInteraction : PathTest
    {
        [Property("Public", "PlanetaryInteraction")]
        [TestCase(126)]
        public void GetSchematicInfo(int schematicid)
        {
            var r = Public.PlanetaryInteraction.GetSchematicInfo(schematicid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
            Console.Write(r.Body);
        }
    }
}
