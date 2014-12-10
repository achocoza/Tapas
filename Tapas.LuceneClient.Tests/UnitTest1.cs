using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tapas.LuceneClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateIndexTest()
        {
            ContentService.Initialize(@"C:\admin\indexThree");
            ContentService.DeleteAll();
            ContentService.AddNode(new PortableNode
            {
                Url = "/",
                Name = "Home",
                Id = 1
            });
            ContentService.AddNode(new PortableNode
            {
                Url = "/Foo",
                Name = "Foo",
                Id = 2,
                ParentId = 1
            });
            ContentService.AddNode(new PortableNode
            {
                Url = "X",
                Name = "x",
                Id = 3, ParentId =1
            });
            ContentService.Dispose();

        }

        [TestMethod]
        public void FindTests()
        {
            ContentService.Initialize(@"C:\admin\indexThree");
            var foo1 = ContentService.GetById(2);
            Assert.AreEqual(2, foo1.Id);

            var foo2 = ContentService.GetById(3);
            Assert.AreEqual(3, foo2.Id);

            var fooName = ContentService.GetByName("Foo");
            Assert.AreEqual(fooName.Id, 2);

            var foo3 = ContentService.GetByUrl("X");
            Assert.AreEqual(3, foo3.Id);

            var foo4 = ContentService.GetByUrl(@"/Foo");
            Assert.AreEqual("/Foo", foo4.Url);

            var home = ContentService.GetByUrl(@"/");


            Assert.AreEqual("Home", home.Name);
            Assert.AreEqual("Foo", foo1.Name);

            ContentService.Dispose();
        }


        [TestMethod]
        public void Delete()
        {
            ContentService.Initialize(@"C:\admin\indexThree");
            ContentService.DeleteAll();
        }

        [TestMethod]
        public void IndexChange()
        {

            ContentService.Initialize(@"C:\admin\indexThree");
            ContentService.DeleteAll();

            ContentService.AddNode(new PortableNode
            {
                Url = "X",
                Name = "x",
                Id = 3,
                ParentId = 1
            }, true);

            var foo1 = ContentService.GetById(3);

            Assert.AreEqual("x", foo1.Name);
            ContentService.AddNode(new PortableNode
            {
                Url = "X",
                Name = "Changed",
                Id = 3,
                ParentId = 1
            }, true);

            var foo2 = ContentService.GetById(3);
            Assert.AreEqual("Changed", foo2.Name);
            
            ContentService.Dispose();
        }

        [TestMethod]
        public void WalkerTests()
        {
            ContentService.Initialize(@"C:\admin\indexThree");
            var foo1 = ContentService.GetById(2);
            Assert.AreEqual(2, foo1.Id);

            var parent = foo1.Parent;
            Assert.AreEqual("Home", parent.Name);

            var children = parent.Children;

            Assert.AreEqual(2, children.Count());

        }
    }
}
