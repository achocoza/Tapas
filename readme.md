A simple api for published Umbraco (6 and 7) content. Made for Ajax queries.

See also http://joeriks-blog.azurewebsites.net/archive/a-prerelease-of-a-new-version-of-tapas-an-api-for-published-umbraco-content/

**Version Bump 2.0.0**
* Simplified Urls
* Content Dump to file (from backoffice)

**Nuget**

	install-package Our.Umbraco.Tapas

**Then try it on your site with your browser js console:**

	$.getJSON("/umbraco/tapas/content/getnode?url=/").done(function(data){console.log(data);})


**Get all nodes as an array:**

	$.getJSON("/umbraco/tapas/content/getdescendantsorself?url=/").done(function(data){console.log(data);})

**Then all nodes as a tree:**

	$.getJSON("/umbraco/tapas/content/gettree?url=/").done(function(data){console.log(data);})

###TapasClient has the following functions:
####Returns (with the promise interface) node/s with all properties:
* getNode
* getChildren
* getParent
* getAncestors
* getDescendantsOrSelf
* getTree

####Parameters (same for all functions):
* getNode(nodeid:number)
* getNode(path:string)
* getNode() use current path

##Using the http api directly:
Api starts at 

	/tapas/content

All requests must be as GET and as application/json (so you'll need fiddler/curl/restconsole to try it)

###Returns a single node:

	/getnode/{id} : gets node by id 
	/getnode?url=.. : gets node by path

###Node format for single node

	{
		"Id": 1087,
		"Name": "Bar",
		"Url": "/foo/bar/",
		"Visible": true,
		"CreateDate": "2013-09-20T06:27:16",
		"UpdateDate": "2013-09-20T06:35:25",
		"Level": 3,
		"SortOrder": 3,
		"UrlName": "bar",
		"DocumentTypeAlias": "content",
		"WriterId": 0,
		"WriterName": "admin",
		"TemplateId": 1093,
		"Properties": {
			"umbracoNaviHide": "0",
			"contactPerson": "",
			"pageAdministrator": "",
			"linkedNodes": "",
			"bodyText": "<p>yada yada yada</p>",
			"header": "",
			"introduction": ""
		},
		"ParentId": 1086,
		"ChildIds": [1089,1090]
	}

###Format for tree

	{
		"NiceUrl": "/some-root/",
		"Name": "Some Root",
		"Visible": false,
		"Id": 1081,
		"UrlName": "some-root",
		"Children": [{
			"NiceUrl": "/somechild/",
			"Name": "Some child",
			"Visible": true,
			"Id": 1084,
			"UrlName": "somechild",
			"Children": []
		}, {
			"NiceUrl": "/some-other-child/",
			"Name": "Some other child",
			"Visible": true,
			"Id": 1086,
			"UrlName": "some-other-child",
			"Children": [{
				...
			}, {
				...
			}, {
				...
			}]
		}]
	}


---

You can also use the tapasClient.js to your nodes easily:

Get and iterate all content as array

	tapasClient.getDescendantsAndSelf().done(function(children){
		for (var child in children) {
			console.log(children[child].Name + "," + children[child].Url);
		}
	});

	$.ajax({url:"/umbraco/tapas/content/gettree"}).done(...)

Get and iterate all content as tree

	tapasClient.getDescendantsAndSelf().done(function(children){
		for (var child in children) {
			console.log(children[child].Name + "," + children[child].Url);
		}
	});

	$.ajax({url:"/umbraco/tapas/content/gettree"}).done(...)


Get and iterate navigation tree (only navigation properties):

    var logChildren = function(children) {
		for (var child in children) {
			console.log(children[child].Name + "," + children[child].NiceUrl);
			logChildren(children[child].Children);
		}
	};
	tapasClient.getNavigationTree().done(logChildren);

	$.ajax({url:"/umbraco/tapas/content/getnavigationtree"}).done(...)



