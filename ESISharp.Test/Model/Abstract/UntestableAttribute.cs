using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ESISharp.Test.Model.Abstract
{
    public class UntestableAttribute : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }

        public UntestableAttribute() { }

        public void BeforeTest(ITest test)
        {
            Assert.Ignore("Test has prerequisites that are untestable using the current character.");
        }

        public void AfterTest(ITest test)
        {
            // Not post-test action required
        }
    }
}
