var tapasClient;
(function (tapasClient) {
    function getCurrent() {
        return {};
    }
    tapasClient.getCurrent = getCurrent;

    function getChildren(selector) {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/nodes/getchildren/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/nodes/getchildren?path=" + selector);
    }
    tapasClient.getChildren = getChildren;

    function getNode(selector) {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/node/getnode/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/node/getnode?path=" + selector);
    }
    tapasClient.getNode = getNode;

    function getParent(selector) {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/node/getparent/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/node/getparent?path=" + selector);
    }
    tapasClient.getParent = getParent;
})(tapasClient || (tapasClient = {}));
//# sourceMappingURL=tapasClient.js.map
