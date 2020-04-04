<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Change_Password.aspx.vb" Inherits="Snowboard_Shop_Online.Update_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Your Password</title>
    <style>
        body
        {
            background-color:blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
          <asp:TextBox ID="usernameBox" runat="server"></asp:TextBox><br />
          <asp:Label ID="Label2" runat="server" Text="Old Password:"></asp:Label>
          <asp:TextBox ID="oldPasswordBox" runat="server"></asp:TextBox><br />
          <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
          <asp:TextBox ID="newPasswordBox" runat="server"></asp:TextBox><br />
          <asp:Label ID="Label4" runat="server" Text="Confirm New Password:"></asp:Label>
          <asp:TextBox ID="confirmNewPasswordBox" runat="server"></asp:TextBox><br />
            <asp:Button ID="changePassword" runat="server" Text="Change Password" />
        </div>
    </form>
</body>
</html>
