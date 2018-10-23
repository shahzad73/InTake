<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="ReportDatesLog.aspx.cs" Inherits="ReportDatesLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link rel="stylesheet" type="text/css" href="scripts/chart/styles/jchartfx.css" />
   <script type="text/javascript" src="scripts/chart/js/jchartfx.system.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.coreBasic.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.data.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.advanced.js"></script>
   <link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />

<div class="wrapper">
    
    <table>
        <tr class="CompareDateRangesTR">    <td><b>Date From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> <b>Date To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>


        <tr>
            <td> Include only signed records </td>   <td> <asp:CheckBox ID="chkIncludeOnlySignedRecs" runat="server" />  </td>    <td></td>  <td> </td>
        </tr>

    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp; <span style="color:Red;"> <asp:Label ID="lblmsg" runat="server"></asp:Label> </span>
    <br />
    <br />

    <table>    
        <tr>
            <td>
                <asp:Button ID="ttn" runat="server" Text="Generate Report     " onclick="ttn_Click" />
                <br />
                <br />
                <span style="font-weight:bold;">Results</span>
            </td>

            <td>
                <asp:Button ID="Button122" runat="server" Text="Save Report Date     " onclick="ttn_Click2" />
                <br />
                <br />
                <span style="font-weight:bold; font-family:Arial;">Previous Report Dates</span>
            </td>
        </tr>

        <tr>
            <td style="width:70%;"><asp:Label runat="server" ID="lblData"></asp:Label></td>
            <td><asp:Label runat="server" ID="lblDates"></asp:Label></td>            
        </tr>
    </table>

    
    
    <br />
    <br />

    <asp:Label id="lblcsv" runat="server"></asp:Label>
    
</div>



    <script language="javascript" type="text/javascript">
        $("#<%= txtFromDate.ClientID %>").datepicker();
        $("#<%= txtToDate.ClientID %>").datepicker();

     </script>

</asp:Content>

