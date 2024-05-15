using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Winforms_Equipo_22
{
    public partial class VistaDetallada : System.Web.UI.Page
    {
        public Dominio.Articulo art;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Dominio.Articulo> artVistaDetalle = new List<Dominio.Articulo>();

                int id = int.Parse(Request.QueryString["id"]);

                artVistaDetalle = (List<Dominio.Articulo>)Session["ListaArticulos"];

                art = artVistaDetalle.Find(x => x.id == id);
            }
        }
    }
}