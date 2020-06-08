<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="ReplacedForm.aspx.cs" Inherits="AppTemplate.Operations.ReplacedForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            width: 468px;
        }
        .auto-style3 {
            height: 22px;
            width: 468px;
        }
        .auto-style4 {
            width: 468px;
            height: 21px;
        }
        .auto-style5 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <center><table class="nav-justified">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label16" runat="server" Text="Customer Name:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Text="Old Meter Number:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="New Meter Number:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Phone Number:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
       <%--  <tr>
            <td class="auto-style2">
                <asp:Label ID="Label18" runat="server" Text="Supervisor:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label5" runat="server" Text="Token Nunmber:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="tokenBox" runat="server" Width="118px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="auto-style4" contenteditable="Label6">
                &nbsp;</td>
            <td class="auto-style5" contenteditable="Label6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" hidden="hidden">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
                <asp:Button ID="btnapprove" runat="server" OnClick="btnapprove_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table></center>
    
</asp:Content>
