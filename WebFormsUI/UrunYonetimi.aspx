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

    <asp:GridView ID="dgvUrunler" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="dgvUrunler_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>

    <hr />

    <br />
    <table class="auto-style1">
        <tr>
            <td>Alış Tarihi</td>
            <td>
                <asp:Calendar ID="dtpAlisTarihi" runat="server"></asp:Calendar>
            </td>
            <td>Teslim Tarihi</td>
            <td>
                <asp:Calendar ID="dtpTeslimTarihi" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>Ürün Adı</td>
            <td>
                <asp:TextBox ID="txtUrunAdi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrunAdi" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Cinsi</td>
            <td>
                <asp:TextBox ID="txtCinsi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCinsi" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Ölçü</td>
            <td>
                <asp:TextBox ID="txtOlcu" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOlcu" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>Müşteri</td>
            <td>
                <asp:DropDownList ID="cbMusteriler" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataTextField="Adi" DataValueField="Id" OnSelectedIndexChanged="cbMusteriler_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Tutar</td>
            <td>
                <asp:TextBox ID="txtTutar" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTutar" ErrorMessage="Boş Geçilemez!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblMusteriAdi" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMusteriTelefon" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Enabled="False" OnClick="btnGuncelle_Click" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" Enabled="False" ValidationGroup="sil" OnClick="btnSil_Click" />
                <asp:Label ID="lblMesaj" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
