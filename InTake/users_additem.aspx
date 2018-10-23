<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="users_additem.aspx.cs" Inherits="listingadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">

            <div class="table">
                <h1 class="heading"><asp:Label ID="lblText" runat="server"></asp:Label> </h1>
            

                    <table>
                        <tr><td></td></tr>
                        <tr><td>

                                <table>
                                    
                                    <tr><td>First Name</td> <td><asp:TextBox runat="server" ID="txtfName"></asp:TextBox> <asp:Label runat="server" ID="lbltxtfName"></asp:Label></td></tr>  

                                    <tr><td>Last Name </td> <td> <asp:TextBox runat="server" ID="txtlName"></asp:TextBox> </td></tr>

                                    <tr><td>Phone </td> <td> <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox> </td></tr>

                                    <tr><td>Email </td> <td> <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox> </td></tr>

                                    <tr><td>Username </td> <td> <asp:TextBox runat="server" onkeyup="javascript:RemoveSpecialChar(this)" ID="txtUserName"></asp:TextBox> <asp:Label runat="server" ID="lbltxtUserName"></asp:Label></td></tr>

                                    <tr><td>Status </td> <td> <asp:DropDownList runat="server" style="font-size:18px; width:100px;" ID="drStatus">    <asp:ListItem value="1">Active</asp:ListItem> <asp:ListItem value="0">Disable</asp:ListItem>    </asp:DropDownList></td></tr>

                                    <tr><td>Role </td> <td> <asp:DropDownList runat="server" style="font-size:18px;  width:100px;" ID="drRole">  <asp:ListItem value="1">Active</asp:ListItem> <asp:ListItem value="2">Disable</asp:ListItem> </asp:DropDownList>   </td></tr>                             

                                    <tr><td>Password</td> <td>  <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox> <asp:Label runat="server" ID="lbltxtPassword"></asp:Label></td></tr>

                                    <tr><td>ReType Password</td> <td>  <asp:TextBox runat="server" ID="txtRePass"></asp:TextBox> <asp:Label runat="server" ID="lblpasserror"></asp:Label></td></tr>

                                    
                                </table>




                                
                                <asp:Button runat="server" ID="btn1" onclick="btn1_Click" Text="Save  "  />
                                <asp:Button runat="server" ID="Button1" onclick="btn2_Click" Text="Cancel   "  />


                        </td></tr>                   
                        <tr><td></td></tr>
                     </table>


            </div>

</div>


<script language="javascript" type="text/javascript">
    function RemoveSpecialChar(txtName) {
        if (txtName.value != '' && txtName.value.match(/^[\w ]+$/) == null) {
            txtName.value = txtName.value.replace(/[\W]/g, '');
        }
    }
</script>

</asp:Content>

