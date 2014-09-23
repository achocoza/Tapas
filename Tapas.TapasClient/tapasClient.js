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
            descendantsAndSelf: "/nodes/getdescendantsandself",
            descendantsAndSelfFlattened: "/nodes/getdescendantsandselfflattened",
            tree: "/navigation/gettree",
            treeFlattened: "/navigation/gettreeflattened",
            byId: "/",
            byPath: "?path="
        }
    };

    function getFromApi(resource, selector) {
        if (typeof selector == "number") {
            return $.getJSON(tapasClient.options.paths.root + resource + tapasClient.options.paths.byId + selector);
        }
        if (!selector)
            selector = getCurrentPath();
        return $.getJSON(tapasClient.options.paths.root + resource + tapasClient.options.paths.byPath + selector);
    }
    tapasClient.getFromApi = getFromApi;

    

    function getChildren(selector) {
        return getFromApi(tapasClient.options.paths.children, selector);
    }
    tapasClient.getChildren = getChildren;

    

    function getDescendantsAndSelf(selector) {
        return getFromApi(tapasClient.options.paths.descendantsAndSelf, selector);
    }
    tapasClient.getDescendantsAndSelf = getDescendantsAndSelf;

    function getDescendantsAndSelfFlattened(selector) {
        return getFromApi(tapasClient.options.paths.descendantsAndSelfFlattened, selector);
    }
    tapasClient.getDescendantsAndSelfFlattened = getDescendantsAndSelfFlattened;

    

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

    

    function getNavigationTree(selector) {
        return getFromApi(tapasClient.options.paths.tree, selector);
    }
    tapasClient.getNavigationTree = getNavigationTree;

    

    function getNavigationTreeFlattened(selector) {
        return getFromApi(tapasClient.options.paths.treeFlattened, selector);
    }
    tapasClient.getNavigationTreeFlattened = getNavigationTreeFlattened;
})(tapasClient || (tapasClient = {}));
//# sourceMappingURL=tapasClient.js.map
