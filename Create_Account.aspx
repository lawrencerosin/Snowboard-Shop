<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Create_Account.aspx.vb" Inherits="Snowboard_Shop_Online.Create_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Create Account</title>
	<style>
		#underline 
		{
			text-decoration:underline;
		}
		#center 
		{
			align-content:center;
		}
		ul 
		{
			display:table;
			margin:0 auto;
		}
		body 
		{
			background-color:orange;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server" align="center">

		<h1 id="underline">Password Requirements</h1>
		<ul>
			<li>Must contain capital and lowercase letters</li>
			<li>Must contain at least one number or special character</li>
			<li>Must be 10 through 20 characters long</li>
			<li>Must not be the same as your first name, last name, or username</li>
		</ul>
        <div>
			<asp:label runat="server" text="First Name:"></asp:label>
			<asp:TextBox ID="firstNameBox" runat="server"></asp:TextBox>
			<asp:CustomValidator ID="firstNameValidator" runat="server" ErrorMessage="You must put in your first name and it must contain only letters" ValidationGroup="account"></asp:CustomValidator>
			<br />
			<asp:label runat="server" text="Last Name:"></asp:label>
			<asp:TextBox ID="lastNameBox" runat="server"></asp:TextBox>
			<asp:CustomValidator ID="lastNameValidator" runat="server" ErrorMessage="You must put in your last name, and it must contain only letters" ValidationGroup="account"></asp:CustomValidator>
			<br />
			<asp:label runat="server" text="E-mail Address:"></asp:label>
			<asp:TextBox ID="emailBox" runat="server" ViewStateMode="Disabled"></asp:TextBox>
			<asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="emailBox" ErrorMessage="Not an e-mail format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="account"></asp:RegularExpressionValidator>
			<br />
			<asp:label runat="server" text="Username:"></asp:label>
			<asp:TextBox ID="usernameBox" runat="server"></asp:TextBox>
			<asp:CustomValidator ID="usernameValidator" runat="server" ErrorMessage="You didn't put in your username or this username already exists." ValidationGroup="account"></asp:CustomValidator>
			<br />
			<asp:label runat="server" text="Password:"></asp:label>
			<asp:TextBox ID="passwordBox" TextMode="Password" runat="server"></asp:TextBox>
			<asp:CustomValidator ID="passwordValidator" runat="server" ErrorMessage="You either didn't put in a password, your passwords don't match, or your password doesn't satisfy the above criteria." ValidationGroup="account"></asp:CustomValidator>
			<br />
			<asp:label runat="server" text="Confirm Password:"></asp:label>
			<asp:TextBox ID="confirmBox" TextMode="Password" runat="server"></asp:TextBox><br />
			<asp:Button ID="createAccount" runat="server" Text="Create Account" ValidationGroup="account" />
			<asp:Button ID="back" runat="server" Text="Back to Log In Page" />
        </div>
    </form>
</body>
</html>
