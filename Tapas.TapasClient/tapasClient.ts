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
    }

    export function getCurrent(): UmbracoNode {
        return <UmbracoNode>{};
    }
    
    export function getChildren(path: string): JQueryPromise<UmbracoNode[]>;
    export function getChildren(id: number): JQueryPromise<UmbracoNode[]>;
    export function getChildren(selector: any): JQueryPromise<UmbracoNode[]> {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/nodes/getchildren/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/nodes/getchildren?path=" + selector);
    }

    export function getNode(path: string): JQueryPromise<UmbracoNode>;
    export function getNode(id: number): JQueryPromise<UmbracoNode>;
    export function getNode(selector: any): JQueryPromise<UmbracoNode> {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/node/getnode/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/node/getnode?path=" + selector);
    }

    export function getParent(path: string): JQueryPromise<UmbracoNode>;
    export function getParent(id: number): JQueryPromise<UmbracoNode>;
    export function getParent(selector: any): JQueryPromise<UmbracoNode> {
        if (typeof selector == "number") {
            return $.getJSON("/umbraco/publishedcontent/node/getparent/" + selector);
        }
        return $.getJSON("/umbraco/publishedcontent/node/getparent?path=" + selector);
    }

    

}