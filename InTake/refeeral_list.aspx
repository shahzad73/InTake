<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="refeeral_list.aspx.cs" Inherits="dma_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">


            <img src="images/plus.png" width="15px" /> <a href="refeeral_additem.aspx">Add new Referral Source</a>           
            
            <br />
            <br />


            <div class="table">

                <h1 class="heading"> <img src="images/icn-injuries.png" width="20px" />  Referral Sources </h1>


                <asp:Repeater id="tblCus" runat="server">

                
                    <HeaderTemplate>
                        <table>
							<thead>
								<td><b>Referral Source</b></td>
                                <td> </td>
                            </thead>
					    <tbody>
                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "ReferralSource")%></td>
                            <td><a href='refeeral_additem.aspx?op=edit&id=<%# DataBinder.Eval(Container.DataItem,"id") %>'> <img width="30px" src="images/file_edit.png" /> </a> </td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>

                </asp:Repeater>

                <asp:Literal ID="litPaging" runat="server"></asp:Literal>

            </div>


</div>
            

</asp:Content>

