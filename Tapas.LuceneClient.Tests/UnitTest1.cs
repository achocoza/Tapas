using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapas.LuceneClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateIndex()
        {
            var x = new CreateIndex(@"C:\admin\index");
        }
        [TestMethod]
        public void Search()
        {
            var y = new Search(@"C:\admin\index");
        }
    }
}
