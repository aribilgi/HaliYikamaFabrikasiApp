<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebFormsUI._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--
        Buraya yazılacak olan css ve javascript kodları master page deki head Id li ContentPlaceHolder ın içine gönderilir böylece bu kodlar oradaki head tag larının arasında çalıştırılır
    <style>
        body {
            background: red;
            color: white;
        }
    </style>
        --%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<h5>Buraya yazılacak olan html kodları masterpage içerisindeki Id si ContentPlaceHolder1 olan ContentPlaceHolder komponentinin içine eklenir, böylece bu sayfanın tasarımı master page içerisinde body etiketlerinin arasında gösterilir!
    </h5>--%>

</asp:Content>
