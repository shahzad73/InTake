using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class rep1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            int d = int.Parse(DateTime.Now.Year.ToString());
            for (int zz = 1900; zz <= d + 1; zz++)
                drStartingYear.Items.Add(new ListItem(zz.ToString(), zz.ToString()));

            drStartingYear.SelectedValue = DateTime.Now.Year.ToString();
        }
    }


    protected void drStartingYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void repo_Click(object sender, EventArgs e)
    {
        pnlitm.Visible = true;
        DBSpace.DBFunctionality.GenReport2(drStartingYear.SelectedValue, litMonthlyTotal, tblLst, Repeater1, Repeater2, Context);
    }


}