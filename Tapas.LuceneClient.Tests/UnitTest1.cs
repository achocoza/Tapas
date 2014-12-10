using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapas.LuceneClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var x = new CreateIndex(@"C:\admin\index");
            var y = new Search(@"C:\admin\index");
        }
    }
}
