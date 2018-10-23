using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class listingformsothers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {

            DataTable dt = DBSpace.DBFunctionality.GetDataTable("select * from dmaregion", Context);
            drDMA.DataSource = dt;
            drDMA.DataTextField = "dmaname";
            drDMA.DataValueField = "id";
            drDMA.DataBind();
            drDMA.Items.Insert(0, new ListItem("All", "-1"));


            dt = DBSpace.DBFunctionality.GetDataTable("Select * from injury", Context);
            drclassification.DataSource = dt;
            drclassification.DataTextField = "injury";
            drclassification.DataValueField = "id";
            drclassification.DataBind();
            drclassification.Items.Insert(0, new ListItem("All", "-1"));

            if (Request.QueryString["clsid"] != null)
                drclassification.SelectedValue = Request.QueryString["clsid"].ToString();

            listing111.SetSortIDForListingScreen = " LastUpdated DESC ";
            listing111.SetOrderByForListingScreen = " Order By LastUpdated DESC";
            listing111.SetListingTitle = "Record Listing";
            listing111.SetPageToRedirectWhenPagging = "listingforms.aspx";

            if (drclassification.SelectedValue != "-1")
                listing111.SetCriteriaForListingAndInitializeListing = " Where isNewlyCreated = 0 and ReportCurrentStatusID = " + Request.QueryString["frm"].ToString() + "and injuryid = " + drclassification.SelectedValue;
            else
                listing111.SetCriteriaForListingAndInitializeListing = " Where isNewlyCreated = 0 and ReportCurrentStatusID = " + Request.QueryString["frm"].ToString();  
        }

        if (Request.QueryString["frm"] == "0")
            lblType.Text = "Bugged Forms List";
        else
            lblType.Text = "Archived Forms List";


    }



    protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("listingformsothers.aspx?statusid=" + "&clsid=" + drclassification.SelectedIndex + "&frm=" + Request.QueryString["frm"].ToString());
    }



    protected void btnButton_Click(object sender, EventArgs e)
    {
        string where = "";

        if (txtfname.Text != "")
        {
            where = where + "&fn=" + txtfname.Text;
        }
        if (txtlname.Text != "")
        {
            where = where + "&ln=" + txtlname.Text;
        }

        if (txtFromDate.Text != "")
        {
            where = where + "&fd=" + txtFromDate.Text;
        }
        if (txtToDate.Text != "")
        {
            where = where + "&td=" + txtToDate.Text;
        }
        if (drDMA.SelectedValue != "-1")
        {
            where = where + "&dma=" + drDMA.SelectedValue;
        }
        if (txtOthers.Text != "")
        {
            where = where + "&oth=" + txtOthers.Text;
        }
        string where2 = "";
        if (chkegy.Checked == true)
            where2 = where2 + "&egy=Yes";
        else
            where2 = where2 + "&egy=No";


        if (where != "")
        {
            Response.Redirect("search.aspx?sid=" + Request.QueryString["frm"].ToString() + "&cls=" + drclassification.SelectedValue + where + where2);
        }
    }

}