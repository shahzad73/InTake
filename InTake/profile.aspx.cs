using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Context.Session["UserID"].ToString();

        if (IsPostBack == false)
        {
            List<DBItem> DBFields = new List<DBItem>();
            GenerateTableFieldsObjects(DBFields, false);

            if (IsPostBack == false)
                DBSpace.DBFunctionality.GetAndSetTableRecord("users", "*", DBFields, this, " id=" + s, Context);
            
        }
    }


    protected void btn1_Click(object sender, EventArgs e)
    {

        if (txtPassword.Text != "")
        {
            if (txtRePass.Text != txtPassword.Text)
            {
                lblpasserror.Text = "Password do not match. Re-Enter your password";
                return;
            }
            else
            {
                Random rnd = new Random();
                string salt = rnd.Next(1, 99999).ToString(); // creates a number between 1 and 12
                string saltedpass = DBSpace.DBFunctionality.GenerateSaltedHash(txtPassword.Text, salt);

                DBSpace.DBFunctionality.RunNonQuery("update users set salt = '" + salt + "', password = '" + saltedpass + "' where id='" + Context.Session["UserID"].ToString() + "'", Context);
            }
        }



        List<DBItem> DBFields = new List<DBItem>();
        GenerateTableFieldsObjects(DBFields, true);

        string s = Context.Session["UserID"].ToString();

        txtPassword.Text = DBSpace.DBFunctionality.EncryptText(txtPassword.Text);

        bool res = true;
        res = DBSpace.DBFunctionality.RunUpdateQueryOnTableRecord("users", DBFields, this, " id=" + s, Context);

        //DBSpace.DBFunctionality.RunNonQuery("Update Users Set Password = '" + DBSpace.DBFunctionality.EncryptText(txtPassword.Text) + "' where UserID = " + s, Context);

        Response.Redirect("home.aspx");
    }



    private void GenerateTableFieldsObjects(List<DBItem> lst, bool isedit)
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


        if (isedit == false)
        {
            itm = new DBItem("lbltxtUserName", "label", "username", "string", false);
            lst.Add(itm);
        }


        //itm = new DBItem("txtPassword", "textbox", "password", "string", false);
        //itm.ErrorMessage = "Enter Password";
        //itm.IsMandatory = true;
        //lst.Add(itm);

    }

}