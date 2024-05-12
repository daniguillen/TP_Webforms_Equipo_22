<%@ Page Title="Carrito Magico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Winforms_Equipo_22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Catalogo</h1>
    
        <div class="row row-cols-1 row-cols-md-3 g-4 ">
            <% foreach (Dominio.Articulo articulo in articulos) 
            { %>
  
                    <div class="col">
                    <div class="card">
                        <img src="<%= articulo.Imagen %>" class="card-img-top",   alt="...">
                        <div class="card-body">
                        <h5 class="card-title">Special title treatment</h5>
                        <p class="card-text" id="cardID"><%= articulo.id %></p>
                            <asp:Label ID="Label1" runat="server" Text='<%= articulo.id %>'></asp:Label>
                        <asp:Button ID="BtnCard" runat="server" OnClick="BTNAgregar_Click" Text="Agregar" class="btn btn-primary" CommandArgument='<%= articulo.id %>' />
                        </div>
                    </div>
                  </div>
 
            <% } %>
        </div>

    


</asp:Content>
