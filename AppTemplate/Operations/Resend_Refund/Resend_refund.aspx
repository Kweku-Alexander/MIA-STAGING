<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Resend_refund.aspx.cs" EnableViewState="True" Inherits="AppTemplate.Operations.Resend_Refund.Resend_refund" %>
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

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>

    <table class="nav-justified">
        <center> <tr>
            <td>

                
                 <tr>
            <td class="style2" >
               
                <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtmnumber_TextChanged" OnLeave="searchTextBox_Leave"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
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
                   
                    <%--<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>--%>

                    <div id="divBackground" class="modal">


                         <asp:GridView
                            ID="GridView1"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"   
                            runat="server"
                            AutoGenerateColumns="False"
                            DataKeyNames="MeterNumber"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            GridView_RowCommand="GridView1_RowCommand"                           
                             OnRowCreated="GridView1_RowCreated"
                            OnRowCommand="GridView1_RowCommand1"
                            AllowPaging="True"
                            BackColor="White"
                            BorderColor="Black"
                            EnableViewState="True"
                            BorderStyle="Solid"
                            BorderWidth="1px"
                            DataBoundItem="DataGridViewRow"
                            CssClass="cssGridView"
                            Width="884px"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                            ShowFooter="True"
                            PageSize="5">

                            <Columns>

                                <asp:BoundField DataField="MeterNumber" HeaderText="MeterNumber" ReadOnly="true">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CustomerPhoneNumber" HeaderText="PhoneNumber" ReadOnly="true">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Remaining Balance" ReadOnly="true">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Token" HeaderText="Token" ReadOnly="true">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreatedAt" HeaderText="Date and Time">
                                        <FooterStyle Width="4px" />
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                 
                                        
                                        <asp:CommandField SelectText="Resend" ShowSelectButton="True" />
                                    </Columns>
 
                        </asp:GridView>


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




                      <%-- This the gridview for Field officer--%>

   <%-- //Grid view for PreSuvary--%>

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
