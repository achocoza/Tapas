using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tapas.Core.Tests
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void SpinUpAInmemory()
        {
            var s = new PortableNodesInMemory();
            s.Add(new PortableNode { Id = 1, Name = "Foo" });
            s.Add(new PortableNode { Id = 2, Name = "Bar", ParentId=1 });

            Assert.AreEqual(1, s.GetById(1).Id);
            Assert.AreEqual(2, s.GetById(2).Id);
            Assert.AreEqual(1, s.GetById(2).ParentId);
            
        }

        [TestMethod]
        public void Walk()
        {
            var s = new PortableNodesInMemory();
            s.Add(new PortableNode { Id = 1, Name = "Foo" });
            s.Add(new PortableNode { Id = 2, Name = "Bar", ParentId = 1 });

            Assert.AreEqual(1, s.GetById(1).Id);
            Assert.AreEqual(1, s.Parent(s.GetById(2)).Id);
            Assert.AreEqual(2, s.Children(s.GetById(1)).FirstOrDefault().Id);

        }
    }
}
