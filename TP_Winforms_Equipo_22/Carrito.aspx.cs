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
          if (Session["Carrito"] != null && Session["ListaArticulos"] != null)
            {
                Listacarrito = (List<Articulo>)Session["Carrito"];
                List<Articulo> Listaoriginal = (List<Articulo>)Session["ListaArticulos"];

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    Articulo seleccionado = Listaoriginal.Find(x => x.id == id);
                    if (seleccionado != null)
                    {
                        Listacarrito.Add(seleccionado);
                        // Actualiza el carrito en la sesión
                        Session["Carrito"] = Listacarrito;
                    }
                }
            }
            else
            {
                Listacarrito = new List<Articulo>();
                Session["Carrito"] = Listacarrito;
            }
            dgvArticulos.DataSource = Listacarrito;
            dgvArticulos.DataBind();
        }
    }
}