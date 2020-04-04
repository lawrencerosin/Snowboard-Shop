<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Forgot_Password.aspx.vb" Inherits="Snowboard_Shop_Online.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="usernameBox" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Send Password" />
        </p>
    </form>
</body>
</html>
