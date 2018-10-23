<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="bike_list.aspx.cs" Inherits="dma_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="wrapper">

            <img src="images/plus.png" width="15px" /> <a href="bike_additem.aspx">Add New Bike</a>           
            
            <br />
            <br />



            <div class="table">
                <h1 class="heading"> <img src="images/icn-vehicle.png" width="20px" /> Bike List </h1>


                  <asp:Repeater id="tblBike" runat="server">
                    <HeaderTemplate>


                        <table>
							<thead>
								<td><b>Bike</b></td>
                                <td> </td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "Bike")%></td>
                            <td><a href='bike_additem.aspx?op=edit&id=<%# DataBinder.Eval(Container.DataItem,"id") %>'> <img width="30px" src="images/file_edit.png" /> </a> </td>
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

            <br />



</asp:Content>

