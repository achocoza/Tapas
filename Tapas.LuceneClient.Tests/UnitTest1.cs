using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapas.LuceneClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateIndexTest()
        {

            CreateIndex.Path = @"C:\admin\indexThree";

            CreateIndex.AddNodeToIndex(new PortableNode
            {
                Url = "/",
                Name = "Home",
                Id = 1
            });
            CreateIndex.AddNodeToIndex(new PortableNode
            {
                Url = "/Foo",
                Name = "Foo",
                Id = 2
            });
            CreateIndex.AddNodeToIndex(new PortableNode
            {
                Url = "X",
                Name = "x",
                Id = 3
            });

        }

        [TestMethod]
        public void Delete()
        {
            CreateIndex.Path = @"C:\admin\indexThree"; 
            CreateIndex.DeleteAllIndexed();
        }
        [TestMethod]
        public void FindTests()
        {
            Search.InitializeSearcher(@"C:\admin\indexThree");
            var foo1 = Search.FindById(2);
            Assert.AreEqual(2, foo1.Id);

            var foo2 = Search.FindById(3);
            Assert.AreEqual(3, foo2.Id);

            var fooName = Search.FindByName("foo");
            Assert.AreEqual(fooName.Id, 2);

            var foo3 = Search.FindByUrl("X");
            Assert.AreEqual(3, foo3.Id);

            var foo4 = Search.FindByUrl(@"/Foo");
            Assert.AreEqual("/Foo", foo4.Url);

            var home = Search.FindByUrl(@"/");


            Assert.AreEqual("Home", home.Name);
            Assert.AreEqual("Foo", foo1.Name);
        }
    }
}
