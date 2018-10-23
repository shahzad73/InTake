using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printreport2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string[] st = Context.Request.QueryString["status"].ToString().Split(',');
        string[] st2 = Context.Request.QueryString["txt"].ToString().Split(',');

        string s1 = "";
        string s2 = "";

        

        if(Context.Request.QueryString["df"].ToString() != "")
        {
            s1 = Context.Request["df"].ToString();
            ll.Text = "From Date : " + Context.Request["df"].ToString();
        }

        if (Context.Request.QueryString["dt"].ToString() != "")
        {
            s2 = Context.Request["dt"].ToString();
            ll.Text = ll.Text + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To Date : " + Context.Request["dt"].ToString();
        }


        string rep = "";
        for(int z = 0; z<st.Length; z++)
        {
            rep = rep + DBSpace.DBFunctionality.GenReport3(st[z], st2[z], s1, s2, Context);

        }

        repo.Text = rep;
    }
}