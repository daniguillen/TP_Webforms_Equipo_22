using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Acciones;
using System.Security.Cryptography.X509Certificates;
using System.Management.Instrumentation;
using System.Diagnostics;

namespace TP_Winforms_Equipo_22
{
    public partial class _Default : Page
    {
           public List<Articulo> articulos {  get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
 

            if (!IsPostBack)
            {

            articulos = new List<Articulo>();
            List<ArticuloEnCarrito> carrito = new List<ArticuloEnCarrito>();
                if (Session["Carrito"] != null)
                    carrito = (List<ArticuloEnCarrito>)Session["Carrito"];
                else {
                    Session["Carrito"]= carrito;
                }

            Controller controller = new Controller();
            articulos = controller.ListarArticulo();

            Session["ListaArticulos"] = articulos;

                Page.DataBind();

            }
        }

        protected void BTN_buscar_Click(object sender, EventArgs e)
        {
            string nombre_buscar = TxtBox_busqueda.Text;

            // Obtener la lista de artículos de la sesión
            articulos = (List<Articulo>)Session["ListaArticulos"];

            articulos = BusquedaGeneral(nombre_buscar, "Nombre");

            Page.DataBind();
        }

          
        public List<Articulo> BusquedaGeneral(string a, string b)
        {
            b = DropDownList1.SelectedValue;
            List <Articulo> Resultado = new List<Articulo>();
            switch (b){ 
                
                case "Marca":
                    Resultado = articulos.FindAll(x => x.marca.DescripcionMarca.ToLower().Contains(a.ToLower()));
                    break;
                case "Categoria":
                    Resultado = articulos.FindAll(x => x.categoria.DescripcionCaterogia.ToLower().Contains(a.ToLower()));
                    break;
                case "Nombre":
                    Resultado = articulos.FindAll(x => x.Nombre.ToLower().Contains(a.ToLower()));
                    break;

            };
                      
            return Resultado;
        }
    }
}
