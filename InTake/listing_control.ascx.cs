using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class listing : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    public string SetCriteriaForListingAndInitializeListing
    {
        set
        {
            if (Request["listingop"] != null)
            {
                BuildListingRec(int.Parse(Request.QueryString["listingpag"].ToString()), value);
            }
            else
            {
                BuildListingRec(1, value);
            }
        }
    }


    public string SetListingTitle
    {
        set
        {
            lblListingTitle.Text = value;
        }

    }

    
    string SortID;
    public string SetSortIDForListingScreen
    {
        set
        {
            SortID = value;
        }

    }

    string OrderBy;
    public string SetOrderByForListingScreen
    {
        set
        {
            OrderBy = value;
        }
    }



    int NoOfRecordsInPage = 25;
    public string SetNoOfRecordsInPage
    {
        set
        {
            NoOfRecordsInPage = int.Parse(value);
        }
    }



    string PageToRedirectWhenPagging = "";   //asxp page to redirect to when paging occurs. basically this is itself
    public string SetPageToRedirectWhenPagging
    {
        set
        {
            PageToRedirectWhenPagging = value;
        }
    }



    string MoreFieldsForPaging = "";   //asxp page to redirect to when paging occurs. basically this is itself
    public string SetMoreFieldsForPaging
    {
        set
        {
            MoreFieldsForPaging = value;
        }
    }


    protected void BuildListingRec(int pag, string Where)
    {
        if (Where != "")
            Where = Where + " And ";

        Where = Where + " [status].id = intake.reportcurrentstatusid and injury.id = intake.injuryid and intake.ReportRegionDMAID = DMARegion.id ";
        int rrr = DBSpace.DBFunctionality.InitializeDatabasePagging(pag, NoOfRecordsInPage, SortID, " Intake.*, [status].status, injury.injury, DMARegion.dmaname ", " Intake, [status], injury, DMARegion ", Where, tblLst, OrderBy, "", Context);
        DBSpace.DBFunctionality.InitializePagingNumbers(litPaging, rrr, NoOfRecordsInPage, PageToRedirectWhenPagging, pag, MoreFieldsForPaging);
        litrcnt.Text = rrr.ToString();
    }

}

