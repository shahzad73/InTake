using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dma_list : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["listingop"] != null)
            BuildListingRec(int.Parse(Request.QueryString["listingpag"].ToString()));
        else
            BuildListingRec(1);
    }


    protected void BuildListingRec(int pag)
    {
        int r = DBSpace.DBFunctionality.InitializeDatabasePagging(pag, 50, " injury asc ", "*", "injury", "", tblInjury, "order by injury", "", Context);
        DBSpace.DBFunctionality.InitializePagingNumbers(litPaging, r, 50, "injury_list.aspx", pag, "");
    }

}