<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="home" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                <div id="menu">


					    <ul class="menu">
						    <li>
                                <a href="rep1.aspx"><img width="65px" src="images/rep1.png" /><span class="text">Agent Performance Report</span></a>
                            </li>
                            <li>
							    <a href="rep4.aspx"><img width="65px" src="images/r1.png" /><span class="text">Referral Source Notes</span></a>
						    </li>
						    <li>
							    <a href="rep2.aspx"><img width="65px" src="images/rep2.png" /><span class="text">Monthly Tracking Sheet</span></a>
						    </li>
						    <li>
							    <a href="rep3.aspx"><img width="65px" src="images/repo3.png" /><span class="text">Status Change Report</span></a>
						    </li>
                        </ul>


                        <ul class="menu">
						    <li>
							    <a href="rep5.aspx?typ=1"><img width="65px" src="images/rep_bike.png" /><span class="text">Bike Type</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=2"><img width="65px" src="images/rep_vehicle.png" /><span class="text">Vehicle Make</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=3"><img width="65px" src="images/rep-referrer.png" /><span class="text">Source of Referrer</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=4"><img width="65px" src="images/report-injury.jpg" /><span class="text">Injury Type</span></a>
						    </li>
                        </ul>



                        <ul class="menu">
						    <li>
							    <a href="rep5.aspx?typ=5"><img width="65px" src="images/rep_age.png" /><span class="text">Age of Rider</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=6"><img width="65px" src="images/rep_volume.png" /><span class="text">Case by Volume</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=7"><img width="65px" src="images/gender.png" /><span class="text">Case by Gender</span></a>
						    </li>

						    <li>
							    <a href="rep5.aspx?typ=8"><img width="65px" src="images/gender2.png" /><span class="text">DMA / State</span></a>
						    </li>
                        </ul>



                        <ul class="menu">
						    <li>
							    <a href="ReportDatesLog.aspx"><img width="65px" src="images/reports.png" /><span class="text">Signed Cases Emails</span></a>
						    </li>

						    <li>
							    <a href="ReportisEgypt.aspx"><img width="65px" src="images/reports.png" /><span class="text">Is Egypt Report</span></a>
						    </li>
                        </ul>


                    </div>
                    

</asp:Content>

