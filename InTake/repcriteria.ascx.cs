using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

public partial class repocriteria : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            initializeDMA("1");
            txtFromDate.Text = DateTime.Now.AddDays(-365).ToString("M/d/yyyy");
            txtToDate.Text = DateTime.Now.ToString("M/d/yyyy");


            int d = int.Parse(DateTime.Now.Year.ToString());
            d = d + 2;
            for (int zz = d; zz >= 2010; zz--)
            {
                yearlist1.Items.Add(new ListItem(zz.ToString(), zz.ToString()));
                yearlist2.Items.Add(new ListItem(zz.ToString(), zz.ToString()));
            }

            yearlist1.SelectedValue = DateTime.Now.Year.ToString();
            month1.SelectedValue = "1";
            yearlist2.SelectedValue = DateTime.Now.Year.ToString();
            month2.SelectedValue = "12";



        }
    }



    protected void indexchange(object sender, EventArgs e)
    {
        initializeDMA(ddViewBy.SelectedValue);
    }


    public string getFromDate()
    {
        return txtFromDate.Text;
    }
    public string getToDate()
    {
        return txtToDate.Text;
    }
    public string getFromDate2()
    {
        if (txtFromDate2.Text != "")
            return txtFromDate2.Text;
        else
            return "1/1/2000";
    }
    public string getToDate2()
    {
        if (txtToDate2.Text != "")
            return txtToDate2.Text;
        else
            return "1/1/2030";
    }
    public bool DateCompare()
    {
        return chkCompare.Checked;
    }

    public string getDateRange1()
    {
        return month1.SelectedValue + "/1/" + yearlist1.SelectedValue;
    }
    public string getDateRange2()
    {
        return month2.SelectedValue + "/1/" + yearlist2.SelectedValue;
    }
    public bool getIncludeSignedReports()
    {
        return chkIncludeSignedReports.Checked;
    }


    public string getViewBy()
    {
        return ddViewBy.SelectedValue;
    }
    public string getDMAorStateSelectedValue()
    {
        if (ddViewBy.SelectedValue == "1")
            return lstDMAState.SelectedValue;
        else
        {
            if(lstDMAState.SelectedValue == "-1")
                return lstDMAState.SelectedValue;
            else
                return lstDMAState.SelectedItem.Text;
        }

        return "-1";
    }





    private void initializeDMA(string no)
    {
        if (no == "1")
        {
            DataTable dt = DBSpace.DBFunctionality.GetDataTable("select * from DMARegion order by dmaname Asc", Context);
            DropDownList myControl = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "lstDMAState");
            myControl.DataSource = dt;
            myControl.DataTextField = "dmaname";
            myControl.DataValueField = "id";
            myControl.DataBind();

            myControl.Items.Insert(0, new ListItem("All", "-1"));

        }


        if (no == "2")
        {
            DataTable dt = DBSpace.DBFunctionality.GetDataTable("select * from State order by city Asc", Context);
            DropDownList myControl = (DropDownList)DBSpace.DBFunctionality.FindControlRecursive(this, "lstDMAState");
            myControl.DataSource = dt;
            myControl.DataTextField = "city";
            myControl.DataValueField = "id";
            myControl.DataBind();

            myControl.Items.Insert(0, new ListItem("All", "-1"));
        }

    }
}