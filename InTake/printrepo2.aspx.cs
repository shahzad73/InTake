using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printreport2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ll.Text = Context.Request.QueryString["year"].ToString();
        DBSpace.DBFunctionality.GenReport2(Context.Request.QueryString["year"].ToString(), litMonthlyTotal, tblLst, Repeater1, Repeater2, Context);
    }
}