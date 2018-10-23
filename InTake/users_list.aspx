<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="users_list.aspx.cs" Inherits="users_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="wrapper">

            <img src="images/plus.png" width="15px" /> <a href="users_additem.aspx">Add New User</a>           
            
            <br />
            <br />


            <div class="table">
                <h1 class="heading"> <img src="images/icn-user.png" width="20px" /> System User List </h1>

                        <asp:Repeater id="tblUser" runat="server" OnItemDataBound="repeaterResult_ItemDataDataBound">

                            <HeaderTemplate>

                                <table>
							        <thead>
                                        <td><b>Name</b></td>
                                        <td><b>Email</b></td>
                                        <td><b>Phone</b></td>
                                        <td><b>Username</b></td>
                                        <td><b>Status</b></td>
                                        <td> </td>
                                    </thead>
					            <tbody>

                            </HeaderTemplate>


                            <ItemTemplate>
                                <tr>
                                    <td width="25%"><%# DataBinder.Eval(Container.DataItem, "firstname")%> <%# DataBinder.Eval(Container.DataItem, "lastname")%></td>
                                    <td width="20%"><%# DataBinder.Eval(Container.DataItem,"email") %></td>
                                    <td width="15%"><%# DataBinder.Eval(Container.DataItem,"phone") %></td>
                                    <td width="15%"><%# DataBinder.Eval(Container.DataItem,"username") %></td>
                                    <td width="10%"><asp:Literal runat="server" ID="ltlOption"> </asp:Literal> </td>
                                    <td width="5%"><a href='users_additem.aspx?op=add&id=<%# DataBinder.Eval(Container.DataItem,"id") %>'> <img width="30px" src="images/file_edit.png" /> </a> </td>
                                </tr>
                            </ItemTemplate>


                            <FooterTemplate>
                                </table>
                            </FooterTemplate>

                        </asp:Repeater>

                    <asp:Literal ID="litPaging" runat="server"></asp:Literal>
            </div>



    </div>


</asp:Content>

