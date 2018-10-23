using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ReportDatesLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAndDisplyReportsDates();
    }



    void GetAndDisplyReportsDates()
    {
        DataTable dt = DBSpace.DBFunctionality.GetDataTable("Select top 50 * from ReportGeneratedDateLogs order by DateTaken DESC", Context);

        int z;
        string s = " <div style='font-family: \"Arial\", Times, serif; font-size:12px; width:200px;'> <table>  <tr> <td> <span style='font-weight:bold;'> From Date </span> </td>  <td> <span style='font-weight:bold;'> To Date </span> </td> </tr> ";
        for (z = 0; z <= dt.Rows.Count - 1; z++)
        {
            s = s + "<tr>  <td>" + Convert.ToDateTime(dt.Rows[z]["DateFrom"].ToString()).ToShortDateString() + "</td>   <td>" + Convert.ToDateTime(dt.Rows[z]["DateTo"].ToString()).ToShortDateString() + "</td>  </tr>";
        }
        s = s + "</table> </div>";

        lblDates.Text = s;
    }



    protected void ttn_Click(object sender, EventArgs e)
    {

        if (txtFromDate.Text == "")
        {
            lblmsg.Text = "Enter From Date";
            return;
        }

        if (txtToDate.Text == "")
        {
            lblmsg.Text = "Enter To Date";
            return;
        }

        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            DataTable dt;
            string LastStatusID = "";
            int TotalRecordsFound = 0;

            if(chkIncludeOnlySignedRecs.Checked == true)
                dt = DBSpace.DBFunctionality.GetDataTable("select intake.id, fname, lname, email, StatusID from statustracking, intake where intake.id = statustracking.intakeid and DateTaken between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "' and StatusID = 6", Context);
            else
                dt = DBSpace.DBFunctionality.GetDataTable("select intake.id, fname, lname, email, StatusID from statustracking, intake where intake.id = statustracking.intakeid and DateTaken between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "'", Context);

            int z, z2;
            string s2 = "";
            string s = " <div style='font-size:12px; width:95%'> <table>  <tr> <td> <span style='font-weight:bold;  font-family:Arial;'> First Name </span> </td>    <td> <span style='font-weight:bold;  font-family:Arial;'> Last Name </span> </td>    <td> <span style='font-weight:bold;'> Email </span> </td>        <td> <span style='font-weight:bold;  font-family:Arial;'> Signed </span> </td>     </tr> ";
            for (z = 0; z <= dt.Rows.Count - 1; z++)
            {
                
                        //this if check is special. if records are shown with Signed(6) state then there is no problem.
                        //if records are shown so that records in any state during a specific date time then there is problem that
                        //record will be displayed multiple time, because record state was in multiple states during that time. 
                        //so to display only unique records, this check is needed. 
                        if (dt.Rows[z]["id"].ToString() != LastStatusID)
                        {

                            bool isFound = false;
                            for (z2 = 0; z2 <= dt.Rows.Count - 1; z2++)
                            {
                                if (dt.Rows[z]["id"].ToString() == dt.Rows[z2]["id"].ToString() && dt.Rows[z2]["StatusID"].ToString() == "6")
                                {
                                    isFound = true;
                                    break;
                                }
                            }


                            if (dt.Rows[z]["email"].ToString().Contains("@"))
                            {
                                if (!((dt.Rows[z]["fname"].ToString() == "" && dt.Rows[z]["lname"].ToString() == "") || dt.Rows[z]["email"].ToString() == ""))
                                {
                                    s2 = s2 + dt.Rows[z]["fname"].ToString() + "," + dt.Rows[z]["lname"].ToString() + "," + dt.Rows[z]["email"].ToString();
                                    s = s + "<tr>  <td>" + dt.Rows[z]["fname"].ToString() + "</td>    <td> " + dt.Rows[z]["lname"].ToString() + "</td>   <td>" + dt.Rows[z]["email"].ToString() + "</td>    <td>";
                                    if (isFound == true)
                                    {
                                        s = s + "Yes";
                                        s2 = s2 + ",Yes";
                                    }
                                    s2 = s2 + "<br>";
                                    s = s + "</td></tr>";

                                    LastStatusID = dt.Rows[z]["id"].ToString();
                                    TotalRecordsFound = TotalRecordsFound + 1;
                                }
                            }

                }
            }
            s = s + "</table> </div>";


            lblData.Text = s;
            lblcsv.Text = s2;
            lblmsg.Text = "Total " + TotalRecordsFound.ToString() + " Records Found";
        }
    }



    protected void ttn_Click2(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            lblmsg.Text = "Enter From Date";
            return;
        }

        if (txtToDate.Text == "")
        {
            lblmsg.Text = "Enter To Date";
            return;
        }

        DBSpace.DBFunctionality.RunNonQuery("Insert into ReportGeneratedDateLogs(DateTaken, DateFrom, DateTo) values('" + DateTime.Now.Date +"', '" + txtFromDate.Text + "', '" + txtToDate.Text + "')", Context);

        GetAndDisplyReportsDates();
    }



}