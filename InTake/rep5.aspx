<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="rep5.aspx.cs" Inherits="repo5" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%@ Register TagPrefix="uc1" TagName="cri" Src="~/repcriteria.ascx" %>


<div class="wrapper">
    
    <div id="ReportTopTitle" style="margin-left:40%; font-size:20px; font-weight:bold;" ></div>

    <br />
    <br />

    <uc1:cri id="cri2" runat="server"   />
    <asp:Button ID="ttn" runat="server" Text="Generate Report     " onclick="ttn_Click" />

    <br />
    <br />
    <br />
    <div id="ReportTitles" style="margin-left:40%; font-size:20px; font-weight:bold;" ></div>
    <br />
    <br />
    <br />

    <div id="htmlstructure"></div>

    <asp:Literal ID="datalist" runat="server"></asp:Literal>

    <br />
    
    

</div>




<script language="javascript" type="text/javascript">

    var DataItems = [];

//    DataItems = [
//    { "Title": "DMA - CA",
//        "data": [{
//            "Caption": "c1",
//            "Region": "",
//            "Data": 23
//        }, {
//            "Caption": "c2",
//            "Region": "",
//            "Data": 45
//        }, {
//            "Caption": "Sc3e",
//            "Region": "",
//            "Data": 42
//        }, {
//            "Caption": "c4",
//            "Region": "",
//            "Data": 28
//        }, {
//            "Caption": "c5",
//            "Region": "",
//            "Data": 12
//        }]
//    },
//    { "Title": "DMA - California",
//        "data": [{
//            "Caption": "c1",
//            "Region": "1",
//            "Data": 34
//        }, {
//            "Caption": "c2",
//            "Region": "1",
//            "Data": 44
//        }, {
//            "Caption": "Sc3e",
//            "Region": "1",
//            "Data": 55
//        }, {
//            "Caption": "c4",
//            "Region": "1",
//            "Data": 53
//        }, {
//            "Caption": "c5",
//            "Region": "1",
//            "Data": 12
//        }]
//    }

//  ];




//    DataItems = [
//    {
//        "Caption": "vergina",
//        "Items": [{
//            "2000": 1760,
//            "2013": 535,
//            "2014": 695,
//            "Month": "Jan"
//        }, {
//            "2000": 1849,
//            "2013": 395,
//            "2014": 688,
//            "Month": "Feb"
//        }, {
//            "2000": 2831,
//            "2013": 685,
//            "2014": 1047,
//            "Month": "Mar"
//        }, {
//            "2000": 2851,
//            "2013": 984,
//            "2014": 1652,
//            "Month": "Apr"
//        }, {
//            "2000": 2961, 
//            "2013": 1579, 
//            "2014": 1889, 
//            "Month": "May"
//        }, {
//            "2000": 1519,
//            "2013": 1539,
//            "2014": 1766,
//            "Month": "Jun"
//        }, {
//            "2000": 2633,
//            "2013": 1489,
//            "2014": 1361,
//            "Month": "Jul"
//        }, {
//            "2000": 1140,
//            "2013": 650,
//            "2014": 874,
//            "Month": "Aug"
//        }, {
//            "2000": 1626,
//            "2013": 653,
//            "2014": 693,
//            "Month": "Sep"
//        }, {
//            "2000": 1478,
//            "2013": 2236,
//            "2014": 786,
//            "Month": "Oct"
//        }, {
//            "2000": 1306,
//            "2013": 1937,
//            "2014": 599,
//            "Month": "Nov"
//        }, {
//            "2000": 1607,
//            "2013": 2138,
//            "2014": 678,
//            "Month": "Dec"
//        }]

//    },

//    {
//        "Caption": "vergina2",
//        "Items": [{
//            "2000": 1760,
//            "2013": 535,
//            "2014": 695,
//            "Month": "Jan"
//        }, {
//            "2000": 1849,
//            "2013": 395,
//            "2014": 688,
//            "Month": "Feb"
//        }, {
//            "2000": 2831,
//            "2013": 685,
//            "2014": 1047,
//            "Month": "Mar"
//        }, {
//            "2000": 2851,
//            "2013": 984,
//            "2014": 1652,
//            "Month": "Apr"
//        }, {
//            "2000": 2961,
//            "2013": 1579,
//            "2014": 1889,
//            "Month": "May"
//        }, {
//            "2000": 1519,
//            "2013": 1539,
//            "2014": 1766,
//            "Month": "Jun"
//        }, {
//            "2000": 2633,
//            "2013": 1489,
//            "2014": 1361,
//            "Month": "Jul"
//        }, {
//            "2000": 1140,
//            "2013": 650,
//            "2014": 874,
//            "Month": "Aug"
//        }, {
//            "2000": 1626,
//            "2013": 653,
//            "2014": 693,
//            "Month": "Sep"
//        }, {
//            "2000": 1478,
//            "2013": 2236,
//            "2014": 786,
//            "Month": "Oct"
//        }, {
//            "2000": 1306,
//            "2013": 1937,
//            "2014": 599,
//            "Month": "Nov"
//        }, {
//            "2000": 1607,
//            "2013": 2138,
//            "2014": 678,
//            "Month": "Dec"
//        }]

//    }
//    ];







    //Getting the parameter name from url  only query string
    function GetQueryStringParameter(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);
        if (results == null)
            return "";
        else
            return results[1];
    }




    var ColorAssignmentToDMAState = [];
    var ColorsArray = ["#00FFFF", "#FFFF00", "#FFE4B5", "#A52A2A", "#DEB887", "#DAA520", "#ADD8E6", "#00FA9A", "#FFA500", "#DB7093", "#9ACD32", "#5F9EA0", "#7FFF00", "#D2691E", "#DC143C", "#B8860B", "#A9A9A9", "#006400", "#BDB76B", "#8B008B", "#E9967A", "#FF1493", "#FFD700", "#6B8E23", "#FF0000", "#00FF7F"];
    var currentIndex = 0;

    function getOrAssignColor(caption) {

        var fnd = "-1";

        $(ColorAssignmentToDMAState).each(function (i, itm) {
            if (itm.Caption == caption)
                fnd = itm.color;
        });

        if(fnd == "-1")
        {
            var opt = { "Caption": caption, "color": ColorsArray[currentIndex] }
            ColorAssignmentToDMAState.push(opt);
            fnd = ColorsArray[currentIndex];
            currentIndex++;
            if(currentIndex >= ColorsArray.length)
                currentIndex = 0;
        }

        return fnd;
    }



    $(document).ready(function () {


        var TotalCountWhereStateDMEisNull1 = 0;
        var TotalCountWhereStateDMEisNull2 = 0;


        if (GetQueryStringParameter("typ") == "1")
            $("#ReportTopTitle").html("Report - Bike Type");

        if (GetQueryStringParameter("typ") == "2")
            $("#ReportTopTitle").html("Report - Vehicle Make");

        if (GetQueryStringParameter("typ") == "3")
            $("#ReportTopTitle").html("Report - Source of Referrer");

        if (GetQueryStringParameter("typ") == "4")
            $("#ReportTopTitle").html("Report - Injury Type");

        if (GetQueryStringParameter("typ") == "5")
            $("#ReportTopTitle").html("Report - Age of Rider");

        if (GetQueryStringParameter("typ") == "6") {
            $("#ReportTopTitle").html("Report - Case by Volume");
            $(".CompareDateRangesTR").hide();  //hide date comparator in the repocriteria file

            //hide date selection objects   and show only month and year dropdowns
            $(".DateCriteria1").hide();
            $(".DateCriteria2").show();
        }
        else {
            //hide month and year drop downs and show date pickets 
            $(".DateCriteria1").show();
            $(".DateCriteria2").hide();
        }


        if (GetQueryStringParameter("typ") == "7")
            $("#ReportTopTitle").html("Report - Case by Gender");

        if (GetQueryStringParameter("typ") == "8") {
            $("#ReportTopTitle").html("Report - DMA, State aggregation");
            $("#viewbydiv").hide();      //these are defined in the repocriteria.ascx file
            $("#ReportTitles").hide();
        }

        if (DataFrmServer != null) {

            var tit = "";

            if ($("#" + ClientObjectNameOfddViewBy).val() == "1") {
                tit = "DMA - ";
                $("#ReportTitles").html("Report By DMA");
            }
            else {
                tit = "State - ";
                $("#ReportTitles").html("Report By State");
            }



            if (GetQueryStringParameter("typ") == "1" || GetQueryStringParameter("typ") == "2" || GetQueryStringParameter("typ") == "3" || GetQueryStringParameter("typ") == "4" || GetQueryStringParameter("typ") == "5" || GetQueryStringParameter("typ") == "7") {

                $("#" + ClientObjectNameOflstDMAState + " option").each(function (i, itm) {
                    var dmaORstate = $(itm).html();

                    if (dmaORstate != "All") {  //ignore the All from dropdown

                        var itmTOadd = { "Title": tit + dmaORstate, "data": [] };

                        var TotalCountForEmptySet = 0;
                        $(DataFrmServer).each(function (i, itm) {
                            if (itm.f1 == dmaORstate && itm.f2.trim() == "")
                                TotalCountForEmptySet = TotalCountForEmptySet + parseInt(itm.f3);
                        });
                        $(DataFrmServer).each(function (i, itm) {
                            if (itm.f1.trim() == dmaORstate && itm.f2.trim() != "" && itm.f3 != 0)
                                itmTOadd.data.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                        });
                        if (TotalCountForEmptySet != 0) {
                            if (GetQueryStringParameter("typ") == "2") //in case of vehicle make report as there is Other vehicle make it make confusion with Others which is empty dataset. so client want to make it combine. my solution in this case Others should be Vehicle Not Selected
                                itmTOadd.data.push({ "Caption": "Vehicle Not Selected", "Region": "", "Data": TotalCountForEmptySet.toString() });
                            else
                                itmTOadd.data.push({ "Caption": "Others", "Region": "", "Data": TotalCountForEmptySet.toString() });
                        }

                        //if there is second data set then calculate its information as well
                        if (CompareTwoCharts == 1) {
                            itmTOadd.data2 = [];

                            TotalCountForEmptySet = 0;
                            $(DataFrmServer2).each(function (i, itm) {
                                if (itm.f1 == dmaORstate && itm.f2.trim() == "")
                                    TotalCountForEmptySet = TotalCountForEmptySet + parseInt(itm.f3);
                            });
                            $(DataFrmServer2).each(function (i, itm) {
                                if (itm.f1.trim() == dmaORstate && itm.f2.trim() != "" && itm.f3 != 0)
                                    itmTOadd.data2.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                            });
                            if (TotalCountForEmptySet != 0) {
                                if (GetQueryStringParameter("typ") == "2") //in case of vehicle make report as there is Other vehicle make it make confusion with Others which is empty dataset. so client want to make it combine. my solution in this case Others should be Vehicle Not Selected
                                    itmTOadd.data2.push({ "Caption": "Vehicle Not Selected", "Region": "", "Data": TotalCountForEmptySet.toString() });
                                else
                                    itmTOadd.data2.push({ "Caption": "Others", "Region": "", "Data": TotalCountForEmptySet.toString() });
                            }

                            if (itmTOadd.data.length > 0 || itmTOadd.data2.length > 0)
                                DataItems.push(itmTOadd);
                        }
                        else {
                            if (itmTOadd.data.length > 0)
                                DataItems.push(itmTOadd);
                        }
                    }

                });




                $(DataFrmServer).each(function (i, itm) {
                    if (itm.f1 == "")
                        TotalCountWhereStateDMEisNull1 = TotalCountWhereStateDMEisNull1 + parseInt(itm.f3);
                });
                if (CompareTwoCharts == 1) {
                    $(DataFrmServer2).each(function (i, itm) {
                        if (itm.f1 == "")
                            TotalCountWhereStateDMEisNull2 = TotalCountWhereStateDMEisNull2 + parseInt(itm.f3);
                    });
                }


                //now display charts one by one
                for (zz = 0; zz < DataItems.length; zz++) {
                    var rn = Math.floor((Math.random() * 9999999) + 1);
                    DisplayCharHTML("ddiv" + rn, DataItems[zz], 1);
                }

                //now aggregate all data for a single aggregated chart
                var CountWhereStateOrDMAisNull = 0;
                if (DataItems.length > 1) {
                    var AllDataItems = { "Title": "All", "data": [] };
                    $(DataItems).each(function (i, itm) {
                        $(itm.data).each(function (i2, itm2) {
                            var isItemFound = false;
                            $(AllDataItems.data).each(function (i3, itm3) {
                                if (itm2.Caption == itm3.Caption && itm2.Region == itm3.Region) {
                                    itm3.Data = parseInt(itm3.Data) + parseInt(itm2.Data);
                                    if (itm2.Caption == "Others" && TotalCountWhereStateDMEisNull1 != 0) {
                                        itm3.Data = parseInt(itm3.Data) + TotalCountWhereStateDMEisNull1;
                                        TotalCountWhereStateDMEisNull1 = 0
                                    }
                                    isItemFound = true;
                                }
                            });

                            if (isItemFound == false)
                                AllDataItems.data.push({ "Caption": itm2.Caption, "Region": itm2.Region, "Data": parseInt(itm2.Data) });
                        });
                    });
                }


                if (CompareTwoCharts == 1) {
                    //now aggregate all data for second range of dates
                    AllDataItems.data2 = [];
                    $(DataItems).each(function (i, itm) {
                        $(itm.data2).each(function (i2, itm2) {
                            var isItemFound = false;

                            $(AllDataItems.data2).each(function (i3, itm3) {
                                if (itm2.Caption == itm3.Caption && itm2.Region == itm3.Region) {
                                    itm3.Data = parseInt(itm3.Data) + parseInt(itm2.Data);
                                    if (itm2.Caption == "Others" && TotalCountWhereStateDMEisNull2 != 0) {
                                        itm3.Data = parseInt(itm3.Data) + TotalCountWhereStateDMEisNull2;
                                        TotalCountWhereStateDMEisNull2 = 0
                                    }
                                    isItemFound = true;
                                }
                            });

                            if (isItemFound == false)
                                AllDataItems.data2.push({ "Caption": itm2.Caption, "Region": itm2.Region, "Data": parseInt(itm2.Data) });
                        });
                    });
                }


                DisplayCharHTML("ddivall", AllDataItems, 2);

            }
            else if (GetQueryStringParameter("typ") == "6") {

                /*
                f1  dmaname
                f2  year(datetaken) as yy
                f3  datename(month, datetaken) as mm
                f4  count(*)
                */

                //get the list of all years
                var years = [];
                $(DataFrmServer).each(function (i, itm) {
                    if (itm.f2 != "") {
                        var add = true;
                        $(years).each(function (i2, itm2) {
                            if (itm2.year == itm.f2)
                                add = false;
                        });

                        if (add == true)
                            years.push({ "year": itm.f2 });
                    }
                });



                $("#" + ClientObjectNameOflstDMAState + " option").each(function (i, itm) {
                    var dmaORstate = $(itm).html();

                    if (dmaORstate != "All") {

                        var itmToAdd = { "Caption": dmaORstate, "Items": [{ "Month": "Jan" }, { "Month": "Feb" }, { "Month": "Mar" }, { "Month": "Apr" }, { "Month": "May" }, { "Month": "Jun" }, { "Month": "Jul" }, { "Month": "Aug" }, { "Month": "Sep" }, { "Month": "Oct" }, { "Month": "Nov" }, { "Month": "Dec"}] };
                        $(years).each(function (i2, itm2) {
                            eval("itmToAdd.Items[0][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[1][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[2][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[3][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[4][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[5][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[6][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[7][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[8][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[9][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[10][" + itm2.year + "]=0");
                            eval("itmToAdd.Items[11][" + itm2.year + "]=0");
                        });

                        DataItems.push(itmToAdd);
                    }

                });


                var DelItemsArray = [];
                $(DataItems).each(function (i, itm) {
                    var KeepItem = false;
                    $(DataFrmServer).each(function (i2, itm2) {
                        if (itm.Caption == itm2.f1) {
                            if (itm2.f3 != null && itm2.f2 != null) {
                                if (itm2.f3 != "" && itm2.f2 != "") {
                                    eval("itm.Items[" + getMonthIndex(itm2.f3) + "][" + itm2.f2 + "] = " + itm2.f4);
                                    KeepItem = true
                                }
                            }
                        }
                    });
                    if (KeepItem == true)
                        DelItemsArray.push({ "item": i });
                });

                var tmpObj = [];
                $(DelItemsArray).each(function (i, itm) {
                    tmpObj.push(DataItems[itm.item]);
                });

                //Showing the graphics now as data structure is prepared
                $(tmpObj).each(function (zz, itm) {

                    var htm = "<div  class='page-break'>  <div style='' id='ddiv" + zz + "'/>   <br/>   <div id='div" + zz + "' style='width:100%;height:350px;' />   </div>";
                    $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/><br/><br/>" + htm);

                    htm = "";
                    htm = "<span style='font-size:16px; font-weight:bold;'>" + itm.Caption + "</span><br><br>";
                    $("#ddiv" + zz).html(htm);
                    loadChart2(itm, "div" + zz, years.length);

                });



                //now aggregate the data. tmpObj contains all items so just aggregate Jan, Feb etc.
                var itmToAddAll = { "Caption": "All", "Items": [{ "Month": "Jan" }, { "Month": "Feb" }, { "Month": "Mar" }, { "Month": "Apr" }, { "Month": "May" }, { "Month": "Jun" }, { "Month": "Jul" }, { "Month": "Aug" }, { "Month": "Sep" }, { "Month": "Oct" }, { "Month": "Nov" }, { "Month": "Dec"}] };
                $(years).each(function (i2, itm2) {
                    eval("itmToAddAll.Items[0][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[1][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[2][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[3][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[4][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[5][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[6][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[7][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[8][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[9][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[10][" + itm2.year + "]=0");
                    eval("itmToAddAll.Items[11][" + itm2.year + "]=0");
                });

                $(years).each(function (i2, itm2) {
                    $(tmpObj).each(function (zz, itm) {

                        //iterate through this this year's Jan,  Feb records and aggregate
                        $(itm.Items).each(function (yy, yitm) {
                            eval("itmToAddAll.Items[" + yy + "][" + itm2.year + "] = itmToAddAll.Items[" + yy + "][" + itm2.year + "] + yitm[" + itm2.year + "]");
                        });

                    });
                });


                var htm = "<div  class='page-break'>  <div style='' id='ddivAll'/>   <br/>   <div id='divAll' style='width:100%;height:350px;' />   </div>";
                $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/><br/><br/>" + htm);

                htm = "";
                htm = "<span style='font-size:16px; font-weight:bold;'>All</span><br><br>";
                $("#ddivAll").html(htm);
                loadChart2(itmToAddAll, "divAll", years.length);

            }
            else if (GetQueryStringParameter("typ") == "8") {
                //dma + state aggregation report

                if (DataFrmServer != null) {
                    var itmTOadd = { "Title": "DMA", data: [] };
                    $(DataFrmServer).each(function (i, itm) {
                        if (itm.f1 == "DMA")
                            itmTOadd.data.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                    });
                    if (CompareTwoCharts == 1) {
                        //now aggregate all data
                        itmTOadd.data2 = [];
                        $(DataFrmServer2).each(function (i, itm) {
                            if (itm.f1 == "DMA")
                                itmTOadd.data2.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                        });
                    }
                    DisplayCharHTML("DMADiv", itmTOadd, 2);




                    itmTOadd = { "Title": "State", data: [] };
                    $(DataFrmServer).each(function (i, itm) {
                        if (itm.f1 == "State")
                            itmTOadd.data.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                    });
                    if (CompareTwoCharts == 1) {
                        //now aggregate all data
                        itmTOadd.data2 = [];
                        $(DataFrmServer2).each(function (i, itm) {
                            if (itm.f1 == "State")
                                itmTOadd.data2.push({ "Caption": itm.f2, "Region": "", "Data": itm.f3 });
                        });
                    }
                    DisplayCharHTML("StateDiv", itmTOadd, 2);
                }

            }

        }

    });





function DisplayCharHTML(divid, data, graphOnSecondLine) {
    var htm = "";

    if (graphOnSecondLine == 1) {
        if (CompareTwoCharts == 0) {
            htm = " <div class='page-break'>  <div style='float:left;' id='" + divid + "'/>    <div id='" + divid + "2' style='float:right; width:550px;height:400px' />   </div>";
            $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/>" + htm);
        }
        if (CompareTwoCharts == 1) {
            htm = "<div  class='page-break'> <br> <div style='float:left;' id='" + divid + "'/>    <div id='" + divid + "2' style='float:right; width:550px;height:400px' />   </div>";
            htm = htm + "<br/><br/><br/> <div>  <div style='float:left;' id='" + divid + "3'/>    <div id='" + divid + "4' style='float:right; width:550px;height:400px' />   </div>";
            $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/>" + htm);
        }    
    }
    else if (graphOnSecondLine == 2) {
        if (CompareTwoCharts == 0) {
            htm = "<div  class='page-break'>  <div id='" + divid + "'/>   <br>   <div id='" + divid + "2' style='width:800px;height:750px;' />   </div>";
            $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/>" + htm);
        }
        if (CompareTwoCharts == 1) {
            htm = "<div  class='page-break'>  <div id='" + divid + "'/>   <br>   <div id='" + divid + "2' style='width:800px;height:600px;' />   </div>";
            htm = htm + "<br><br/><br/>  <div>  <div id='" + divid + "3'/>   <br>   <div id='" + divid + "4' style='width:800px;height:600px;' />   </div>";
            $("#htmlstructure").append("<br/><br/><br/><div style='height:2px; width:100%; border:solid 1px gray; background-color:gray;' /><br/>" + htm);
        }
    }


    CharLoadLineData(data.data, data.Title, divid, divid + "2", 1); 
    if (CompareTwoCharts == 1) 
        CharLoadLineData(data.data2, "", divid + "3", divid + "4", 2);
}




function CharLoadLineData(data, Title, divid, chartDivID, DateRange) {
    var total = 0;

    data.sort(function (obj1, obj2) {

        if (GetQueryStringParameter("typ") == "5") {
            //if this is age group then sort based on first character of f1 which is  15-20   20-30  etc.    get first charactaer and then sort on it.
            if (obj1.Caption == "Age not specified")
                return true;     //as this is not numeric it will always come on the last
            else
                return parseInt(obj1.Caption.charAt(0)) - parseInt(obj2.Caption.charAt(0));
        }
        else
            return obj2.Data - obj1.Data;
    });


    $(data).each(function (i, itm) {
        total = total + parseInt(itm.Data);
    });

    if (total != 0) {
        htm = "";

        if (Title != "")
            htm = "<span style='font-size:16px; font-weight:bold;'>" + Title + "</span><br><br><br/><br/>";


        //PrimaryDateRangeText and SecondaryDateRangeText are set in the backend in javascript
        if (DateRange == 1)
            htm = htm + "<span style='font-size:16px; font-weight:bold;'>" + PrimaryDateRangeText + "</span><br><br>";
        else
            htm = htm + "<span style='font-size:16px; font-weight:bold;'>" + SecondaryDateRangeText + "</span><br><br>";


            $(data).each(function (i, itm) {
                var pp = Math.floor((parseInt(itm.Data) / total) * 100).toFixed(1);
                htm = htm + "<span style='display: inline-block; width:150px; font-size:14px;' >" + itm.Caption + "</span>   <span style='display: inline-block; width:50px; font-size:14px;' >" + itm.Data + "</span>  <span style='font-size:14px;'>" + pp + "%</span><br><br>";
            });
        
        htm = htm + "<span style='display: inline-block; width:150px; font-weight:bold;' >Total</span>    <span style='font-weight:bold;'> " + total + "</span><br><br>";

        $("#" + divid).html(htm);


        if (data.length > 1)
            loadChart(data, chartDivID);
        else
            $("#" + chartDivID).css("height", "80px");
    }
    else {

        htm = "";
        if (DateRange == 1)
            htm = htm + "<span style='font-size:16px; font-weight:bold;'>" + PrimaryDateRangeText + "</span><br><br>";
        else
            htm = htm + "<span style='font-size:16px; font-weight:bold;'>" + SecondaryDateRangeText + "</span><br><br>";


        $("#" + divid).html(htm + "No Data Found");
        $("#" + chartDivID).css("height", "80px");
    }
}





function loadChart(v1, divid) {
    var chart2 = "";
    var a = 0;
        
        chart2 = new cfx.Chart();
        chart2.setGallery(cfx.Gallery.Pie);

        chart2.setDataSource(v1);

        var fields = chart2.getDataSourceSettings().getFields();

        var field1 = new cfx.FieldMap();
        field1.setName("Caption");
        field1.setUsage(cfx.FieldUsage.RowHeading);
        fields.add(field1);

        var field2 = new cfx.FieldMap();
        field2.setName("Region");
        field2.setUsage(cfx.FieldUsage.ColumnHeading);
        fields.add(field2);

        var fieldVal = new cfx.FieldMap();
        fieldVal.setName("Data");
        fieldVal.setUsage(cfx.FieldUsage.Value);
        fields.add(fieldVal);

        var crosstab = new cfx.data.CrosstabDataProvider();

        crosstab.setDataSource(chart2.getDataSource());
        chart2.setDataSource(crosstab);
        var data = chart2.getData();
        data.setSeries(1);

        chart2.getAllSeries().getPointLabels().setVisible(true);
        var titles = chart2.getTitles();
        var title = new cfx.TitleDockable();
        title.setText("");
        titles.add(title);

        chart2.getLegendBox().setVisible(true);

        var divHolder2 = document.getElementById(divid);

        //var pie = chart2.getGalleryAttributes();
        //pie.setExplodingMode(cfx.ExplodingMode.All);
        //chart2.getView3D().setEnabled(true);

        chart2.create(divHolder2);


        $(v1).each(function (i, itm) {
            chart2.getPoints().getItem(-1, i).setColor(  getOrAssignColor( itm.Caption ) );
        });

}










function loadChart2(v1, divid, yearcount) {
    var chart3 = "";
    var a = 0;
    
    chart3 = new cfx.Chart();
    chart3.setGallery(cfx.Gallery.Bar);
    chart3.setDataSource(v1.Items);
    var titles = chart3.getTitles();
    var title = new cfx.TitleDockable();
    title.setText(v1.Caption);
    titles.add(title);
    var divHolder3 = document.getElementById(divid);
    chart3.create(divHolder3);


    if (chart3.getSeries().getItem(0) != null)
        chart3.getSeries().getItem(0).getPointLabels().setVisible(true);

    if(chart3.getSeries().getItem(1) != null)
        chart3.getSeries().getItem(1).getPointLabels().setVisible(true);

    if (chart3.getSeries().getItem(2) != null)
        chart3.getSeries().getItem(2).getPointLabels().setVisible(true);
    
        
}




function getMonthIndex(itm) {
    if (itm == "January")
        return 0;
    if (itm == "February")
        return 1;
    if (itm == "March")
        return 2;
    if (itm == "April")
        return 3;
    if (itm == "May")
        return 4;
    if (itm == "June")
        return 5;
    if (itm == "July")
        return 6;
    if (itm == "August")
        return 7;
    if (itm == "September")
        return 8;
    if (itm == "October")
        return 9;
    if (itm == "November")
        return 10;
    if (itm == "December")
        return 11;
}



</script>



</asp:Content>

