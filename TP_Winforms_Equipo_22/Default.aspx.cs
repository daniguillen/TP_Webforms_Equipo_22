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
                    Session.Add("Carrito", carrito);
                }


            Controller controller = new Controller();
            articulos = controller.ListarArticulo();


                Page.DataBind();

            }
         


        }

        public void BTNAgregar_Click(object sender, EventArgs e)
        {

            string parametro = ((LinkButton)sender).CommandArgument;
            int id = int.Parse(parametro);
            Articulo articulo = new Articulo();
            articulo= articulos.Find(a => a.id == id);
            Session.Add("Carrito", articulo);
            







        }
    }
}