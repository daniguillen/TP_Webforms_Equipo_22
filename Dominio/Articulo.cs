using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
       
        public Marca marca;

        public Categoria categoria;

        public SqlMoney Precio { get; set; }
        public string Imagen { get; set; }

        public void Cargar()
        {

        }
    }
    public class Categoria
    {
        public int IDCategoria { get; set; }
        public string DescripcionCaterogia { get; set; }
    }
    public class Marca
    {
        public int IDMarca { get; set; }
        public string DescripcionMarca { get; set; }
    }

}
