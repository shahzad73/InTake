<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="rep3.aspx.cs" Inherits="repo3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />
<div class="wrapper">

    <h3>Status Change Report</h3>

    <table>
        <tr>
            <td style="vertical-align:top;"> <b>Select Status</b> </td> 
            <td>
                <asp:ListBox  style="font-size:18px; height:150px; width:400px;" SelectionMode="Multiple" runat="server" ID="lststatus" > </asp:ListBox>
                <br />
                <span style="color:Red"><asp:Label runat="server" ID="lblst"></asp:Label></span>
            </td>
            <td></td>
            <td></td>
        </tr>
        

        <tr>    <td><b>Taken Date From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> <b>Taken Date To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>

        <tr><td colspan="4"></td></tr>

        <tr><td colspan="4"><asp:Button ID="ttn" runat="server" Text="Generate Report     " onclick="ttn_Click" /></td></tr>

        

    </table>
    <br />
    <br />
    <br />
    <br />

     <asp:Literal runat="server" ID="repo"></asp:Literal>


<script language="javascript" type="text/javascript">
    $("#<%= txtFromDate.ClientID %>").datepicker();
    $("#<%= txtToDate.ClientID %>").datepicker();
</script>


<script language="javascript" type="text/javascript">

    function f4(s1, s2) {
        window.open("printrepo3.aspx?status=" + s1 + "&txt=" + s2 + "&df=" + $("#<%= txtFromDate.ClientID %>").val() + "&dt=" + $("#<%= txtToDate.ClientID %>").val() );
    }

</script>



</div>

</asp:Content>

