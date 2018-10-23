using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for DBFunctionality
/// </summary>
/// 
namespace DBSpace
{

    public class DBFunctionality
    {

        //string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionMgr"];


        public DBFunctionality()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        

        public static SqlConnection GetDBConnection()
        {
                SqlConnection conn;
                string connStr = ConfigurationManager.ConnectionStrings["MyDbConn1"].ToString();
                conn = new SqlConnection(connStr);
                conn.Open();
                return conn;
        }



        public static DataSet GetDataSet(string s, HttpContext cont)
        {
            SqlConnection conn;
            try
            {
                DataSet DBSet = new DataSet();
                conn = GetDBConnection();
                SqlDataAdapter adp1 = new SqlDataAdapter(s, conn);
                adp1.Fill(DBSet);
                adp1 = null;
                conn.Close();
                return DBSet;
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();

                return null;
            }
        }



        public static DataTable GetDataTable(string s, HttpContext cont)
        {
            SqlConnection conn;
            try
            {
                DataTable DBTable = new DataTable();
                conn = GetDBConnection();
                SqlDataAdapter adp1 = new SqlDataAdapter(s, conn);
                adp1.Fill(DBTable);
                adp1 = null;
                conn.Close();
                return DBTable;
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();

                return null;
            }
        }







        public static void RunNonQuery(string s, HttpContext cont)
        {
            SqlConnection conn;

            try
            {
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = s;
                conn = GetDBConnection();
                sqlCmd.Connection = conn;
                sqlCmd.ExecuteNonQuery();
                sqlCmd = null;
                conn.Close();
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();
            }
        }


        public static string RunNumberScalarQuery(string s, HttpContext cont)
        {
            SqlConnection conn;
            try
            {
                string val;
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = s;
                conn = GetDBConnection();
                sqlCmd.Connection = conn;
                val = sqlCmd.ExecuteScalar().ToString();
                sqlCmd = null;
                conn.Close();
                return val;
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();

                return null;
            }

        }



        public static string RunInsertQueryWithIdentityRetuen(string s, HttpContext cont)
        {
            //Use Select Scopt identity at the end of the sql statement to return the last identity column value
            //Insert into  Catalog(CatalogName) values('AnotherTest') SELECT SCOPE_IDENTITY()
            SqlConnection conn;

            s = s + " " + "SELECT SCOPE_IDENTITY()";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = s;
                conn = GetDBConnection();
                sqlCmd.Connection = conn;
                string ss = sqlCmd.ExecuteScalar().ToString();
                conn.Close();
                return ss;
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();

                return null;
            }
        }




        public static DataRow GetSingleRecordFromATable(string s, HttpContext cont)
        {
            SqlConnection conn;

            try
            {
                DataTable DBTable = new DataTable();
                conn = GetDBConnection();
                SqlDataAdapter adp1 = new SqlDataAdapter(s, conn);
                DataRow dr;
                adp1.Fill(DBTable);
                adp1 = null;
                if (DBTable.Rows.Count == 0)
                    dr = null;
                else
                    dr = DBTable.Rows[0];

                conn.Close();
                return dr;
            }
            catch (Exception e)
            {
                cont.Response.Redirect("~/error.aspx");
                cont.Response.Write(e.ToString());
                cont.Response.Write("<br>");
                cont.Response.Write("<br>");
                cont.Response.Write(s);

                cont.Response.End();

                return null;
            }

        }



        public static DataTable ReturnDataTableUsingStoredProcedure(SqlCommand cmd, HttpContext cont)
        {
            DataTable DBTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();


            cmd.Connection = GetDBConnection();

            da.SelectCommand = cmd;
            da.Fill(DBTable);
            da = null;
            return DBTable;
        }




        public static void ExecuteStoredProcedure(SqlCommand cmd, HttpContext cont)
        {
            DataTable DBTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            cmd.Connection = GetDBConnection();
            cmd.ExecuteNonQuery();
        }



        public static bool RunInsertionQuery(string tablename, List<DBItem> lst, Control rootControl, bool RunNonQueryOrIdentityReturn, HttpContext cont)
        {
            string fld, vals;

            fld = "insert into " + tablename + "(";
            vals = " values(";

            TextBox tx;
            ListBox ls;
            DropDownList dr;
            bool chk;
            bool res = true;

            IEnumerator<DBItem> objs = lst.GetEnumerator();
            while (objs.MoveNext())
            {
                DBItem itm = (DBItem)objs.Current;

                if (itm.FieldType == "textbox")
                {
                    tx = (TextBox)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";

                    if (tx.Text == "" && itm.IsMandatory == true)
                    {
                        SetErrorMessageOfInputControl(rootControl, itm);
                        res = false;
                    }
                    else
                    {
                        if (itm.DBFieldType == "string")
                        {
                            vals = vals + "'" + tx.Text.Replace("'", "''") + "',";
                        }

                        if (itm.DBFieldType == "int")
                        {
                            int z;

                            chk = int.TryParse(tx.Text, out z);
                            if (chk == false)
                            {
                                SetErrorMessageOfInputControl(rootControl, itm);
                                res = false;
                            }
                            else
                                vals = vals + tx.Text + ",";
                        }
                    }

                }
                else if (itm.FieldType == "listbox")
                {
                    ls = (ListBox)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";
                    if (itm.DBFieldType == "nvarchar")
                        vals = vals + "'" + ls.SelectedValue.ToString() + "',";
                    if (itm.DBFieldType == "int")
                        vals = vals + ls.SelectedValue.ToString() + ",";
                }
                else if (itm.FieldType == "dropbox")
                {
                    dr = (DropDownList)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";
                    if (itm.DBFieldType == "string")
                        vals = vals + "'" + dr.SelectedValue.ToString() + "',";
                    if (itm.DBFieldType == "int")
                        vals = vals + dr.SelectedValue.ToString() + ",";
                }
            }

            if (res == false)
                return false;

            fld = fld.Substring(0, fld.Length - 1);
            vals = vals.Substring(0, vals.Length - 1);

            string ss = fld + ")" + vals + ")";




            string ret = "";
            if (RunNonQueryOrIdentityReturn == true)
                DBSpace.DBFunctionality.RunNonQuery(ss, cont);
            else
                ret = DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen(ss, cont);

            return true;
        }








        public static string RunInsertionQuery2(string tablename, List<DBItem> lst, Control rootControl, HttpContext cont)
        {
            //this function is exactly the same as RunInsertionQuery   except it returns the id of newly generated reocrd

            string fld, vals;

            fld = "insert into " + tablename + "(";
            vals = " values(";

            TextBox tx;
            ListBox ls;
            DropDownList dr;
            bool chk;
            bool res = true;

            IEnumerator<DBItem> objs = lst.GetEnumerator();
            while (objs.MoveNext())
            {
                DBItem itm = (DBItem)objs.Current;

                if (itm.FieldType == "textbox")
                {
                    tx = (TextBox)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";

                    if (tx.Text == "" && itm.IsMandatory == true)
                    {
                        SetErrorMessageOfInputControl(rootControl, itm);
                        res = false;
                    }
                    else
                    {
                        if (itm.DBFieldType == "string")
                        {
                            vals = vals + "'" + tx.Text.Replace("'", "''") + "',";
                        }

                        if (itm.DBFieldType == "int")
                        {
                            int z;

                            chk = int.TryParse(tx.Text, out z);
                            if (chk == false)
                            {
                                SetErrorMessageOfInputControl(rootControl, itm);
                                res = false;
                            }
                            else
                                vals = vals + tx.Text + ",";
                        }
                    }

                }
                else if (itm.FieldType == "listbox")
                {
                    ls = (ListBox)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";
                    if (itm.DBFieldType == "nvarchar")
                        vals = vals + "'" + ls.SelectedValue.ToString() + "',";
                    if (itm.DBFieldType == "int")
                        vals = vals + ls.SelectedValue.ToString() + ",";
                }
                else if (itm.FieldType == "dropbox")
                {
                    dr = (DropDownList)FindControlRecursive(rootControl, itm.FieldName);
                    fld = fld + itm.DBField + ",";
                    if (itm.DBFieldType == "string")
                        vals = vals + "'" + dr.SelectedValue.ToString() + "',";
                    if (itm.DBFieldType == "int")
                        vals = vals + dr.SelectedValue.ToString() + ",";
                }
            }

            if (res == false)
                return "false";

            fld = fld.Substring(0, fld.Length - 1);
            vals = vals.Substring(0, vals.Length - 1);

            string ss = fld + ")" + vals + ")";


            string ret = "";

            ret = DBSpace.DBFunctionality.RunInsertQueryWithIdentityRetuen(ss, cont);

            return ret;
        }










        public static void SetErrorMessageOfInputControl(Control rootControl, DBItem itm)
        {
            Label lbl;
            lbl = (Label)FindControlRecursive(rootControl, "lbl" + itm.FieldName);
            lbl.Text = itm.ErrorMessage;
        }



        public static DataRow  GetAndSetTableRecord(string tablename, string fieldlist, List<DBItem> lst, Control rootControl, string GetCriteria, HttpContext cont)
        {
            IEnumerator<DBItem> objs = lst.GetEnumerator();

            string cri = "Select " + fieldlist + " from " + tablename + " Where " + GetCriteria;

            DataRow dr = DBSpace.DBFunctionality.GetSingleRecordFromATable(cri, cont);
            TextBox tx;
            ListBox ls;
            Label lbl;
            DropDownList dd;

        

            if (dr == null)
            {
                cont.Response.Redirect("home.aspx");
            }


            objs = lst.GetEnumerator();
            while (objs.MoveNext())
            {
                DBItem itm = (DBItem)objs.Current;

                if (itm.FieldType == "textbox")
                {
                    try
                    {
                        tx = (TextBox)FindControlRecursive(rootControl, itm.FieldName);
                        tx.Text = dr[itm.DBField].ToString();
                    }
                    catch(Exception ex)
                    {
                        cont.Response.Write(itm.FieldName);
                        cont.Response.End();
                    }

                }
                if (itm.FieldType == "listbox")
                {
                    ls = (ListBox)FindControlRecursive(rootControl, itm.FieldName);
                    ls.SelectedValue = dr[itm.DBField].ToString();                        
                }
                if (itm.FieldType == "dropbox")
                {
                    dd = (DropDownList)FindControlRecursive(rootControl, itm.FieldName);
                    dd.SelectedValue = dr[itm.DBField].ToString();
                }
                if (itm.FieldType == "label")
                {
                    lbl = (Label)FindControlRecursive(rootControl, itm.FieldName);
                    lbl.Text = dr[itm.DBField].ToString();
                }

            }


            return dr;
        }




        public static void InitializeFormDropDownFields(List<DBItem> lst, Control rootControl, HttpContext cont)
        {
            DropDownList dd;

            IEnumerator<DBItem> objs = lst.GetEnumerator();
            while (objs.MoveNext())
            {
                DBItem itm = (DBItem)objs.Current;

                if (itm.TableBound != "")
                {
                    if (itm.FieldType == "dropbox")
                    {
                        dd = (DropDownList)FindControlRecursive(rootControl, itm.FieldName);

                        DataTable dt = DBSpace.DBFunctionality.GetDataTable("select * from " + itm.TableBound + " order by " + itm.TableBoundTextFieldColumn + " Asc", cont);
                        dd.DataSource = dt;
                        dd.DataTextField = itm.TableBoundTextFieldColumn;
                        dd.DataValueField = itm.TableBoundIDColumn;
                        dd.DataBind();
                    }
                }
            }

        }




        public static bool RunUpdateQueryOnTableRecord(string tablename, List<DBItem> lst, Control rootControl, string GetCriteria, HttpContext cont)
        {
            //"upate temp set name='aaa', address='aaa', phone='aaa' where id=12"
            TextBox tx;
            ListBox ls;
            DropDownList dd;
            string st = "Update " + tablename + " set ";


            IEnumerator<DBItem> objs = lst.GetEnumerator();
            while (objs.MoveNext())
            {
                DBItem itm = (DBItem)objs.Current;
                bool chk;


                if (itm.IsPrimaryKey == false)
                {
                    if (itm.FieldType == "textbox")
                    {
                        tx = (TextBox)FindControlRecursive(rootControl, itm.FieldName);

                        if (tx.Text == "" && itm.IsMandatory == true)
                        {
                            SetErrorMessageOfInputControl(rootControl, itm);
                            return false;
                        }

                        if (itm.DBFieldType == "string")
                        {
                            st = st + itm.DBField + "='" + tx.Text.Replace("'", "''") + "',";
                        }

                        if (itm.DBFieldType == "int")
                        {
                            int z;

                            chk = int.TryParse(tx.Text, out z);
                            if (chk == false)
                            {
                                SetErrorMessageOfInputControl(rootControl, itm);
                                return false;
                            }

                            st = st + itm.DBField + "=" + tx.Text + ",";
                        }


                    }
                    else if (itm.FieldType == "listbox")
                    {
                        ls = (ListBox)FindControlRecursive(rootControl, itm.FieldName);
                        if (itm.DBFieldType == "nvarchar")
                            st = st + itm.DBField + "='" + ls.SelectedValue + "',";
                        if (itm.DBFieldType == "int")
                            st = st + itm.DBField + "=" + ls.SelectedValue + ",";
                    }
                    else if (itm.FieldType == "dropbox")
                    {
                        dd = (DropDownList)FindControlRecursive(rootControl, itm.FieldName);
                        if (itm.DBFieldType == "string")
                            st = st + itm.DBField + "='" + dd.SelectedValue + "',";
                        if (itm.DBFieldType == "int")
                            st = st + itm.DBField + "=" + dd.SelectedValue + ",";
                    }
                }
            }

            st = st.Substring(0, st.Length - 1);
            st = st + " Where " + GetCriteria;

            DBSpace.DBFunctionality.RunNonQuery(st, cont);

            return true;
        }



        public static int InitializeDatabasePagging(int PageNo, int Records, string OverID, string FieldList, string TableList, string WhereClause, Repeater rt, string OrderBy, string TopRecs, HttpContext cont)
        {
            //WITH PagRecords AS
            //(
            //    Select ROW_NUMBER() OVER(ORDER BY id ASC) AS RowNo, t.* from test t
            //) 
            //SELECT *
            //FROM PagRecords 
            //WHERE RowNo BETWEEN 2 AND 4;

            int start, end;

            PageNo = PageNo - 1;
            if (PageNo == 0)
            {
                start = 1;
                end = Records;
            }
            else
            {
                start = (PageNo * Records) + 1;
                end = start + Records - 1;
            }

            //string SQL = "WITH PagRecords AS (Select ROW_NUMBER() OVER(ORDER BY " + OverID + ") As RowNo, " +  FieldList + " from " + TableList + " " + WhereClause + ") SELECT " + TopRecs + " * FROM PagRecords WHERE RowNo BETWEEN " + start.ToString() + " AND " + end.ToString() + " " + OrderBy;
            string SQL = "WITH PagRecords AS (Select ROW_NUMBER() OVER(" + OrderBy + ") As RowNo, " + FieldList + " from " + TableList + " " + WhereClause + ") SELECT " + TopRecs + " * FROM PagRecords WHERE RowNo BETWEEN " + start.ToString() + " AND " + end.ToString();
            DataTable dt = DBSpace.DBFunctionality.GetDataTable(SQL, cont);

            rt.DataSource = dt;
            rt.DataBind();

            return int.Parse(DBSpace.DBFunctionality.RunNumberScalarQuery("select count(*) from " + TableList + " " + WhereClause, cont));
        }



        public static int GetTotalRecordsOfATable(string tablename, string WhereClase, HttpContext cont)
        {
            return int.Parse( DBSpace.DBFunctionality.RunNumberScalarQuery("Select Count(*) from " + tablename + WhereClase , cont) );
        }




        public static void InitializePagingNumbers(Literal lit, int Records, int RecordsPerPage, string ServerASPXPage, int CurrentPageNo, string CriteriaFieldsParameters)
        {
            lit.Text = "";


            if (Records <= RecordsPerPage)
                return;    //no need to show paging


            int RecordPages = Records / RecordsPerPage;

            if ((Records % RecordsPerPage) != 0)
                RecordPages = RecordPages + 1;


            string s = "<ul class='pagination'>";

            if (RecordPages == 0)
                RecordPages = 1;


            int startpag = 0;
            int endpag = 0;

            string nextpagelink = "";
            string previouspagelink = "";

            if(CurrentPageNo < 6)
            {
                startpag = 0;
                endpag = 6;
                previouspagelink = "";
                nextpagelink = "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (CurrentPageNo + 1).ToString() + "&" + CriteriaFieldsParameters + "'>Next ></a></li>";
            }
            if (CurrentPageNo >= 6)
            {
                startpag = CurrentPageNo - 2;
                endpag = CurrentPageNo + 2;
                nextpagelink = "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (CurrentPageNo + 1).ToString() + "&" + CriteriaFieldsParameters + "'>Next ></a></li>";
                previouspagelink = "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (CurrentPageNo - 1).ToString() + "&" + CriteriaFieldsParameters + "'>< Previous</a></li>";
            }
            if (CurrentPageNo + 2 > RecordPages)
            {
                startpag = CurrentPageNo - 2;
                endpag = CurrentPageNo + 2;
                nextpagelink = "";
                previouspagelink = "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (CurrentPageNo - 1).ToString() + "&" + CriteriaFieldsParameters + "'>< Previous</a></li>";
            }
            previouspagelink = "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=1&" + CriteriaFieldsParameters + "'><< First</a></li>" + previouspagelink;
            nextpagelink = nextpagelink + "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + RecordPages + "&" + CriteriaFieldsParameters + "'>Last >></a></li>";


            s = s + previouspagelink;
            for (int a = startpag; a <= endpag; a++)
            {
                if (a > RecordPages)
                    break;

                if (a != 0)
                {
                    if (a == CurrentPageNo)
                        s = s + "<li class='num current'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (a).ToString() + "&" + CriteriaFieldsParameters + "'>" + (a).ToString() + "</a></li>";
                    else
                        s = s + "<li class='num'><a href='" + ServerASPXPage + "?listingop=paging&listingpag=" + (a).ToString() + "&" + CriteriaFieldsParameters + "'>" + (a).ToString() + "</a></li>";
                }
            }
            s = s + nextpagelink;
            s = s + "</ul>";

            lit.Text = s;
        }




        public static Control FindControlRecursive(Control rootControl, string controlID)
        {


            if (rootControl.ID == controlID)
                return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null)
                    return controlToReturn;
            }

            return null;

        }





        public static string GetReport1(string month, int mon, int year, HttpContext cont)
        {
            string ss = "";
            DataTable dt = DBSpace.DBFunctionality.GetDataTable("Select * from users", cont);

            for (int zzz = 0; zzz < dt.Rows.Count; zzz++)
                ss = ss + DBSpace.DBFunctionality.GetReport1Data(month, mon, year, int.Parse(dt.Rows[zzz]["id"].ToString()), dt.Rows[zzz]["firstname"].ToString() + " " + dt.Rows[zzz]["lastname"].ToString(), cont);

            ss = ss + DBSpace.DBFunctionality.GetReport1Data2(mon, year, month, cont);

            return ss;
        }






        public static string GetReport1Data(string mon, int mm, int year,  int usr, string usrnm, HttpContext cont)
        {
            string htm = "";

            int premonth, preyear;

            if (mm == 1)
            {
                premonth = 12;
                preyear = -1;
            }
            else
            {
                premonth = mm - 1;
                preyear = 0;
            }

            string s = "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + premonth + " and year(datetaken) = " + (year + preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + premonth + " and year(datetaken) = " + (year + preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + premonth + " and year(datetaken) = " + (year + preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt, r.id as dmaid from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where takenbyuserid = " + usr + " and month(datetaken) = " + premonth + " and year(datetaken) = " + (year + preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";


            DataSet ss = DBSpace.DBFunctionality.GetDataSet(s, cont);

            year = year - 3;

            htm = htm + "<div class='table'>";
            htm = htm + "<h1 class='heading'> " + usrnm + " : " + mon + " </h1>";

            htm = htm + "<table>";
            htm = htm + "<thead><tr>";
            htm = htm + "<td><b>DMA</b></td>";
            htm = htm + "<td>" + mon + " " + year + " (YTD)</td>";
            htm = htm + "<td>" + mon + " " + (year + 1) + " (YTD)</td>";
            htm = htm + "<td>" + mon + " " + (year + 2) + " (YTD)</td>";
            htm = htm + "<td>" + mon + " " + (year + 3) + " (YTD)</td>";
            htm = htm + "</tr></thead>";
            htm = htm + "<tbody>";


            for (int zzz = 0; zzz < ss.Tables[0].Rows.Count; zzz++)
            {
                htm = htm + "<tr>";

                htm = htm + "<td>" + ss.Tables[0].Rows[zzz]["dmaname"].ToString() + "</td>";

                int year2 = year;

                for (int t1 = 0; t1 <= 6; t1 = t1 + 2)
                {
                    if (ss.Tables[t1].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[t1+1].Rows[zzz]["cnt"].ToString() != "")
                        htm = htm + "<td><span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year2 + "," + ss.Tables[t1].Rows[zzz]["dmaid"].ToString() + ", 1)'>" + ss.Tables[t1].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year2 + "," + ss.Tables[t1].Rows[zzz]["dmaid"].ToString() + ", 3)'>" + (int.Parse(ss.Tables[t1+1].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[t1].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                    else if (ss.Tables[t1].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[t1+1].Rows[zzz]["cnt"].ToString() == "")
                        htm = htm + "<td><span style='color:blue;; cursor:pointer' onclick='ShowUserCases(" + usr + "," + mm + "," + year2 + "," + ss.Tables[t1].Rows[zzz]["dmaid"].ToString() + ", 1)'>" + ss.Tables[t1].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year2 + "," + ss.Tables[t1].Rows[zzz]["dmaid"].ToString() + ", 1)'>" + ss.Tables[t1].Rows[zzz]["cnt"].ToString() + "</span>)</td>";
                    else if (ss.Tables[t1].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[t1+1].Rows[zzz]["cnt"].ToString() != "")
                        htm = htm + "<td>0 (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year2 + "," + ss.Tables[t1].Rows[zzz]["dmaid"].ToString() + ", 2)'>" + (int.Parse(ss.Tables[t1+1].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                    else if (ss.Tables[t1].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[t1+1].Rows[zzz]["cnt"].ToString() == "")
                        htm = htm + "<td></td>";

                    year2++;
                }


                //if (ss.Tables[0].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td><span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ", 1)'>" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ", 3)'>" + (int.Parse(ss.Tables[1].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[0].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //else if (ss.Tables[0].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td><span style='color:blue;; cursor:pointer' onclick='ShowUserCases(" + usr + "," + mm + "," + year + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ", 1)'>" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ", 1)'>" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + "</span>)</td>";
                //else if (ss.Tables[0].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td>0 (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + "," + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ", 2)'>" + (int.Parse(ss.Tables[1].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //if (ss.Tables[0].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td></td>";



                //if (ss.Tables[2].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td><span class='textUnderLine' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 1) + "," + ss.Tables[2].Rows[zzz]["cnt"].ToString() + ", 1)'>" + ss.Tables[2].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 1) + "," + ss.Tables[2].Rows[zzz]["cnt"].ToString() + ", 3)'>" + (int.Parse(ss.Tables[3].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[2].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //else if (ss.Tables[2].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td><span class='textUnderLine' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 1) + ", 1)'>" + ss.Tables[2].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 1) + ", 1)'>" + ss.Tables[2].Rows[zzz]["cnt"].ToString() + "</span>)</td>";
                //else if (ss.Tables[2].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td>0 (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + ", 2)'>" + (int.Parse(ss.Tables[3].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //if (ss.Tables[2].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td></td>";



                //if (ss.Tables[4].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td><span class='textUnderLine'  onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 2) + ", 1)'>" + ss.Tables[4].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 2) + ", 3)'>" + (int.Parse(ss.Tables[5].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[4].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //else if (ss.Tables[4].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td><span class='textUnderLine'  onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 2) + ", 1)'>" + ss.Tables[4].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 2) + ", 1)'>" + ss.Tables[4].Rows[zzz]["cnt"].ToString() + "</span>)</td>";
                //else if (ss.Tables[4].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td>0 (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + ", 2)'>" + (int.Parse(ss.Tables[5].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //if (ss.Tables[4].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td></td>";



                //if (ss.Tables[6].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td><span class='textUnderLine'  onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 3) + ", 1)'>" + ss.Tables[6].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 3) + ", 3)'>" + (int.Parse(ss.Tables[7].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[6].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //else if (ss.Tables[6].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td><span class='textUnderLine'  onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 3) + ", 1)'>" + ss.Tables[6].Rows[zzz]["cnt"].ToString() + "</span> (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + (year + 3) + ", 1)'>" + ss.Tables[6].Rows[zzz]["cnt"].ToString() + "</span>)</td>";
                //else if (ss.Tables[6].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() != "")
                //    htm = htm + "<td>0 (<span style='color:blue; cursor:pointer;' onclick='ShowUserCases(" + usr + "," + mm + "," + year + ", 2)'>" + (int.Parse(ss.Tables[7].Rows[zzz]["cnt"].ToString())) + "</span>)</td>";
                //if (ss.Tables[6].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() == "")
                //    htm = htm + "<td></td>";


                htm = htm + "</tr>";
            }


            htm = htm + "</tbody>";
            htm = htm + "</table>";
            htm = htm + "</div>";


            htm = htm + "<br/><br/><br/>";

            return htm;
        }








        public static string GetReportNotes(HttpContext cont, string df, string dt)
        {
            string ss = "";
            DataTable dt2 = DBSpace.DBFunctionality.GetDataTable("Select * from ReferralSources", cont);

            for (int zzz = 0; zzz < dt2.Rows.Count; zzz++)
                ss = ss + DBSpace.DBFunctionality.GetReportNotes2(dt2.Rows[zzz]["id"].ToString(), dt2.Rows[zzz]["ReferralSource"].ToString(), cont, df, dt);

            return ss;
        }
        public static string GetReportNotes2(string did, string dma, HttpContext cont, string df, string dt)
        {
            string s = "";

            if (df != "" & dt != "")
                s = "Select * from intake, DMARegion where ReferralSourceID = " + did + " and DateTaken between '" + df + "' and '" + dt + "'";
            else if (df != "" && dt == "")
                s = "Select * from intake, DMARegion where ReferralSourceID = " + did + " and DateTaken >= '" + df + "'";
            else if (df == "" && dt != "")
                s = "Select * from intake, DMARegion where ReferralSourceID = " + did + " and DateTaken <= '" + dt + "'";
            else
                s = "Select * from intake, DMARegion where ReferralSourceID = " + did;

            s = s + " and intake.ReportRegionDMAID = DMARegion.id order by DateTaken DESC";

            string htm = "";

            DataTable dt2 = DBSpace.DBFunctionality.GetDataTable(s, cont);

            if (dt2.Rows.Count > 0)
            {
                htm = htm + "<div class='table'>";
                htm = htm + "<h1 class='heading'> " + dma + " </h1>";

                htm = htm + "<table>";
                htm = htm + "<thead><tr>";
                htm = htm + "<td>DMA</td>";
                htm = htm + "<td>Name</td>";
                htm = htm + "<td>Date Taken</td>";
                htm = htm + "<td>Comments</td>";
                htm = htm + "<td></td>";
                htm = htm + "</tr></thead>";
                htm = htm + "<tbody>";


                for (int zzz = 0; zzz < dt2.Rows.Count; zzz++)
                {
                    htm = htm + "<tr>";
                    htm = htm + "<td style='width:15%'>" + dt2.Rows[zzz]["dmaname"].ToString() + "</td>";
                    htm = htm + "<td style='width:20%'>" + dt2.Rows[zzz]["fname"].ToString() + " " + dt2.Rows[zzz]["lname"].ToString() + "</td>";
                    htm = htm + "<td style='width:15%'>" + Convert.ToDateTime(dt2.Rows[zzz]["DateTaken"].ToString()).ToShortDateString().ToString() + "</td>";
                    htm = htm + "<td style='width:47%'>" + dt2.Rows[zzz]["ReffererSourcesNotes"].ToString() + "</td>";
                    htm = htm + "<td style='width:3%'> <a href='intake.aspx?id=" + dt2.Rows[zzz]["id"].ToString() + "'> <img src='images/file_edit.png' width='30px'> </a></td>";
                    htm = htm + "</tr>";
                }


                htm = htm + "</tbody>";
                htm = htm + "</table>";
                htm = htm + "</div>";

                htm = htm + "<br/><br/><br/>";
            }

            return htm;
        }









        public static string GetReport1Data2(int mm, int year, string monthtext, HttpContext cont)
        {
            string htm = "";

            int premonth, preyear;

            if (mm == 1)
            {
                premonth = 12;
                preyear = -1;
            }
            else
            {
                premonth = mm - 1;
                preyear = 0;
            }

            string s = "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + premonth + " and year(datetaken) = " + (year - preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where   month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where   month(datetaken) = " + premonth + " and year(datetaken) = " + (year - preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + premonth + " and year(datetaken) = " + (year - preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            year++;
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + mm + " and year(datetaken) = " + year + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";
            s = s + "select id, dmaname, cnt from dmaregion r left join (select count(*) as cnt, ReportRegionDMAID from intake where  month(datetaken) = " + premonth + " and year(datetaken) = " + (year - preyear) + " group by ReportRegionDMAID ) t on t.ReportRegionDMAID = r.id order by dmaname;";

            DataSet ss = DBSpace.DBFunctionality.GetDataSet(s, cont);

            year = year - 3;

            htm = htm + "<div class='table'>";
            htm = htm + "<h1 class='heading'> Cumulative </h1>";

            htm = htm + "<table>";
            htm = htm + "<thead><tr>";
            htm = htm + "<td><b>DMA</b></td>";
            htm = htm + "<td>" + monthtext + " " + year + " (YTD)</td>";
            htm = htm + "<td>" + monthtext + " " + (year + 1) + " (YTD)</td>";
            htm = htm + "<td>" + monthtext + " " + (year + 2) + " (YTD)</td>";
            htm = htm + "<td>" + monthtext + " " + (year + 3) + " (YTD)</td>";
            htm = htm + "</tr></thead>";
            htm = htm + "<tbody>";



            for (int zzz = 0; zzz < ss.Tables[0].Rows.Count; zzz++)
            {
                htm = htm + "<tr>";

                htm = htm + "<td>" + ss.Tables[0].Rows[zzz]["dmaname"].ToString() + "</td>";

                if (ss.Tables[0].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + " (" + (int.Parse(ss.Tables[1].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[0].Rows[zzz]["cnt"].ToString())) + ")</td>";
                else if (ss.Tables[0].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td>" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + " (" + ss.Tables[0].Rows[zzz]["cnt"].ToString() + ")</td>";
                else if (ss.Tables[0].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>0 (" + (int.Parse(ss.Tables[1].Rows[zzz]["cnt"].ToString())) + ")</td>";
                if (ss.Tables[0].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[1].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td></td>";


                if (ss.Tables[2].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>" + ss.Tables[2].Rows[zzz]["cnt"].ToString() + " (" + (int.Parse(ss.Tables[3].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[2].Rows[zzz]["cnt"].ToString())) + ")</td>";
                else if (ss.Tables[2].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td>" + ss.Tables[2].Rows[zzz]["cnt"].ToString() + " (0)</td>";
                else if (ss.Tables[2].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>0 (" + (int.Parse(ss.Tables[3].Rows[zzz]["cnt"].ToString())) + ")</td>";
                if (ss.Tables[2].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[3].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td></td>";




                if (ss.Tables[4].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>" + ss.Tables[4].Rows[zzz]["cnt"].ToString() + " (" + (int.Parse(ss.Tables[5].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[4].Rows[zzz]["cnt"].ToString())) + ")</td>";
                else if (ss.Tables[4].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td>" + ss.Tables[4].Rows[zzz]["cnt"].ToString() + " (0)</td>";
                else if (ss.Tables[4].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>0 (" + (int.Parse(ss.Tables[5].Rows[zzz]["cnt"].ToString())) + ")</td>";
                if (ss.Tables[4].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[5].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td></td>";



                if (ss.Tables[6].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>" + ss.Tables[6].Rows[zzz]["cnt"].ToString() + " (" + (int.Parse(ss.Tables[7].Rows[zzz]["cnt"].ToString()) + int.Parse(ss.Tables[6].Rows[zzz]["cnt"].ToString())) + ")</td>";
                else if (ss.Tables[6].Rows[zzz]["cnt"].ToString() != "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td>" + ss.Tables[6].Rows[zzz]["cnt"].ToString() + " - (0)</td>";
                else if (ss.Tables[6].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() != "")
                    htm = htm + "<td>0 (" + (int.Parse(ss.Tables[7].Rows[zzz]["cnt"].ToString())) + ")</td>";
                if (ss.Tables[6].Rows[zzz]["cnt"].ToString() == "" && ss.Tables[7].Rows[zzz]["cnt"].ToString() == "")
                    htm = htm + "<td></td>";


                htm = htm + "</tr>";
            }


            htm = htm + "</tbody>";
            htm = htm + "</table>";
            htm = htm + "</div>";


            htm = htm + "<br/><br/><br/>";

            return htm;
        }





        public static void GenReport2(string year, Literal lit, Repeater rep1, Repeater rep2, Repeater rep3, HttpContext cont)
        {

            string s = @"SELECT 
                      SUM(CASE datepart(month,DateTaken) WHEN 1 THEN 1 ELSE 0 END) AS 'January',
                      SUM(CASE datepart(month,DateTaken) WHEN 2 THEN 1 ELSE 0 END) AS 'February',
                      SUM(CASE datepart(month,DateTaken) WHEN 3 THEN 1 ELSE 0 END) AS 'March',
                      SUM(CASE datepart(month,DateTaken) WHEN 4 THEN 1 ELSE 0 END) AS 'April',
                      SUM(CASE datepart(month,DateTaken) WHEN 5 THEN 1 ELSE 0 END) AS 'May',
                      SUM(CASE datepart(month,DateTaken) WHEN 6 THEN 1 ELSE 0 END) AS 'June',
                      SUM(CASE datepart(month,DateTaken) WHEN 7 THEN 1 ELSE 0 END) AS 'July',
                      SUM(CASE datepart(month,DateTaken) WHEN 8 THEN 1 ELSE 0 END) AS 'August',
                      SUM(CASE datepart(month,DateTaken) WHEN 9 THEN 1 ELSE 0 END) AS 'September',
                      SUM(CASE datepart(month,DateTaken) WHEN 10 THEN 1 ELSE 0 END) AS 'October',
                      SUM(CASE datepart(month,DateTaken) WHEN 11 THEN 1 ELSE 0 END) AS 'November',
                      SUM(CASE datepart(month,DateTaken) WHEN 12 THEN 1 ELSE 0 END) AS 'December',
                      SUM(CASE datepart(year,DateTaken) WHEN ";
            s = s + year;
            s = s + @" THEN 1 ELSE 0 END) AS 'TOTAL'
                    FROM
                        intake
                    WHERE
                      isNewlyCreated = 0";
            s = s + " AND DateTaken BETWEEN '" + year + "/01/01' AND '" + year + "/12/31'";
            DataTable dt = DBSpace.DBFunctionality.GetDataTable(s, cont);

            s = "<td>" + dt.Rows[0]["January"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["February"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["March"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["April"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["May"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["June"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["July"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["August"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["September"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["October"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["November"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["December"].ToString() + "</td>";
            s = s + "<td>" + dt.Rows[0]["TOTAL"].ToString() + "</td>";

            lit.Text = s;





            s = @"SELECT
              d.dmaname,
              SUM(CASE datepart(month,DateTaken) WHEN 1 THEN 1 ELSE 0 END) AS Jan,
              SUM(CASE datepart(month,DateTaken) WHEN 2 THEN 1 ELSE 0 END) AS Feb,
              SUM(CASE datepart(month,DateTaken) WHEN 3 THEN 1 ELSE 0 END) AS Mar,
              SUM(CASE datepart(month,DateTaken) WHEN 4 THEN 1 ELSE 0 END) AS Apr,
              SUM(CASE datepart(month,DateTaken) WHEN 5 THEN 1 ELSE 0 END) AS May,
              SUM(CASE datepart(month,DateTaken) WHEN 6 THEN 1 ELSE 0 END) AS June,
              SUM(CASE datepart(month,DateTaken) WHEN 7 THEN 1 ELSE 0 END) AS July,
              SUM(CASE datepart(month,DateTaken) WHEN 8 THEN 1 ELSE 0 END) AS Agu,
              SUM(CASE datepart(month,DateTaken) WHEN 9 THEN 1 ELSE 0 END) AS Sept,
              SUM(CASE datepart(month,DateTaken) WHEN 10 THEN 1 ELSE 0 END) AS Oct,
              SUM(CASE datepart(month,DateTaken) WHEN 11 THEN 1 ELSE 0 END) AS Nov,
              SUM(CASE datepart(month,DateTaken) WHEN 12 THEN 1 ELSE 0 END) AS Dec,
              SUM(CASE datepart(year,DateTaken) WHEN ";
            s = s + year;
            s = s + @"  THEN 1 ELSE 0 END) AS 'TOTAL'
            FROM intake i
              Right JOIN DMARegion d ON i.ReportRegionDMAID = d.id 
            WHERE
              isNewlyCreated = 0";
            s = s + " And DateTaken BETWEEN '" + year + "/01/01' AND '" + year + "/12/31' GROUP BY d.dmaname";
            dt = DBSpace.DBFunctionality.GetDataTable(s, cont);

            rep1.DataSource = dt;
            rep1.DataBind();




            s = @"SELECT
              d.ReferralSource,
              SUM(CASE datepart(month,DateTaken) WHEN 1 THEN 1 ELSE 0 END) AS Jan,
              SUM(CASE datepart(month,DateTaken) WHEN 2 THEN 1 ELSE 0 END) AS Feb,
              SUM(CASE datepart(month,DateTaken) WHEN 3 THEN 1 ELSE 0 END) AS Mar,
              SUM(CASE datepart(month,DateTaken) WHEN 4 THEN 1 ELSE 0 END) AS Apr,
              SUM(CASE datepart(month,DateTaken) WHEN 5 THEN 1 ELSE 0 END) AS May,
              SUM(CASE datepart(month,DateTaken) WHEN 6 THEN 1 ELSE 0 END) AS June,
              SUM(CASE datepart(month,DateTaken) WHEN 7 THEN 1 ELSE 0 END) AS July,
              SUM(CASE datepart(month,DateTaken) WHEN 8 THEN 1 ELSE 0 END) AS Agu,
              SUM(CASE datepart(month,DateTaken) WHEN 9 THEN 1 ELSE 0 END) AS Sept,
              SUM(CASE datepart(month,DateTaken) WHEN 10 THEN 1 ELSE 0 END) AS Oct,
              SUM(CASE datepart(month,DateTaken) WHEN 11 THEN 1 ELSE 0 END) AS Nov,
              SUM(CASE datepart(month,DateTaken) WHEN 12 THEN 1 ELSE 0 END) AS Dec,
              SUM(CASE datepart(year,DateTaken) WHEN ";
            s = s + year;
            s = s + @"  THEN 1 ELSE 0 END) AS 'TOTAL'
            FROM intake i
              Right JOIN ReferralSources d ON i.ReferralSourceID = d.id 
            WHERE
              isNewlyCreated = 0";
            s = s + " And DateTaken BETWEEN '" + year + "/01/01' AND '" + year + "/12/31' GROUP BY d.ReferralSource";
            dt = DBSpace.DBFunctionality.GetDataTable(s, cont);

            rep2.DataSource = dt;
            rep2.DataBind();




            s = @"SELECT
              d.Injury,
              SUM(CASE datepart(month,DateTaken) WHEN 1 THEN 1 ELSE 0 END) AS Jan,
              SUM(CASE datepart(month,DateTaken) WHEN 2 THEN 1 ELSE 0 END) AS Feb,
              SUM(CASE datepart(month,DateTaken) WHEN 3 THEN 1 ELSE 0 END) AS Mar,
              SUM(CASE datepart(month,DateTaken) WHEN 4 THEN 1 ELSE 0 END) AS Apr,
              SUM(CASE datepart(month,DateTaken) WHEN 5 THEN 1 ELSE 0 END) AS May,
              SUM(CASE datepart(month,DateTaken) WHEN 6 THEN 1 ELSE 0 END) AS June,
              SUM(CASE datepart(month,DateTaken) WHEN 7 THEN 1 ELSE 0 END) AS July,
              SUM(CASE datepart(month,DateTaken) WHEN 8 THEN 1 ELSE 0 END) AS Agu,
              SUM(CASE datepart(month,DateTaken) WHEN 9 THEN 1 ELSE 0 END) AS Sept,
              SUM(CASE datepart(month,DateTaken) WHEN 10 THEN 1 ELSE 0 END) AS Oct,
              SUM(CASE datepart(month,DateTaken) WHEN 11 THEN 1 ELSE 0 END) AS Nov,
              SUM(CASE datepart(month,DateTaken) WHEN 12 THEN 1 ELSE 0 END) AS Dec,
              SUM(CASE datepart(year,DateTaken) WHEN ";
            s = s + year;
            s = s + @"  THEN 1 ELSE 0 END) AS 'TOTAL'
            FROM intake i
              Right JOIN Injury d ON i.InjuryID = d.id 
            WHERE
              isNewlyCreated = 0";
            s = s + " And DateTaken BETWEEN '" + year + "/01/01' AND '" + year + "/12/31' GROUP BY d.Injury";
            dt = DBSpace.DBFunctionality.GetDataTable(s, cont);

            rep3.DataSource = dt;
            rep3.DataBind();

        }





        public static string GenReport3(string statusid, string status, string df, string dt, HttpContext cont)
        {
            string htm = "";

            string sql = @"select t2.intakeid, t1.intakeid, i.DateTaken, t2.maxdate, u.firstname, u.lastname, i.fname, i.lname, comments from statustracking t1
                            inner join
                            (select intakeid, max(StatusChangeDate) maxdate from statustracking where ";

            sql = sql + "statusid = " + statusid;

            if (df != "" && dt == "")
                sql = sql + " and StatusChangeDate >= '" + df + "'";
            else if (df == "" && dt != "")
                sql = sql + " and StatusChangeDate <= '" + dt + "'";
            else if (df != "" && dt != "")
                sql = sql + " and StatusChangeDate >= '" + df + "' and StatusChangeDate <= '" + dt + "'";

            sql = sql + @"group by intakeid ) t2
                            on t1.intakeid = t2.intakeid and t1.StatusChangeDate = t2.maxdate 
                            inner join users u on u.id = t1.actiontakenbyuser
                            inner join intake i on t1.intakeid = i.id
                            where i.isnewlycreated = 0";


            DataTable dt2 = DBSpace.DBFunctionality.GetDataTable(sql , cont);
            

            htm = htm + "<div class='table'>";
            htm = htm + "<h1 class='heading'> " + status + " </h1>";

            htm = htm + "<table>";
            htm = htm + "<thead><tr>";
            htm = htm + "<td style='width:13%;'>Date Changed</td>";
            htm = htm + "<td style='width:13%;'>Date Taken</td>";
            htm = htm + "<td style='width:16%;'>Changed By</td>";
            htm = htm + "<td style='width:16%;'>Case</td>";
            htm = htm + "<td>Notes</td>";
            htm = htm + "<td></td>";
            htm = htm + "</tr></thead>";
            htm = htm + "<tbody>";

            for (int zzz = 0; zzz < dt2.Rows.Count; zzz++)
            {
                htm = htm + "<tr>";
                htm = htm + "<td>" + DateTime.Parse(dt2.Rows[zzz]["DateTaken"].ToString()).ToShortDateString() + " </td>";
                htm = htm + "<td>" + DateTime.Parse(dt2.Rows[zzz]["maxdate"].ToString()).ToShortDateString() + " </td>";
                htm = htm + "<td>" + dt2.Rows[zzz]["firstname"].ToString() + " " + dt2.Rows[zzz]["lastname"].ToString() + " </td>";
                htm = htm + "<td>" + dt2.Rows[zzz]["fname"].ToString() + " " + dt2.Rows[zzz]["lname"].ToString() + " </td>";
                htm = htm + "<td>" + dt2.Rows[zzz]["comments"].ToString() + " </td>";
                htm = htm + "<td> <a href='intake.aspx?id=" + dt2.Rows[zzz]["intakeid"].ToString() + "'> <img src='images/file_edit.png' width='30px'> </a></td>";
                htm = htm + "<tr>";
            }

            htm = htm + "</tbody>";
            htm = htm + "</table>";
            htm = htm + "</div>";


            htm = htm + "<br/><br/><br/>";

            return htm;
        }








        //this function will convert a password added with salt 
        public static string GenerateSaltedHash(string value, string salt)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }


        public static string EncryptText(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
        }
        //Decrypt the text
        public static string DecryptText(string strText)
        {
            return Decrypt(strText, "&%#@?,:*");
        }


        //The function used to encrypt the text
        private static string Encrypt(string strText, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0X12, 0X34, 0X56, 0X78, 0X90, 0XAB, 0XCD, 0XEF };

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //The function used to decrypt the text
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0X12, 0X34, 0X56, 0X78, 0X90, 0XAB, 0XCD, 0XEF };
            byte[] inputByteArray = new byte[strText.Length + 1];

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                strText = strText.Replace(" ", "+");
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;

                return encoding.GetString(ms.ToArray());

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
                HttpContext.Current.Response.End();
                throw ex;
            }
        }



    }
}