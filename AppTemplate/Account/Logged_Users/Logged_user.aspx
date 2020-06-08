<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" Culture="en-GB" AutoEventWireup="true" CodeBehind="Logged_user.aspx.cs" Inherits="AppTemplate.Account.Logged_Users.Logged_user" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.elevateZoom-3.0.8.min.js"></script>
    <script type="text/javascript">

</script>
    
    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style3 {
            height: 77px;
            color: Black;
            font-size: 14px;
        }

        .style5 {
            height: 77px;
            color: Black;
            font-size: 14px;
            width: 633px;
        }

        .style6 {
            width: 259px;
            height: 105px;
        }

        .style7 {
            width: 99px;
            height: 77px;
            margin-left: 0px;
        }

        .style8 {
            height: 77px;
            color: Black;
            font-size: 14px;
            width: 837px;
        }

        .style9 {
            width: 147px;
        }

        .style10 {
            width: 219px;
        }

        .style11 {
            width: 103px;
        }
    </style>
    <%--//image for DATE//--%>
  <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
      .auto-style1 {
          height: 26px;
      }
      </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div>
        <table class="style1">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend> SET DATE</legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px">
                           
                              <table class="style1">
                                <tr>
                                    <td>Start Date:</td>
                                    <td>
                                        <asp:TextBox ID="Start_date"  runat="server" OnTextChanged="txtStartDate_TextChanged" Textmode="Date" DateFormat="yyyy/MM/dd" OnSelectedIndexChanged="StartDate_SelectedIndexChanged"></asp:TextBox>
                                    </td>
                                    <td>End Date:</td>
                                    <td>
                                        <asp:TextBox ID="last_date" runat="server" OnTextChanged="ToEndTxt_TextChanged" TextMode="Date"  OnSelectedIndexChanged="EndDate_SelectedIndexChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" OnClick="Search_Click" Text="Search" />
                                        
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </fieldset>

        

<fieldset style="width:auto">
        <legend>USERS LONGIN HISTORY</legend>
     <asp:Panel ID="Panel3" runat="server" BorderWidth="3px">
      <asp:GridView ID="GridView1" 
                    runat="server" 
                    AllowPaging="True"
                    AlternatingRowStyle-BackColor="White" 
                    AlternatingRowStyle-ForeColor="#000" 
                    AutoGenerateColumns="False" 
                    DataKeyNames="username"
                    HeaderStyle-BackColor="#3AC0F2"
                    HeaderStyle-ForeColor="White" 
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    PageSize="10" RowStyle-BackColor="White" 
                    Visible="False" Width="805px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#000000" />
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Name" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="role" HeaderText="role" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="district" HeaderText="District" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="region" HeaderText="Region" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="lastLogin" HeaderText="last Login" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        
                    </Columns>
                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White" />
                    <RowStyle BackColor="White" />
                </asp:GridView>
         <asp:Button ID="btnexp" runat="server" OnClick="ExportToExcel" Text="Export" />
    </asp:Panel>
        </fieldset>

    </div>
  
    




    <tr>
        <td class="auto-style1">

            <br />
            <p align="center">
                <asp:Label ID="lblpopup" runat="server" Text="ok"></asp:Label>
                <asp:Label ID="oldmeter" runat="server" Text="Label5" Visible="False"></asp:Label>
                <asp:Label ID="Login_Usename" runat="server" Text="Label5" Visible="False"></asp:Label>
            </p>
        </td>
    </tr>


    <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Panel5" TargetControlID="lblpopup" CancelControlID="btnclose" PopupDragHandleControlID="headerdiv" runat="server"></ajaxToolkit:ModalPopupExtender>


    </asp:Content>
