<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="changestatus.aspx.cs" Inherits="changestatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<div class="wrapper">

<div class="table">
    
    <h1 class="heading"> Change Status </h1>



<table>

    <tr>
            <td style="width:150px;">Select Status  </td>  <td>  <asp:DropDownList style="font-size:18px;" runat="server" ID="drStatus"></asp:DropDownList>  &nbsp;&nbsp;&nbsp;&nbsp;        <span style="color:Red;">  <asp:Label ID="lblstat" runat="server"></asp:Label> </span>      </td>
    </tr>
    
    <tr >           
            <td style="vertical-align:top; line-height:normal;">Comments </td>  
            <td>    
                <asp:TextBox ID="txtcommets" runat="server" TextMode="MultiLine" Rows="100" Columns="100"></asp:TextBox> 
                &nbsp;&nbsp;&nbsp;
                <span style="color:Red;"> <asp:Label ID="txtcom" runat="server"></asp:Label> </span>
            </td>
    </tr>

    

    <tr><td colspan="2"><asp:Button ID="btn" runat="server" Text="     Save       " onclick="btn1_Click" />  <asp:Button ID="Button1" runat="server" Text="     Cancel       " onclick="btn2_Click" />  </td></tr>

</table>

</div>


</div>

</asp:Content>

