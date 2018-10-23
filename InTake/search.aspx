<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="wrapper">
<uc1:listing id="listing111" runat="server"  />
</div>
</asp:Content>

