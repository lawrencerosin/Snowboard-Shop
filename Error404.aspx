<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Error404.aspx.vb" Inherits="Snowboard_Shop_Online.Error404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Doesn't Exist</title>
    <script>
        function ShowCurrentURL() {
            document.getElementById("url").innerHTML = window.location.href;
        }
    </script>
</head>
<body style="background-color:lightgray" onload="ShowCurrentURL()">
    <h1>
        The page with the address <span id="url"></span>doesn't exist.<br /> 
        Double check your url to make sure there are no spelling or grammar errors
    </h1>
    <h1>If you're sure there are no spelling or grammar errors, <br />
        then the page was either gotten rid of, its url changed, or there are errors in its code.</h1>
    <a href="Main.aspx" style="background-color:blue; color:yellow">Return to Home Page</a>
</body>
</html>
