<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="dma_list.aspx.cs" Inherits="dma_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            
<div class="wrapper">

            
            <img src="images/plus.png" width="15px" /> <a href="dma_additem.aspx">Add New DMA</a>           
            
            <br />
            <br />


            <div class="table">
                <h1 class="heading"> <img src="images/icn-dma.png" width="20px" /> DMA Region List </h1>


                <asp:Repeater id="tblCus" runat="server">
                    <HeaderTemplate>

                        <table>
							<thead>
								<td><b>DMA Region</b></td>
                                <td> </td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "dmaname")%></td>
                            <td><a href='dma_additem.aspx?op=add&id=<%# DataBinder.Eval(Container.DataItem,"id") %>'> <img width="30px" src="images/file_edit.png" /> </a> </td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                
                <asp:Literal ID="litPaging" runat="server"></asp:Literal>


            </div>
            

            <br />

</div>

</asp:Content>

