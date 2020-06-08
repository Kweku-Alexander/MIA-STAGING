<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation ="false" CodeBehind="MainPage.aspx.cs" Inherits="AppTemplate.Operations.MainPage" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server" href="css/style.css">

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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <table class="nav-justified">
        <center> <tr>
            <td>

                
                 <tr>
            <td class="style2" >
                <center>
                <fieldset >
            <legend> METER NUMBER</legend>                 
                    <asp:TextBox ID="txtmnumber" runat="server" OnTextChanged="txtmnumber_TextChanged" OnLeave="searchTextBox_Leave"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                     <div style="clear:both;padding:10px 0;">
                <label id="msg" runat="server"></label>
            </div>
                </fieldset>
                    </center>
             </td>    
        </tr>
                   


            </td>
        </tr> </center>
        <tr>
            <td class="auto-style1">

<%--<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">--%>
                 <tr>
            <td class="style2" >

       <center>         <fieldset >

                    

                    
            <legend> METER DETAILS</legend>                 
                   
                    <%--<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>--%>

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








                </fieldset> </center>
             
<%--<asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="400%">--%>
                     <asp:GridView
                         ID="GridView1" 
                         runat="server" 
                         AutoGenerateColumns="False" 
                         DataKeyNames="CustomerName" 
                         OnPageIndexChanging="GridView1_PageIndexChanging" 
                         OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                         OnRowEditing="GridView1_RowEditing"
                         onrowupdating="GridView1_RowUpdating"  
                         OnRowDataBound = "OnRowDataBound" 
                         OnRowCreated="GridView1_RowCreated" 
                         AllowPaging="True"
                         BackColor="White" 
                         BorderColor="Black"
                         BorderStyle="Solid" 
                         BorderWidth="1px"
                         DataBoundItem ="DataGridViewRow" 
                         
                         CssClass ="cssGridView"
                        
                         


                         Width="884px" 
                         onselectedindexchanged="GridView1_SelectedIndexChanged1" ShowFooter="True">

                    <Columns>  
                       
                       <asp:BoundField DataField="MeterNumber" HeaderText="Meter Number" ReadOnly="true"> 
                        <FooterStyle Width="4px" BorderColor="#000099" />
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
                            <HeaderStyle ForeColor="White" HorizontalAlign="Center"  />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                            <asp:BoundField DataField="GeoCode" HeaderText="Geo Code">
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Remarks" HeaderText="Inspected By" ReadOnly="true">
                           <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                       <%--<asp:ImageField DataImageUrlField="ImageOneUrl" HeaderText="Image1" ReadOnly="true">
                             <ControlStyle Height="30px" Width="30px" />
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>--%>
                         <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageOneUrl" runat="server" ImageUrl='<%# Eval("ImageOneUrl")%>'
                Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
                             <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                             <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageTwoUrl" runat="server" ImageUrl='<%# Eval("ImageTwoUrl")%>'
                Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
    </asp:TemplateField>
                        <%--<asp:ImageField DataImageUrlField="ImageTwoUrl" HeaderText="Image2" ReadOnly="true">
                            <ControlStyle Height="30px" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>--%>
                         <asp:BoundField DataField="TariffClass" HeaderText="Approval Status" ReadOnly="true">
                  

                          <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                  

                          <asp:CommandField ShowSelectButton="True"/>
                        </Columns>  


                        

                   <%-- <FooterStyle BackColor="White" ForeColor="#000066" />  --%>
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
   <%-- </asp:Panel>--%>
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
            <td class="auto-style2"></td>
        </tr>
    </table>
    </center>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Test5i.aspx.cs" Inherits="AppTemplate.Test5.Test5i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
