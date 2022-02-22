<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, form{
            height:100%;
            margin:0;
            padding:0;
        }
        form {
            display:flex;
            justify-content:center;
            align-items:center;
        }
        .auto-style1 {
            width: 100%;
        }
        #loginForm{
            width: 333px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginForm">
            <fieldset>
                <legend>Kullanıcı Girişi</legend>
                <table class="auto-style1">
                    <tr>
                        <td>Kullanıcı Adı</td>
                        <td>
                            <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Şifre</td>
                        <td>
                            <asp:TextBox ID="txtSifre" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnGiris" runat="server" Text="Giriş" OnClick="btnGiris_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>

        </div>
    </form>
</body>
</html>
