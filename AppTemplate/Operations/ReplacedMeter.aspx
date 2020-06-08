<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="ReplacedMeter.aspx.cs" Inherits="AppTemplate.Operations.ReplacedMeter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <center>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 24px;
             width: 178%;
         }

        body
{
    margin: 0;
    padding: 0;
    height: 100%;
}
.modal
{
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
#divImage
{
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
    <style type="text/css">
        .auto-style1 {
            width: 156%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td>


                 <tr>
            <td class="style2" >
               <center> <fieldset >
            <legend> REPLACED METER NUMBER</legend>                 
                   <asp:TextBox ID="txtmnumber" runat="server" OnTextChanged="txtmnumber_TextChanged"></asp:TextBox> 
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                </fieldset>
               </center> 
             </td>    
        </tr>


            </td>
        </tr>
        <tr>
            <td class="auto-style1">

<%--<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>--%>
                 <tr>
            <td class="style2" >
               <center><fieldset >

                    

                    
       <center> <legend> METER DETAILS</legend></center>           
                    
                    <%--</asp:Content>--%>

                   </center>
                     <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerName" 
                  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                  OnRowEditing="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating"  OnRowDataBound = "OnRowDataBound"
                  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                              Width="884px"  onselectedindexchanged="GridView1_SelectedIndexChanged1" ShowFooter="True">
                    <Columns>  
                       
                       
                       <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="true"> 
                        <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OldMeterNumber" HeaderText="Old Meter Number" ReadOnly="true"> 
                           <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                           <asp:BoundField DataField="NewMeterNumber" HeaderText="New Meter Number" ReadOnly="true">
                           <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                           <asp:BoundField DataField="FinalReading" HeaderText="Final Reading" ReadOnly="true">
                        <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LengthOfCable" HeaderText="Length Of Cable" ReadOnly="true">
                         <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                         <asp:BoundField DataField="MeterUserMobileNumber" HeaderText="PhoneNumber" ReadOnly="true">
                            <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                            <asp:BoundField DataField="AmountRemaining" HeaderText="AmountRemaining">
                        <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageUrlOne")%>'
                Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
                            <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Eval("ImageUrlTwo")%>'
                Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
                            <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl='<%# Eval("ImageUrlThree")%>'
                Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
                             <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
    </asp:TemplateField>
                         <%--<asp:ImageField DataImageUrlField="ImageUrlOne" HeaderText="Image1" ReadOnly="true">
                             <ControlStyle Height="30px" Width="30px" />
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                        <asp:ImageField DataImageUrlField="ImageUrlTwo" HeaderText="Image2" ReadOnly="true">
                            <ControlStyle Height="30px" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                        <asp:ImageField DataImageUrlField="ImageUrlThree" HeaderText="Image2" ReadOnly="true">
                            <ControlStyle Height="30px" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>
                          --%>
                          <asp:CommandField ShowSelectButton="True">
                        <FooterStyle BackColor="#FF3300" BorderColor="#FF3300" />
                        </asp:CommandField>
                        </Columns>  


                        <FooterStyle BackColor="#FF3300" />
                    <HeaderStyle Forecolor="#000066" BackColor="#6a6a6a" Font-Bold="True"/>  <%--top hear--%>
                    <PagerStyle ForeColor="#000066" BackColor="#fff" />  <%--down header--%>
                    <RowStyle ForeColor="#000066" />   
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />  
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />  
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />  
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />  
                    <SortedDescendingHeaderStyle BackColor="#00547E" />  
                </asp:GridView>
</center>
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





                </fieldset></center> 
             </td>    
        </tr>

                <%--</asp:Content>--%>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnexp" runat="server" OnClick="btnexp_Click" Text="Export" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    </center>
</asp:Content>
