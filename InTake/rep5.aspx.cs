using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

public partial class repo5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        datalist.Text = "";
    }

    protected void ttn_Click(object sender, EventArgs e)
    {
        if (IsPostBack == true)
        {
            repocriteria myControl = (repocriteria)DBSpace.DBFunctionality.FindControlRecursive(this, "cri2");
            if (myControl != null)
            {
                string dtFrom = "";
                string dtTo = "";

                if (Request.QueryString["typ"].ToString() == "6")
                {
                    dtFrom = myControl.getDateRange1();
                    dtTo = myControl.getDateRange2();
                }
                else
                {
                    dtFrom = myControl.getFromDate();
                    dtTo = myControl.getToDate();
                }

                string datecri = "";
                if (dtFrom != "" && dtTo == "")
                    datecri = " DateTaken >= '" + dtFrom + "'";
                else if (dtFrom == "" && dtTo != "")
                    datecri = " DateTaken <= '" + dtTo + "'";
                else if (dtFrom!= "" && dtTo != "")
                    datecri = " DateTaken >= '" + dtFrom+ "' and DateTaken <= '" + dtTo + "'";

                ExecuteCriteria(datecri, "DataFrmServer");

                if (myControl.DateCompare() == true)
                {
                    datecri = "";
                    if (myControl.getFromDate2() != "" && myControl.getToDate2() == "")
                        datecri = " DateTaken >= '" + myControl.getFromDate2() + "'";
                    else if (myControl.getFromDate2() == "" && myControl.getToDate2() != "")
                        datecri = " DateTaken <= '" + myControl.getToDate2() + "'";
                    else if (myControl.getFromDate2() != "" && myControl.getToDate2() != "")
                        datecri = " DateTaken >= '" + myControl.getFromDate2() + "' and DateTaken <= '" + myControl.getToDate2() + "'";

                    ExecuteCriteria(datecri, "DataFrmServer2");
                    datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var CompareTwoCharts = 1; var PrimaryDateRangeText = '" + myControl.getFromDate() + " - " + myControl.getToDate() + "';    var SecondaryDateRangeText = '" + myControl.getFromDate2() + " - " + myControl.getToDate2() + "';</script>";
                }
                else
                    datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var CompareTwoCharts = 0; var PrimaryDateRangeText = '" + myControl.getFromDate() + " - " + myControl.getToDate() + "';</script>";
            }
        }

    }






    protected void ExecuteCriteria(string datecri, string jsVariableName)
    {

        repocriteria myControl = (repocriteria)DBSpace.DBFunctionality.FindControlRecursive(this, "cri2");

        if (myControl.getViewBy() == "1")
        {
            if (myControl.getDMAorStateSelectedValue() != "-1")
            {
                if (datecri != "")
                    datecri = datecri + " and ";
                datecri = datecri + " ReportRegionDMAID = " + myControl.getDMAorStateSelectedValue();
            }
        }
        else if (myControl.getViewBy() == "2")
        {
            if (myControl.getDMAorStateSelectedValue() != "-1")
            {
                if (datecri != "")
                    datecri = datecri + " and ";
                datecri = datecri + " State = '" + myControl.getDMAorStateSelectedValue() + "'";
            }
        }


        if (Request.QueryString["typ"].ToString() == "1")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getBikeTypeReport(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "2")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getVehicleMakeReport(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "3")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getSourceOfReferrerReport(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "4")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getInjuryType(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "5")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getRiderAgeType(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "6")
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getCaseByVolume(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "7")   //by sex
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getGenderTypeReport(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

        if (Request.QueryString["typ"].ToString() == "8")   //state dma aggregation
            datalist.Text = datalist.Text + "<script language='javascript' type='text/javascript'>var " + jsVariableName + " = " + getAggregatedReportOfDMAandState(myControl.getViewBy(), datecri, myControl.getIncludeSignedReports()) + "  </script>";

    }






    protected string getBikeTypeReport(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";
        //p is viewby dma or state
        if (p == "1")
        {
            if(IncludeOnlySignedReport == false)
                sql = "select dmaname, ClientVehicleBikeType, count(*) as count from intake, DMARegion Where ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, ClientVehicleBikeType order by dmaname";
            else
                sql = "select dmaname, ClientVehicleBikeType, count(*) as count from intake, DMARegion, StatusTracking Where ReportRegionDMAID = DMARegion.id and intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by dmaname, ClientVehicleBikeType order by dmaname";
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select [state], ClientVehicleBikeType, count(*) as count from intake where " + datecri + " group by state, ClientVehicleBikeType order by state";
            else
                sql = "select [state], ClientVehicleBikeType, count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by state, ClientVehicleBikeType order by state";
        }


        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }






    protected string getGenderTypeReport(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";
        //p is viewby dma or state
        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select dmaname, gender, count(*) as count from intake, DMARegion Where ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, gender order by dmaname, count";
            else
                sql = "select dmaname, gender, count(*) as count from intake, DMARegion, StatusTracking Where ReportRegionDMAID = DMARegion.id and intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by dmaname, gender order by dmaname, count";
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select [state], gender, count(*) as count from intake where " + datecri + " group by state, gender order by state, count";
            else
                sql = "select [state], gender, count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by state, gender order by state, count";
        }


        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }





    //select state, count(*) count from intake group by state
    //select dmaname, count(*) as count from intake, DMARegion Where ReportRegionDMAID = DMARegion.id group by dmaname
    protected string getAggregatedReportOfDMAandState(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";

        sql = "select 'DMA', dmaname, count(*) as count from intake, DMARegion Where ReportRegionDMAID = DMARegion.id and intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by dmaname";

        sql = sql + " union all select 'State', [state], count(*) as count from intake where intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by state";

        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }



    protected string getVehicleMakeReport(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";

        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select dmaname, VehicleInfoMake, count(*) as count from intake, DMARegion Where ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, VehicleInfoMake order by dmaname";
            else
                sql = "select dmaname, VehicleInfoMake, count(*) as count from intake, DMARegion, StatusTracking Where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, VehicleInfoMake order by dmaname";
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select [state], VehicleInfoMake, count(*) as count from intake where " + datecri + " group by state, VehicleInfoMake order by state";
            else
                sql = "select [state], VehicleInfoMake, count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and " + datecri + " group by state, VehicleInfoMake order by state";
        }

        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }




    protected string getSourceOfReferrerReport(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";

        //check out in these statements that  order by just appear in the last statement of all unions 

        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = "select dmaname, ReferralSource, count(*) as count from intake, DmaRegion, ReferralSources where ReportRegionDMAID = DmaRegion.id and ReferralSourceID = ReferralSources.id and " + datecri + " group by dmaname, ReferralSource";
                sql = sql + " union all ";
                sql = sql + "select dmaname, '' as ReferralSource, count(*) as count from intake, DmaRegion where ReportRegionDMAID = DmaRegion.id and ReferralSourceID is null and " + datecri + " group by dmaname ";
                sql = sql + " union all ";
                sql = sql + "select  '' as dmaname, '' as ReferralSource, count(*) as count from intake where ReportRegionDMAID is null and  " + datecri + " order by dmaname ";
            }
            else
            {
                sql = "select dmaname, ReferralSource, count(*) as count from intake, DmaRegion, ReferralSources, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DmaRegion.id and ReferralSourceID = ReferralSources.id and " + datecri + " group by dmaname, ReferralSource";
                sql = sql + " union all ";
                sql = sql + "select dmaname, '' as ReferralSource, count(*) as count from intake, DmaRegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DmaRegion.id and ReferralSourceID is null and " + datecri + " group by dmaname ";
                sql = sql + " union all ";
                sql = sql + "select  '' as dmaname, '' as ReferralSource, count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID is null and  " + datecri + " order by dmaname ";

            }
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = "select [state], ReferralSource, count(*) as count from intake, ReferralSources where  ReferralSourceID = ReferralSources.id and " + datecri + " group by [state], ReferralSource";
                sql = sql + " union all ";
                sql = sql + "select [state], '' as ReferralSource, count(*) as count from intake where  ReferralSourceID is null and " + datecri + " group by [state]";
            }
            else
            {
                sql = "select [state], ReferralSource, count(*) as count from intake, ReferralSources, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReferralSourceID = ReferralSources.id and " + datecri + " group by [state], ReferralSource";
                sql = sql + " union all ";
                sql = sql + "select [state], '' as ReferralSource, count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  ReferralSourceID is null and " + datecri + " group by [state]";
            }
        }


        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }




    protected string getInjuryType(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";


        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = @"select dmaname, InjuryName, count(*) as count from intake, DmaRegion, InjuryTypes where ReportRegionDMAID = DmaRegion.id and InjuryTypeID = InjuryTypes.InjuryID  and DateCriteriaHere group by dmaname, InjuryName
                        union
                        select dmaname, 'No-Injury', count(*) as count from intake, DmaRegion where ReportRegionDMAID = DmaRegion.id and InjuryTypeID = -1  and DateCriteriaHere  group by dmaname";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
            else
            {
                sql = @"select dmaname, InjuryName, count(*) as count from intake, DmaRegion, InjuryTypes, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DmaRegion.id and InjuryTypeID = InjuryTypes.InjuryID  and DateCriteriaHere group by dmaname, InjuryName
                        union
                        select dmaname, 'No-Injury', count(*) as count from intake, DmaRegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DmaRegion.id and InjuryTypeID = -1  and DateCriteriaHere  group by dmaname";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = @"select [State], InjuryName, count(*) as count from intake, InjuryTypes where InjuryTypeID = InjuryTypes.InjuryID  and DateCriteriaHere  group by [State], InjuryName
                    union
                    select [State], 'No-Injury', count(*) as count from intake where InjuryTypeID = -1   and DateCriteriaHere  group by [State]
                    ";
                sql = sql.Replace("DateCriteriaHere", datecri);
            }
            else
            {
                sql = @"select [State], InjuryName, count(*) as count from intake, InjuryTypes, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and InjuryTypeID = InjuryTypes.InjuryID  and DateCriteriaHere  group by [State], InjuryName
                    union
                    select [State], 'No-Injury', count(*) as count from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and InjuryTypeID = -1 and DateCriteriaHere group by [State]
                    ";
                sql = sql.Replace("DateCriteriaHere", datecri);
            }
        }



        DataTable dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
        return getJSONOfRecordSet(dt);
    }



    protected string getRiderAgeType(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";

        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = @"select dmaname, '15-19', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 9 and 15 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '20-29', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 29 and 29 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '30-39', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 30 and 39 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '40-49', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 40 and 49 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '50-59', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 50 and 59 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '60+', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 60 and 110 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, 'Age not specified', count(*) from intake, DMARegion where ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) > 110 and DateCriteriaHere group by dmaname
                        ";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
            else
            {
                sql = @"select dmaname, '15-19', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 9 and 15 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '20-29', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 29 and 29 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '30-39', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 30 and 39 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '40-49', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 40 and 49 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '50-59', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 50 and 59 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, '60+', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 60 and 110 and DateCriteriaHere group by dmaname
                        union all
                        select dmaname, 'Age not specified', count(*) from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and ReportRegionDMAID = DMARegion.id and (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) > 110 and DateCriteriaHere group by dmaname
                        ";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
        }

        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
            {
                sql = @"select (case when state != '' then state else 'No State Specified' end ) as State2, '15-19', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 9 and 15  and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '20-29', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 29 and 29 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '30-39', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 30 and 39 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '40-49', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 40 and 49 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '50-59', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 50 and 59 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '60+', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 60 and 110 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, 'Age not specified', count(*) from intake where (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) > 110 and DateCriteriaHere group by state
                        ";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
            else
            {
                sql = @"select (case when state != '' then state else 'No State Specified' end ) as State2, '15-19', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 9 and 15  and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '20-29', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 29 and 29 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '30-39', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 30 and 39 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '40-49', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 40 and 49 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '50-59', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 50 and 59 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, '60+', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) between 60 and 110 and DateCriteriaHere group by state
                        union all
                        select (case when state != '' then state else 'No State Specified' end ) as State2, 'Age not specified', count(*) from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  (case when isdate(dob) = 1 then datediff(year, dob, DateTaken) else 1000 end ) > 110 and DateCriteriaHere group by state
                        ";

                sql = sql.Replace("DateCriteriaHere", datecri);
            }
        }


        DataTable dt;
        try
        {
             dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
             return getJSONOfRecordSet(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            Response.End();
        }

        return "[]";
    }





    protected string getCaseByVolume(string p, string datecri, bool IncludeOnlySignedReport)
    {
        string sql = "";
        
        if (p == "1")
        {
            if (IncludeOnlySignedReport == false)            
                sql = "select dmaname, year(datetaken) as yy, datename(month, datetaken) as mm, count(*) as cnt from intake, DMARegion where ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, year(datetaken), datename(month, datetaken) order by dmaname";            
            else
                sql = "select dmaname, year(datetaken) as yy, datename(month, datetaken) as mm, count(*) as cnt from intake, DMARegion, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  ReportRegionDMAID = DMARegion.id and " + datecri + " group by dmaname, year(datetaken), datename(month, datetaken) order by dmaname";            
        }
        
        if (p == "2")
        {
            if (IncludeOnlySignedReport == false)
                sql = "select state, year(datetaken) as yy, datename(month, datetaken) as mm, count(*) as cnt from intake where " + datecri + " group by state, year(datetaken), datename(month, datetaken) order by state";            
            else
                sql = "select state, year(datetaken) as yy, datename(month, datetaken) as mm, count(*) as cnt from intake, StatusTracking where intake.id = statustracking.intakeid and statustracking.statusid = 6 and  " + datecri + " group by state, year(datetaken), datename(month, datetaken) order by state";            
        }


        DataTable dt;
        try
        {
            dt = DBSpace.DBFunctionality.GetDataTable(sql, Context);
            return getJSONOfRecordSet(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            Response.End();
        }


        return "[]";
    }


    protected string getJSONOfRecordSet(DataTable dt)
    {
        //field 1 contains 
        int a;
        string json = "[";
        for (a = 0; a < dt.Rows.Count; a++)
        {
            json = json + "{\"f1\":\"" + dt.Rows[a][0].ToString() + "\", \"f2\":\"" + dt.Rows[a][1].ToString() + "\", \"f3\":\"" + dt.Rows[a][2].ToString() + "\"";
            if (dt.Columns.Count >= 4)
                json = json + ", \"f4\":\"" + dt.Rows[a][3].ToString() + "\"";
            json = json + "},";
        }

        if (json == "[")
            json = "[]";
        else
            json = json.Substring(0, json.Length - 1) + "]";
        
        return json;
    }


}