﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dma_list : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["listingop"] != null)
            BuildListingRec(int.Parse(Request.QueryString["listingpag"].ToString()));
        else
            BuildListingRec(1);
    }


    protected void BuildListingRec(int pag)
    {
        int z = DBSpace.DBFunctionality.InitializeDatabasePagging(pag, 50, " dmaname asc ", "*", "DMARegion", "", tblCus, "order by dmaname", "", Context);
        DBSpace.DBFunctionality.InitializePagingNumbers(litPaging, z, 50, "dma_list.aspx", pag, "");
    }

}