<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepart.aspx.cs" Inherits="Lab3.AddDepart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Department</title>
    <style>
        .form-container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f4f4f4;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-top: 50px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            font-size: 16px;
            margin-bottom: 5px;
        }

        .form-group .form-control {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .form-group .btn-save {
            background-color: #4b4276;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .form-group .btn-save:hover {
            background-color: #625693;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Add Department</h2>
            <div class="form-group">
                <label for="txtDepartmentId">Department ID:</label>
                <asp:TextBox ID="txtDepartmentId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtDepartmentName">Department Name:</label>
                <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDepartmentDescription">Department Description:</label>
                <asp:TextBox ID="txtDepartmentDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSaveDepartment" runat="server" Text="Save Department" OnClick="btnSaveDepartment_Click" CssClass="btn-save" />
            </div>
        </div>
    </form>
</body>
</html>
