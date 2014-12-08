using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tapas.ContentApi.Tests
{
    [TestClass]
    public class LoadContent
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var remoteUrl = "http://localhost:43896/";
                var url = "/";
                var portableNodeCollection = new PortableNodeCollection();
                var json = webClient.DownloadString(remoteUrl + "/umbraco/tapas/content/getdescendantsorself?url=" + url);
                var des = JsonConvert.DeserializeObject<List<PortableNode>>(json);
                foreach (var p in des)
                {
                    portableNodeCollection.AddOrUpdate(p);
                }
                Assert.AreEqual(17, portableNodeCollection.PortableNodes.Count);
            }

        }

        [TestMethod]
        public void TestMethodSingleDoc()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var remoteUrl = "http://localhost:43896/";
                var url = "/learn";
                var portableNodeCollection = new PortableNodeCollection();
                var json = webClient.DownloadString(remoteUrl + "/umbraco/tapas/content/getnode?url=" + url);

                //var json2 = "{\"Children\":[],\"ContentSet\":[],\"ContentType\":null,\"CreateDate\":\"2014-12-07T11:20:50\",\"CreatorId\":0,\"CreatorName\":\"jonas\",\"DocumentTypeAlias\":\"LandingPage\",\"DocumentTypeId\":1061,\"Id\":1074,\"IsDraft\":false,\"ItemType\":0,\"Level\":2,\"Name\":\"Learn\",\"Parent\":null,\"ParentId\":1073,\"Path\":\"-1,1073,1074\",\"Properties\":[],\"PropertiesDictionary\":{\"umbracoNaviHide\":false,\"content\":\"\"},\"SortOrder\":0,\"TemplateId\":1057,\"UpdateDate\":\"2014-12-07T11:20:52\",\"Url\":\"/learn/\",\"UrlName\":\"learn\",\"Version\":\"00000000-0000-0000-0000-000000000000\",\"WriterId\":0,\"WriterName\":\"jonas\"}";
                //Assert.AreEqual(json, json2);

                var des = JsonConvert.DeserializeObject<PortableNode>(json);

                
            }

        }


    }
}
