<%@ Page Title="Carrito Magico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Winforms_Equipo_22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Catalogo</h1>


    <div class="d-flex mb-5">
        <div class="d-flex justify-content-center">

        <div class="rounded border border-secondary bordebusqueda d-flex align-items-center">
            <asp:TextBox ID="TxtBox_busqueda" runat="server" placeholder="Busqueda" CssClass=" btnsearch" Style="background-color:transparent"></asp:TextBox>
            <span class="glyphicon glyphicon-search"></span>
        </div>
       
        <asp:Button ID="BTN_buscar" runat="server" Text="Buscar" class="btn btn-primary me-3 ms-2"  OnClick="BTN_buscar_Click" />
        </div>
        <div>


    <label>Busqueda por: </label>
    <asp:DropDownList ID="DropDownList1" runat="server" class="form-select" CssClass="btn btn-secondary btn-sm dropdown-toggle">
        <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
        <asp:ListItem Value="Marca">Marca</asp:ListItem>
        <asp:ListItem Value="Categoria">Categoría</asp:ListItem>
    </asp:DropDownList>
        </div>
    </div>



    <div class="row row-cols-1 row-cols-md-3 g-4 " >
        <% foreach (Dominio.Articulo articulo in articulos)
            { %>

        <div class="col">
            <div class="card" style=" border: 3px solid lightgreen">
                <div class="card-body" id="ContenedorImagen" style="background-color: dimgray">
                    <img src="<%=articulo.Imagen[0] %>" class="card-img-top imagenGaleria" alt="..." />
                </div>
                <div class="card-body revisionPadding" style="background-color:gray ">
                    <h3 class="card-title text-center"><%= articulo.Nombre %></h3>
                    <p class="card-text text-center mt-3 mb-3" id="cardID"><%= articulo.Descripcion %></p>
                    <div class="d-flex justify-content-around mt-3">
                        <a href="Carrito.aspx?id=<%=articulo.id %>" class="btn btn-primary">Comprar</a>
                        <a href="VistaDetallada.aspx?id=<%=articulo.id %>" class="btn btn-primary">Detalle</a>
                    </div>
                </div>
            </div>
        </div>

        <% } %>
    </div>




</asp:Content>
