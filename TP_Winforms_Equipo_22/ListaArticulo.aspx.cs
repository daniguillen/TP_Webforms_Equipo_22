using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acciones;

namespace TP_Winforms_Equipo_22
{
    public partial class ListaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller artController = new Controller();
            dgvArticulos.DataSource = artController.listarConSP();
            dgvArticulos.DataBind();    //en el ambito web enlazamaos los datos
        }
    }
}