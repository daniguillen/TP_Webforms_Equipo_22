
<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Carrito.aspx.cs" 
    Inherits="TP_Winforms_Equipo_22.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de artículos</h1>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvArticulos_RowCommand">
        <Columns>
            <asp:BoundField DataField="Articulo.Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Articulo.Precio" HeaderText="Precio" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:Button ID="btnRestar" runat="server" Text="-" 
                        CommandName="Restar" 
                        CommandArgument='<%# Container.DataItemIndex %>'
                         CssClass="btn btn-secondary"/>
                    <asp:Label 
                        ID="lblCantidad" 
                        runat="server" 
                        Text='<%# Bind("Cantidad") %>'>

                    </asp:Label>
                    <asp:Button ID="btnSumar" 
                        runat="server" 
                        Text="+" 
                         CssClass="btn btn-secondary"
                        CommandName="Sumar" 
                        CommandArgument='<%# 
                        Container.DataItemIndex %>' />

                      <asp:Button ID="BtnEliminar" 
                        runat="server" 
                        text="Eliminar"
                        CssClass="btn btn-danger"
                        CommandName="Eliminar" 
                        CommandArgument='<%# Container.DataItemIndex %>'>
                      </asp:Button>
                    <span class="glyphicon glyphicon-trash" style="margin-left: 5px;"></span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <a  href="Default.aspx" class="btn btn-secondary">Seguir Comprando</a>
        <asp:Label ID="lbltotalCompra" CssClass="btn btn-outline-info" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>



        