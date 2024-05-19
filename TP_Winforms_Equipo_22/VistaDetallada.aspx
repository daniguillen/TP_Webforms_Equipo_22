<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaDetallada.aspx.cs" Inherits="TP_Winforms_Equipo_22.VistaDetallada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="blog section-padding" data-scroll-index="5" style="padding-top: 0;">
        <div class="container mt-0">
            <div class="row">
                <div class="col-12">
                    <div class="sec-head bord-thin-bottom pb-20 mb-80 d-flex justify-content-evenly">
                        <h2><%=art.Nombre %></h2>
                        <h2>Marca: <%=art.marca.DescripcionMarca %></h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div style="max-width: 100%;" class="d-flex justify-content-center mb-30 col-6 ">
                    <div id="carouselExampleCaptions" class="carousel slide carousel-dark" data-bs-ride="carousel" style="max-width: 600px;">
                        <div class="carousel-indicators">
                            <% for (int i = 0; i < art.Imagen.Count; i++)
                                { %>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="<%=i %>" class="<%=i == 0 ? "active" : "" %>" aria-current="<%=i == 0 ? "true" : "false" %>" aria-label="Slide <%=i + 1 %>"></button>
                            <% } %>
                        </div>
                        <div class="carousel-inner">
                            <% 
                                for (int i = 0; i < art.Imagen.Count; i++)
                                {
                                    string imagenUrl = art.Imagen[i];
                                    string activeClass = i == 0 ? "active" : "";
                            %>
                            <div class="carousel-item <%=activeClass %>">
                                <img src="<%=imagenUrl %>" class="rounded d-block w-100 img-fluid" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5 style="display: none;">Slide <%=i + 1 %></h5>
                                    <p style="display: none;">Imagen <%=i + 1 %></p>
                                </div>
                            </div>
                            <% } %>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev" style="color:olivedrab">
                            <span class="carousel-control-prev-icon rounded-circle" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next" style="color:olivedrab">
                            <span class="carousel-control-next-icon rounded-circle" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
           



            <div class="col-6">

                <div class="row">
                    <div class="col-12 ">

                        <p>Categoria: <%=art.categoria.DescripcionCaterogia %></p>
                        <p>Precio: $<%=art.Precio %></p>
                        <p>Descripcion: <%=art.Descripcion %></p>
                        <p>Codigo: <%=art.Codigo %></p>
                    </div>



                    <div class="d-flex justify-content-evenly col-12">
                        <a href="Carrito.aspx?id=<%=art.id %>" class="btn btn-primary">Comprar</a>
                        <a href="Default.aspx?id=<%=art.id %>" class="btn btn-secondary">Volver</a>
                    </div>
                </div>

            </div>

        </div>
        </div>
    </section>
</asp:Content>
