<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="AppTemplate.Account.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            width: 368px;
        }
        .auto-style3 {
            height: 22px;
            width: 368px;
        }
        .auto-style7 {
            height: 21px;
        }
        .auto-style8 {
            width: 368px;
            height: 21px;
        }
        .auto-style10 {
            width: 535px;
        }
        .auto-style11 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
          <table class="auto-style10">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>CREATE USER</legend></legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px">
        <table class="style1">
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="txt_createUsername" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
           
                    <caption>
                        <p>
                        </p>
                        <tr>
                            <td>Telephone Number:</td>
                            <td>
                                <asp:TextBox ID="txt_createTelephone" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Role:</td>
                            <td>
                                <asp:DropDownList ID="droprole"  runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                         <tr>
                            <td>Region:</td>
                            <td>
                                 <asp:TextBox ID="login_region" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                         <tr>
                            <td class="auto-style11">District:</td>
                            <td class="auto-style11">
                                <asp:DropDownList ID="drop_district" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
                                
                            </td>
                            <td class="auto-style11"></td>
                            <td class="auto-style11"></td>
                        </tr>
                                    <%--             <tr>
                            <td>Region:</td>
                            <td>
                                <asp:DropDownList ID="drop_district" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btncreate" runat="server" OnClick="btncreate_Click" Text="Create User" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
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
        <td class="auto-style2">
          <center>   
              <asp:GridView 
                  ID="GridView1" 
                  runat="server" 
                  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                  Width="312px" ShowFooter="True">

                <HeaderStyle Forecolor="#000066" BackColor="#6a6a6a" Font-Bold="True" HorizontalAlign="Center"/>  <%--top hear--%>
                    <PagerStyle ForeColor="#000066" BackColor="#fff" />  <%--down header--%>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
                 <asp:Label ID="login_regionId" runat="server" Text="Label"></asp:Label>
                               
                                 </center> 
        </td>
        
    </tr>
        

   
    <tr>
        <td class="auto-style7">
            </td>
        <td class="auto-style8">
            <asp:Label ID="login_username" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
         
    </tr>
    <tr>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style3">

   
            <asp:Label ID="role" runat="server" Text="Label" Visible="False" ></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ></asp:Label>
        </td>
        <td class="auto-style1">
        </td>
    </tr>
   
   
    
</table>
        </center>
</asp:Content>
