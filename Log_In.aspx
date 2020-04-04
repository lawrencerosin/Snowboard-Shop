<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Log_In.aspx.vb" Inherits="Snowboard_Shop_Online.Log_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Sign In</title>
</head>
<body style="background-color:blue">
    <form id="form1" runat="server">
        <div>
			<asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
			<asp:TextBox ID="usernameBox" runat="server"></asp:TextBox><br />
			<asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
			<asp:TextBox ID="passwordBox" TextMode="Password" runat="server"></asp:TextBox><br />
			<asp:Button ID="signIn" runat="server" Text="Sign In" />
			<asp:Button ID="createAccount" runat="server" Text="Create Account" /><br />
			<asp:Button ID="forgotPassword" runat="server" Text="Forgot Password" />
			<asp:Button ID="changePassword" runat="server" Text="Change Password" />
        </div>
    </form>
</body>
</html>
