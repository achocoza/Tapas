using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapas.Helpers;
using System.Collections.Generic;

namespace Tapas.ContentApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json = @"{""Children"":null,""ContentSet"":null,""ContentType"":null,""CreateDate"":""2014-12-07T11:20:49"",""CreatorId"":0,""CreatorName"":""jonas"",""DocumentTypeAlias"":""Home"",""DocumentTypeId"":1060,""Id"":1073,""IsDraft"":false,""ItemType"":0,""Level"":1,""Name"":""Home"",""Parent"":null,""Path"":""-1,1073"",""Properties"":null,""PropertiesDictionary"":{""siteDescription"":""This is an official Umbraco Starter kit. It shows of the newest features in Umbraco and is the perfect place to start for newcomers.. Everything is made to be taken apart. It's your own little playground. Enjoy!"",""siteTitle"":""Fanoe - Umbraco Starter Kit"",""siteLogo"":""/media/1042/logo.jpg"",""content"":{""name"":""1 column layout"",""sections"":[{""grid"":12,""rows"":[{""name"":""Banner"",""areas"":[{""grid"":12,""allowAll"":false,""allowed"":[""rte"",""banner_headline"",""banner_tagline""],""config"":{},""styles"":{""margin-bottom"":""60px""},""controls"":[{""value"":""Welcome to Fanoe"",""editor"":{""name"":""Banner Headline"",""alias"":""banner_headline"",""view"":""textstring"",""icon"":""icon-coin"",""config"":{""style"":""font-size: 36px; line-height: 45px; font-weight: bold; text-align:center"",""markup"":""<h1 style='font-size:62px;text-align:center'>#value#</h1>""}}},{""value"":""This is the new default starter kit for Umbraco, we enjoy building things that not only look great, but also work great."",""editor"":{""name"":""Banner Tagline"",""alias"":""banner_tagline"",""view"":""textstring"",""icon"":""icon-coin"",""config"":{""style"":""font-size: 25px; line-height: 35px; font-weight: normal; text-align:center"",""markup"":""<h2 style='font-weight: 100; font-size: 40px;text-align:center'>#value#</h2>""}}}]},{""grid"":4,""allowAll"":false,""allowed"":[""rte"",""media""],""controls"":[{""value"":""<h2>The starter kit</h2>\n<p>Congratulations on getting up and running with the “Fanoe” starter kit. It's a great way to get to know the Grid datatype.</p>\n<p><a href=\""/{localLink:1078}\"" title=\""The starter kit\"">Learn about the starter kit →</a><a href=\""/{localLink:1078}\"" title=\""The Starterkit\""><br /></a></p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]},{""grid"":4,""allowAll"":false,""allowed"":[""rte"",""media""],""controls"":[{""value"":""<h2>Learn the basics</h2>\n<p>To get started on the right foot make sure to check out our documentation - from tutorials to API reference.</p>\n<p><a href=\""/{localLink:1079}\"" title=\""Basics\"">Off to the docs →</a></p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]},{""grid"":4,""allowAll"":false,""allowed"":[""rte"",""media""],""controls"":[{""value"":""<h2>Master classes</h2>\n<p>The best way to learn Umbraco is through the Master classes that’s running every month in most regions.</p>\n<p><a href=\""/{localLink:1080}\"" title=\""Masterclasses\"">Learn about the masterclasses →</a></p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]}],""styles"":{""background-image"":""url(/media/1044/14441035391_7ee1d0d166_h_darken.jpg)""},""config"":{""class"":""dark""},""id"":""d28a05da-2404-c1e7-6265-01b07fc5f722""},{""name"":""Two column"",""areas"":[{""grid"":6,""allowAll"":false,""allowed"":[""rte"",""media"",""media_round"",""quote""],""controls"":[{""value"":""<h1>Umbraco Forms</h1>\n<p>With our add-on product Umbraco Forms it’s a breeze to create any type of form you can imagine.</p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]},{""grid"":6,""allowAll"":false,""allowed"":[""rte"",""media"",""media_round"",""quote""],""controls"":[{""value"":""<h1>Package repository</h1>\n<p>At Our Umbraco you’ll find hundreds of free packages made and maintained by the community.</p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]}],""styles"":{""background-image"":""url(/media/1023/form-bg.png)""},""config"":{""class"":""light""},""id"":""5362ea7d-e729-078b-e717-a1e7aa69fd4b""},{""name"":""Full width image"",""areas"":[{""grid"":12,""allowAll"":false,""allowed"":[""media_wide_cropped"",""media_wide""],""controls"":[{""value"":{""focalPoint"":{""left"":0.5,""top"":0.5},""id"":1127,""image"":""/media/1046/14386124825_d43f359900_h_cropped.jpg""},""editor"":{""name"":""Image wide"",""alias"":""media_wide"",""view"":""media"",""render"":""/App_Plugins/Grid/Editors/Render/media_wide.cshtml"",""icon"":""icon-picture""}}]}],""styles"":{},""config"":{""class"":""full triangle""},""id"":""953b3802-6b4f-20ed-66f9-9a855e9afdd4""},{""name"":""Two column"",""areas"":[{""grid"":6,""allowAll"":false,""allowed"":[""rte"",""media"",""media_round"",""quote""],""controls"":[{""value"":""<h2>Sharing is caring</h2>\n<p>Our Umbraco is our community hub, bringing together over a hundred thousand people every month sharing knowledge in the forum, documentation, blogs, packages and much more.</p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]},{""grid"":6,""allowAll"":false,""allowed"":[""rte"",""media"",""media_round"",""quote""],""controls"":[{""value"":""<h2>Born global, loving local</h2>\n<p>If you can’t make it to CodeGarden, that doesn’t mean you have to miss the chance of hanging out with the Umbraco community. You can do just that through the many local user groups and meetups</p>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]}],""styles"":{},""config"":{""class"":""purple""},""id"":""29cac0ff-d8e9-605b-9e7b-6809dce55edd""},{""name"":""Banner"",""areas"":[{""grid"":12,""allowAll"":false,""allowed"":[""rte"",""banner_headline"",""banner_tagline""],""controls"":[{""value"":""<h1 style=\""text-align: center;\"">CodeGarden</h1>\n<h5 style=\""text-align: center;\"">Every year in June, around 500 Umbracians gather in Denmark for our annual conference “CodeGarden”.</h5>"",""editor"":{""name"":""Rich text editor"",""alias"":""rte"",""view"":""rte"",""icon"":""icon-article""}}]}],""styles"":{""background-image"":""url(/media/1028/14435732345_c9f5b48dfa_h_dark.jpg)""},""config"":{""class"":""dark""},""id"":""0093bd05-735a-9623-8509-28085818745c""}]}]}},""SortOrder"":0,""TemplateId"":1056,""UpdateDate"":""2014-12-07T11:20:51"",""Url"":""/"",""UrlName"":""home"",""Version"":""00000000-0000-0000-0000-000000000000"",""WriterId"":0,""WriterName"":""jonas""}";
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SerializableNode>(json);
        }

        [TestMethod]
        public void TestJson2()
        {
            var json =@"{""Children"":[],""ContentSet"":[],""ContentType"":null,""CreateDate"":""2014-12-07T11:20:50"",""CreatorId"":0,""CreatorName"":""jonas"",""DocumentTypeAlias"":""LandingPage"",""DocumentTypeId"":1061,""Id"":1074,""IsDraft"":false,""ItemType"":0,""Level"":2,""Name"":""Learn"",""Parent"":null,""ParentId"":1073,""Path"":""-1,1073,1074"",""Properties"":[],""PropertiesDictionary"":{""umbracoNaviHide"":false,""content"":""""},""SortOrder"":0,""TemplateId"":1057,""UpdateDate"":""2014-12-07T11:20:52"",""Url"":""/learn/"",""UrlName"":""learn"",""Version"":""00000000-0000-0000-0000-000000000000"",""WriterId"":0,""WriterName"":""jonas""}";
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SerializableNode>(json);
        }
        [TestMethod]
        public void TestJson3()
        {
            var json = "{\"Children\":[],\"ContentSet\":[],\"ContentType\":null,\"CreateDate\":\"2014-12-07T11:20:50\",\"CreatorId\":0,\"CreatorName\":\"jonas\",\"DocumentTypeAlias\":\"LandingPage\",\"DocumentTypeId\":1061,\"Id\":1074,\"IsDraft\":false,\"ItemType\":0,\"Level\":2,\"Name\":\"Learn\",\"Parent\":null,\"ParentId\":1073,\"Path\":\"-1,1073,1074\",\"Properties\":[],\"PropertiesDictionary\":{\"umbracoNaviHide\":false,\"content\":\"\"},\"SortOrder\":0,\"TemplateId\":1057,\"UpdateDate\":\"2014-12-07T11:20:52\",\"Url\":\"/learn/\",\"UrlName\":\"learn\",\"Version\":\"00000000-0000-0000-0000-000000000000\",\"WriterId\":0,\"WriterName\":\"jonas\"}";
            var jsoe = "{\"Children\":[],\"ContentSet\":[],\"ContentType\":null,\"CreateDate\":\"2014-12-07T11:20:50\",\"CreatorId\":0,\"CreatorName\":\"jonas\",\"DocumentTypeAlias\":\"LandingPage\",\"DocumentTypeId\":1061,\"Id\":1074,\"IsDraft\":false,\"ItemType\":0,\"Level\":2,\"Name\":\"Learn\",\"Parent\":null,\"ParentId\":1073,\"Path\":\"-1,1073,1074\",\"Properties\":[],\"PropertiesDictionary\":{\"umbracoNaviHide\":false,\"content\":\"\"},\"SortOrder\":0,\"TemplateId\":1057,\"UpdateDate\":\"2014-12-07T11:20:52\",\"Url\":\"/learn/\",\"UrlName\":\"learn\",\"Version\":\"00000000-0000-0000-0000-000000000000\",\"WriterId\":0,\"WriterName\":\"jonas\"}";


            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SerializableNode>(json);

        }

        [TestMethod]
        public void TestJsonArray()
        {
            var json = @"[{""Children"":[],""ContentSet"":[],""ContentType"":null,""CreateDate"":""2014-12-07T11:20:50"",""CreatorId"":0,""CreatorName"":""jonas"",""DocumentTypeAlias"":""LandingPage"",""DocumentTypeId"":1061,""Id"":1074,""IsDraft"":false,""ItemType"":0,""Level"":2,""Name"":""Learn"",""Parent"":null,""ParentId"":1073,""Path"":""-1,1073,1074"",""Properties"":[],""PropertiesDictionary"":{""umbracoNaviHide"":false,""content"":""""},""SortOrder"":0,""TemplateId"":1057,""UpdateDate"":""2014-12-07T11:20:52"",""Url"":""/learn/"",""UrlName"":""learn"",""Version"":""00000000-0000-0000-0000-000000000000"",""WriterId"":0,""WriterName"":""jonas""},{""Children"":[],""ContentSet"":[],""ContentType"":null,""CreateDate"":""2014-12-07T11:20:50"",""CreatorId"":0,""CreatorName"":""jonas"",""DocumentTypeAlias"":""LandingPage"",""DocumentTypeId"":1061,""Id"":1074,""IsDraft"":false,""ItemType"":0,""Level"":2,""Name"":""Learn"",""Parent"":null,""ParentId"":1073,""Path"":""-1,1073,1074"",""Properties"":[],""PropertiesDictionary"":{""umbracoNaviHide"":false,""content"":""""},""SortOrder"":0,""TemplateId"":1057,""UpdateDate"":""2014-12-07T11:20:52"",""Url"":""/learn/"",""UrlName"":""learn"",""Version"":""00000000-0000-0000-0000-000000000000"",""WriterId"":0,""WriterName"":""jonas""}]";

            
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SerializableNode>>(json);
            Assert.AreEqual(2, result.Count);
        }



        [TestMethod]
        public void AddNodes()
        {
            var json1 = @"{""Children"":[],""ContentSet"":[],""ContentType"":null,""CreateDate"":""2014-12-07T11:20:50"",""CreatorId"":0,""CreatorName"":""jonas"",""DocumentTypeAlias"":""LandingPage"",""DocumentTypeId"":1061,""Id"":1074,""IsDraft"":false,""ItemType"":0,""Level"":2,""Name"":""Learn"",""Parent"":null,""ParentId"":1073,""Path"":""-1,1073,1074"",""Properties"":[],""PropertiesDictionary"":{""umbracoNaviHide"":false,""content"":""""},""SortOrder"":0,""TemplateId"":1057,""UpdateDate"":""2014-12-07T11:20:52"",""Url"":""/learn/"",""UrlName"":""learn"",""Version"":""00000000-0000-0000-0000-000000000000"",""WriterId"":0,""WriterName"":""jonas""}";
            var result1 = Newtonsoft.Json.JsonConvert.DeserializeObject<PortableNode>(json1);

            var result2 = Newtonsoft.Json.JsonConvert.DeserializeObject<PortableNode>(json1);
            result2.Id = 2;

            var p = new PortableNodeCollection();
            p.AddOrUpdate(result1);

            result1.Name = "Foo";
            p.AddOrUpdate(result1);
            p.AddOrUpdate(result2);

            Assert.AreEqual(2, p.PortableNodes.Count);
            Assert.AreEqual("Foo", p.PortableNodes.Find(t=>t.Id==result1.Id).Name);

        }
    }
}
