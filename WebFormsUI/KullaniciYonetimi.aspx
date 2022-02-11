<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="KullaniciYonetimi.aspx.cs" Inherits="WebFormsUI.KullaniciYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Kullanıcı Yönetimi<br />
        <asp:GridView ID="dgvKullanicilar" runat="server" OnSelectedIndexChanged="dgvKullanicilar_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        Kullanıcı Bilgileri</p>
    <table class="auto-style1">
        <tr>
            <td>Kullanıcı Adı</td>
            <td>
                <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
            </td>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Adı</td>
            <td>
                <asp:TextBox ID="txtAdi" runat="server"></asp:TextBox>
            </td>
            <td>Şifre</td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Soyadı</td>
            <td>
                <asp:TextBox ID="txtSoyadi" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:CheckBox ID="cbDurum" runat="server" Text="Durum" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Enabled="False" OnClick="btnGuncelle_Click" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" Enabled="False" OnClick="btnSil_Click" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        <asp:Literal ID="ltMesaj" runat="server"></asp:Literal>
    </p>
</asp:Content>
