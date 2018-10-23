using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
            //Response.Redirect(redirectUrl);
        }
    }



    protected void txtbutton_Click(object sender, EventArgs e)
    {
        if (checkForSQLInjection(txtname.Text) == true)
            return;

            DataRow dr = DBSpace.DBFunctionality.GetSingleRecordFromATable("Select * from users where username = '" + txtname.Text + "'", Context);




        if (dr != null)
        {
            if (dr["password"].ToString() == DBSpace.DBFunctionality.GenerateSaltedHash(txtpass.Text, dr["salt"].ToString()))
            {
                if (dr["status"].ToString() == "1")
                {
                    Context.Session["UserID"] = dr["id"].ToString();
                    Context.Session["RoleID"] = dr["roleid"].ToString();
                    Context.Session.Timeout = 120;
                    Response.Redirect("home.aspx");
                }
                else
                    lblno.Text = "Admin disable your account";
            }
            else
                lblno.Text = "Username/Password not valid";
        }
        else
            lblno.Text = "Username/Password not valid";




    }




    public static Boolean checkForSQLInjection(string userInput)
    {

        bool isSQLInjection = false;
        string[] sqlCheckList = { "--",
                                       ";--",
                                       ";",
                                       "/*",
                                       "*/",
                                        "@@",
                                        "@",
                                        "char",
                                       "nchar",
                                       "varchar",
                                       "nvarchar",
                                       "alter",
                                       "begin",
                                       "cast",
                                       "create",
                                       "cursor",
                                       "declare",
                                       "delete",
                                       "drop",
                                       "end",
                                       "exec",
                                       "execute",
                                       "fetch",
                                            "insert",
                                          "kill",
                                             "select",
                                           "sys",
                                            "sysobjects",
                                            "syscolumns",
                                           "table",
                                           "update"
                                };


        string CheckString = userInput.Replace("'", "''");
        for (int i = 0; i <= sqlCheckList.Length - 1; i++)
        {
            if ((CheckString.IndexOf(sqlCheckList[i],StringComparison.OrdinalIgnoreCase) >= 0))
            {    
                isSQLInjection = true;
            }
        }
        return isSQLInjection;
    }

}