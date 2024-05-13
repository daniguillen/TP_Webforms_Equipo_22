using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Acciones;

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
            List<Articulo> carrito = new List<Articulo>();
                if (Session["Carrito"] != null)
                    carrito = (List<Articulo>)Session["Carrito"];
                else {
                    Session["Carrito"]= carrito;
                }


            Controller controller = new Controller();
            articulos = controller.ListarArticulo();

            Session["ListaArticulos"] = articulos;

            Page.DataBind();

            }
         

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}