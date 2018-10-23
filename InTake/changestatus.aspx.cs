using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changestatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            DataTable dt2 = DBSpace.DBFunctionality.GetDataTable("Select * from status order by orderno", Context);
            drStatus.DataSource = dt2;
            drStatus.DataTextField = "status";
            drStatus.DataValueField = "id";
            drStatus.DataBind();
            //drStatus.Items.Insert(2, new ListItem("_____________________________________", "-99"));
            drStatus.Items.Insert(11, new ListItem("_____________________________________", "-99")); 

            DataRow dr = DBSpace.DBFunctionality.GetSingleRecordFromATable("Select * from intake where id = " + Context.Request.QueryString["formid"], Context);
            drStatus.SelectedValue = dr["ReportCurrentStatusID"].ToString();
        }
    }


    protected void btn1_Click(object sender, EventArgs e)
    {
        if (drStatus.SelectedValue.ToString() == "-99")
        {
            txtcom.Text = "";
            lblstat.Text = "Select Status";
            return;
        }

        if (txtcommets.Text == "")
        {
            lblstat.Text = "";
            txtcom.Text = "Enter Comments";
            return;
        }


        DBSpace.DBFunctionality.RunNonQuery("Insert into StatusTracking(StatusChangeDate, InTakeID, StatusID, ActionTakenByUser, Comments) values('" + DateTime.Now.ToString() + "', " + Request.QueryString["formid"].ToString() + ", " + drStatus.SelectedValue.ToString() + ", " + Context.Session["UserID"] + ", '" + txtcommets.Text.Replace("'","''") + "')", Context);
        DBSpace.DBFunctionality.RunNonQuery("update intake set ReportCurrentStatusID = " + drStatus.SelectedValue.ToString() + " where id = " + Request.QueryString["formid"].ToString(), Context);
        
        Response.Redirect("intake.aspx?id=" + Request.QueryString["formid"].ToString());
    }


    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("intake.aspx?id=" + Request.QueryString["formid"].ToString());
    }

}   

