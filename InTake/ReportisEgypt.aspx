<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="ReportisEgypt.aspx.cs" Inherits="ReportisEgypt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">
    
    <table>
        <tr class="CompareDateRangesTR">    <td><b>Date From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> <b>Date To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>
    </table>
    <br />

    <table>    
        <tr>
            <td>
                <asp:Button ID="ttn" runat="server" Text="Generate Report     " onclick="ttn_Click" />
                <br />
                <br />
                <span style="font-weight:bold;">Results</span>
            </td>
        </tr>

        <tr>
            <td style="width:70%;"><asp:Label runat="server" ID="lblData"></asp:Label></td>            
        </tr>
    </table>

    
    
    <br />
    <br />

    <asp:Label id="lblcsv" runat="server"></asp:Label>
    
</div>

</asp:Content>

