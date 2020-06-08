<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AppTemplate.Account.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
            width: 321px;
        }
        .auto-style8 {
            width: 463px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>

        <table class="style1">
            <tr>
                <td class="auto-style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>CREATE NEW PASSWORD</legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px">
        <table class="style1">
                <tr>
                    <td>User Name:</td>
                    <td>
                        <asp:TextBox ID="txt_createUsername" runat="server" Width="156px" ></asp:TextBox>
                    </td>
                  
                    <td>
                        &nbsp;</td>
                </tr>
           
                    <caption>
                        <p>
                        </p>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btncreate" runat="server" OnClick="btncreate_Click" Text="Create Password" />
                            </td>
                            <td></td>
                            <td>
                                &nbsp;</td>
                       
                </caption>
                    
                                                         
        </table>
    </asp:Panel>
                    </fieldset>

                </td>

            </tr>
        </table>
     <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
           
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td class="auto-style6">
                        </td>
                        <td class="auto-style3">
                            <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </center>
</asp:Content>
