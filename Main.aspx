<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="Snowboard_Shop_Online.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Snowboard Shop</title>
	<style>
		#logo 
		{
			font-size:30px;
			color:saddlebrown;
			text-align:center;
		}
		#logIn 
		{
			/*Moves button to right*/
			position:absolute;
			right:100px;
		}
		body
		{
			background-image:url("snowboard shop background.png");
			background-size:cover;
		}
		table, tr, td
		{
			border-width:1px;
			border-style:solid;
			border-color:black;

		}
        footer
        {
           color:white;
           position:absolute;
           bottom:50px;
        }
        #center{
            position:absolute;
            right:-800px;
        }
	</style>
</head>
<body>
	<form id="form1" runat="server">
	  <asp:Button ID="logIn" runat="server" Text="Log in Page" />
   </form>
   <p id="logo">Welcome to the Snowboard Shop</p><br />
	<asp:table runat="server" align="center" ID="priceTable">
		<%--Titles of columns--%>
		<asp:TableRow><asp:TableCell>Purchase Type</asp:TableCell><asp:TableCell>Price Per Amount</asp:TableCell></asp:TableRow>
	    <asp:TableRow><asp:TableCell>Snowboard Without Boots</asp:TableCell><asp:TableCell>$20 each</asp:TableCell></asp:TableRow>
		<asp:TableRow><asp:TableCell>Snowboard With Boots</asp:TableCell><asp:TableCell>$30 each</asp:TableCell></asp:TableRow>
	</asp:table>
</body>
</html>
<footer>
		<p id="center">SKATE ON THE LOVE OF SNOW.</p>
</footer>