<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="UrunYonetimi.aspx.cs" Inherits="WebFormsUI.UrunYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Ürün Yönetimi</h1>

    <asp:GridView ID="dgvUrunler" runat="server"></asp:GridView>

    <hr />

    <br />
    <table class="auto-style1">
        <tr>
            <td>Ürün Adı</td>
            <td>
                <asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrunAdi" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>Alış Tarihi</td>
            <td>
                <asp:TextBox ID="txtAlisTarihi" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Cinsi</td>
            <td>
                <asp:TextBox ID="txtCinsi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCinsi" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>Teslim Tarihi</td>
            <td>
                <asp:TextBox ID="txtTeslimTarihi" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ölçü</td>
            <td>
                <asp:TextBox ID="txtOlcu" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOlcu" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>Müşteri</td>
            <td>
                <asp:DropDownList ID="cbMusteriler" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Tutar</td>
            <td>
                <asp:TextBox ID="txtTutar" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTutar" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Enabled="False" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" Enabled="False" ValidationGroup="sil" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
