<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Lab3.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <table>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <H2>Update Student Info</H2>
            </td>    
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <H3></H3>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Student Name : </strong></td>
            <td>&nbsp;<asp:TextBox id="txtbox_name"  runat="server" OnTextChanged="txtbox_name_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtbox_name" ErrorMessage="Enter Studend Name" ForeColor="Red">

                </asp:RequiredFieldValidator>
            </td>
                                
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Student ID : </strong></td>
            <td>&nbsp;<asp:TextBox ID="txtbox_ID" runat="server" Enabled="false"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtbox_ID" ErrorMessage="Enter Studend ID" ForeColor="Red">

                </asp:RequiredFieldValidator>

</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Course : </strong></td>
            <td>&nbsp;<asp:DropDownList runat="server" ID="ddl_Course">
                <asp:ListItem Text="Computer Science" Value="1"></asp:ListItem>
                <asp:ListItem Text="Electrical Engineering" Value="2"></asp:ListItem>
                <asp:ListItem Text="Mechanical Engineering" Value="3"></asp:ListItem>
                <asp:ListItem Text="Architecture" Value="4"></asp:ListItem>
                <asp:ListItem Text="Electronic Engineering" Value="5"></asp:ListItem>
                <asp:ListItem Text="Technology Management" Value="6"></asp:ListItem>
                <asp:ListItem Text="Aeronautical Engineering" Value="7"></asp:ListItem>
                <asp:ListItem Text="Civil Engineering" Value="8"></asp:ListItem>
                      </asp:DropDownList>&nbsp;
                                

</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <asp:Button ID="ButtonSave" Text="Save" runat="server" OnClick="ButtonSave_Click" />&nbsp;
            <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />&nbsp;
            <asp:Button ID="ButtonDelete" Text="Delete" runat="server" OnClientClick="javascript:return confirm('Are you sure to delete this record?');" OnClick="ButtonDelete_Click" />&nbsp;
            </td>
            <td class="auto-style8">&nbsp;<asp:Label id="lblStatus" ForeColor="Red" runat="server"></asp:Label></td>
        </tr>    
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>    
    </table>
</asp:Content>
