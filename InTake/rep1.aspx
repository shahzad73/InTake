<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="rep1.aspx.cs" Inherits="rep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="wrapper">

    <h3>Agent Performance Report</h3>
    <b>Starting Year</b>&nbsp;&nbsp;      <asp:DropDownList style="font-size:18px; height:30px;" 
        runat="server" ID="drYear" Height="17px" 
        Width="98px">  <asp:ListItem Text="1990" Value="1990"></asp:ListItem> </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <b>Month</b>&nbsp;&nbsp;      <asp:DropDownList style="font-size:18px; height:30px;" 
        runat="server" ID="drmonth" Height="17px" 
        Width="98px"> 

            <asp:ListItem Text="January" value="1"></asp:ListItem>
            <asp:ListItem Text="February" value="2"></asp:ListItem>
            <asp:ListItem Text="March" value="3"></asp:ListItem>
            <asp:ListItem Text="April" value="4"></asp:ListItem>
            <asp:ListItem Text="May" value="5"></asp:ListItem>
            <asp:ListItem Text="June" value="6"></asp:ListItem>
            <asp:ListItem Text="July" value="7"></asp:ListItem>
            <asp:ListItem Text="August" value="8"></asp:ListItem>
            <asp:ListItem Text="September" value="9"></asp:ListItem>
            <asp:ListItem Text="October" value="10"></asp:ListItem>
            <asp:ListItem Text="November" value="11"></asp:ListItem>
            <asp:ListItem Text="December" value="12"></asp:ListItem>
        
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ttn" runat="server" Text="Generate Report     " 
        onclick="ttn_Click" />


    <br />
    <br />
    <br />
    <br />


    <asp:Literal runat="server" ID="repo"></asp:Literal>
       


<script language="javascript" type="text/javascript">

    function f4() {
        window.open ("printrepo1.aspx?mon=" + $("#<%= drmonth.ClientID %>").val() + "&year=" + $("#<%= drYear.ClientID %>").val() + "&month=" + $("#<%= drmonth.ClientID %> option:selected").text());
    }


    function ShowUserCases(uid, month, year, dmaid, recs) {
        
        /*
            recs
            1 = only  YEAR  records to show of the agent
            2 = only  Previous YEAR   records to show of the agent
            3 = show both Year and Previus YEAR recoeds of the agent 
        */

        window.open("rep1_agentrecs.aspx?uid=" + uid + "&month=" + month + "&year=" + year + "&dmaid=" + dmaid + "&recs=" + recs);   
    }



</script>



</div>


</asp:Content>

