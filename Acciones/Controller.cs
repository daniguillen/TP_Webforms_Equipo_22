using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Data.SqlTypes;
using System.Reflection;
using Dominio;
using System.Text.RegularExpressions;

namespace Acciones
{
    public class Controller
    {
        public List<Articulo> listarConSP()
        {
            List<Articulo> Lista = new List<Articulo>();
            AccesoDatos lector = new AccesoDatos();

            //lector.setearQuery("create procedure storedListar as  BEGIN	SELECT a.id,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca,  c.Id AS IDCategoria,  c.Descripcion ,i.ImagenUrl FROM ARTICULOS a inner JOIN marcas m ON a.IdMarca = m.Id inner JOIN categorias c ON a.idcategoria = c.id inner JOIN IMAGENES i ON a.id = i.IdArticulo  exec storedListar  ; end;");
            //lector.setearProcedimiento("storedListar");
            lector.setearQuery("SELECT a.id,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca,  c.Id AS IDCategoria,  c.Descripcion ,i.ImagenUrl FROM ARTICULOS a inner JOIN marcas m ON a.IdMarca = m.Id inner JOIN categorias c ON a.idcategoria = c.id inner JOIN IMAGENES i ON a.id = i.IdArticulo;");
            lector.ejecutarLectura();
            while (lector.Lector.Read())
            {
                Articulo aux = new Articulo();
                
                aux.id = lector.Lector.GetInt32(0);
                aux.Codigo = lector.Lector.GetString(1);
                aux.Nombre = lector.Lector.GetString(2);
                aux.Descripcion = lector.Lector.GetString(3);
                aux.Precio = lector.Lector.GetSqlMoney(4);
                aux.Imagen = lector.Lector.GetString(9);
                aux.marca.IDMarca = lector.Lector.IsDBNull(5) ? 0 : lector.Lector.GetInt32(5);
                aux.marca.DescripcionMarca = lector.Lector.GetString(6);
                aux.categoria.IDCategoria = lector.Lector.GetInt32(7);

                aux.categoria.DescripcionCaterogia = lector.Lector.GetString(8);

                Lista.Add(aux);

            }

            lector.cerrarConexion();
            return Lista;
        }
        public List<Articulo> ListarArticulo()
        {
            List<Articulo> Lista = new List<Articulo>();
           
            AccesoDatos lector = new AccesoDatos();

            lector.setearQuery("SELECT a.id,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca,  c.Id AS IDCategoria,  c.Descripcion ,i.ImagenUrl FROM ARTICULOS a inner JOIN marcas m ON a.IdMarca = m.Id inner JOIN categorias c ON a.idcategoria = c.id inner JOIN IMAGENES i ON a.id = i.IdArticulo;");
            lector.ejecutarLectura();

            while (lector.Lector.Read()) {

                Articulo aux=new Articulo();
             
                aux.id= lector.Lector.GetInt32(0);
                aux.Codigo = lector.Lector.GetString(1);
                aux.Nombre=lector.Lector.GetString(2);
                aux.Descripcion = lector.Lector.GetString(3);
                aux.Precio=lector.Lector.GetSqlMoney(4);
                aux.marca.IDMarca = lector.Lector.GetInt32 (5);
                aux.marca.DescripcionMarca = lector.Lector.GetString(6);
                aux.categoria.IDCategoria = lector.Lector.GetInt32(7);
                aux.categoria.DescripcionCaterogia= lector.Lector.GetString(8);
                aux.Imagen=lector.Lector.GetString(9);
                                                                   
                Lista.Add(aux);
                       
            }

            lector.cerrarConexion();
            return Lista;   
        
        }

        //buscar un articulo
        public List<Articulo> Buscar(string buscar)
        {
            AccesoDatos nuevaConexion = new AccesoDatos();
            List<Articulo> articuloList = new List<Articulo>();


            nuevaConexion.setearQuery("SELECT a.id ,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca, \r\nCASE WHEN c.Id IS NULL THEN '0' ELSE c.Id END AS IDCategoria, \r\nCASE WHEN c.Descripcion IS NULL THEN '0' ELSE c.Descripcion END ,i.ImagenUrl \r\nFROM ARTICULOS a\r\nLEFT JOIN marcas m ON a.IdMarca = m.Id\r\nLEFT JOIN categorias c ON a.idcategoria = c.id \r\nLEFT JOIN IMAGENES i ON a.id = i.IdArticulo where a.Nombre like '%" + buscar + "%' or a.Descripcion like '%" + buscar + "%' or m.Descripcion like '%" + buscar + "%' or c.Descripcion like '%" + buscar + "%';");
            nuevaConexion.ejecutarLectura();
            while (nuevaConexion.Lector.Read())
            {
                Articulo aux = new Articulo();
               

                aux.id= nuevaConexion.Lector.GetInt32(0);
                aux.Codigo = nuevaConexion.Lector.GetString(1);
                aux.Nombre = nuevaConexion.Lector.GetString(2);
                aux.Descripcion = nuevaConexion.Lector.GetString(3);
                aux.Precio = nuevaConexion.Lector.GetSqlMoney(4);
                aux.marca.IDMarca = nuevaConexion.Lector.GetInt32(5);
                aux.marca.DescripcionMarca = nuevaConexion.Lector.GetString(6);
                aux.categoria.IDCategoria = nuevaConexion.Lector.GetInt32(7);
                aux.categoria.DescripcionCaterogia = nuevaConexion.Lector.GetString(8);
                aux.Imagen = nuevaConexion.Lector.GetString(9);

                articuloList.Add(aux);

            }
            nuevaConexion.cerrarConexion(); 
            return articuloList;
        }
        //consulta de marca
        public List<Marca> Marca() {
            AccesoDatos nuevaConexion = new AccesoDatos();
            
            List<Marca> ListaMarca = new List<Marca>();
           

            nuevaConexion.setearQuery("SELECT * from Marcas"); 
            nuevaConexion.ejecutarLectura();
            while (nuevaConexion.Lector.Read())
            {
                Marca auxM = new Marca();
                auxM.IDMarca = nuevaConexion.Lector.GetInt32(5);
                auxM.DescripcionMarca = nuevaConexion.Lector.GetString(6);
                ListaMarca.Add(auxM);
            }
            nuevaConexion.cerrarConexion();
            return ListaMarca;
        }

        //consulta de categoria 
        public List<Categoria> Categoria()
        {
            AccesoDatos nuevaConexion = new AccesoDatos();
            List<Categoria> Categorias = new List<Categoria>();
            nuevaConexion.setearQuery("SELECT * from Categorias");
            nuevaConexion.ejecutarLectura();
            while (nuevaConexion.Lector.Read())
            {
                Categoria auxC = new Categoria();
                auxC.IDCategoria = nuevaConexion.Lector.GetInt32(0);
                auxC.DescripcionCaterogia = nuevaConexion.Lector.GetString(1);
                Categorias.Add(auxC);
            }

            nuevaConexion.cerrarConexion();
            return Categorias;
        }

        //modificar
        public void Modificar(Articulo Modificar, Marca marca, Categoria categoria)
        {

            AccesoDatos nuevaConexion = new AccesoDatos();
            
            nuevaConexion.setearQuery("update ARTICULOS set Codigo='"+ Modificar.Codigo + "', Nombre='" + Modificar.Nombre + "', Descripcion='"+ Modificar.Descripcion + "',IdMarca='"+ marca.IDMarca + "', IdCategoria='"+ categoria.IDCategoria + "', precio='" + Modificar.Precio + "' where id= '" + Modificar.id + "' update IMAGENES set ImagenUrl='" + Modificar.Imagen + "' where '" + Modificar.id + "'=IMAGENES.IdArticulo");
            nuevaConexion.ejecutarLectura();
            nuevaConexion.cerrarConexion();
            
            return;
        }


        public List<Articulo> Busqueda(string buscar)
        {
            AccesoDatos nuevaConexion = new AccesoDatos();

            List<Articulo> articuloList = new List<Articulo>();


            nuevaConexion.setearQuery("SELECT a.id, a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca, CASE WHEN c.Id IS NULL THEN '0' ELSE c.Id END AS IDCategoria, \r\nCASE WHEN c.Descripcion IS NULL THEN '0' ELSE c.Descripcion END ,i.ImagenUrl FROM ARTICULOS a LEFT JOIN marcas m ON a.IdMarca = m.Id LEFT JOIN categorias c ON a.idcategoria = c.id  LEFT JOIN IMAGENES i ON a.id = i.IdArticulo where a.Nombre like '%" + buscar + "%' or a.Descripcion like '%" + buscar + "%' or m.Descripcion like '%" + buscar + "%' or c.Descripcion like '%" + buscar + "%';");
                nuevaConexion.ejecutarLectura();

            while (nuevaConexion.Lector.Read())
            {

                Articulo aux = new Articulo();

                Busqueda auxResultado = new Busqueda();
                aux.id = nuevaConexion.Lector.GetInt32(0);
                aux.Codigo = nuevaConexion.Lector.GetString(1);
                aux.Nombre = nuevaConexion.Lector.GetString(2);
                aux.Descripcion = nuevaConexion.Lector.GetString(3);
                aux.Precio = nuevaConexion.Lector.GetSqlMoney(4);
                aux.marca.IDMarca = nuevaConexion.Lector.GetInt32(5);
                aux.marca.DescripcionMarca = nuevaConexion.Lector.GetString(6);
                aux.categoria.IDCategoria = nuevaConexion.Lector.GetInt32(7);
                aux.categoria.DescripcionCaterogia = nuevaConexion.Lector.GetString(8);
                aux.Imagen = nuevaConexion.Lector.GetString(9);

                

                articuloList.Add(aux);
            }

                nuevaConexion.cerrarConexion();
                return articuloList;
        }

        public void Agregar(Articulo artNuevo)
        {       
            //conexion a bd
            AccesoDatos datos = new AccesoDatos();

            try
            {
              
                datos.setearQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES ('"+artNuevo.Codigo+"','" + artNuevo.Nombre+"', '" + artNuevo.Descripcion + "','" + artNuevo.marca.IDMarca+ "','" + artNuevo.categoria.IDCategoria+ "','" + artNuevo.Precio + "') INSERT INTO IMAGENES(idArticulo, ImagenUrl) VALUES((SELECT MAX(id) FROM Articulos),'" + artNuevo.Imagen + "');");
                datos.ejecutarAccion();
        
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarMarca(string a) 
        {
            AccesoDatos conect= new AccesoDatos();
            string b = a.Substring(0, 1).ToUpper() + a.Substring(1).ToLower();
            conect.setearQuery("insert into MARCAS(descripcion) values('"+b+"');");
            conect.ejecutarAccion();
            conect.cerrarConexion();
        }

        public void AgregarCategoria(string a)
        {
            AccesoDatos conect = new AccesoDatos();

            string b = a.Substring(0, 1).ToUpper() + a.Substring(1).ToLower();
            conect.setearQuery("insert into CATEGORIAS(descripcion) values('" +b+ "');");
            conect.ejecutarAccion();
            conect.cerrarConexion();
        }

        public void EliminarCategoria(string a)
        {
            AccesoDatos conect = new AccesoDatos();
            conect.setearQuery("delete from CATEGORIAS  where Descripcion='"+a+"'");
            conect.ejecutarAccion();
            conect.cerrarConexion();
        }
        public void EliminarMarca(string a)
        {
            AccesoDatos conect = new AccesoDatos();
            conect.setearQuery("delete from MARCAS  where Descripcion='"+a+"'");
            conect.ejecutarAccion();
            conect.cerrarConexion();
        }


        public List<Articulo> BuscarporMarca(string buscar)
        {
            AccesoDatos nuevaConexion = new AccesoDatos();
            List<Articulo> articuloList = new List<Articulo>();

            nuevaConexion.setearQuery("SELECT distinct a.id ,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca, c.Id AS IDCategoria, c.Descripcion,i.ImagenUrl FROM ARTICULOS a INNER JOIN marcas m ON a.IdMarca = m.Id INNER JOIN categorias c ON a.idcategoria = c.id INNER JOIN IMAGENES i ON a.id = i.IdArticulo where m.Descripcion like '%"+ buscar +"%' AND m.Id = a.IdMarca;");
            nuevaConexion.ejecutarLectura();
            while (nuevaConexion.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.id = nuevaConexion.Lector.GetInt32(0);
                aux.Codigo = nuevaConexion.Lector.GetString(1);
                aux.Nombre = nuevaConexion.Lector.GetString(2);
                aux.Descripcion = nuevaConexion.Lector.GetString(3);
                aux.Precio = nuevaConexion.Lector.GetSqlMoney(4);
                aux.marca.IDMarca = nuevaConexion.Lector.GetInt32(5);
                aux.marca.DescripcionMarca = nuevaConexion.Lector.GetString(6);
                aux.categoria.IDCategoria = nuevaConexion.Lector.GetInt32(7);
                aux.categoria.DescripcionCaterogia = nuevaConexion.Lector.GetString(8);
                aux.Imagen = nuevaConexion.Lector.GetString(9);

                articuloList.Add(aux);

            }
            nuevaConexion.cerrarConexion();
            return articuloList;
        }

        public List<Articulo> BuscarporCategoria(string buscar)
        {
            AccesoDatos nuevaConexion = new AccesoDatos();
            List<Articulo> articuloList = new List<Articulo>();

            nuevaConexion.setearQuery("SELECT distinct a.id ,a.Codigo, a.Nombre, a.Descripcion, a.Precio,  m.id as IDMarca, m.Descripcion AS Marca, c.Id AS IDCategoria, c.Descripcion,i.ImagenUrl FROM ARTICULOS a INNER JOIN marcas m ON a.IdMarca = m.Id INNER JOIN categorias c ON a.idcategoria = c.id INNER JOIN IMAGENES i ON a.id = i.IdArticulo where c.Descripcion like '%" + buscar + "%' AND c.Id = a.IdCategoria;");
            nuevaConexion.ejecutarLectura();
            while (nuevaConexion.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.id = nuevaConexion.Lector.GetInt32(0);
                aux.Codigo = nuevaConexion.Lector.GetString(1);
                aux.Nombre = nuevaConexion.Lector.GetString(2);
                aux.Descripcion = nuevaConexion.Lector.GetString(3);
                aux.Precio = nuevaConexion.Lector.GetSqlMoney(4);
                aux.marca.IDMarca = nuevaConexion.Lector.GetInt32(5);
                aux.marca.DescripcionMarca = nuevaConexion.Lector.GetString(6);
                aux.categoria.IDCategoria = nuevaConexion.Lector.GetInt32(7);
                aux.categoria.DescripcionCaterogia = nuevaConexion.Lector.GetString(8);
                aux.Imagen = nuevaConexion.Lector.GetString(9);

                articuloList.Add(aux);

            }
            nuevaConexion.cerrarConexion();
            return articuloList;
        }
    }
    
}
