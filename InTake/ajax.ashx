<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Web;

public class ajax : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        context.Response.Write("{\"op\":\"" + context.Request.Form["data"].ToString() + "\"}");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}