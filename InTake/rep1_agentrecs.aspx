<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rep1_agentrecs.aspx.cs" Inherits="rep1_agentrecs" %>
<%@ Register TagPrefix="uc1" TagName="listing" Src="~/listing_control.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
        <uc1:listing id="listing111" runat="server"  />
        <br />
        <uc1:listing id="listing222" runat="server"  />
        </div>
    </form>
</body>
</html>
