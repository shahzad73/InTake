using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class listingforms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Session["SearchCriteria"] = "";    //reset search critera so that intake form do not show back to search button

            //DataTable dt = DBSpace.DBFunctionality.GetDataTable("select id, status + '  -   (' + cast(NoOfFormsInThisList as nvarchar(50)) + ')' as statuscount from status where isDisplayedOnListingScreen = 1 order by orderno", Context);
            DataTable dt = DBSpace.DBFunctionality.GetDataTable("select id, status from status order by orderno", Context);
            drstatus.DataSource = dt;
            drstatus.DataTextField = "status";
            drstatus.DataValueField = "id";
            drstatus.DataBind();
            drstatus.Items.Insert(0, new ListItem("All", "-1"));

            dt = DBSpace.DBFunctionality.GetDataTable("Select * from injury", Context);
            drclassification.DataSource = dt;
            drclassification.DataTextField = "injury";
            drclassification.DataValueField = "id";
            drclassification.DataBind();
            drclassification.Items.Insert(0, new ListItem("All", "-1"));

            if (Request.QueryString["statusid"] != null)
                drstatus.SelectedValue = Request.QueryString["statusid"].ToString();

            if (Request.QueryString["clsid"] != null)
                drclassification.SelectedValue = Request.QueryString["clsid"].ToString();

            if (Request.QueryString["fld"] != null)
                drfields.SelectedValue = Request.QueryString["fld"].ToString();

            if (Request.QueryString["sort"] != null)
                drsort.SelectedValue = Request.QueryString["sort"].ToString();


            dt = DBSpace.DBFunctionality.GetDataTable("select * from dmaregion", Context);
            drDMA.DataSource = dt;
            drDMA.DataTextField = "dmaname";
            drDMA.DataValueField = "id";
            drDMA.DataBind();
            drDMA.Items.Insert(0, new ListItem("All", "-1"));

            listing111.SetSortIDForListingScreen = " LastUpdated DESC ";
            listing111.SetOrderByForListingScreen = " Order By " + drfields.SelectedValue + " " + drsort.SelectedValue;
            listing111.SetListingTitle = "Record Listing";
            listing111.SetPageToRedirectWhenPagging = "listingforms.aspx";
            listing111.SetMoreFieldsForPaging = "statusid=" + drstatus.SelectedValue.ToString() + "&clsid=" + drclassification.SelectedValue + "&fld=" + drfields.SelectedValue + "&sort=" + drsort.SelectedValue;

            string where = "";

            if (drstatus.SelectedValue.ToString() != "-1")
                where = " and ReportCurrentStatusID = " + drstatus.SelectedValue.ToString();
            if (drclassification.SelectedValue.ToString() != "-1")
                where = where + " and injuryid = " + drclassification.SelectedValue;

            listing111.SetCriteriaForListingAndInitializeListing = " Where isNewlyCreated = 0 " + where;
        }
    }



    protected void drstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("listingforms.aspx?fld=" + drfields.SelectedValue + "&sort=" + drsort.SelectedValue + "&statusid=" + drstatus.SelectedValue + "&clsid=" + drclassification.SelectedIndex);
    }



    protected void btnButton_Click(object sender, EventArgs e)
    {

        //string where = "";

        //if (txtfname.Text != "")
        //{
        //    where = where + "&fn=" + txtfname.Text;
        //}
        //if (txtlname.Text != "")
        //{
        //    where = where + "&ln=" + txtlname.Text;
        //}
        //if (txtFromDate.Text != "")
        //{
        //    where = where + "&fd=" + txtFromDate.Text;
        //}
        //if (txtToDate.Text != "")
        //{
        //    where = where + "&td=" + txtToDate.Text;
        //}
        //if (drDMA.SelectedValue != "-1")
        //{
        //    where = where + "&dma=" + drDMA.SelectedValue;
        //}
        //if (txtOthers.Text != "")
        //{
        //    where = where + "&oth=" + txtOthers.Text;
        //}

        //string where2 = "";
        //if (chkegy.Checked == true)
        //    where2 = where2 + "&egy=Yes";
        //else
        //    where2 = where2 + "&egy=No";

        //if (where != "")
        //    Response.Redirect("search.aspx?sid=" + drstatus.SelectedValue.ToString() + "&cls=" + drclassification.SelectedValue + where + where2);


        string where = "";
        if (txtfname.Text != "")
            where = where + " and fname like '%" + txtfname.Text + "%'";
        if (txtlname.Text != "")
            where = where + " and lname like '%" + txtlname.Text + "%'";
        if (drDMA.SelectedValue != "-1")
            where = where + " and ReportRegionDMAID = " + drDMA.SelectedValue;
        if (drclassification.SelectedValue != "-1")
            where = where + " and Injuryid = " + drclassification.SelectedValue;
        if (drstatus.SelectedValue.ToString() != "-1")
            where = where + " and ReportCurrentStatusID = " + drstatus.SelectedValue.ToString();
        if (txtOthers.Text != "")
            where = where + " and allfields like '%" + txtOthers.Text + "%'";
        if (txtFromDate.Text != "" && txtToDate.Text == "")
            where = where + " and datetaken >= '" + txtFromDate.Text + "'";
        if (txtFromDate.Text == "" && txtToDate.Text != "")
            where = where + " and datetaken <= '" + txtToDate.Text + "'";
        if (txtFromDate.Text != "" && txtToDate.Text != "")
            where = where + " and datetaken >= '" + txtFromDate.Text + "' and datetaken <= '" + txtToDate.Text + "'";


        if (where != "")
        {
            if (chkegy.Checked == true)
                where = where + " and isEgypt = 'Yes'";

            Session["SearchCriteria"] = where;
            Response.Redirect("search.aspx");
        }

    }

}
