using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_list : System.Web.UI.Page
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
        int z = 0;
        if (Context.Session["RoleID"].ToString() == "3")
        {
            z = DBSpace.DBFunctionality.InitializeDatabasePagging(pag, 50, " id asc ", "*", "users", " where roleid in(1,2)", tblUser, "order by firstname", "", Context);
        }
        else if (Context.Session["RoleID"].ToString() == "4")
            z = DBSpace.DBFunctionality.InitializeDatabasePagging(pag, 50, " id asc ", "*", "users", " where roleid in(1,2,3)", tblUser, "order by firstname", "", Context);

        DBSpace.DBFunctionality.InitializePagingNumbers(litPaging, z, 50, "users_list.aspx", pag, "");
    }


    protected void repeaterResult_ItemDataDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lblName = new Literal();
            lblName = (Literal)e.Item.FindControl("ltlOption");

            DataRowView drv = e.Item.DataItem as DataRowView;
            
            if(drv["status"].ToString() == "1")
                lblName.Text = "Active";
            else
                lblName.Text = "Disabled";
        }        
    }

}