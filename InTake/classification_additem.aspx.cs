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
            lblText.Text = "Edit Classification";
            if (IsPostBack == false)
            {
                List<DBItem> DBFields = new List<DBItem>();
                GenerateTableFieldsObjects(DBFields);
                DBSpace.DBFunctionality.GetAndSetTableRecord("Injury", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            }
        }
        else
            lblText.Text = "Add New Classification";
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtInjury", "textbox", "Injury", "string", false);
        itm.ErrorMessage = "Enter Injury Type";
        itm.IsMandatory = true;
        lst.Add(itm);
    }


    protected void btn1_Click(object sender, EventArgs e)
    {
        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool ret = true;


        string s = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from injury where injury ='" + txtInjury.Text + "'", Context);
        if (s == "1")
        {
            lbltxtInjury.Text = "Injury type already exists";
            ret = false;
        }
        else
        {
            if (Request.QueryString["op"] != null)
                ret = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("Injury", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            else
                ret = DBSpace.DBFunctionality.RunInsertionQuery("Injury", DBFields, this, false, Context);
        }


        if (ret == true)
            Response.Redirect("classification_list.aspx");
    }


    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("classification_list.aspx");
    }

}