<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateSchedule.aspx.cs" Inherits="Lab3.UpdateSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
       <link rel="stylesheet" type="text/css" href="Css/create.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="main_content">
        <div class="header">Update Schedule</div>

        <div class="info">
        
            <div class="form-group">
                <asp:Label ID="lblCrewID" runat="server" Text="Crew ID:"></asp:Label>
                <asp:TextBox ID="txtCrewID" runat="server" CssClass="input" required></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblFullName" runat="server" Text="Full Name:"></asp:Label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="input" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="ddlJobRoles">Department:</label>
                 <asp:DropDownList ID="ddlJobRoles" runat="server" CssClass="input" required></asp:DropDownList>

            </div>

            <div class="form-group">
                <asp:Label ID="lblDutyTime" runat="server" Text="Duty Time (*Hour):"></asp:Label>
                <asp:TextBox ID="txtDutyTime" runat="server" CssClass="input" required></asp:TextBox>
            </div>

            <div class="form-group">
                 <label for="txtStartTime">Start Time:</label>
                 <input type="time" id="txtStartTime" runat="server" name="txtStartTime" class="input" required />

            </div>

            <div class="form-group">
                <asp:Label ID="lblEndTime" runat="server" Text="End Time:"></asp:Label>
               <input type="time" id="txtEndTime" runat="server" name="txtEndTime" class="input" required />
            </div>



            <asp:Button ID="btnUpdateSchedule" runat="server" Text="Update Schedule" CssClass="button" OnClick="btnUpdateSchedule_Click" />
        </div>
    </div>
</asp:Content>
