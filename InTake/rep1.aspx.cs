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
                drYear.Items.Add(new ListItem(zz.ToString(), zz.ToString()));

            drYear.SelectedValue = DateTime.Now.Year.ToString();
        }
    }


    protected void ttn_Click(object sender, EventArgs e)
    {
        //string ss = "";
        //DataTable dt = DBSpace.DBFunctionality.GetDataTable("Select * from users", Context);

        //for (int zzz = 0; zzz < dt.Rows.Count; zzz++)
        //    ss = ss + DBSpace.DBFunctionality.GetReport1Data(drmonth.SelectedItem.Text, int.Parse(drmonth.SelectedValue), int.Parse(drYear.SelectedValue), drmonth.SelectedItem.Text, int.Parse(dt.Rows[zzz]["id"].ToString()), dt.Rows[zzz]["firstname"].ToString() + " " + dt.Rows[zzz]["lastname"].ToString(), Context);
        
        //ss = ss + DBSpace.DBFunctionality.GetReport1Data2(int.Parse(drmonth.SelectedValue), int.Parse(drYear.SelectedValue), drmonth.SelectedItem.Text, Context);

        //ss = "<span style='border:black 1px solid; padding:8px; margin-right:8px; width:8%; display:inline-block; float:left;  cursor:pointer;' onclick='f4()'> <img src='images/pri.png' width='17px'> &nbsp;Print</span> <br><br>" + ss ;

        //repo.Text = ss;


        string ss = DBSpace.DBFunctionality.GetReport1(drmonth.SelectedItem.Text,int.Parse(drmonth.SelectedValue), int.Parse(drYear.SelectedValue), Context);
        ss = "<span style='border:black 1px solid; padding:8px; margin-right:8px; width:8%; display:inline-block; float:left;  cursor:pointer;' onclick='f4()'> <img src='images/pri.png' width='17px'> &nbsp;Print</span> <br><br>" + ss ;
        repo.Text = ss;

    }


}