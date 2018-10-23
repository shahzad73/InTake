using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Context.Session["UserID"] == null)
            Response.Redirect("login.aspx");

        if (Context.Session["RoleID"] == null)
            Response.Redirect("login.aspx");
    }


    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Context.Session["UserID"] = null;
        Response.Redirect("login.aspx");
    }
}
