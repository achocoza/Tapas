var tapasClient;
(function (tapasClient) {
    function getCurrentPath() {
        return window.location.pathname;
    }
    tapasClient.getCurrentPath = getCurrentPath;
    tapasClient.options = {
        paths: {
            root: "/umbraco/publishedcontent",
            children: "/nodes/getchildren",
            node: "/node/getnode",
            parent: "/node/getparent",
            ancestors: "/nodes/getancestors",
            descendantsOrSelf: "/nodes/getdescendantsorself",
            tree: "/nodes/gettree",
            navigationTree: "/nodes/getnavigationtree",
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
        getDescendantsOrSelf(path).done(function (result) {
            tapasClient.contentArray = result;
            var end = new Date().getTime();
            var spentMilliseconds = end - start;

            console.log("Content array loaded (load time " + spentMilliseconds + "ms) and available on tapasClient.contentArray");
            console.log(tapasClient.contentArray);
        });
    }
    tapasClient.loadContentArray = loadContentArray;

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
