<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MainPage.aspx.cs" Inherits="AppTemplate.Operations.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" href="/css/style.css">

    <style type="text/css">
        .modalPopup {
            background-color: #FFFFFF;
            width: 800px;
            border: 3px solid #0DA9D0;
            height: 450px;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: white;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .button {
                height: 23px;
                color: white;
                line-height: 23px;
                text-align: center;
                cursor: pointer;
                background-color: red;
                border: 1px solid #5C5C5C;
            }
    </style>

    <center>
     <link href="css/StyleSheet.css" rel="stylesheet" type ="text/css"/>
    <style type="text/css">
        .cssGridView {
            width: 100%;
            background: orange;
        }

        .auto-style1 {
            height: 20px;
        }

        .auto-style2 {
            height: 218px;
        }

        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 550px;
            width: 600px;
            padding: 3px;
            border: solid 1px black;
        }
    </style>
         <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" type="text/javascript"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous" type="text/javascript"></script>
    <!-- Boostrap DatePicket CSS -->
    /
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePciker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

    <script src="../jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../Scripts/jquery-1.11.3.min.js" type="text/javascript"></script>

    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>

    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../jquery/jquery.blockUI.js" type="text/javascript"></script>

    <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
</script>

    <style type="text/css">
        .auto-style1 {
            height: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="district" runat="server" ReadOnly="True" Visible="false" ></asp:TextBox>
                 <asp:Button ID="district_change" runat="server" Text="Change District" OnClick="District_Click" Visible="false"  />

    <table class="nav-justified">
        <center> <tr>
            <td>

                
                 <tr>
            <td class="style2" >
               
                <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtmnumber" runat="server" OnTextChanged="txtmnumber_TextChanged" OnLeave="searchTextBox_Leave"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                     <asp:TextBox ID="search_amount" runat="server" OnTextChanged="txtmnumber_Textamount" OnLeave="searchTextBox_amount" OnText="" placeholder="Amount Remaining" Textmode="Number" Visible="false"></asp:TextBox>
                    <asp:Button ID="Button1_Amount" runat="server" Text="Search" OnClick="btnsearch_amount" />
                     <div style="clear:both;padding:10px 0;">
                <label id="msg" runat="server"></label>
            </div>
                </fieldset>
                   
             </td>    
        </tr>
                   


            </td>
        </tr> </center>
        <tr>
            <td class="auto-style1">

                <%--<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">--%>

                <tr>
                    <td class="style2">

                        <center>        
                            
                            
<fieldset >

                    

                    
            <legend> METER DETAILS</legend>                 

    <%--image expend--%>
                    <div id="divBackground" class="modal">


                    </div>
                    <div id="divImage">
                    <table style="height: 100%; width: 100%">
                        <tr>
                            <td valign="middle" align="center">
                                <img id="imgLoader" alt="" src="images/loader.gif" />
                                <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="bottom">
                                <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                                </td>
                        </tr>
                    </table>
                    </div>




       <asp:GridView
                           
                            ID="GridView1"
                            runat="server"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"                                                       
                             AllowPaging ="True"                               
                             Visible="False"
                             AutoGenerateColumns="False"
                            DataKeyNames="CustomerName"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            OnRowCreated="GridView1_RowCreated"
                            OnRowCommand="GridView1_RowCommand1"
                            GridView_RowCommand="GridView1_RowCommand"                            
                            BackColor="White"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                            ShowFooter="True"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                            PageSize="10"
                            Font-Bold="False" Width="881px" >

                           <%-- <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />--%>


                            <Columns>

                                <asp:BoundField DataField="OldMeterNumber" HeaderText="Old Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" />
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NewMeterNumber" HeaderText="New Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" />
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="TelephoneNumber" HeaderText="Telephone" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NewCode" HeaderText="NewCode">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District" ReadOnly="true">
                                  <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrlOne")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                  <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
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
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                            
                                <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                               


                            </Columns>

                        </asp:GridView>

                        <asp:GridView
                            ID="GridView2"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"                                                                                       
                             runat="server"
                            AutoGenerateColumns="False"
                            DataKeyNames="OldMeterNumber"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            OnRowCreated="GridView1_RowCreated"
                            GridView_RowCommand="GridView1_RowCommand"
                            OnRowCommand="GridView1_RowCommand1"
                            AllowPaging="True"
                            BackColor="White"
                            BorderColor="Black"
                            BorderStyle="Solid"
                            BorderWidth="1px"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            Width="884px"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                            ShowFooter="True"
                            PageSize="10" Visible="False">

                            <Columns>

                                <asp:BoundField DataField="OldMeterNumber" HeaderText="Old Meter Number" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                      <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NewMeterNumber" HeaderText="New Meter Number" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TelephoneNumber" HeaderText="Telephone" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="NewCode" HeaderText="NewCode">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="District" HeaderText="District" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="70px" />
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
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                               
                                <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Authorise" />
                                <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" />
                                  <asp:CommandField ShowSelectButton="True" SelectText="Select" />


                            </Columns>
                        </asp:GridView>
    <br />
    <asp:Button ID="btnSelected" runat="server" Text="Authorise Selected" OnClick="Selected_Click" Visible="false" />
    <br /><br />


                      <%-- This the gridview for Field officer--%>
                 <asp:GridView
                            ID="GridView3"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"                                                                                       
                             runat="server"                         
                            AutoGenerateColumns="False"
                            DataKeyNames="OldMeterNumber"
                            OnPageIndexChanging="GridView3_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            OnRowCreated="GridView1_RowCreated"
                            OnRowCommand="GridView1_RowCommand1"
                            GridView_RowCommand="GridView1_RowCommand"
                            AllowPaging="True"
                            BackColor="White"
                            EnableViewState="True"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                            ShowFooter="True"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                            Font-Bold="False" Width="881px" Visible="False"
                                  PageSize="10">

                            <Columns>

                                <asp:BoundField DataField="OldMeterNumber" HeaderText="Old Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" />
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NewMeterNumber" HeaderText="New Meter Number" ReadOnly="true">
                                    <FooterStyle Width="4px" />
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="TelephoneNumber" HeaderText="Telephone" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NewCode" HeaderText="NewCode">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District" ReadOnly="true">
                                  <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
                                   <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrlOne")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                  <FooterStyle Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Width="100px"/>
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
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

   <%-- //Grid view for PreSuvary--%>
                         <asp:GridView
                            ID="GridView4"
                           HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"                                                                                       
                             runat="server"  
                            AutoGenerateColumns="False"
                            DataKeyNames="MeterNumber"
                            OnPageIndexChanging="GridView4_PageIndexChanging"
                            OnRowCancelingEdit="GridView4_RowCancelingEdit"
                            OnRowEditing="GridView4_RowEditing"
                            OnRowUpdating="GridView4_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            GridView_RowCommand="GridView4_RowCommand"                            OnRowCreated="GridView4_RowCreated"

                            OnRowCommand="GridView4_RowCommand1"
                            AllowPaging="True"
                            BackColor="White"
                            BorderColor="Black"
                            EnableViewState="True"
                            BorderStyle="Solid"
                            BorderWidth="1px"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            Width="884px"
                            OnSelectedIndexChanged="GridView4_SelectedIndexChanged1"
                            ShowFooter="True"
                            PageSize="10" Visible="False">

                            <Columns>

                                <asp:BoundField DataField="MeterNumber" HeaderText="Meter Number" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                      <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Telephone" HeaderText="Telephone" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MeterReading" HeaderText="Meter Reading" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateOfVisit" HeaderText="Date Of Visit" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SPN" HeaderText="SPN" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageOneUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("ImageTwoUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageThreeUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                               
                <asp:TemplateField HeaderText="New Meter Number">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_NewMeter" runat="server" Text='<%#Eval("SupervisionRemarks") %>'></asp:Label> 
                        
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_NewMeter" runat="server" Text='<%#Eval("SupervisionRemarks") %>' Width="60px"></asp:TextBox>
                        
                    </EditItemTemplate>  
                </asp:TemplateField>  
                                  <asp:CommandField ShowEditButton="true" />


                            </Columns>

                        </asp:GridView>
       <asp:GridView
                            ID="GridView5"
                            HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"                                                                                       
                             runat="server"  
                            AutoGenerateColumns="False"
                            DataKeyNames="MeterNumber"
                            OnPageIndexChanging="GridView4_PageIndexChanging"
                            OnRowCancelingEdit="GridView4_RowCancelingEdit"
                            OnRowEditing="GridView4_RowEditing"
                            OnRowUpdating="GridView4_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            GridView_RowCommand="GridView4_RowCommand"                            OnRowCreated="GridView4_RowCreated"

                            OnRowCommand="GridView4_RowCommand1"
                            AllowPaging="True"
                            BackColor="White"
                            BorderColor="Black"
                            EnableViewState="True"
                            BorderStyle="Solid"
                            BorderWidth="1px"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            Width="884px"
                            OnSelectedIndexChanged="GridView4_SelectedIndexChanged1"
                            ShowFooter="True"
                            PageSize="10" Visible="False">

                            <Columns>

                                <asp:BoundField DataField="MeterNumber" HeaderText="Meter Number" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                      <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Telephone" HeaderText="Telephone" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MeterReading" HeaderText="Meter Reading" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateOfVisit" HeaderText="Date Of Visit" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageOneUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("ImageTwoUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview Image">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageThreeUrl")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                               
                <asp:TemplateField HeaderText="New Meter Number">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_NewMeter" runat="server" Text='<%#Eval("SupervisionRemarks") %>'></asp:Label> 
                        
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_NewMeter" runat="server" Text='<%#Eval("SupervisionRemarks") %>' Width="60px"></asp:TextBox>
                        
                    </EditItemTemplate>  
                </asp:TemplateField>  
                                  <asp:CommandField ShowEditButton="true" />
                                <%--<asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  

                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>--%>


                                
                               
<%--                                <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve" />--%>
                                <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" />
                                  <%--<asp:CommandField ShowSelectButton="True" SelectText="Select" />--%>


                            </Columns>

                        </asp:GridView>

                </fieldset> 

                        </center>

                        <%--<asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="400%">--%>

                        <%-- </asp:Panel>--%>


                    </td>
                </tr>

                <%--</asp:Content>--%>

            </td>
        </tr>



        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnexp" runat="server" OnClick="btnexp_Click" Text="Export" />
                <br />
                <p align="center">
                    <asp:Label ID="lblpopup" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="oldmeter" runat="server" Text="Label5" Visible="False"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="Login_Usename" runat="server" Text="Label" Visible="False"></asp:Label>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
    </center>
        
        
    
    
   
</asp:Content>
