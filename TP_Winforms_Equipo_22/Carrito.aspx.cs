using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acciones;
using Dominio;

namespace TP_Winforms_Equipo_22
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> Listacarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                Listacarrito = (List<Articulo>)Session["Carrito"];
            }
            else
            {
                Listacarrito = new List<Articulo>();
            }
            dgvArticulos.DataSource = Listacarrito;
            dgvArticulos.DataBind();
        }
    }
}