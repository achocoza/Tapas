using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapas.OrigoDbClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            OrigoContentService.Add(new Tapas.PortableNode
            {
                Url = "/",
                Name = "Root"
            });
            OrigoContentService.Add(new Tapas.PortableNode
            {
                Url = "/foo",
                Name = "Foo"
            });

            var get = OrigoContentService.ContentByUrl("/");

            Assert.IsNotNull(get);
            Assert.AreEqual("Root", get.Name);
            

        }
    }
}
