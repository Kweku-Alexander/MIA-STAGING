<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewAllDetials.aspx.cs" Inherits="AppTemplate.Operations.ViewMeter.ViewAllDetials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style type="text/css">
        .auto-style1 {
            height: 20px;
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
       <%-- <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Text="Meter Number:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label DataField="OldMeterNumber" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Expected Location:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label DataField="MeterType" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Authorized By:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <%--<tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Digital Address:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label12" runat="server" Text="Rating:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label14" runat="server" Text="Meter Reading:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label17" runat="server" Text="Size Of Cable:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label5" runat="server" Text="Service Pole Number:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>

        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label19" runat="server" Text="Transformer Number:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label21" runat="server" Text="DateOfVisit:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label23" runat="server" Text="InspectedBy:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>

         <tr>
            <td class="auto-style3">
                <asp:Label ID="Label24" runat="server" Text="TariffClass:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label26" runat="server" Text="GeoCode:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label28" runat="server" Text="IsMeterFaulty:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label29" runat="server" Text="Remarks:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>
         <tr>
            <td class="auto-style1">
                <asp:Label ID="Label34" runat="server" Text="Image1:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Image ID="Image1" runat="server" />
             </td>
        </tr>--%>
    <%--    <tr>
            <td class="auto-style1">
                <asp:Label ID="Label35" runat="server" Text="Image2:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Image ID="Image2" runat="server" />
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label36" runat="server" Text="Image3:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Image ID="Image3" runat="server" />
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
                <asp:Button ID="Btncancel" runat="server" Text="Close" OnClick="Btncancel_Click" />
            </td>
        </tr>--%>
       
        <asp:GridView
                            ID="GridView1"
                            runat="server"
                            AutoGenerateColumns="False"
                            DataKeyNames="CustomerName"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            OnRowCreated="GridView1_RowCreated"
                            AllowPaging="True"
                            BackColor="White"
                            BorderColor="Black"
                            BorderStyle="Solid"
                            BorderWidth="1px"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            Width="884px"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" ShowFooter="True">

                            <Columns>

                                <asp:BoundField DataField="OldMeterNumber" HeaderText="Old Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" BorderColor="#000099" />
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NewMeterNumber" HeaderText="New Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" BorderColor="#000099" />
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                    <FooterStyle ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TelephoneNumber" HeaderText="Telephone" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                               <%-- <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NewCode" HeaderText="NewCode">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SupervisorDate" HeaderText="Supervisor Date" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrlOne")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("ImageUrlTwo")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               

                                <asp:CommandField ShowSelectButton="True" SelectText="View Details" />
                                <asp:CommandField ShowSelectButton="True" />--%>
                            </Columns>




                            <%-- <FooterStyle BackColor="White" ForeColor="#000066" />  --%>
                            <FooterStyle BackColor="#FF3300" />
                            <HeaderStyle ForeColor="#000066" BackColor="#6a6a6a" Font-Bold="True" />
                            <%--top hear--%>
                            <PagerStyle ForeColor="#000066" BackColor="#fff" />
                            <%--down header--%>
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </center>
</asp:Content>
