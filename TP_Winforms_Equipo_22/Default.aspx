<%@ Page Title="Carrito Magico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Winforms_Equipo_22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h1>Catalogo</h1>
<div class="card-container  justify-content-between d-flex">

<% foreach (Dominio.Articulo articulo in articulos)
    { %>
  
    <div class="row" style= "width:100%">
  <div class="col-sm-6">
    <div class="card">
         <img src="<%= articulo.Imagen %>" class="card-img-top",   alt="...">
      <div class="card-body">
        <h5 class="card-title">Special title treatment</h5>
        <p class="card-text"><%= articulo.Nombre %> </p>
       <asp:Button ID="BTNAgregar" runat="server" OnClick="BTNAgregar_Click" Text="Agregar" class="btn btn-primary" CommandArgument='<%articulo.id %>'/>
      </div>
    </div>
  </div>
</div>
 
    <% } %>

</div>


</asp:Content>
