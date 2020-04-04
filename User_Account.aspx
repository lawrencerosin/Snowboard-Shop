<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="User_Account.aspx.vb" Inherits="Snowboard_Shop_Online.User_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Account</title>
    <style>
        body
        {
            background-color:yellow;
        }
    </style>
    <script>
        function SaveToFile() {
            var fileName = prompt("What do you want the name of the file to be?");
            var dataFile = new XMLHttpRequest();
            dataFile.open("POST", fileName, true);
            dataFile.onreadystatechange = function () {
       //         if (dataFile.status == 200 && dataFile.readyState == 4) {
                    var contents = document.getElementById("renterInfo");
                    alert(contents.textContent);
               // }
            };
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
		<asp:Label ID="welcoming" runat="server" Text=""></asp:Label>
		<asp:Button ID="Button1" runat="server" style="position:absolute; right:-100px;" Text="Sign Out" />
		<div>
         
		<asp:Label ID="Label1" runat="server" Text="Day in Business"></asp:Label>
		<asp:TextBox ID="dayBox" runat="server"></asp:TextBox><br />
		<asp:Label ID="Label2" runat="server" Text="Snowboards Purchased Without Boots"></asp:Label>
		<asp:TextBox ID="noBootsBox" runat="server"></asp:TextBox><br />
		<asp:Label ID="Label3" runat="server" Text="Snowboards Purchased With Boots"></asp:Label>
		<asp:TextBox ID="bootsBox" runat="server"></asp:TextBox><br />
			<asp:Button ID="calculateRent" runat="server" Text="Rent the Snowboards" />
            <asp:Button ID="save" runat="server" Text="Save" OnClientClick="SaveToFile()"/>
		
			<asp:GridView ID="renterInfo" runat="server" AutoGenerateColumns="False" Height="213px">
				<Columns>
					<asp:BoundField HeaderText="Day in Business" ReadOnly="True" />
					<asp:BoundField HeaderText="Snowboards Rented Without Boots" ReadOnly="True" />
					<asp:BoundField HeaderText="Snowboards Rented With Boots" ReadOnly="True" />
					<asp:BoundField HeaderText="Day's Fee For Snowboards Without Boots" ReadOnly="True" />
					<asp:BoundField HeaderText="Day's Fee For Snowboards With Boots" ReadOnly="True" />
					<asp:BoundField HeaderText="Total Day's Fee" ReadOnly="True" />
				</Columns>
			</asp:GridView>
        </div>	
    </form>
</body>
</html>
