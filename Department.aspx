<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="Lab3.Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<style>
    .container {
       max-width: 80%;
       margin: 0 auto;
       padding: 20px;
       background-color: #f4f4f4;
       border-radius: 8px;
       box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
       padding-bottom:100px;
    }

    .header {
      font-size: 24px;
      font-weight: bold;
      margin-bottom: 20px;
      color: #333;
  }

  .info {
      padding: 20px;
      background-color: #fff;
      border-radius: 8px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }

    .add-button {
        background-color: #4b4276;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
    }

    .add-button:hover {
        background-color: #625693;
    }

    .table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .table th,
    .table td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: left;
    }

    .table th {
        background-color: #f2f2f2;
    }

    .delete-button {
        padding: 8px 12px;
        font-size: 14px;
        margin-right: 5px;
        cursor: pointer;
        background-color: #d1b200;
        color: #fff;
        border: none;
        border-radius: 4px;
    }

    .delete-button:hover {
        background-color: #e3c747;
    }

    .lbl-error {
        color: red;
        margin-top: 10px;
        display: block;
    }
</style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="container">
        <div class="header">Department Management</div>
        <div class="info">
            <asp:Button ID="btnAddDepartment" CssClass="add-button" runat="server" Text="Add Department" OnClick="btnAddDepartment_Click" />
            <asp:Label ID="lblErrorMessageDetails" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
         <asp:GridView ID="GridViewDepartments" runat="server" AutoGenerateColumns="False" CssClass="table" EmptyDataText="No departments found"
            OnRowDeleting="GridViewDepartments_RowDeleting" DataKeyNames="DepartmentId">
            <Columns>
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                <asp:BoundField DataField="DepartmentDesc" HeaderText="Department Description" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete-button"
                            OnClientClick='<%# "return confirmDelete(\"" + Eval("DepartmentId") + "\")" %>' CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>
