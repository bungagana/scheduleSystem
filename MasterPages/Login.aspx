<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab3.MasterPages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style>
        
       .header {
            text-align: center;
            font-size: 20px;
            margin-top: 20px;
            margin-bottom:2px;
        }

        .profile-icon {
            text-align: center;
            margin-top: -18px;
        }

        .profile-icon img {
            width: 50px; /* Adjust the width as needed */
            height: auto;
        }

        .auto-style8 {
            padding: 5px;
        }
        .auto-style2 {
            font-weight: bold;
        }
        .auto-style3 {
            font-weight: bold;
        }
        .auto-style4 {
            padding: 5px;
        }
        .login-table {
            border-collapse:inherit;
            margin: 0 auto;
            margin-top:20px;
            margin-right:190px;
            
        }
        .login-table td {
            padding-top: 5px;
            
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
  
     <div class="header">
        <h4>Login</h4>
    </div>
    <div class="profile-icon">
        <img src="Icon-Profile.png" alt="Profile Icon">
    </div>
    <table class="login-table">
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2"><strong>Enter your ID and Password</strong></td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>ID :</strong></td>
            <td class="auto-style4">&nbsp;<asp:TextBox id="txtbox_ID" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revID"
                    runat="server"
                    ControlToValidate="txtbox_ID"
                    ValidationExpression="^[A-Za-z0-9]{6,12}$"
                    ErrorMessage="ID must be 6 to 12 characters long and contain only letters and numbers."
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Password :</strong></td>
            <td class="auto-style4">&nbsp;<asp:TextBox ID="txtbox_password" TextMode="Password"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="rfvPassword" 
                    runat="server" 
                    ControlToValidate="txtbox_password" 
                    InitialValue="" 
                    ErrorMessage="Please enter your password!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />&nbsp;
                <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click"/>&nbsp;

            </td>
            <td class="auto-style8">&nbsp;<asp:Label ID="lblStatus" ForeColor="Red" runat="server"></asp:Label></td>
        </tr>
        
    </table>

</asp:Content>
