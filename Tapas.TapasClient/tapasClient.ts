module tapasClient {

    export interface UmbracoNode {
        Id: number;
        Level: number;
        NiceUrl: string;
        SortOrder: number;
        UrlName: string;
        NodeTypeAlias: string;
        CreatorName: string;
        Template: number;
        CreateDate: string;
        UpdateDate: string;
        ParentId: number;
        ChildIds: number[];
        Children: UmbracoNode[];
    }
    export interface UmbracoNav {
        Id: number;
        Name: string;
        NiceUrl: string;
        Visible: boolean;
        UrlName: string;
        Children: UmbracoNav[];
    }
    export function getCurrentPath() {
        return window.location.pathname;
    }
    export var options = {
        paths: {
            root: "/umbraco/publishedcontent",
            children: "/nodes/getchildren",
            node: "/node/getnode",
            parent: "/node/getparent",
            ancestors: "/nodes/getancestors",
            descendantsOrSelf: "/nodes/getdescendantsorself",
            tree: "/node/gettree",
            byId: "/",
            byPath: "?url="

        }

    }

    export function getFromApi<T>(resource: string, selector?: any): JQueryPromise<T> {
        if (typeof selector == "number") {
            return $.getJSON(options.paths.root + resource + options.paths.byId + selector);
        }
        if (!selector) selector = getCurrentPath();
        return $.getJSON(options.paths.root + resource + options.paths.byPath + selector);
    }

    /**
    *   Get children from current path (no arg), path (string arg) or id (number arg)
    */
    export function getChildren(path: string): JQueryPromise<UmbracoNode[]>;
    export function getChildren(id: number): JQueryPromise<UmbracoNode[]>;
    export function getChildren(selector?: any): JQueryPromise<UmbracoNode[]> {
        return getFromApi<UmbracoNode[]>(options.paths.children, selector);
    }

    /**
    *   Get descandants and self from current path (no arg), path (string arg) or id (number arg)
    */
    export function getDescendantsAndSelf(path: string): JQueryPromise<UmbracoNode[]>;
    export function getDescendantsAndSelf(id: number): JQueryPromise<UmbracoNode[]>;
    export function getDescendantsAndSelf(selector?: any): JQueryPromise<UmbracoNode[]> {
        return getFromApi<UmbracoNode[]>(options.paths.descendantsAndSelf, selector);
    }

    export function getDescendantsAndSelfFlattened(path: string): JQueryPromise<UmbracoNode[]>;
    export function getDescendantsAndSelfFlattened(id: number): JQueryPromise<UmbracoNode[]>;
    export function getDescendantsAndSelfFlattened(selector?: any): JQueryPromise<UmbracoNode[]> {
        return getFromApi<UmbracoNode[]>(options.paths.descendantsAndSelfFlattened, selector);
    }


    /**
    *   Get ancestors from current path (no arg), path (string arg) or id (number arg)
    */
    export function getAncestors(path: string): JQueryPromise<UmbracoNode[]>;
    export function getAncestors(id: number): JQueryPromise<UmbracoNode[]>;
    export function getAncestors(selector?: any): JQueryPromise<UmbracoNode[]> {
        return getFromApi<UmbracoNode[]>(options.paths.ancestors, selector);
    }

    /**
    *   Get node from current path (no arg), path (string arg) or id (number arg)
    */
    export function getNode(path: string): JQueryPromise<UmbracoNode>;
    export function getNode(id: number): JQueryPromise<UmbracoNode>;
    export function getNode(selector?: any): JQueryPromise<UmbracoNode> {
        return getFromApi<UmbracoNode>(options.paths.node, selector);
    }

    /**
    *   Get parent node from current path (no arg), path (string arg) or id (number arg)
    */
    export function getParent(path: string): JQueryPromise<UmbracoNode>;
    export function getParent(id: number): JQueryPromise<UmbracoNode>;
    export function getParent(selector?: any): JQueryPromise<UmbracoNode> {
        return getFromApi<UmbracoNode>(options.paths.parent, selector);
    }

    /**
    *   Get full navigation tree from current path (no arg), path (string arg) or id (number arg)
    */
    export function getNavigationTree(path: string): JQueryPromise<UmbracoNav>;
    export function getNavigationTree(id: number): JQueryPromise<UmbracoNav>;
    export function getNavigationTree(selector?: any): JQueryPromise<UmbracoNav> {
        return getFromApi<UmbracoNode>(options.paths.tree, selector);
    }

    /**
    *   Get full navigation tree, flattened, from current path (no arg), path (string arg) or id (number arg)
    */
    export function getNavigationTreeFlattened(path: string): JQueryPromise<UmbracoNav[]>;
    export function getNavigationTreeFlattened(id: number): JQueryPromise<UmbracoNav[]>;
    export function getNavigationTreeFlattened(selector?: any): JQueryPromise<UmbracoNav[]> {
        return getFromApi<UmbracoNode>(options.paths.treeFlattened, selector);
    }

}

