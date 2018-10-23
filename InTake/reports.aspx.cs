using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SearchCriteria"] = "";    //reset search critera so that intake form do not show back to search button


        if (Context.Session["RoleID"] == null)
            Response.Redirect("login.aspx");


        //roles table contains 4 roles  
        //1	Author	System User         
        //2	Editor	System Administrator
        //3	Admin	Administrator       
        //4	Super	Super Admin         

    }
}