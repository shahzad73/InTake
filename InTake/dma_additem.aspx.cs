using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dma_additem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["op"] != null)
        {
            lblText.Text = "Edit DMA Record";

            if (IsPostBack == false)
            {
                List<DBItem> DBFields = new List<DBItem>();
                GenerateTableFieldsObjects(DBFields);
                DBSpace.DBFunctionality.GetAndSetTableRecord("DMARegion", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            }
        }
        else
            lblText.Text = "Add New DMA Record";
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtDMAName", "textbox", "dmaname", "string", false);
        itm.ErrorMessage = "Enter DMA Name";
        itm.IsMandatory = true;
        lst.Add(itm);
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool ret = true;


        string s = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from DMARegion where dmaname ='" + txtDMAName.Text + "'", Context);
        if (s == "1")
        {
            lbltxtDMAName.Text = "DMA Name already exists";
            ret = false;
        }
        else
        {
            if (Request.QueryString["op"] != null)
                ret = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("DMARegion", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            else
            {
                ret = DBSpace.DBFunctionality.RunInsertionQuery("DMARegion", DBFields, this, false, Context);
            }

        }


        if (ret == true) 
            Response.Redirect("dma_list.aspx");
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("dma_list.aspx");
    }
}


