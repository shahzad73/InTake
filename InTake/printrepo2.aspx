<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printrepo2.aspx.cs" Inherits="printreport2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta http-equiv="Content-Type" content="text/html; charset=UTF=8" />
		<meta name="viewport" content="width=device-width, maximum-scale=1.0, minimum-scale=1.0, initial-scale=1.0" />

		<title>Levenbaum Trachtenberg Intake Management System</title>

		<link rel="stylesheet" type="text/css" href="styles/reset.css" />
		<link rel="stylesheet" type="text/css" href="styles/style.css" />
		<link rel="stylesheet" type="text/css" href="styles/screen_layout_large.css" />
		<link rel="stylesheet" type="text/css" media="only screen and (min-width:50px) and (max-width:550px)" href="styles/screen_layout_small.css" />
		<link rel="stylesheet" type="text/css" media="only screen and (min-width:551px) and (max-width:800px)" href="styles/screen_layout_medium.css" />
		<!--[if lt IE 9]>
		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
		<![endif]-->

		<link rel="shortcut icon" href="/favicon.ico" />
		<link rel="apple-touch-icon" href="/apple-touch-icon.png" />
</head>
<body>
    <form id="form1" runat="server">

    

<br />
<br />

<div class="wrapper">
    <h3>Year Report ( <asp:Literal runat="server" ID="ll"></asp:Literal> )</h3>

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


</div>





    </form>
</body>
</html>
