<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab3.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link rel="stylesheet" type="text/css" href="Css/regis.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>L O G I N</h2>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="messageLabel" Visible="false"></asp:Label>

            <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Crew ID" CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Password" CssClass="input" required></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />

            <p>Don't have an account? <a href="Regis.aspx">Register</a></p>
        </div>
    </form>
</body>
</html>
