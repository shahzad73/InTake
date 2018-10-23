using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class listingadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        if (IsPostBack == false)
        {
            DBSpace.DBFunctionality.InitializeFormDropDownFields(DBFields, this, Context);
            string sql = "";
            if (Context.Session["RoleID"].ToString() == "3")
                sql = "Select * from role where id in (1,2)";
            else if (Context.Session["RoleID"].ToString() == "4")
                sql = "Select * from role where id in (1,2,3,4)";

            DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
            drRole.DataSource = dt;
            drRole.DataTextField = "role";
            drRole.DataValueField = "id";
            drRole.DataBind();
        }


        if (Request.QueryString["op"] != null)
        {
            lblText.Text = "Edit User";

            if (IsPostBack == false)
            {
                DBSpace.DBFunctionality.GetAndSetTableRecord("users", "*", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            }
        }
        else
            lblText.Text = "Add New User";
    }

    protected void btn1_Click(object sender, EventArgs e)
    {

        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields);

        bool res = true;

        if (txtPassword.Text != "")
        {
            if (txtRePass.Text != txtPassword.Text)
            {
                lblpasserror.Text = "Password do not match. Re-Enter your password";
                return;
            }
        }



        Random rnd = new Random();
        string salt = rnd.Next(1, 99999).ToString(); // creates a number between 1 and 12
        string saltedpass = DBSpace.DBFunctionality.GenerateSaltedHash(txtPassword.Text, salt);


        if (Request.QueryString["op"] != null)
        {
            res = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("users", DBFields, this, " id=" + Request.QueryString["id"].ToString(), Context);
            DBSpace.DBFunctionality.RunNonQuery("update users set salt = '" + salt + "', password = '" + saltedpass + "' where id='" + Request.QueryString["id"].ToString() + "'", Context);
        }
        else
        {
            string ret = "";
            ret = DBSpace.DBFunctionality.RunInsertionQuery2("users", DBFields, this, Context);
            DBSpace.DBFunctionality.RunNonQuery("update users set salt = '" + salt + "', password = '" + saltedpass + "' where id='" + ret + "'", Context);
        }




        if(res == true)
            Response.Redirect("users_list.aspx");
    }


    private void GenerateTableFieldsObjects(List<DBItem> lst)
    {
        DBItem itm;
        itm = new DBItem("txtfName", "textbox", "firstname", "string", false);
        itm.ErrorMessage = "Enter First Name";
        itm.IsMandatory = true;
        lst.Add(itm);

        itm = new DBItem("txtlName", "textbox", "lastname", "string", false);
        itm.ErrorMessage = "Enter Last Name";
        lst.Add(itm);
        
        
        itm = new DBItem("txtPhone", "textbox", "phone", "string", false);
        lst.Add(itm);
        
        
        itm = new DBItem("txtEmail", "textbox", "email", "string", false);
        lst.Add(itm);
        
        
        itm = new DBItem("txtUserName", "textbox", "username", "string", false);
        itm.ErrorMessage = "Enter User Name";
        itm.IsMandatory = true;
        lst.Add(itm);


        itm = new DBItem("drStatus", "dropbox", "status", "int", false);
        lst.Add(itm);


        itm = new DBItem("drRole", "dropbox", "roleid", "int", false);
//        itm.TableBound = "role";
//        itm.TableBoundIDColumn = "id";
//        itm.TableBoundTextFieldColumn = "role";
        lst.Add(itm);
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("users_list.aspx");
    }
}