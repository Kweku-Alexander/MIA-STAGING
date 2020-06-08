<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="captureInfo.aspx.cs" Inherits="AppTemplate.CaptureInfo.captureInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 100%;
           
               }
        .style3
        {
            height: 77px;
            
            color:Black;
            font-size:14px;
           
        }
        
        .style5
        {
            height: 77px;
            
            color: Black;
            font-size: 14px;
            width: 633px;
        }
        .style6
        {
            width: 259px;
            height: 105px;
        }
        .style7
        {
            width: 99px;
            height: 77px;
            margin-left: 0px;
        }
        .style8
        {
            height: 77px;
          
            color: Black;
            font-size: 14px;
            width: 837px;
        }
                    
        .style9
        {
            width: 147px;
        }
        .style10
        {
            width: 219px;
        }
        .style11
        {
            width: 103px;
        }
        .auto-style30 {
            margin-left: 0;
            margin-bottom: 14px;
        }
        .auto-style31 {
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div>
        <table class="style1">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>CUSTOMER INFORMATION</legend>
                        <asp:Panel ID="Panel2" runat="server" BorderWidth="3px">
        <table class="style1">
                <tr>
                    <td>Old Meter Number:</td>
                    <td>
                        <asp:TextBox ID="search_txt" runat="server" CssClass="auto-style30" Height="19px" OnTextChanged="search_txt_TextChanged"  Width="122px" ></asp:TextBox>
                        <asp:Button ID="search_btn" runat="server" Text="Search" Width="119px" />
                    </td>
                    <td>
                        Image 1:</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" accept="image/png, image/jpeg, image/jpg" Height="22px" Width="212px" />
                    </td>
                </tr>
           
                    <caption>
                        <p>
                        </p>
                        <tr>
                            <td>Customer Name:</td>
                            <td>
                                <asp:TextBox ID="cusName_txt" runat="server" OnTextChanged="cusName_txt_TextChanged" ReadOnly="true" ></asp:TextBox>
                            </td>
                            <td>Image 2:</td>
                            <td>
                                <asp:FileUpload ID="FileUpload2" runat="server" Height="20px" Width="212px" />
                            </td>
                        </tr>
                        <tr>
                            <td>Telephone:</td>
                            <td>
                                <asp:TextBox ID="telephone_txt" runat="server"></asp:TextBox>
                            </td>
                            <td>Image 3:</td>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" Height="21px" Width="212px" />
                            </td>
                        </tr>

                        <tr>
                            <td>Old Meter Number:</td>
                            <td>
                                <asp:TextBox ID="oldMeterNumber_txt" runat="server"  ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>New Meter Number:</td>
                            <td>
                                <asp:TextBox ID="newMeterNumber_txt" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td>Amount to Refund:</td>
                            <td>
                                <asp:TextBox ID="balance_txt" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Final Reading:</td>
                            <td>
                                <asp:TextBox ID="finalReading_txt" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Phase:</td>
                            <td>
                                <asp:DropDownList ID="phase_drop" runat="server" Height="16px" Width="126px" OnSelectedIndexChanged="phase_drop_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="Choose"></asp:ListItem>
                                    <asp:ListItem Value="1 phase"></asp:ListItem>
                                    <asp:ListItem>3 phase</asp:ListItem>
                                    <asp:ListItem>SINGLEPHASE</asp:ListItem>
                                    <asp:ListItem>THREEPHASE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Location:</td>
                            <td>
                                <asp:TextBox ID="location_txt" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td>Location Of Meter:</td>
                            <td>
                                <asp:DropDownList ID="locOfMeterDrop" runat="server" Height="16px" Width="126px" OnSelectedIndexChanged="locOfMeterDrop_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="choose">choose</asp:ListItem>
                                    <asp:ListItem Value="NON STANDARD"></asp:ListItem>
                                    <asp:ListItem Value="Wall"></asp:ListItem>
                                    <asp:ListItem Value="Pole"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td>Tariff Class:</td>
                            <td>
                                <asp:DropDownList ID="tarifClassDrop" runat="server" Height="16px" Width="125px" OnSelectedIndexChanged="tarifClassDrop_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="Choose"></asp:ListItem>
                                    <asp:ListItem Value="Residential (prepayment)"></asp:ListItem>
                                    <asp:ListItem Value="Non Residential (prepayment)"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td class="auto-style31">Length Of Cable:</td>
                            <td class="auto-style31">
                                <asp:TextBox ID="len_cable_txt" runat="server" Width="115px"></asp:TextBox>
                            </td>
                            <td class="auto-style31"></td>
                            <td class="auto-style31">
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                                </td>
                        </tr>
                         <tr>
                            <td></td>
                            <td>
                                
                                <asp:Button ID="capture_info_btn" runat="server" OnClick="capture_info_btn_Click" Text="Submit" Width="122px" />
                                
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                </caption>
                    
                                                         
        </table>
    </asp:Panel>
                    </fieldset>

                </td>

            </tr>
        </table>

  

</fieldset>
    </div>
    
</asp:Content>