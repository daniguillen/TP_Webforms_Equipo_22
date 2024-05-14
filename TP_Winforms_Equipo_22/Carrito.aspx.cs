using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Winforms_Equipo_22
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<ArticuloEnCarrito> Listacarrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null && Session["ListaArticulos"] != null)
                {
                    Listacarrito = (List<ArticuloEnCarrito>)Session["Carrito"];
                    List<Articulo> Listaoriginal = (List<Articulo>)Session["ListaArticulos"];

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        Articulo seleccionado = Listaoriginal.Find(x => x.id == id);

                        if (seleccionado != null)
                        {
                            ArticuloEnCarrito articuloEnCarrito = Listacarrito.Find(x => x.Articulo.id == id);

                            if (articuloEnCarrito != null)
                            {
                                articuloEnCarrito.Cantidad++;
                            }
                            else
                            {
                                Listacarrito.Add(new ArticuloEnCarrito(seleccionado));
                            }

                            Session["Carrito"] = Listacarrito;
                        }
                    }
                }
                else
                {
                    Listacarrito = new List<ArticuloEnCarrito>();
                    Session["Carrito"] = Listacarrito;
                }

                dgvArticulos.DataSource = Listacarrito;
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Listacarrito = (List<ArticuloEnCarrito>)Session["Carrito"];

            if (e.CommandName == "Sumar")
            {
                Listacarrito[index].Cantidad++;
            }
            else if (e.CommandName == "Restar" && Listacarrito[index].Cantidad > 1)
            {
                Listacarrito[index].Cantidad--;
            }

            Session["Carrito"] = Listacarrito;
            dgvArticulos.DataSource = Listacarrito;
            dgvArticulos.DataBind();
        }
    }
}
