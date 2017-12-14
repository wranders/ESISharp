using ESISharp.Enumeration;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Test.Paths.Public
{
    public class Opportunities : PathTest
    {
        static object[] GetGroupInfo_TestOne =
        {
            new object[] { 100, Language.English },
            new object[] { 101, Language.German },
            new object[] { 102, Language.French },
            new object[] { 103, Language.Russian },
            new object[] { 105, Language.Japanese },
            new object[] { 106, Language.Chinese },
        };

        [Property("Public", "Opportunities")]
        [Test]
        public void GetGroups()
        {
            var r = Public.Opportunities.GetGroups().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Opportunities")]
        [TestCase(100)]
        public void GetGroupInfo(int groupid)
        {
            var r = Public.Opportunities.GetGroupInfo(groupid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Opportunities")]
        [Test, TestCaseSource("GetGroupInfo_TestOne")]
        public void GetGroupInfo(int groupid, Language language)
        {
            var r = Public.Opportunities.GetGroupInfo(groupid, language).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Opportunities")]
        [Test]
        public void GetTasks()
        {
            var r = Public.Opportunities.GetTasks().Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }

        [Property("Public", "Opportunities")]
        [TestCase(2)]
        public void GetTaskInfo(int taskid)
        {
            var r = Public.Opportunities.GetTaskInfo(taskid).Execute();
            Assert.True(r.Code == HttpStatusCode.OK);
        }
    }
}
