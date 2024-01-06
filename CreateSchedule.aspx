<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateSchedule.aspx.cs" Inherits="Lab3.CreateSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Css/create.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="main_content">
        <div class="header">Create Schedule</div>

        <div class="info">
            <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="message-panel">
                <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>

            <label for="txtFullName">Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="input" placeholder="Full Name" required></asp:TextBox>

            <label for="txtCrewID">Crew ID:</label>
            <asp:TextBox ID="txtCrewID" runat="server" CssClass="input" placeholder="Crew ID" required></asp:TextBox>

            <label for="ddlJobRoles">Department:</label>
            <asp:DropDownList ID="ddlJobRoles" runat="server" CssClass="input" required></asp:DropDownList>

            <label for="txtDutyTime">Duty Time:</label>
            <asp:TextBox ID="txtDutyTime" runat="server" CssClass="input" placeholder="Duty Time" required></asp:TextBox>

            <label for="txtStartTime">Start Time:</label>
            <input type="time" id="txtStartTime" runat="server" name="txtStartTime" class="input" required />

            <label for="txtEndTime">End Time:</label>
            <input type="time" id="txtEndTime" runat="server" name="txtEndTime" class="input" required />

            <asp:Button ID="btnSaveSchedule" runat="server" Text="Save Schedule" CssClass="button" OnClick="btnSaveSchedule_Click" />
        </div>
    </div>
</asp:Content>
