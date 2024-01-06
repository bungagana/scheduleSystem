<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Schedules.aspx.cs" Inherits="Lab3.Schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style>
        .main_content {
            max-width: 100%;
            margin: 0 auto;
            padding: 20px;
            background-color: #f4f4f4;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
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


        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .add-button {
            padding: 12px 24px;
            font-size: 16px;
            cursor: pointer;
            background-color: #594f8d;
            color: #fff;
            border: none;
            border-radius: 4px;
            text-decoration: none;s
            transition: background-color 0.3s ease;
        }

        .add-button:hover {
            background-color: #4b4276;
        }

        .edit-button, .delete-button {
            padding: 8px 12px;
            font-size: 14px;
            margin-right: 5px;
            cursor: pointer;
            background-color: #d1b200;
            color: #fff;
            border: none;
            border-radius: 4px;
            text-decoration: none;
        }

        .delete-button {
            background-color: #f44336;
        }

        .edit-button:hover, .delete-button:hover {
            background-color:#c09c0f;
        }

    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="main_content">
        <div class="header">View Schedule</div>
        <div class="info">
            <asp:Button ID="btnAddSchedule" CssClass="add-button" runat="server" Text="Add Schedule" OnClick="btnAddSchedule_Click" />
            <asp:Label ID="lblErrorMessageDetails" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            <asp:GridView ID="GridViewSchedules" runat="server" AutoGenerateColumns="False" CssClass="table" EmptyDataText="No schedules found"
                OnRowEditing="GridViewSchedules_RowEditing" OnRowDeleting="GridViewSchedules_RowDeleting" DataKeyNames="crewID">
                <Columns>
                    <asp:BoundField DataField="ScheduleId" HeaderText="No" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="CrewID" HeaderText="Crew ID" />
                    <asp:BoundField DataField="JobRoles" HeaderText="Job Roles" />
                    <asp:BoundField DataField="DutyTime" HeaderText="Duty Time (*Hour)" />
                    <asp:BoundField DataField="StartTime" HeaderText="Start Time" />
                    <asp:BoundField DataField="EndTime" HeaderText="End Time" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="edit-button" CommandName="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete-button"
                                OnClientClick='<%# "return confirmDelete(\"" + Eval("CrewID") + "\")" %>' CommandName="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
