<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

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

        <script src="scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
		<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

</head>
<body  id="log">
    <form id="form1" runat="server">
    <div id="login">
    
			<img id="login-heading" src="images/logo.jpg" />
			<label>Username</label>
			<asp:TextBox runat="server" ID="txtname"></asp:TextBox>
			<br>
			<label>Password</label>
			<asp:TextBox runat="server" TextMode="Password" ID="txtpass"></asp:TextBox>
			<br>
            <asp:Button  class="button-all" runat="server" ID="txtbutton" Text="Login" style="width:250px;" onclick="txtbutton_Click" />
            <br />
            <br />
            <asp:Label ID="lblno" runat="server"></asp:Label>
    </div>


    <br />
    <br />
    


    </form>
</body>
</html>
