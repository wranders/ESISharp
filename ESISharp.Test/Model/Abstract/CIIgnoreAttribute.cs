using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Test.Model.Abstract
{
    public class CIIgnoreAttribute : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }

        public CIIgnoreAttribute() { }

        public void BeforeTest(ITest test)
        { 
            var a = Environment.GetEnvironmentVariable("CI");
            if (a != null && a == "True")
            {
                Assert.Ignore("Test requires user input, so is ignored in CI environments.");
            }
        }

        public void AfterTest(ITest test)
        {
            // No post-test action required.
        }
    }
}
