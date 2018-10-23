using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dma_additem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["op"] != null)
        {
            lblText.Text = "Edit Referral Source";
            if (IsPostBack == false)
            {
                List<DBItem> DBFields = new List<DBItem>();
                GenerateTableFieldsObjects(DBFields);
                DBSpace.DBFunctionality.GetAndSetTableRecord("ReferralSources", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            }
        }
        else
            lblText.Text = "Add Referral Source";
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtRefeeralName", "textbox", "ReferralSource", "string", false);
        itm.ErrorMessage = "Enter Value";
        itm.IsMandatory = true;
        lst.Add(itm);
    }


    protected void btn1_Click(object sender, EventArgs e)
    {
        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool ret = true;


        string s = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from ReferralSources where ReferralSource ='" + txtRefeeralName.Text + "'", Context);
        if (s == "1")
        {
            lbltxtRefeeralName.Text = "Referral source already exists";
            ret = false;
        }
        else
        {
            if (Request.QueryString["op"] != null)
                ret = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("ReferralSources", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            else
                ret = DBSpace.DBFunctionality.RunInsertionQuery("ReferralSources", DBFields, this, false, Context);
        }


        if (ret == true) 
            Response.Redirect("refeeral_list.aspx");
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("refeeral_list.aspx");
    }

}