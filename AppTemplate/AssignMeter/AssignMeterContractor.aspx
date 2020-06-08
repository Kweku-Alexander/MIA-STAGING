<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AssignMeterContractor.aspx.cs" Inherits="AppTemplate.AssignMeter.AssignMeterContractor" %>
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
        .auto-style1 {
            height: 26px;
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>


    <div>
        <table class="style1">
            <tr>
                <td class="style8">
                    <fieldset style=": 5px; padding: 15px; margin: 0; border: 1px solid #bbb;">
                        <legend>Filter</legend>
                        <asp:Panel ID="Panel1" runat="server" BorderWidth="3px">
        <table class="style1">
                <tr>
                    <td>Meter Number:</td>
                    <td>
                        <asp:TextBox ID="meter_num" runat="server" ></asp:TextBox>
                    </td>
                    <td>Plot Number:</td>
                    <td>
                        <asp:DropDownList ID="DropDown_ploit" runat="server" OnSelectedIndexChanged="DropDown_ploit_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
           
                    <caption>
                        <p>
                        </p>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                            </td>
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
    <fieldset style="width:auto">
        <legend>CUSTOMER DETAILS</legend>
     <asp:Panel ID="Panel2" runat="server" BorderWidth="3px">
    <asp:GridView
                            ID="GridView1"
                             HeaderStyle-BackColor="#3AC0F2" 
                             HeaderStyle-ForeColor="White"
                             RowStyle-BackColor="White"
                             AlternatingRowStyle-BackColor="White" 
                             AlternatingRowStyle-ForeColor="#000"
                             runat="server"
                             AutoGenerateColumns="False" 
                             DataKeyNames="CustomerName"  
                             OnPageIndexChanging="GridView1_PageIndexChanging"
                             AllowPaging ="True"  
                             PageSize="10"
                             Visible="False">

<AlternatingRowStyle BackColor="White" ForeColor="#000000"></AlternatingRowStyle>

                            <Columns>
                                 <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SPN" HeaderText="SPN" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MeterNumber" HeaderText="Old Meter Number" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                      <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SupervisionRemarks" HeaderText="New Meter Number" ReadOnly="true">
                                  <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>   
                                <asp:BoundField DataField="GeoCode" HeaderText="Geo code" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>   
                                 <asp:BoundField DataField="Telephone" HeaderText="Telephone" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Phase" HeaderText="Phase" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="TariffClass" HeaderText="Tariff Class" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" ReadOnly="true">
                                     <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                     <ItemStyle HorizontalAlign="Center" />
                                     <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateOfVisit" HeaderText="Date Of Visit" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InspectedBy" HeaderText="Inspected By" ReadOnly="true">
                                    <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>


                            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="White"></RowStyle>

                        </asp:GridView>
         <asp:Button ID="btnexp" runat="server" OnClick="ExportToExcel" Text="Export" />
    </asp:Panel>
        </fieldset>&nbsp;
    <fieldset style="width:auto">
          <legend>Assignment</legend>
     <asp:Panel ID="Panel4" runat="server" BorderWidth="3px">
    <p>
        
           
           
        <table class="style1">
            <tr>
                <td>Meter Index:</td>
                <td>
                    <asp:TextBox ID="old_meter_num0" runat="server" OnTextChanged="old_meter_num0_TextChanged"></asp:TextBox>
                </td>
                <td>Contractor:</td>
                <td>
                    <asp:TextBox ID="phase0" runat="server" OnTextChanged="TextBox3_TextChanged" Height="16px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>First Meter Number:</td>
                <td>
                    <asp:TextBox ID="customer_nm" runat="server" OnTextChanged="customer_nm_TextChanged"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Last Meter Number:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="digital_add" runat="server" OnTextChanged="digital_add_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    </td>
            </tr>
           
        </table>
        
           
           
    </p>
    </asp:Panel>
    </fieldset>

   


    <tr>
            <td class="auto-style1">
                <br />
                <p align="center">
                    <asp:Label ID="lblpopup" runat="server" Text="ok" ></asp:Label>
                </p>
            </td>
        </tr>




            
</asp:Content>
