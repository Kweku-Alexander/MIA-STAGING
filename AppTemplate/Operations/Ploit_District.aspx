<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Ploit_District.aspx.cs" Inherits="AppTemplate.Operations.Ploit_District" %>
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


    <div>
        <table class="style1">
            <tr>
                <td class="style8">
                    <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtmnumber" runat="server" OnTextChanged="txtmnumber_TextChanged" OnLeave="searchTextBox_Leave"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"  />
                        Ploit:<asp:DropDownList ID="Ploit_list" runat="server" OnSelectedIndexChanged="Ploit_Change">
                        </asp:DropDownList>
                     <div style="clear:both;padding:10px 0;">
                <label id="msg" runat="server"></label>
            </div>
                </fieldset>
                  

                </td>

            </tr>
        </table>



        </fieldset>
    </div>
    
    
    




    <tr>
        <td class="auto-style1">
            <br />
            <p align="center">
                <asp:Label ID="lblpopup" runat="server" Text="ok"></asp:Label>
                <asp:Label ID="oldmeter" runat="server" Text="Label5" Visible="False"></asp:Label>
                <asp:Label ID="login_district" runat="server" Text="Label5" Visible="False"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </p>
        </td>
    </tr>


    <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Panel5" TargetControlID="lblpopup" CancelControlID="btnclose" PopupDragHandleControlID="headerdiv" runat="server"></ajaxToolkit:ModalPopupExtender>


    </asp:Content>
