<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DetialsModelWeb.aspx.cs" Inherits="AppTemplate.Operations.DetialsModelWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
         .modalPopup{
            background-color:#FFFFFF;
            width:800px;
            border:3px solid #0DA9D0;
            height:450px;
        }
        .modalPopup .header{
            background-color:#2FBDF1;
            height:30px;
            color:white;
            line-height:30px;
            text-align:center;
            font-weight:bold;
        }
        .modalPopup .footer
        {
            padding:3px;
        }
        .modalPopup .button
        {
            height: 23px;
            color: white;
            line-height: 23px;
            text-align: center;
            cursor: pointer;
            background-color:red;
            border:1px solid #5C5C5C;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server">

     </asp:ScriptManager>

    <p>
    </p>
    <p align='center'>
        <asp:Button ID="Button1" runat="server" OnClick="btnsearch_Click" Text="Button" />
    &nbsp;</p>
    <p align='center'>
        <asp:Label ID="lblpopup" runat="server" Text="Label"></asp:Label>
        </p>

    <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Panel1" TargetControlID="lblpopup" CancelControlID="btnclose"  PopupDragHandleControlID="headerdiv" runat="server"></ajaxToolkit:ModalPopupExtender>
    
       
    <asp:Panel ID="Panel1" CssClass="modalPopup" runat="server">
        <div id ="headerdiv" class="header"></div>
        <div id ="divdetails" align="center">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="cssGridView" DataBoundItem="DataGridViewRow" DataKeyNames="CustomerName" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCreated="GridView1_RowCreated" OnRowDataBound="OnRowDataBound" OnRowEditing="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" onselectedindexchanged="GridView1_SelectedIndexChanged1" ShowFooter="True" Width="884px">
                <Columns>
                    <asp:BoundField DataField="MeterNumber" HeaderText="Meter Number" ReadOnly="true">
                    <FooterStyle BorderColor="#000099" Width="4px" />
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                    <FooterStyle ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Telephone" HeaderText="Telephone" ReadOnly="true">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MeterReading" HeaderText="Meter Reading" ReadOnly="true">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GeoCode" HeaderText="Geo Code">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InspectedBy" HeaderText="Inspected By" ReadOnly="true">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" ReadOnly="true">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="ImageThreeUrl" HeaderText="Image1" ReadOnly="true">
                        <ControlStyle Height="30px" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="Preview Image">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl='<%# Eval("ImageOneUrl")%>' OnClientClick="return LoadDiv(this.src);" Style="cursor: pointer" Width="50px" />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Preview Image">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" ImageUrl='<%# Eval("ImageTwoUrl")%>' OnClientClick="return LoadDiv(this.src);" Style="cursor: pointer" Width="50px" />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%--<asp:ImageField DataImageUrlField="ImageTwoUrl" HeaderText="Image2" ReadOnly="true">
                            <ControlStyle Height="30px" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>--%>
                    <asp:BoundField DataField="SupervisonApprovalStatus" HeaderText="Approval Status" ReadOnly="true">
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <%-- <FooterStyle BackColor="White" ForeColor="#000066" />  --%>
                <FooterStyle BackColor="#FF3300" />
                <HeaderStyle BackColor="#6a6a6a" Font-Bold="True" Forecolor="#000066" />
                <%--top hear--%>
                <PagerStyle BackColor="#fff" ForeColor="#000066" />
                <%--down header--%>
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
        <div id ="footerdiv" class="footer"> 
    <asp:Button ID="btnclose" runat="server" Text="X" />
    </div>

    </asp:Panel>

</asp:Content>
