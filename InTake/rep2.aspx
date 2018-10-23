<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="rep2.aspx.cs" Inherits="rep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<div class="wrapper">

    <h3>Year Report</h3>
    <b>Select Year</b>&nbsp;&nbsp;&nbsp;      
    <asp:DropDownList style="font-size:18px;" runat="server" ID="drStartingYear" 
        Height="20px" 
        Width="115px">   </asp:DropDownList>   
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
    
    <asp:Button runat="server" Text="Generate Report  " ID="repo" 
        onclick="repo_Click" />

    <br />
    <br />

<script language="javascript" type="text/javascript">

    function f4() {
        window.open("printrepo2.aspx?year=" + $("#<%= drStartingYear.ClientID %>").val());
    }

</script>




<asp:Panel runat="server" ID="pnlitm" Visible="false">

<span style='border:black 1px solid; padding:8px; margin-right:8px; width:8%; display:inline-block; float:left;  cursor:pointer;' onclick='f4()'> <img src='images/pri.png' width='17px'> &nbsp;Print</span> 
<br />
<br />

    <div class="table">
        <h1 class="heading"> Monthly Totals </h1>

                <table>
				    <thead><tr>
					    <td>Jan</td>
                        <td>Feb</td>
                        <td>Mar</td>
                        <td>Apr</td>
                        <td>May</td>
                        <td>Jun</td>
                        <td>Jul</td>
                        <td>Aug</td>
                        <td>Sep</td>
                        <td>Oct</td>
                        <td>Nov</td>
                        <td>Dec</td>
                        <td>Total</td>
                    </tr></thead>
			    <tbody>
                        <tr>
                            <asp:Literal runat="server" ID="litMonthlyTotal"></asp:Literal>
                        </tr>

                </tbody>

                </table>

        </div>




<br /><br />




    <div class="table">
        <h1 class="heading"> DMA Totals </h1>

                <asp:Repeater id="tblLst" runat="server">
                    <HeaderTemplate>

                        <table>
							<thead>
                                <td style="width:150px;"></td>
					            <td>Jan</td>
                                <td>Feb</td>
                                <td>Mar</td>
                                <td>Apr</td>
                                <td>May</td>
                                <td>Jun</td>
                                <td>Jul</td>
                                <td>Aug</td>
                                <td>Sep</td>
                                <td>Oct</td>
                                <td>Nov</td>
                                <td>Dec</td>
                                <td>Total</td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "dmaname")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "jan")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "feb")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "mar")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "apr")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "may")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "june")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "july")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "agu")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "sept")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "oct")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "nov")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "dec")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "total")%></td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

        </div>








<br /><br />




    <div class="table">
        <h1 class="heading"> Referral Sources Totals </h1>

                <asp:Repeater id="Repeater1" runat="server">
                    <HeaderTemplate>

                        <table>
							<thead>
                                <td  style="width:150px;"></td>
					            <td>Jan</td>
                                <td>Feb</td>
                                <td>Mar</td>
                                <td>Apr</td>
                                <td>May</td>
                                <td>Jun</td>
                                <td>Jul</td>
                                <td>Aug</td>
                                <td>Sep</td>
                                <td>Oct</td>
                                <td>Nov</td>
                                <td>Dec</td>
                                <td>Total</td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "ReferralSource")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "jan")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "feb")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "mar")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "apr")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "may")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "june")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "july")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "agu")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "sept")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "oct")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "nov")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "dec")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "total")%></td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

        </div>









<br /><br />




    <div class="table">
        <h1 class="heading"> Case Type Totals </h1>

                <asp:Repeater id="Repeater2" runat="server">
                    <HeaderTemplate>

                        <table>
							<thead>
                                <td  style="width:150px;"></td>
					            <td>Jan</td>
                                <td>Feb</td>
                                <td>Mar</td>
                                <td>Apr</td>
                                <td>May</td>
                                <td>Jun</td>
                                <td>Jul</td>
                                <td>Aug</td>
                                <td>Sep</td>
                                <td>Oct</td>
                                <td>Nov</td>
                                <td>Dec</td>
                                <td>Total</td>
                            </thead>

					    <tbody>

                    </HeaderTemplate>


                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "Injury")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "jan")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "feb")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "mar")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "apr")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "may")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "june")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "july")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "agu")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "sept")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "oct")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "nov")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "dec")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "total")%></td>
                        </tr>
                    </ItemTemplate>


                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

        </div>









</asp:Panel>





</div>


</asp:Content>

