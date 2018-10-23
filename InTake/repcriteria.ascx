<%@ Control Language="C#" AutoEventWireup="true" CodeFile="repcriteria.ascx.cs" Inherits="repocriteria" %>
<link href="scripts/ui/css/jquery-ui.css" rel="stylesheet" type="text/css" />

   <link rel="stylesheet" type="text/css" href="scripts/chart/styles/jchartfx.css" />
   <script type="text/javascript" src="scripts/chart/js/jchartfx.system.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.coreBasic.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.data.js"></script>
   <script type="text/javascript" src="scripts/chart/js/jchartfx.advanced.js"></script>


                    <table>

                        <tr>    <td colspan="2" ><span style="font-weight:bold;">Primary Date Range</span> </td>    </tr>

                        <tr class="DateCriteria1" style="display:none;">    <td><b>Date From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate"></asp:TextBox>      </td>    <td> <b>Date To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate"></asp:TextBox> </td>   </tr>
                        
                        
                        <tr class="DateCriteria2" style="display:none;">    <td><b>From</b></td>    
                            <td>   
                                <asp:DropDownList style="font-size:18px;" runat="server" ID="month1"><asp:ListItem Text="January" value="1"></asp:ListItem><asp:ListItem Text="February" value="2"></asp:ListItem><asp:ListItem Text="March" value="3"></asp:ListItem><asp:ListItem Text="April" value="4"></asp:ListItem><asp:ListItem Text="May" value="5"></asp:ListItem><asp:ListItem Text="June" value="6"></asp:ListItem><asp:ListItem Text="July" value="7"></asp:ListItem><asp:ListItem Text="August" value="8"></asp:ListItem><asp:ListItem Text="September" value="9"></asp:ListItem><asp:ListItem Text="October" value="10"></asp:ListItem><asp:ListItem Text="November" value="11"></asp:ListItem><asp:ListItem Text="December" value="12"></asp:ListItem></asp:DropDownList>   &nbsp;&nbsp;  <asp:DropDownList style="font-size:18px;" runat="server" ID="yearlist1"></asp:DropDownList>   
                            </td>
                            
                            <td> <b>Date To</b> </td>    <td> 
                                <asp:DropDownList style="font-size:18px;" runat="server" ID="month2"><asp:ListItem Text="January" value="1"></asp:ListItem><asp:ListItem Text="February" value="2"></asp:ListItem><asp:ListItem Text="March" value="3"></asp:ListItem><asp:ListItem Text="April" value="4"></asp:ListItem><asp:ListItem Text="May" value="5"></asp:ListItem><asp:ListItem Text="June" value="6"></asp:ListItem><asp:ListItem Text="July" value="7"></asp:ListItem><asp:ListItem Text="August" value="8"></asp:ListItem><asp:ListItem Text="September" value="9"></asp:ListItem><asp:ListItem Text="October" value="10"></asp:ListItem><asp:ListItem Text="November" value="11"></asp:ListItem><asp:ListItem Text="December" value="12"></asp:ListItem></asp:DropDownList>   &nbsp;&nbsp;  <asp:DropDownList style="font-size:18px;" runat="server" ID="yearlist2"></asp:DropDownList>   
                            </td>   
                        </tr>
                        
                        
                        
                        <tr id="viewbydiv"><td>View By</td> <td><asp:DropDownList ID="ddViewBy"  style="font-size:18px;" OnSelectedIndexChanged="indexchange" runat="server" AutoPostBack="True">  <asp:ListItem Text="DMA" Value="1"></asp:ListItem>  <asp:ListItem Text="State" Value="2"></asp:ListItem>  </asp:DropDownList>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      <asp:DropDownList style="font-size:18px;" ID="lstDMAState" runat="server"></asp:DropDownList>             </td>  </tr>  

                        <tr class="CompareDateRangesTR">    <td colspan="2" style="vertical-align:middle;">  <asp:CheckBox runat="server" ID="chkCompare" />  <span style="font-weight:bold">Compare with secondary date range</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    </td>    </tr>
                        <tr class="CompareDateRangesTR">    <td><b>Date From</b></td>    <td>  <asp:TextBox runat="server" ID="txtFromDate2"></asp:TextBox>      </td>    <td> <b>Date To</b> </td>    <td> <asp:TextBox runat="server" ID="txtToDate2"></asp:TextBox> </td>   </tr>

                        <tr>
                            <tr class="CompareDateRangesTR">    <td colspan="2" style="vertical-align:middle;"> <asp:CheckBox ID="chkIncludeSignedReports" runat="server" /> <span style="font-weight:bold"> Show only Signed cases </span>  </td> </tr>
                        </tr>

                    </table>

                    

                    <br />
                    <br />



    <script language="javascript" type="text/javascript">
        $("#<%= txtFromDate.ClientID %>").datepicker();
        $("#<%= txtToDate.ClientID %>").datepicker();
        $("#<%= txtFromDate2.ClientID %>").datepicker();
        $("#<%= txtToDate2.ClientID %>").datepicker();


        var ClientObjectNameOfddViewBy = "<%= ddViewBy.ClientID %>";
        var ClientObjectNameOflstDMAState = "<%= lstDMAState.ClientID %>";
    </script>


