<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Lab3.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        /* regis.css */

        body {
            margin: 0;
            font-family: 'Josefin Sans', sans-serif;
            background-color: #f3f5f9;
        }

        .profile-container {
            width: 100%;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        h2 {
            margin: 0 0 20px;
            font-family: 'Galdeano-Regular', 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            position: relative;
            font-size: 24px;
            text-align: center;
        }

        h2::after {
            content: '';
            display: block;
            width: 100px;
            height: 2px;
            background-color: #4b4276;
            margin-top: 8px;
            position: absolute;
            left: 50%;
            transform: translateX(-50%);
        }

        label {
            size: 14px;
            display: block;
            margin-top: 10px;
            margin-bottom: 2px;
            font-weight: 500;
            text-align: left;
        }

        input,
        select {
            width: 100%;
            padding: 10px;
            margin: 8px 0;
            border: 1px solid #ccc;
            border-radius: 8px;
            box-sizing: border-box;
        }

        .edit-button {
            width: 100%;
            margin-top: 20px;
            padding: 10px;
            background-color: #4b4276;
            color: white;
            border: none;
            border-radius: 25px;
            cursor: pointer;
        }

        .save-button {
            width: 100%;
            margin-top: 20px;
            padding: 10px;
            background-color: #008CBA;
            color: white;
            border: none;
            border-radius: 25px;
            cursor: pointer;
        }

        .messageLabel {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="profile-container">
        <h2>Hello <%= Session["Username"] %></h2>
        <div>
            <asp:Label ID="lblCrewId" runat="server" Text="Crew ID: "></asp:Label>
            <asp:TextBox ID="txtCrewId" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblFullName" runat="server" Text="Full Name: "></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDepartment" runat="server" Text="Department: "></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblUserRole" runat="server" Text="User Role: "></asp:Label>
            <asp:TextBox ID="txtUserRole" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="edit-button" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="save-button" OnClick="btnSave_Click" />
    </div>
</asp:Content>
