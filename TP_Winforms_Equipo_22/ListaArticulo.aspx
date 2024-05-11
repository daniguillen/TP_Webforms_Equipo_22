<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="TP_Winforms_Equipo_22.ListaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de articulos</h1>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"> </asp:GridView>
</asp:Content>
