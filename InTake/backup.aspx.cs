using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class backup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlCommand command = new SqlCommand();
        command.CommandText = "sp_backup";
        command.CommandType = CommandType.StoredProcedure;

        // Add the input parameter and set its properties.
        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DBName";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = "intakedb";
        // Add the parameter to the Parameters collection.
        command.Parameters.Add(parameter);

        string s = DateTime.Now.ToShortDateString();
        s = "DBBackup_" + s + ".bak";
        s = s.Replace("/", "-");
        s = "E:\\HostingSpaces\\cdghost\\intake.ltinjurylaw.com\\wwwroot\\DBBackups\\" + s;


        // Add the input parameter and set its properties.
        parameter = new SqlParameter();
        parameter.ParameterName = "@Filename";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = s;
        // Add the parameter to the Parameters collection.
        command.Parameters.Add(parameter);



        // Add the input parameter and set its properties.
        parameter = new SqlParameter();
        parameter.ParameterName = "@DBDesc";
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = "Dbbackup from server";
        // Add the parameter to the Parameters collection.
        command.Parameters.Add(parameter);


        DBSpace.DBFunctionality.ReturnDataTableUsingStoredProcedure(command, Context);

        Response.Write("backup created");

    }
}