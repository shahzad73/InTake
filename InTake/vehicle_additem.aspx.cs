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
            lblText.Text = "Edit Vehicle";
            if (IsPostBack == false)
            {
                List<DBItem> DBFields = new List<DBItem>();
                GenerateTableFieldsObjects(DBFields);
                DBSpace.DBFunctionality.GetAndSetTableRecord("Vehicle", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            }
        }
        else
            lblText.Text = "Add New Vehicle";
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtVehicleMake", "textbox", "vehicle", "string", false);
        itm.IsMandatory = true;
        itm.ErrorMessage = "Enter Vehicle Make";
        lst.Add(itm);
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool ret = true;

        string s = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from Vehicle where vehicle ='" + lbltxtVehicleMake.Text + "'", Context);
        if (s == "1")
        {
            lbltxtVehicleMake.Text = "Vehicle already exists";
            ret = false;
        }
        else
        {

            if (Request.QueryString["op"] != null)
                ret = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("Vehicle", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            else
                ret = DBSpace.DBFunctionality.RunInsertionQuery("Vehicle", DBFields, this, false, Context);
        }


        if (ret == true) 
            Response.Redirect("vehicle_list.aspx");
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("vehicle_list.aspx");
    }

}