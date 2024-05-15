<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaDetallada.aspx.cs" Inherits="TP_Winforms_Equipo_22.VistaDetallada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Vista detalle</h1>

    <div class="card mb-3">
        <img src="<%=art.Imagen%>" class="card-img-top" alt="...">
        <div class="card-body">
            <h4 class="card-title"><%=art.Nombre %></h4>
            <h5 class="card-title"><%=art.marca.DescripcionMarca %></h5>
            <h5 class="card-title"><%=art.categoria.DescripcionCaterogia %></h5>
            <h4 class="card-title">$<%=art.Precio %></h4>
            <p class="card-text"><%=art.Descripcion %></p>
            <p class="card-text"><small class="text-body-secondary">Codigo: <%=art.Codigo %></small></p>
            <a href="Carrito.aspx?id=<%=art.id %>" class="btn btn-primary">Agregar</a>

        </div>
    </div>
</asp:Content>


                       
