 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage2.aspx.cs" Inherits="AppTemplate.Login.Stock.LoginPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>

    <link href=" Login/Style.css" rel="stylesheet" />

    
</head>

<body>
    <form id="form1" runat="server">
        <section>
            <img src="Login/Stock/back1.png" class="panel" />
        </section>
        <div class="sec2">
            <div class="container">
                <div class="social">

                </div>
                <div class="content">
                    <h2>Login</h2>

                    <asp:TextBox ID="txt_username"  placeholder="Username" runat="server" ></asp:TextBox><br />
                    <asp:TextBox ID="txt_password"  placeholder="Password" runat="server"  OnTextChanged="txt_password_TextChanged" TextMode="Password" ></asp:TextBox><br />
                    <asp:Button ID="btn_login" runat="server" Text="Login"  OnClick="btn_login_Click" /><br/><br />
                     <asp:HyperLink ID="lnkdwnload" runat="server" NavigateUrl="~/Android_Application/MIA.apk">Download Meter Installation App</asp:HyperLink>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
