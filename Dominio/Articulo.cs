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
        
        public Articulo() { }
        public int id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
       
        public Marca marca = new Marca();

        public Categoria categoria = new Categoria();

        public SqlMoney Precio { get; set; }
        public List<string> Imagen { get; set; }

        
        public void Cargar()
        {

        }
    }
    public class Categoria
    {
        public Categoria() { }
        public int IDCategoria { get; set; }
        public string DescripcionCaterogia { get; set; }
    }
    public class Marca
    {
        public Marca() { }
        public int IDMarca { get; set; }
        public string DescripcionMarca { get; set; }

    }
    public class ArticuloEnCarrito
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        public ArticuloEnCarrito(Articulo articulo)
        {
            Articulo = articulo;
            Cantidad = 1;
        }
    }

}
