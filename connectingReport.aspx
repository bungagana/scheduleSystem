<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="connectingReport.aspx.cs" Inherits="Lab3.connectingReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms"
    namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager runat="server" />
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="400px">
        </rsweb:ReportViewer>
    </div>
</asp:Content>
