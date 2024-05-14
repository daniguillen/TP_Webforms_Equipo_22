
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Winforms_Equipo_22.Carrito"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de articulos</h1>
   <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvArticulos_RowCommand" >
    <Columns>
        <asp:BoundField DataField="Articulo.Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Articulo.Precio" HeaderText="Precio" />
        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:Button ID="btnRestar" runat="server" Text="-" CommandName="Restar" CommandArgument='<%# Container.DataItemIndex %>' />
                <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                <asp:Button ID="btnSumar" runat="server" Text="+" CommandName="Sumar" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
