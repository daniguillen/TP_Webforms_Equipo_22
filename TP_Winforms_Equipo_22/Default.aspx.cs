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
            articulos = new List<Articulo>();
            Controller controller = new Controller();
            articulos = controller.ListarArticulo();
           
        }

        public void BTNAgregar_Click(object sender, EventArgs e)
        {
         
            
        }
    }
}