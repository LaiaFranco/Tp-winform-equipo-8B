using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Linq.Expressions;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar()
        {
            List<Articulo> ListaArticulo = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT A.Id AS ArticuloId, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, 
                         A.Precio, A.IdMarca, M.Descripcion AS MarcaDescripcion, 
                         A.IdCategoria, C.Descripcion AS CategoriaDescripcion, 
                         I.Id AS ImagenId, I.ImagenUrl
                  FROM ARTICULOS A
                  LEFT JOIN MARCAS M ON A.IdMarca = M.Id 
                  LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                  LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id  
                  ORDER BY A.Id");

                datos.ejecutarLectura();


                if (datos.Lector != null)
                {
                    while (datos.Lector.Read())
                    {
                        Articulo nuevoArticulo = CargarArticulo(datos.Lector); 
                       
                        ListaArticulo.Add(nuevoArticulo);
                    }
                }

                return ListaArticulo;
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
        public Articulo CargarArticulo(SqlDataReader Lector)
        {
            Articulo nuevoArticulo = new Articulo();

            nuevoArticulo.Id = (int)(Lector["ArticuloId"]);
            nuevoArticulo.CodigoDeArtculo = Lector["Codigo"].ToString();
            nuevoArticulo.Nombre = Lector["Nombre"].ToString();
            nuevoArticulo.Descripcion = Lector["ArticuloDescripcion"].ToString();
            nuevoArticulo.Precio = (decimal)(Lector["Precio"]);

            // Marca
            if (Lector["IdMarca"] != DBNull.Value)
            {
                nuevoArticulo.Marca = new Marca();
                nuevoArticulo.Marca.Id = (int)(Lector["IdMarca"]);
                nuevoArticulo.Marca.Descripcion = Lector["MarcaDescripcion"].ToString();
            }

            // Categoria
            if (Lector["IdCategoria"] != DBNull.Value)
            {
                nuevoArticulo.Categoria = new Categoria();
                nuevoArticulo.Categoria.Id = (int)(Lector["IdCategoria"]);
                nuevoArticulo.Categoria.Descripcion = Lector["CategoriaDescripcion"].ToString();
            }

            // Imagen
            if (Lector["ImagenId"] != DBNull.Value)
            {
                nuevoArticulo.Imagen = new Imagen();
                nuevoArticulo.Imagen.Id = (int)(Lector["ImagenId"]);
                nuevoArticulo.Imagen.UrlImagen = Lector["ImagenUrl"].ToString();
            }

            return nuevoArticulo; 

        }

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                     "VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)");

                datos.setearParametro("@codigo", nuevo.CodigoDeArtculo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);

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

        public void Actualizar(Articulo art) {

            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id");

                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@codigo", art.CodigoDeArtculo);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);

                datos.ejecutarAccion();

            }

            catch (Exception ex) {

                throw ex;

            }
            finally
            {

                datos.cerrarConexion();

            }

        }

        public void Modificar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET " +
                           "Codigo = @codigo, " +
                           "Nombre = @nombre, " +
                           "Descripcion = @descripcion, " +
                           "IdMarca = @idMarca, " +
                           "IdCategoria = @idCategoria, " +
                           "Precio = @precio " +
                           "WHERE Id = @id"
                           );
                datos.setearParametro("@codigo", nuevo.CodigoDeArtculo); 
                datos.setearParametro("@nombre",nuevo.Nombre);
                datos.setearParametro("@descripcion",nuevo.Descripcion);
                datos.setearParametro("@idMarca",nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria",nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@Id", nuevo.Id); 

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


        public void Eliminar(int id)
        { 
            AccesoDatos datos = new AccesoDatos();
            try {

                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();


            } catch (Exception ex) {

                throw ex;
            
            }
            finally
            {

                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Codigo, A.Nombre,  A.Descripcion,  M.Descripcion AS Marca, C.Descripcion AS Categoria, I.ImagenUrl,  A.Id" +
                    "FROM ARTICULOS A INNER " +
                    "JOIN MARCAS M ON M.Id = A.IdMarca " +
                    "INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria" +
                    "LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id";

                if (campo == "Codigo")
                {
                    consulta = Campo("Codigo",consulta, criterio,filtro);

                }
                else if (campo == "Nombre")
                {
                    consulta = Campo("Nombre", consulta, criterio,filtro);
                }
                else if (campo == "Descripcion")
                {

                    consulta = Campo("Descripcion",consulta ,criterio,filtro);
                }
                else if (campo == "Marca")
                {
                    consulta = Campo("Marca",consulta ,criterio,filtro);
                }
                else if (campo == "Categoria")
                {
                    consulta = Campo("Categoria",consulta ,criterio,filtro);
                }
                else 
                 {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                 }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo nuevoArticulo = negocio.CargarArticulo(datos.Lector);

                    lista.Add(nuevoArticulo);

                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Campo(string campo,string consulta,string criterio,string filtro)
        {

            switch (criterio)
            {
                case "Comienza con":
                    consulta += campo + " LIKE '" + filtro + "%'";
                    break;

                case "Termina con":
                    consulta += campo + " LIKE '%" + filtro + "'";
                    break;

                case "Igual a":
                    consulta += campo + " = '" + filtro + "'";
                    break;

                default:
                    consulta += campo + " LIKE '%" + filtro + "%'";
                    break;
            }

            return consulta;
        }


    }   
}
