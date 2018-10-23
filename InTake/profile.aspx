<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">
                <div class="table">
                <h1 class="heading"> Edit profile and password </h1>
            

                    <table>
                        <tr><td></td></tr>
                        <tr><td>

                                <table>
                                    
                                    <tr><td>First Name</td> <td><asp:TextBox runat="server" ID="txtfName"></asp:TextBox> <asp:Label runat="server" ID="lbltxtfName"></asp:Label></td></tr>  

                                    <tr><td>Last Name </td> <td> <asp:TextBox runat="server" ID="txtlName"></asp:TextBox> </td></tr>

                                    <tr><td>Phone </td> <td> <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox> </td></tr>

                                    <tr><td>Email </td> <td> <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox> </td></tr>

                                    <tr><td>UserName </td> <td> <asp:Label runat="server" ID="lbltxtUserName"></asp:Label></td></tr>

                                    <tr><td>Password</td> <td>  <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox></tr>
                                
                                    <tr><td>ReType Password</td> <td>  <asp:TextBox runat="server" ID="txtRePass"></asp:TextBox> <asp:Label runat="server" ID="lblpasserror"></asp:Label></td></tr>

                                </table>




                                
                                <asp:Button runat="server" ID="btn1" onclick="btn1_Click" Text="Save  "  />



                        </td></tr>                   
                        <tr><td></td></tr>
                     </table>


            </div>
</div>

</asp:Content>

