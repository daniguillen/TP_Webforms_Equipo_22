using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Winforms_Equipo_22
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<ArticuloEnCarrito> Listacarrito;
        public void contadorCarrito() {
            if (Listacarrito.Count > 0)
            {
                int aux = 0;
                for (int i = 0; i < Listacarrito.Count; i++)
                {
                    aux += Listacarrito[i].Cantidad;
                }

                Session["Cantidad"] = aux.ToString();

            }
            else { Session["Cantidad"] = ""; }
        }

        public void totalDeCompra() {

            SqlMoney aux = 0;

            for (int i = 0; i < Listacarrito.Count; i++) 
            {
                
                aux += Listacarrito[i].Cantidad * SqlMoney.Parse(Listacarrito[i].Articulo.Precio.ToString());
                
            }
            
            if (aux != 0)
            {   
                
                lbltotalCompra.Text = "TOTAL= $" + aux;
            }
            else
            {
                lbltotalCompra.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"]  == null && Session["Carrito"]== null)
                {
                    Response.Redirect("Default.aspx");
                }


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
                   // Session["Carrito"] = Listacarrito;
                }

                totalDeCompra();

                dgvArticulos.DataSource = Listacarrito;
                contadorCarrito();
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
            else if (e.CommandName == "Eliminar" )
            {
                Listacarrito.Remove(Listacarrito[index]) ;
               
            }
            Session["Carrito"] = Listacarrito;
            Response.Redirect("Carrito.aspx");
            totalDeCompra() ;

            dgvArticulos.DataSource = Listacarrito;
           
            dgvArticulos.DataBind();
            
        }
    }
}
