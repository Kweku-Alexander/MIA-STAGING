<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReplacementForm.aspx.cs" Inherits="AppTemplate.Operations.ReplamentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.elevateZoom-3.0.8.min.js"></script>
    <script type="text/javascript">

</script>
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
      <%--image expend--%>
   <link href="css/StyleSheet.css" rel="stylesheet" type ="text/css"/>
    <style type="text/css">
        .cssGridView {
            width: 100%;
            background: orange;
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


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

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
    <div>
        <table class="style1">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>CUSTOMER INFORMATION</legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px">
                            <table class="style1">
                                <tr>
                                    <td>Old Meter Number:</td>
                                    <td>
                                        <asp:TextBox ID="old_meter_num" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>Phase:</td>
                                    <td>
                                        <asp:TextBox ID="phase" runat="server" OnTextChanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>

                                <caption>
                                    <p>
                                    </p>
                                    <tr>
                                        <td>Customer Name:</td>
                                        <td>
                                            <asp:TextBox ID="customer_nm" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>Date of Visit:</td>
                                        <td>
                                            <asp:TextBox ID="dateofvist" runat="server" OnTextChanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Digital Address:</td>
                                        <td>
                                            <asp:TextBox ID="digital_add" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>Traffic Class:</td>
                                        <td>
                                            <asp:TextBox ID="traff_class" runat="server" OnTextChanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Telephone Number:</td>
                                        <td>
                                            <asp:TextBox ID="tele" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>Account Number:</td>
                                        <td>
                                            <asp:TextBox ID="Acc_num" runat="server" OnTextChanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>New Meter Number:</td>
                                        <td>
                                            <asp:TextBox ID="new_meter_num" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>Meter Type:</td>
                                        <td>
                                            <asp:TextBox ID="meter_type" runat="server" OnTextChanged="TextBox3_TextChanged" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Remaining Balance:</td>
                                        <td>
                                            <asp:TextBox ID="remain_bal" runat="server" ReadOnly="True"></asp:TextBox>
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
    <fieldset style="width: auto">
        <legend>PURCHASING HISTORY E-CASH</legend>
        <asp:Panel ID="Panel2" runat="server" BorderWidth="3px">
            <p>
                <td class="style1">

                    <asp:Label ID="Label9" runat="server" Text="NUMBER OF PURCHASES"></asp:Label>
                    <asp:TextBox ID="no_of_purchases_txt" runat="server" ReadOnly="True" Width="46px"></asp:TextBox>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="cssGridView" DataBoundItem="DataGridViewRow" DataKeyNames="DisplayMeterID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCreated="GridView1_RowCreated" OnRowDataBound="OnRowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" ShowFooter="false" Width="884px">
                        <Columns>
                            <asp:BoundField DataField="DisplayMeterID" HeaderText="Meter Number" ReadOnly="true"><%--<FooterStyle Width="4px" />--%>
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="meterid" HeaderText="Meter ID" ReadOnly="true">
                        <FooterStyle BorderColor="#000099" Width="4px" />
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                            <asp:BoundField DataField="Purchasing_Amount" HeaderText="Purchasing Amount" ReadOnly="true"><%--<FooterStyle ForeColor="White" HorizontalAlign="Center" />--%>
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Transaction_Date" HeaderText="Transaction Date" ReadOnly="true">
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VendingStation" HeaderText="Vending Station" ReadOnly="true">
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No">
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="userid" HeaderText="Userid" ReadOnly="true">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                            <asp:BoundField DataField="Name" HeaderText="Cashier Name" ReadOnly="true">
                                <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </p>
        </asp:Panel>
    </fieldset>
    <fieldset style="width: auto">
        <legend>OLD METER PICTURES</legend>
        <asp:Panel ID="Panel3" runat="server" BorderWidth="3px">


            <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrlOne")%>' Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
            <asp:ImageButton ID="Image2" runat="server" ImageUrl='<%# Eval("ImageUrlTwo")%>' Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
            <asp:ImageButton ID="Image3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>' Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
            



        </asp:Panel>
    </fieldset>
    <fieldset style="width: auto">
        <legend>REFUND</legend>
        <asp:Panel ID="Panel4" runat="server" BorderWidth="3px">
            <p>
                <table class="style1">
                                <tr>
                                    <td>Remaining Balance:</td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Amount_rem" runat="server" ReadOnly="True" Width="97px"></asp:TextBox>
                                        <asp:Button ID="refund_btn" runat="server" OnClick="btn_refund_Click" Text="REFUND" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Reasonid" runat="server" Text="Reason For Rejecting:" Visible="False"></asp:Label>
                                        <td>
                                            <asp:TextBox ID="Reason_message" runat="server" OnTextChanged="TextBox3_TextChanged" TextMode="MultiLine" Visible="False"></asp:TextBox>
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                     <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="approve_btn" runat="server" OnClick="approve_Click" Text="Authorise" Visible="False" Width="82px" />
                                            <asp:Button ID="resend_btn" runat="server" OnClick="btnResend_Click" Text="Resend" Visible="False" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="reject_btn" runat="server" OnClick="reject_Click" Text="Reject" Visible="False" />
                                            <asp:Button ID="escalate_btn" runat="server" OnClick="btnEscalate_Click" Text="Escalate" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       <td>&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>

                    </table>
                <tr>
                    <td>&nbsp;<p>
                        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="Usename2" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="OldMet" runat="server" Text="Label" Visible="False"></asp:Label>
                        </p>
                    </td>

                  
            </p>
        </asp:Panel>
    </fieldset>




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


    <asp:Panel ID="Panel5" CssClass="modalPopup" runat="server" Width="580px">
        <div id="headerdiv" class="header"></div>
        <div id="footerdiv" class="footer">


            <asp:Table ID="Table1" runat="server" BackColor="White" BorderColor="DarkRed" BorderWidth="2px" CellPadding="5" CellSpacing="5" Font-Names="Palatino" Font-Size="X-Large" ForeColor="Black" Width="529px">
                <asp:TableHeaderRow runat="server" BackColor="blue" Font-Bold="true" ForeColor="Snow">

                    <asp:TableHeaderCell>Customer Information</asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>

                    </asp:TableHeaderCell>



                </asp:TableHeaderRow>
                <asp:TableRow ID="TableRow22" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>CustomerName</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow1" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>MeterNumber</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow2" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>AccountNumber</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow3" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>CustomerPhoneNumber</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Amount" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>Token</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server" BackColor="#CCCCCC">
                    <asp:TableHeaderCell>Id</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableFooterRow runat="server" BackColor="#CCCCCC">
                    <asp:TableCell ColumnSpan="3" Font-Italic="true" HorizontalAlign="Right">
                    
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>

            <asp:Button ID="Btn_resend" OnClick="RESEND" runat="server" Text="Resend" />

            <asp:Button ID="btnclose" runat="server" Text="Close" />

        </div>

    </asp:Panel>
</asp:Content>
