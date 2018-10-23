<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                <div id="menu">

					<ul class="menu">
						<li>
							<a href="home.aspx?op=NewInTake"><img src="images/icn-new.png" /><span class="text">New Intake Form</span></a>
						</li>
						<li>
							<a href="listingforms.aspx"><img src="images/icn-view.png" /><span class="text">Find Cases</span></a>
						</li>
					</ul>


                    <asp:Panel ID="p1" runat="server">
					    <ul class="menu">
						    <li>
							    <a href="dma_list.aspx"><img src="images/icn-dma.png" /><span class="text">DMA</span></a>
						    </li>
						    <li>
							    <a href="vehicle_list.aspx"><img width="65px" src="images/icn-vehicle.png" /><span class="text">Vehicle Makes</span></a>
						    </li>
						    <li>
							    <a href="classification_list.aspx"><img src="images/icn-injuries.png" /><span class="text">Classifications</span></a>
						    </li>
						    <li>
                                <a href="refeeral_list.aspx"><img width="65px" src="images/ref.png" /><span class="text">Referral Types</span></a>
						    </li>

						    <li>
                                <a href="bike_list.aspx"><img width="65px" src="images/bike.png" /><span class="text">Bikes</span></a>
						    </li>
					    </ul>
                    </asp:Panel>


                    <asp:Panel ID="p2" runat="server">
					    <ul class="menu">
						    <li>
							    <a href="users_list.aspx"><img width="79px" src="images/icn-user.png" /><span class="text">User Management</span></a>
						    </li>
						    <li>
                                <a href="reports.aspx"><img width="79px" src="images/reports.png" /><span class="text">Reports</span></a>
                            </li>
                        </ul>

                    </asp:Panel>

                    </div>
                    
                    <div class="wrapper">
                        <uc1:listing id="listing111" runat="server"   />
                    </div>


</asp:Content>