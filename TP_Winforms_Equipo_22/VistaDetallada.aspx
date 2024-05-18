<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaDetallada.aspx.cs" Inherits="TP_Winforms_Equipo_22.VistaDetallada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Vista detalle</h1>
    <div class="card mb-3">
        <div id="carouselExample" class="carousel slide">
            <div class="carousel-inner">
                <% 
                  for (int i = 0; i < art.Imagen.Count; i++)
                    {
                        string imagenUrl = art.Imagen[i];
                        string activeClass = i == 0 ? "active" : "";
                %>
                <div class="carousel-item <%=activeClass %>">
                    <img src="<%=imagenUrl %>" class="d-block w-100" alt="...">
                </div>
                 <% } %>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <div class="card-body">
            <h4 class="card-title"><%=art.Nombre %></h4>
            <h5 class="card-title"><%=art.marca.DescripcionMarca %></h5>
            <h5 class="card-title"><%=art.categoria.DescripcionCaterogia %></h5>
            <h4 class="card-title">$<%=art.Precio %></h4>
            <p class="card-text"><%=art.Descripcion %></p>
            <p class="card-text"><small class="text-body-secondary">Codigo: <%=art.Codigo %></small></p>
            <a href="Carrito.aspx?id=<%=art.id %>" class="btn btn-primary">Comprar</a>
            <a href="Default.aspx?id=<%=art.id %>" class="btn btn-primary">Volver</a>

        </div>
    </div>
</asp:Content>



