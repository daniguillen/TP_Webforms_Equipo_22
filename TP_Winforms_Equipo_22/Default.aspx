<%@ Page Title="Carrito Magico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Winforms_Equipo_22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Catalogo</h1>
                   
    <div>
            <asp:TextBox ID="TxtBox_busqueda" runat="server" placeholder="Busqueda"></asp:TextBox>
    <span class="glyphicon glyphicon-search"></span>
            <asp:Button ID="BTN_buscar" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BTN_buscar_Click" />
        </div>
           <asp:DropDownList ID="DropDownList1" runat="server" class="form-select">
           <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
            <asp:ListItem Value="Marca">Marca</asp:ListItem>
            <asp:ListItem Value="Categoria">Categoría</asp:ListItem>
            </asp:DropDownList>
  
        
    
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
