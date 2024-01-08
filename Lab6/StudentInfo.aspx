<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="Lab3.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <H2>Student Info</H2> <br /><br />
    <asp:Button ID="AddNew" Text="Add New Student" runat="server" OnClick="ButtonAddNew_Click" />&nbsp;
    <br /><br />
    <div>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
    OnRowDataBound="GridView1_RowDataBound"
    OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
    OnRowDeleting="GridView1_RowDeleting"
    AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"
    DataKeyNames="student_id">
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <Columns>
        <asp:BoundField DataField="name" HeaderText="Student Name" />
        <asp:BoundField DataField="student_id" HeaderText="Student ID" />
        <asp:BoundField DataField="course" HeaderText="Course" />
        <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30" />
        <asp:ButtonField Text="Delete" CommandName="Delete" ItemStyle-Width="30" />
    </Columns>
</asp:GridView>

        <br />
        <asp:Label ID="msg" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>
