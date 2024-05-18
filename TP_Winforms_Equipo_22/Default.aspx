<%@ Page Title="Carrito Magico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Winforms_Equipo_22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Catalogo</h1>
                   
    <div>
            <asp:TextBox ID="TxtBox_busqueda" runat="server" placeholder="Busqueda"></asp:TextBox>
    <span class="glyphicon glyphicon-search"></span>
            <asp:Button ID="BTN_buscar" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BTN_buscar_Click" />
        </div>
           <asp:DropDownList ID="DropDownList1" runat="server" class="form-select" CssClass="btn btn-secondary btn-sm dropdown-toggle">
           <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
            <asp:ListItem Value="Marca">Marca</asp:ListItem>
            <asp:ListItem Value="Categoria">Categoría</asp:ListItem>
            </asp:DropDownList>
  
                    <div id="carouselExample" class="carousel slide">
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="https://upload.wikimedia.org/wikipedia/commons/8/88/Tecnolog%C3%ADa_celulares.jpg" class="d-block w-100" alt="...">
                    <h5>Celulares</h5>
                    <p>Los mejores celulares para la venta, con promociones increíbles</p>
                </div>
                <div class="carousel-item">
                  <img src="https://www.lg.com/ar/televisores/lg-79UB9800" class="d-block w-100" alt="...">
                     <h5>Televisores</h5>
                    <p>Veni a chusmear los televisores, y llevate el más grande</p>
                </div>
                <div class="carousel-item">
                  <img src="https://www.shutterstock.com/es/image-vector/set-handheld-game-consoles-isolated-vector-2182533173" class="d-block w-100" alt="...">
                 <h5>Consolas</h5>
             <p>Los mejores precios en consolas</p>
                </div>
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
    
        <div class="row row-cols-1 row-cols-md-3 g-4 ">
            <% foreach (Dominio.Articulo articulo in articulos)
                { %>
  
               <div class="col">
                 <div class="card">
                   <img src="<%= articulo.Imagen %>" class="card-img-top",   alt="...">
                      <div class="card-body">
                      <h5 class="card-title"><%= articulo.Nombre %></h5>
                      <p class="card-text" id="cardID"><%= articulo.Descripcion %></p>
                         <a href="Carrito.aspx?id=<%=articulo.id %>" class="btn btn-primary" >Comprar</a>
                         <a href="VistaDetallada.aspx?id=<%=articulo.id %>" class="btn btn-primary">Detalle</a>
                          
                      </div>
                   </div>
               </div>
 
            <% } %>
        </div>
   

    


</asp:Content>
