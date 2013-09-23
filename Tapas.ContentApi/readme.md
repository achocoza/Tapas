##A simple api for published Umbraco 6+ content. Made for Ajax queries.

Api starts at 

	/umbraco/publishedcontent

All requests must be as GET and as application/json (so you'll need fiddler/curl/restconsole to try it)

###Returns a single node:

	/node/getnode/{id} : gets node by id
	/node/getnode?path=.. : gets node by path

	/node/getparent/{id} : gets parent of 1065
	/node/getparent?path=...

###Returns array of nodes:

	/nodes/getchildren/{id} : gets all child nodes of the node with that id 
	/nodes/getchildren?path=...

	/nodes/getancestors/{id}
	/nodes/getancestors?path=...


###Returns hierarchy of nodes:

	/nodes/getdescendantsandself/{id}
	/nodes/getdescendantsandself?path=...


###Returns navigation tree (only name, url, id & visible) of nodes:

	/navigation/gettree/{id}
	/navigation/gettree?path=...


###Node format for single node

	{
		"Id": 1087,
		"Level": 3,
		"NiceUrl": "/foo/bar/",
		"Name": "Bar",
		"SortOrder": 3,
		"UrlName": "bar",
		"NodeTypeAlias": "content",
		"CreatorName": "admin",
		"Template": 1093,
		"Properties": {
			"umbracoNaviHide": "0",
			"contactPerson": "",
			"pageAdministrator": "",
			"linkedNodes": "",
			"bodyText": "<p>yada yada yada</p>",
			"header": "",
			"introduction": ""
		},
		"CreateDate": "2013-09-20T06:27:16",
		"UpdateDate": "2013-09-20T06:35:25",
		"ParentId": 1086,
		"ChildIds": [1089,1090]
	}

###Format for navigation tree

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