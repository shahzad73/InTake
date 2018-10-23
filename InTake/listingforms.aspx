<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="listingforms.aspx.cs" Inherits="listingforms" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />


<div class="wrapper">

Status &nbsp;&nbsp;<asp:DropDownList runat="server" id="drstatus" AutoPostBack="True" style="font-size:18px"
        onselectedindexchanged="drstatus_SelectedIndexChanged" Width="360px"></asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Classification &nbsp;&nbsp;<asp:DropDownList runat="server" id="drclassification" AutoPostBack="True" style="font-size:18px"
        onselectedindexchanged="drstatus_SelectedIndexChanged" Width="320px"></asp:DropDownList>

<br /><br />

<div style="border:1px solid black; padding-top:10px;">
<table>

    <tr>    <td>DMA</td>    <td><asp:DropDownList style="font-size:16px" runat="server" ID="drDMA"></asp:DropDownList></td>    <td></td><td></td>    </tr>  

    <tr>    <td>Taken Date From</td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> Taken Date To </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>

    <tr>    <td>First Name</td>    <td> <asp:TextBox runat="server" ID="txtfname"></asp:TextBox>               </td>    <td> Last Name </td>    <td> <asp:TextBox runat="server" ID="txtlname"></asp:TextBox> </td>   </tr>

    <tr>    <td>Other Fields</td>    <td> <asp:TextBox runat="server" ID="txtOthers"></asp:TextBox>               <td style="vertical-align:top;">Remote Only</td>   <td><asp:CheckBox runat="server" ID="chkegy" /> </td>   </tr>

    <tr>    <td><asp:Button ID="btnButton" runat="server" Text="Search  " onclick="btnButton_Click"/></td>    <td></td>    <td></td><td></td>    </tr>  

</table>
</div>
<br />
<div style="float:right;">  Sort By &nbsp;&nbsp;&nbsp; <asp:DropDownList  AutoPostBack="True" style="font-size:16px" runat="server" ID="drfields" onselectedindexchanged="drstatus_SelectedIndexChanged">    <asp:ListItem Value="DateTaken" Text="Date Taken"></asp:ListItem>    <asp:ListItem Value="fname" Text="Name"></asp:ListItem>       <asp:ListItem Value="injury" Text="Injury Type"></asp:ListItem>     <asp:ListItem Value="ReportRegionDMAID" Text="DMA"></asp:ListItem>    <asp:ListItem Value="LastUpdated" Text="Last Updated"></asp:ListItem>     <asp:ListItem Value="Status" Text="Status"></asp:ListItem>      </asp:DropDownList>      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;         <asp:DropDownList  AutoPostBack="True" style="font-size:16px" runat="server" ID="drsort" onselectedindexchanged="drstatus_SelectedIndexChanged">   <asp:ListItem Value="asc" Text="Ascending"></asp:ListItem>  <asp:ListItem Value="Desc" Text="Decending"></asp:ListItem>    </asp:DropDownList>    </div>
<br />
<uc1:listing id="listing111" runat="server"  />

</div>

<script language="javascript" type="text/javascript">
    $("#<%= txtFromDate.ClientID %>").datepicker();
    $("#<%= txtToDate.ClientID %>").datepicker();
        

    var fldid = <%= drfields.ClientID %>.selectedIndex;
    var sort = <%= drsort.ClientID %>.selectedIndex;       



    SetHeasers(0, "spdateTaken", " Taken");
    SetHeasers(1, "spName", " Name");
    SetHeasers(2, "spType", " Injury");
    SetHeasers(3, "spDMA", " DMA");
    SetHeasers(4, "spLastUpdated", " Updated");
    SetHeasers(5, "spStatus", " Status");



    function SetHeasers(fldcheck, fldspanid, fldText)
    {
        if(fldid == fldcheck)
        {
            if(sort == 0)
            {
                $("#" + fldspanid).html("<img src='images/up.png' width='12px' />" + fldText);
                $("#" + fldspanid).attr("onclick","SortRecordsList(" + fldcheck + ", 1)");
            }
            else 
            {
                $("#" + fldspanid).html("<img src='images/down.png' width='12px' />" + fldText);
                $("#" + fldspanid).attr("onclick","SortRecordsList(" + fldcheck + ", 0)");
            }
        }
        else
        {
                $("#" + fldspanid).html("<img src='images/sorting.png' alt='Click to sort on this field' width='15px' />" + fldText);
                $("#" + fldspanid).attr("onclick","SortRecordsList(" + fldcheck + ", 1)");
        }
    }



    function SortRecordsList(fld, sort) {
        <%= drfields.ClientID %>.selectedIndex = fld;
        <%= drsort.ClientID %>.selectedIndex = sort;
        __doPostBack('<%= drfields.UniqueID  %>', '');
    }

</script>


</asp:Content>

