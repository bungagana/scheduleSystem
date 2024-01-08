<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regis.aspx.cs" Inherits="Lab3.Regis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link rel="stylesheet" type="text/css" href="Css/regis.css">
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>R E G I S T E R</h2>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="messageLabel" Visible="false"></asp:Label>

            <asp:TextBox ID="txtCrewId" runat="server" placeholder="Enter Crew ID" CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtFullName" runat="server" placeholder="Enter Full Name" CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter Username" CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password Min 8 character" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#?]).{8,}$" title="Password should be at least 8 characters in length and should include at least one upper case letter, one number, and one special character." CssClass="input" required></asp:TextBox>

            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="input" required></asp:TextBox>

           <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input" required OnDataBound="ddlDepartment_DataBound">
    <asp:ListItem Text="Select Department" Value="" Disabled="true" Selected="true"></asp:ListItem>
</asp:DropDownList>


            <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="input" required>
                <asp:ListItem Text="Select User Role" Value="" Disabled="true" Selected="true"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
            </asp:DropDownList>

            <div class="g-recaptcha" data-sitekey="6LddKTUpAAAAAN_NKCpMMpnHVoiP0qHvGbkj3Nys"></div>

            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="button" />
            <p>Already Have Account? <a href="Login.aspx">Login</a></p>

        </div>
    </form>
</body>
</html>
