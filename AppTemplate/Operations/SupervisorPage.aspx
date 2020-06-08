<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SupervisorPage.aspx.cs" Inherits="AppTemplate.Operations.SupervisorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center> <table class="nav-justified">
        <tr>
            <td>


                 <tr>
            <td class="style2" >
                <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtmnumber" runat="server"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Button" OnClick="btnsearch_Click" />
                </fieldset>
             </td>    
        </tr>


            </td>
        </tr>
        <tr>
            <td class="auto-style1">


                 <tr>
            <td class="style2" >
                <fieldset >
            <legend> METER DETAILS</legend>                 
                    
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>

                </fieldset>
             </td>    
        </tr>



            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
        </center> 
</asp:Content>
