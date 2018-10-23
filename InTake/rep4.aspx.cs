using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rep4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ttn_Click(object sender, EventArgs e)
    {
        string s = DBSpace.DBFunctionality.GetReportNotes(Context, txtFromDate.Text, txtToDate.Text);

        if (s == "")
            repo.Text = "No records found";
        else
            repo.Text = "<span style='border:black 1px solid; padding:8px; margin-right:8px; width:8%; display:inline-block; float:left;  cursor:pointer;' onclick='f4(\"" + txtFromDate.Text + "\", \"" + txtToDate.Text + "\")'> <img src='images/pri.png' width='17px'> &nbsp;Print</span> <br><br>" + s;
    }

}
