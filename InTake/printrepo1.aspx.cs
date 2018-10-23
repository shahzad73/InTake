using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printrepo1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ll.Text = Context.Request.QueryString["month"].ToString() + " " + Context.Request.QueryString["year"].ToString();
        repo.Text = "<br><br><br>" + DBSpace.DBFunctionality.GetReport1(Context.Request.QueryString["month"].ToString(), int.Parse(Context.Request.QueryString["mon"].ToString()), int.Parse(Context.Request.QueryString["year"].ToString()), Context);
    }
}