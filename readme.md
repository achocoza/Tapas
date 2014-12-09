A simple api for published Umbraco (6 and 7) content. Made for Ajax queries or use from an external MVC application.

**Host your content on your Umbraco site - install Umbraco host nuget (or install the umbraco package from our.)**

	install-package Our.Umbraco.Tapas

**Then try it on your site with your browser js console:**

	$.getJSON("/umbraco/tapas/content/getnode?url=/").done(function(data){console.log(data);})

**Get all nodes as an array:**

	$.getJSON("/umbraco/tapas/content/getdescendantsorself?url=/").done(function(data){console.log(data);})

**Then all nodes as a tree:**

	$.getJSON("/umbraco/tapas/content/gettree?url=/").done(function(data){console.log(data);})

Read the wiki for detailed information about usage.

See also http://joeriks-blog.azurewebsites.net/archive/a-prerelease-of-a-new-version-of-tapas-an-api-for-published-umbraco-content/


**(Beta) If you like to get your Umbraco content from a vanilla MVC site - use the MVC client binaries**

	install-package Our.Umbraco.TapasClient


##Version history##

**Version 3.0.0 - first version of a MVC Client**
Using a new (slightly changed) serialized format to be able to deserialize the nodes to IPublishedContent again - and also to be able
to deserialize to a "PortableNode" which is independent of Umbraco - but with the same properties and content functions.

That means you use TapasMVCClient in a vanilla MVC application, connect it to a Umbraco site, and use the content with familiar
syntax as Children, Parent, Name, Url and so on. Properties are transformed into a Dictionary<string,object> which works fine for most
simple properties. (But complex properties like the 7.2 Grid require custom json parsing.) 

See below for more information, or checkout the SampleWeb project to see how to use it.


**Version 2.0.0 - Nuget, simplified URLs and first version of dump to file**

