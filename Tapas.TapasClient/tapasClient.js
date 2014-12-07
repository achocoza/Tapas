var tapasClient;
(function (tapasClient) {
    function getCurrentPath() {
        return window.location.pathname;
    }
    tapasClient.getCurrentPath = getCurrentPath;
    tapasClient.options = {
        paths: {
            root: "/umbraco/tapas",
            children: "/content/getchildren",
            node: "/content/getnode",
            parent: "/content/getparent",
            ancestors: "/content/getancestors",
            descendantsOrSelf: "/content/getdescendantsorself",
            tree: "/content/gettree",
            navigationTree: "/content/getnavigationtree",
            byId: "/",
            byPath: "?url="
        },
        async: true
    };

    tapasClient.contentTree;
    tapasClient.contentArray;

    function loadContentTree(path) {
        if (typeof path === "undefined") { path = "/"; }
        var start = new Date().getTime();
        getTree(path).done(function (result) {
            tapasClient.contentTree = result;
            var end = new Date().getTime();
            var spentMilliseconds = end - start;

            console.log("Content tree loaded (load time " + spentMilliseconds + "ms) and available on tapasClient.contentTree");
            console.log(tapasClient.contentTree);
        });
    }
    tapasClient.loadContentTree = loadContentTree;
    function loadContentArray(path) {
        if (typeof path === "undefined") { path = "/"; }
        var start = new Date().getTime();
        var promise = getDescendantsOrSelf(path);

        promise.done(function (result) {
            tapasClient.contentArray = result;
            var end = new Date().getTime();
            var spentMilliseconds = end - start;

            console.log("Content array loaded (load time " + spentMilliseconds + "ms) and available on tapasClient.contentArray");
            console.log(tapasClient.contentArray);
        });
        return promise;
    }
    tapasClient.loadContentArray = loadContentArray;

    function attachArraySearch(inputDomObject, resultDomObject) {
        loadContentArray();
        var content = "";

        inputDomObject.keyup(function () {
            if (inputDomObject.val() != content) {
                content = inputDomObject.val();
                var ul = $("<ul>");

                var result = arraySearch(content);
                for (var i in result) {
                    var res = result[i];
                    ul.append("<li><a href='" + res.Url + "'>" + res.Name + "</a></li>");
                }

                resultDomObject.html(ul);
            }
        });
    }
    tapasClient.attachArraySearch = attachArraySearch;

    function arraySearch(searchString) {
        if (typeof tapasClient.contentArray == "undefined")
            console.log("Nothing to do. You need to load the contentArray first (tapasClient.loadContentArray)");
        else {
            var result = tapasClient.contentArray.filter(function (item) {
                if (typeof item.Name == "undefined")
                    return false;

                if (item.Name.indexOf(searchString) != -1) {
                    item._searchScore = 10;
                    return true;
                }

                if (item.Properties)
                    for (var prop in item.Properties) {
                        if (item.Properties[prop] != null && item.Properties[prop].toString().indexOf(searchString) != -1) {
                            item._searchScore = 1;
                            return true;
                        }
                    }
            });

            var sortedResult = result.sort(function (a, b) {
                if (a._searchScore > b._searchScore)
                    return -1;
                if (a._searchScore == b._searchScore && a.UpdateDate > b.UpdateDate)
                    return -1;
                return 1;
            });

            return result;
        }
    }
    tapasClient.arraySearch = arraySearch;

    // JQueryPromise<T>
    function getFromApi(resource, selector) {
        var ajaxCall = function (path) {
            if (tapasClient.options.async)
                return $.getJSON(path);
            else {
                var result = {};
                $.ajax({
                    url: tapasClient.options.paths.root + resource + tapasClient.options.paths.byId + selector, dataType: "json", success: function (data) {
                        return result = data;
                    }
                });
                return result;
            }
        };

        if (typeof selector == "number") {
            return ajaxCall(tapasClient.options.paths.root + resource + tapasClient.options.paths.byId + selector);
        }
        if (!selector)
            selector = getCurrentPath();

        return ajaxCall(tapasClient.options.paths.root + resource + tapasClient.options.paths.byPath + selector);
    }
    tapasClient.getFromApi = getFromApi;

    

    function getChildren(selector) {
        return getFromApi(tapasClient.options.paths.children, selector);
    }
    tapasClient.getChildren = getChildren;

    

    function getDescendantsOrSelf(selector) {
        return getFromApi(tapasClient.options.paths.descendantsOrSelf, selector);
    }
    tapasClient.getDescendantsOrSelf = getDescendantsOrSelf;

    

    function getAncestors(selector) {
        return getFromApi(tapasClient.options.paths.ancestors, selector);
    }
    tapasClient.getAncestors = getAncestors;

    

    function getNode(selector) {
        return getFromApi(tapasClient.options.paths.node, selector);
    }
    tapasClient.getNode = getNode;

    

    function getParent(selector) {
        return getFromApi(tapasClient.options.paths.parent, selector);
    }
    tapasClient.getParent = getParent;

    

    function getTree(selector) {
        return getFromApi(tapasClient.options.paths.tree, selector);
    }
    tapasClient.getTree = getTree;

    

    function getNavigationTree(selector) {
        return getFromApi(tapasClient.options.paths.navigationTree, selector);
    }
    tapasClient.getNavigationTree = getNavigationTree;
})(tapasClient || (tapasClient = {}));
//# sourceMappingURL=tapasClient.js.map
