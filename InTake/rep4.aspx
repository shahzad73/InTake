<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="rep4.aspx.cs" Inherits="rep4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />


<div class="wrapper">


            <div class="wrapper">

                    <h3>Referral Source Notes</h3>

                    <table>

                        <tr>    <td><b>Date Taken From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> <b>Date Taken To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>

                        <tr><td colspan="4" style="color:Red;"> <asp:Label ID="msg" runat="server"></asp:Label> </td></tr>

                        <tr><td colspan="4"><asp:Button ID="ttn" runat="server" Text="Generate Report     " onclick="ttn_Click" /></td></tr>
    
                    </table>

            </div>


        
        <br /><br /><br />


        <asp:Literal runat="server" ID="repo"></asp:Literal>

</div>


    <script language="javascript" type="text/javascript">
        $("#<%= txtFromDate.ClientID %>").datepicker();
        $("#<%= txtToDate.ClientID %>").datepicker();


        function f4(fd, td) {
            alert("-");
        }

    </script>

</asp:Content>

