using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //string where = "";
        //if (Request.QueryString["fn"] != null)
        //    where = where + " and fname like '%" + Request.QueryString["fn"] + "%'";
        //if (Request.QueryString["ln"] != null)
        //    where = where + " and lname like '%" + Request.QueryString["fn"] + "%'";
        //if (Request.QueryString["dma"] != null)
        //    where = where + " and ReportRegionDMAID = " + Request.QueryString["dma"];
        //if (Request.QueryString["cls"] != null)
        //    if (Request.QueryString["cls"].ToString() != "-1")
        //        where = where + " and Injuryid = " + Request.QueryString["cls"];
        //if (Request.QueryString["sid"] != null)
        //    if (Request.QueryString["sid"].ToString() != "-1")
        //        where = where + " and ReportCurrentStatusID = " + Request.QueryString["sid"];
        //if (Request.QueryString["oth"] != null)
        //    where = where + " and allfields like '%" + Request.QueryString["oth"] + "%'";
        //if (Request.QueryString["fd"] != null && Request.QueryString["td"] == null)
        //    where = where + " and datetaken > '" + Request.QueryString["fd"].ToString() + "'";
        //if (Request.QueryString["fd"] == null && Request.QueryString["td"] != null)
        //    where = where + " and datetaken < '" + Request.QueryString["td"].ToString() + "'";
        //if (Request.QueryString["fd"] != null && Request.QueryString["td"] != null)
        //    where = where + " and datetaken between '" + Request.QueryString["fd"].ToString() + "' and '" + Request.QueryString["td"].ToString() + "'";

        //where = where + " and isEgypt='" + Request.QueryString["egy"] + "'";s

        if (Session["SearchCriteria"].ToString() == "")
            Response.Redirect("listingforms.aspx");

        listing111.SetSortIDForListingScreen = " LastUpdated DESC ";
        listing111.SetOrderByForListingScreen = " Order By LastUpdated DESC";
        listing111.SetListingTitle = "Search Listing";
        listing111.SetNoOfRecordsInPage = "1000000";
        listing111.SetCriteriaForListingAndInitializeListing = " Where isNewlyCreated = 0 " + Session["SearchCriteria"].ToString();     // must be called in the last
    }
}
