<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="listingformsothers.aspx.cs" Inherits="listingformsothers" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />

<div class="wrapper">

<h3><asp:Label runat="server" ID="lblType"></asp:Label></h3>


Classification &nbsp;&nbsp;<asp:DropDownList runat="server" id="drclassification" AutoPostBack="True" style="font-size:18px"
        onselectedindexchanged="drstatus_SelectedIndexChanged" Width="240px"></asp:DropDownList>

<br />
<br />

<div style="border:1px solid black; padding-top:10px;">

<table>

        <tr>    <td>DMA</td>    <td><asp:DropDownList style="font-size:16px" runat="server" ID="drDMA"></asp:DropDownList></td>    <td></td><td></td>    </tr>  

        <tr>    <td>Taken Date From</td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> Taken To Date </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>

        <tr>    <td>First Name</td>    <td> <asp:TextBox runat="server" ID="txtfname"></asp:TextBox>               </td>    <td> Last Name </td>    <td> <asp:TextBox runat="server" ID="txtlname"></asp:TextBox> </td>   </tr>

        <tr>    <td>Other Fields</td>    <td> <asp:TextBox runat="server" ID="txtOthers"></asp:TextBox>               <td style="vertical-align:top;">Remote Only</td>   <td><asp:CheckBox runat="server" ID="chkegy" /> </td>   </tr>

        <tr>    <td><h3><asp:Button ID="btnButton" runat="server" Text="Search  " onclick="btnButton_Click"/></h3></td>    <td></td>    <td></td><td></td>    </tr>  
</table>
</div>

<br />

<uc1:listing id="listing111" runat="server"  />



<script language="javascript" type="text/javascript">
    $("#<%= txtFromDate.ClientID %>").datepicker();
    $("#<%= txtToDate.ClientID %>").datepicker();
</script>

</div>


</asp:Content>

