using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acciones;
using Dominio;

namespace TP_Winforms_Equipo_22
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<ArticuloEnCarrito> Listacarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null && Session["ListaArticulos"] != null)
            {
                Listacarrito = (List<Dominio.ArticuloEnCarrito>)Session["Carrito"];
                List<Articulo> Listaoriginal = (List<Articulo>)Session["ListaArticulos"];

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Articulo seleccionado = Listaoriginal.Find(x => x.id == id);

                    if (seleccionado != null)
                    {
                        // Buscar si el artículo ya está en el carrito
                        ArticuloEnCarrito articuloEnCarrito = Listacarrito.Find(x => x.Articulo.id == id);

                        if (articuloEnCarrito != null)
                        {
                            // Incrementar cantidad
                            articuloEnCarrito.Cantidad++;
                        }
                        else
                        {
                            // Agregar nuevo artículo al carrito
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

            // Adaptar la asignación al DataSource según las propiedades que quieras mostrar
            dgvArticulos.DataSource = Listacarrito;
            dgvArticulos.DataBind();

        }
        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                        
                int index = Convert.ToInt32(e.CommandArgument);
                Listacarrito = (List<ArticuloEnCarrito>)Session["Carrito"];

                if (e.CommandName == "Sumar")
                    Listacarrito[index].Cantidad++;
                {
                }
                if (e.CommandName == "Restar" && Listacarrito[index].Cantidad > 1)
                {
                    Listacarrito[index].Cantidad--;
                }

                Session["Carrito"] = Listacarrito;
                dgvArticulos.DataSource = Listacarrito;
                dgvArticulos.DataBind();
            }
        }

 
    }
