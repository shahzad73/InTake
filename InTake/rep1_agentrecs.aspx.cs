using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rep1_agentrecs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["recs"].ToString() == "1" || Request.QueryString["recs"].ToString() == "3")
        {
            listing111.Visible = true;
            listing111.SetSortIDForListingScreen = " LastUpdated DESC ";
            listing111.SetOrderByForListingScreen = " Order By LastUpdated DESC";
            listing111.SetListingTitle = "Agent Records of " + getMonthName(int.Parse(Request.QueryString["month"].ToString())) + " " + Request.QueryString["year"].ToString();
            listing111.SetNoOfRecordsInPage = "1000000";
            listing111.SetCriteriaForListingAndInitializeListing = " where takenbyuserid = " + Request.QueryString["uid"].ToString() + " and month(datetaken) = " + Request.QueryString["month"].ToString() + " and year(datetaken) = " + Request.QueryString["year"].ToString() + " and ReportRegionDMAID = " + Request.QueryString["dmaid"].ToString();     // must be called in the last
        }
        else
            listing111.Visible = false;



        if (Request.QueryString["recs"].ToString() == "2" || Request.QueryString["recs"].ToString() == "3")
        {
            int m = int.Parse( Request.QueryString["month"].ToString() );
            int y = int.Parse(Request.QueryString["year"].ToString());
            if (m == 1)
            {
                m = 12;
                y = y - 1;
            }
            else
                m = m - 1;


            listing222.Visible = true;
            listing222.SetSortIDForListingScreen = " LastUpdated DESC ";
            listing222.SetOrderByForListingScreen = " Order By LastUpdated DESC";
            listing222.SetListingTitle = "Agent Records of " + getMonthName(m) + " " + y.ToString();
            listing222.SetNoOfRecordsInPage = "1000000";
            listing222.SetCriteriaForListingAndInitializeListing = " where takenbyuserid = " + Request.QueryString["uid"].ToString() + " and month(datetaken) = " + m.ToString() + " and year(datetaken) = " + y.ToString() + " and ReportRegionDMAID = " + Request.QueryString["dmaid"].ToString();      // must be called in the last
        }
        else
            listing222.Visible = false;
    }




    public string getMonthName(int m)
    {
                      if(m ==  1) 
                           return "January";
                      if(m ==  2) 
                          return "February";
                      if(m ==  3) 
                          return "March";
                      if(m ==  4) 
                          return "April";
                      if(m ==  5) 
                          return "May";
                      if(m ==  6) 
                          return "June";
                      if(m ==  7) 
                          return "July";
                      if(m ==  8) 
                          return "August";
                      if(m ==  9) 
                          return "September";
                      if(m ==  10) 
                          return "October";
                      if(m ==  11) 
                          return "November";
                      if(m ==  12) 
                          return "December";

        return "";
    }
}