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
            var m = "Test has prerequisites or parameters that are untestable or unreliable for all circumstances. " +
                    "The code presented in these tests show how the operation should be done, not a working example.";
            Assert.Ignore(m);
        }

        public void AfterTest(ITest test)
        {
            // Not post-test action required
        }
    }
}
