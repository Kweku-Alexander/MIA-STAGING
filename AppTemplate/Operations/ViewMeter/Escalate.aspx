<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Escalate.aspx.cs" Inherits="AppTemplate.Operations.ViewMeter.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
     <link href="../Operations/css/StyleSheet.css" rel="stylesheet" type ="text/css"/>
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

        <script lang="javascript" type="text/javascript">

            function SelectAllCheckboxes(chk) {
                var totalRows = $("#<%=GridView1.ClientID %> tr").length;
                var selected = 0;
                $('#<%=GridView1.ClientID %>').find("input:checkbox").each(function () {
                    if (this != chk) {
                        this.checked = chk.checked;
                        selected += 1;
                    }
                });
            }
            function CheckCheckboxes(chk) {
                if (chk.checked) {
                    var totalRows = $('#<%=GridView1.ClientID %> :checkbox ').length;
                    var checked = $('#<%=GridView1.ClientID %> :checkbox:checked').length
                    if (checked == (totalRows = 1)) {
                        $('#<%=GridView1.ClientID %>').find("input:checkbox").each(function () {
                            this.checked = true;
                        });
                    }
                    else {
                        $('#<%=GridView1.ClientID %>').find('input:checked:first').removeAttr('checked');
                    }
                }
                else {
                    $('#<%=GridView1.ClientID %>').find('input:checked:first').removeAttr('checked');
                }
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   
        
             <table class="nav-justified">
        <center> <tr>
            <td>

                
                 <tr>
            <td class="style2" >
                
                <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtmnumber" runat="server" OnTextChanged="txtmnumber_TextChanged" OnLeave="searchTextBox_Leave"></asp:TextBox>
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

                        <center>         <fieldset >

                    

                    
            <legend>ESCALATED METERS</legend>                 
                   
                    <%--<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>--%>

                    <div id="divBackground" class="modal">


                    </div>
                    <div id="divImage">
                    <table style="height: 100%; width: 100%">
                        <tr>
                            <td valign="middle" align="center">
                                <img id="imgLoader" alt="" src="../Operations/images/loader.gif" />
                                <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="bottom">
                                <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button_click"/>
                            </td>
                        </tr>
                    </table>
                    </div>



<asp:GridView
                           ID="GridView1"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"
                             runat="server"
                             AutoGenerateColumns="False" 
                             AllowPaging ="True"  
                            PageSize="10"
                            DataKeyNames="CustomerName"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="OnRowDataBound"
                            OnRowCreated="GridView1_RowCreated"
                            GridView_RowCommand="GridView1_RowCommand"
                            OnRowCommand="GridView1_RowCommand1"
                            DataBoundItem="DataGridViewRow"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                            >

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
                                <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
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
                                <asp:BoundField DataField="RemainingBalance" HeaderText="Remaining Balance" ReadOnly="true">
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
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                                            Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                    </ItemTemplate>
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                               <%-- <asp:ButtonField ButtonType="Link" CommandName="View_Details" Text="View Details" />--%>
                                <asp:CommandField  ShowSelectButton="True" SelectText="Approve" ButtonType="Button" />
                                <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" />
                              

                            </Columns>

                        </asp:GridView>




                </fieldset> </center>

                        <%--<asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="400%">--%>
                        
                       </a></td>
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
                </p>
                <asp:Label ID="Label1" runat="server" Text="Label"  Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">

                <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Panel1" TargetControlID="lblpopup" CancelControlID="btnclose" PopupDragHandleControlID="headerdiv" runat="server"></ajaxToolkit:ModalPopupExtender>


                &nbsp;</td>
        </tr>
    </table>
    </center>
        
        
    
    
   
</asp:Content>


