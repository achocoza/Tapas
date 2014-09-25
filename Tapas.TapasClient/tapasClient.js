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

    // JQueryPromise<T>
    function getFromApi(resource, selector) {
        var ajaxCall = function (path) {
            if (async)
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
