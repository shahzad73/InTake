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
            lblText.Text = "Edit Bike";
            if (IsPostBack == false)
            {
                List<DBItem> DBFields = new List<DBItem>();
                GenerateTableFieldsObjects(DBFields);
                DBSpace.DBFunctionality.GetAndSetTableRecord("Bike", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
                hidOldValue.Value = txtBike.Text;
            }
        }
        else
            lblText.Text = "Add New Bike";
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtBike", "textbox", "bike", "string", false);
        itm.IsMandatory = true;
        itm.ErrorMessage = "Enter Bike";
        lst.Add(itm);
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool ret = true;

        string s = DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from Bike where Bike ='" + lbltxtBike.Text + "'", Context);
        if (s == "1")
        {
            lbltxtBike.Text = "Bike already exists";
            ret = false;
        }
        else
        {
            if (Request.QueryString["op"] != null)
            {
                ret = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("Bike", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
                DBSpace.DBFunctionality.RunNonQuery("Update Intake Set ClientVehicleBikeType = '" + txtBike.Text + "' Where ClientVehicleBikeType = '" + hidOldValue.Value + "'", Context);
            }
            else
                ret = DBSpace.DBFunctionality.RunInsertionQuery("Bike", DBFields, this, false, Context);
        }


        if (ret == true) 
            Response.Redirect("bike_list.aspx");
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("bike_list.aspx");
    }

}