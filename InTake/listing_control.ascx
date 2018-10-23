<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listing_control.ascx.cs" Inherits="listing" %>

            Record Count : <asp:Literal ID="litrcnt" runat="server"></asp:Literal>
            <br /><br />
            <div class="table">
                <h1 class="heading"> <img src="images/icn-dma.png" width="20px" /> <asp:Label ID="lblListingTitle" runat="server"></asp:Label> </h1>


                <asp:Repeater id="tblLst" runat="server">
                    <HeaderTemplate>

                        <table>
							<thead>
								<td><span id="spdateTaken" style="width:120px; cursor: pointer; " > Taken </span> </td>
								<td><span id="spName" style="cursor: pointer;"> Name </span></td>
								<td><span id="spType" style="cursor: pointer;"> Type </span></td>
								<td><span id="spDMA" style="cursor: pointer;"> DMA  </span></td>
								<td><span id="spLastUpdated" style="cursor: pointer;"> Updated  </span></td>
                                <td style="width:120px; cursor: pointer;"><span id="spStatus"> Status  </span></td>
                                <td></td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# string.Format("{0:M/d/yyyy}", DataBinder.Eval(Container.DataItem, "DateTaken"))%> </td>
                            <td><%# DataBinder.Eval(Container.DataItem, "fName")%> <%# DataBinder.Eval(Container.DataItem, "lName")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "injury")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "dmaname")%></td> 
                            <td><%# string.Format("{0:M/d/yyyy}", DataBinder.Eval(Container.DataItem, "LastUpdated"))%> </td>
                            <td  style="width:200px;"><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                            <td><a href='intake.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>'> <img width="30px" src="images/file_edit.png" /> </a> </td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>


                <asp:Literal ID="litPaging" runat="server"></asp:Literal>







            </div>
