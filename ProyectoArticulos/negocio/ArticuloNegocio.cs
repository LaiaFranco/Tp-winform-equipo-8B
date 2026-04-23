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
                string consulta =  @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, 
                                       A.Precio, A.IdMarca, M.Descripcion AS Marca, 
                                       A.IdCategoria, C.Descripcion AS Categoria, 
                                       I.Id AS ImagenId, I.ImagenUrl
                                       FROM ARTICULOS A
                                       LEFT JOIN MARCAS M ON A.IdMarca = M.Id 
                                       LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                                       LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id"; 

                if (campo == "Cod.Articulo")
                {
                    switch (criterio)
                    { 
                        case "Comienza con":
                            consulta += " where A.Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " where A.Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where A.Codigo like '%" + filtro + "%'";
                            break;
                    }
                 }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where A.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " where A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                
                }
                else if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " where A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where A.Descripcion like '%" + filtro + "%'";
                            break;
                    }

                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where M.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " where M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                    
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " where C.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " where C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " where C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                    
                }
                else 
                 {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " where A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += " where A.Precio < " + filtro;
                            break;
                        default:
                            consulta += " where A.Precio = " + filtro;
                            break;
                    }
                 }

                
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo nuevoArticulo = new Articulo();

                    nuevoArticulo.Id = (int)(datos.Lector["Id"]);
                    nuevoArticulo.CodigoDeArtculo = datos.Lector["Codigo"].ToString();
                    nuevoArticulo.Nombre = datos.Lector["Nombre"].ToString();
                    nuevoArticulo.Descripcion = datos.Lector["Descripcion"].ToString();
                    nuevoArticulo.Precio = (decimal)(datos.Lector["Precio"]);

                    // Marca
                  
                     nuevoArticulo.Marca = new Marca();
                     nuevoArticulo.Marca.Descripcion = datos.Lector["Marca"].ToString();


                    // Categoria

                     nuevoArticulo.Categoria = new Categoria();
                     nuevoArticulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();


                    // Imagen

                     nuevoArticulo.Imagen = new Imagen();
                     nuevoArticulo.Imagen.UrlImagen = datos.Lector["ImagenUrl"].ToString();
                    

                    lista.Add(nuevoArticulo);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }   
}
