using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

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

                        Articulo nuevoArticulo = new Articulo();


                        nuevoArticulo.Id = (int)(datos.Lector["ArticuloId"]);
                        nuevoArticulo.CodigoDeArtculo = datos.Lector["Codigo"].ToString();
                        nuevoArticulo.Nombre = datos.Lector["Nombre"].ToString();
                        nuevoArticulo.Descripcion = datos.Lector["ArticuloDescripcion"].ToString();
                        nuevoArticulo.Precio = (decimal)(datos.Lector["Precio"]);

                        // Marca
                        if (datos.Lector["IdMarca"] != DBNull.Value)
                        {
                            nuevoArticulo.Marca = new Marca();
                            nuevoArticulo.Marca.Id = (int)(datos.Lector["IdMarca"]);
                            nuevoArticulo.Marca.Descripcion = datos.Lector["MarcaDescripcion"].ToString();
                        }

                        // Categoria
                        if (datos.Lector["IdCategoria"] != DBNull.Value)
                        {
                            nuevoArticulo.Categoria = new Categoria();
                            nuevoArticulo.Categoria.Id = (int)(datos.Lector["IdCategoria"]);
                            nuevoArticulo.Categoria.Descripcion = datos.Lector["CategoriaDescripcion"].ToString();
                        }

                        // Imagen
                        if (datos.Lector["ImagenId"] != DBNull.Value)
                        {
                            nuevoArticulo.Imagen = new Imagen();
                            nuevoArticulo.Imagen.Id = (int)(datos.Lector["ImagenId"]);
                            nuevoArticulo.Imagen.UrlImagen = datos.Lector["ImagenUrl"].ToString();
                        }

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

    }
}
