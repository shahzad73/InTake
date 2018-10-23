using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class repo3 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            lblst.Text = "<br/>";
            DataTable dt2 = DBSpace.DBFunctionality.GetDataTable("Select * from status order by orderno", Context);
            lststatus.DataSource = dt2;
            lststatus.DataTextField = "status";
            lststatus.DataValueField = "id";
            lststatus.DataBind();
        }
    }


    protected void ttn_Click(object sender, EventArgs e)
    {
        string rep = "";


        if (lststatus.SelectedItem == null)
        {
            lblst.Text = "Select atleast 1 status from list";
            return;
        }
        else
            lblst.Text = "<br/>";

        string sss = "";
        string sss2 = "";
        foreach (ListItem item in lststatus.Items)
        {
            if (item.Selected)
            {
                //Context.Response.Write(item.Value);
                rep = rep + DBSpace.DBFunctionality.GenReport3(item.Value, item.Text, txtFromDate.Text, txtToDate.Text, Context);
                sss = sss + item.Value + ",";
                sss2 = sss2 + item.Text + ",";
            }
        }


        if (rep != "")
        {
            sss = sss.Substring(0, sss.Length - 1);
            sss2 = sss2.Substring(0, sss2.Length - 1);
            rep = "<span style='border:black 1px solid; padding:8px; margin-right:8px; width:8%; display:inline-block; float:left;  cursor:pointer;' onclick='f4(\"" + sss + "\", \"" + sss2 + "\")'> <img src='images/pri.png' width='17px'> &nbsp;Print</span> <br><br>" + rep;
            repo.Text = rep;
        }
    }


}