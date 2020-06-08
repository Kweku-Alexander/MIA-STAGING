<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="District.aspx.cs" Inherits="AppTemplate.Operations.Selete_District.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
          <table class="auto-style10">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>SELECT DISTRICT</legend></legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px" Width="226px">
        <table class="style1">
                
                    <tr>
                        <td class="auto-style11">District:</td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="drop_district" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="140px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style1"></td>
                    </tr>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btncreate" runat="server" OnClick="btncreate_Click" Text="go" />
                        </td>
                        <td class="auto-style1">&nbsp;</td>
                        </caption>
                    </tr>
                    
                                                         
        </table>
    </asp:Panel>
                    </fieldset>

                </td>

            </tr>
       
        </center>

</asp:Content>
