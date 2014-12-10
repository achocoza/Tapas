using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace Tapas.LuceneClient.Tests
{
    /// <summary>
    /// Summary description for WalkerTests
    /// </summary>
    [TestClass]
    public class WalkerTests
    {
        public WalkerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            ContentService.Initialize(@"C:\admin\indexThree");        
        
        }
        [ClassCleanup()]
        public static void MyClassCleanup() {
            ContentService.Dispose();
        }
        

        [TestMethod]
        public void TestMethod1()
        {

            //
            // 90 ms on my computer
            //
            var foo1 = ContentService.GetById(2);
            Assert.AreEqual(2, foo1.Id);

            var parent = foo1.Parent;
            Assert.AreEqual("Home", parent.Name);

            var children = parent.Children;

            var foo2 = ContentService.GetById(1);
            var foo2Children = foo2.Children;

            Assert.AreEqual(2, children.Count());

        }
    }
}
