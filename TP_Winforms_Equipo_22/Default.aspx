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
                      <h5 class="card-title"><%= articulo.Nombre %></h5>
                      <p class="card-text" id="cardID"><%= articulo.Descripcion %></p>
                         <a href="Carrito.aspx?id=<%=articulo.id %>" class="btn btn-primary">Agregar</a>

                      </div>
                   </div>
               </div>
 
            <% } %>
        </div>
    <asp:Label ID="LblCantidadTotal" runat="server" Text=""></asp:Label>

    


</asp:Content>
