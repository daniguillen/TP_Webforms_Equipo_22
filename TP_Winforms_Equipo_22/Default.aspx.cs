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

                if(carrito.Count > 0)
                {
                        int aux=0;
                      //  Session["Cantidad"] = aux;
                    for (int i = 0; i < carrito.Count; i++)
                    {
                        aux += carrito[i].Cantidad;
                    }
                LblCantidadTotal.Text = aux.ToString();
                    
                }

                
                Page.DataBind();

            }
         

        }



        
    }
}