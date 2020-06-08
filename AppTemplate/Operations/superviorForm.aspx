<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="superviorForm.aspx.cs" Inherits="AppTemplate.Operations.superviorForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <center>
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Meter Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmnuber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtcname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Telephone Number"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txttel" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style3">
                <asp:Label ID="Label7" runat="server" Text="InspectedBy"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="Inspect_text" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Supervisor Remark"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsupervisorremark" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Supervisor Remark"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Reason for Approval\Rejections"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtreason" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnapprove" runat="server" OnClick="btnapprove_Click" Text="Approve" />
                <asp:Button ID="btnreject" runat="server" Text="Reject" OnClick="btnreject_Click" />
            </td>
            <td class="auto-style2">
                <asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </center>
</asp:Content>
