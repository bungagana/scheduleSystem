<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Lab3.MasterPages.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <style>
       
        body, div, p, textarea, input, button {
            margin: 0;
            padding: 0;
        }

        .contact-container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }

        .contact-heading {
            font-size: 24px;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 12px;
           padding-right:24px;
        }

        label {
            display: flex;
            font-weight: bold;
        }

        input[type="text"],
        textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        textarea {
            resize: vertical; 
        }

        button {
            padding: 10px 20px;
            background-color: #007bff; 
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        button:hover {
            background-color: #0056b3; 
        }
    </style>

      <div class="contact-container">
        <h2 class="contact-heading">Contact Us</h2>
        <div class="contact-info">
            <p>If you have any questions or feedback, please feel free to contact us:</p>
            <div class="form-group">
                <label for="txtID">Student ID:</label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                       ID="rfvID" 
                       runat="server" 
                       ControlToValidate="txtID" 
                       InitialValue="" 
                       ErrorMessage="Student ID is required" 
                       ForeColor="Red">
                   </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                 
            </div>
            <div class="form-group">
                <label for="txtmesseges">Message:</label>
                <asp:TextBox ID="txtmesseges" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="contactButton" runat="server" CssClass="btn btn-primary" OnClick="submitFormContact" Text="Submit" />
                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" OnClick="cancelForm" Text="Cancel" />
            </div
        </div>
    </div>
</asp:Content>


