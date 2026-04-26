using System;
using System.Collections.Generic;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
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
                                LEFT JOIN (
                                    SELECT IdArticulo, Id, ImagenUrl,
                                           ROW_NUMBER() OVER (PARTITION BY IdArticulo ORDER BY Id) AS rn
                                    FROM IMAGENES
                                ) I ON A.Id = I.IdArticulo AND I.rn = 1
                                ORDER BY A.Id");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["ArticuloId"];
                    art.CodigoDeArtculo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();
                    art.Descripcion = datos.Lector["ArticuloDescripcion"].ToString();
                    art.Precio = (decimal)datos.Lector["Precio"];

                    if (datos.Lector["IdMarca"] != DBNull.Value)
                    {
                        art.Marca = new Marca
                        {
                            Id = (int)datos.Lector["IdMarca"],
                            Descripcion = datos.Lector["MarcaDescripcion"].ToString()
                        };
                    }

                    if (datos.Lector["IdCategoria"] != DBNull.Value)
                    {
                        art.Categoria = new Categoria
                        {
                            Id = (int)datos.Lector["IdCategoria"],
                            Descripcion = datos.Lector["CategoriaDescripcion"].ToString()
                        };
                    }

                    if (datos.Lector["ImagenId"] != DBNull.Value)
                    {
                        art.Imagen = new Imagen
                        {
                            Id = (int)datos.Lector["ImagenId"],
                            UrlImagen = datos.Lector["ImagenUrl"].ToString()
                        };
                    }

                    lista.Add(art);
                }
                return lista;
            }
            catch (Exception ex) { 
                
                throw ex; 
            
            
            }
            finally { 
                datos.cerrarConexion(); 
            
            }
        }

        public List<Articulo> listarIdxCodigo()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Codigo FROM ARTICULOS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    articulos.Add(new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        CodigoDeArtculo = datos.Lector["Codigo"].ToString()
                    });
                }
                return articulos;
            }
            catch (Exception ex) { 
                throw ex; 
            }
            finally { 
                datos.cerrarConexion(); 
            }
        }

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)");
                datos.setearParametro("@codigo", nuevo.CodigoDeArtculo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public void Modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id");
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@codigo", art.CodigoDeArtculo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { 
                throw ex;
            }
            finally { 
                datos.cerrarConexion(); 
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { 
                throw ex;
            }
            finally { 
                datos.cerrarConexion(); 
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, 
                                       A.Precio, A.IdMarca, M.Descripcion AS Marca, 
                                       A.IdCategoria, C.Descripcion AS Categoria, 
                                       I.Id AS ImagenId, I.ImagenUrl
                                FROM ARTICULOS A
                                LEFT JOIN MARCAS M ON A.IdMarca = M.Id 
                                LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                                LEFT JOIN (
                                    SELECT IdArticulo, Id, ImagenUrl,
                                           ROW_NUMBER() OVER (PARTITION BY IdArticulo ORDER BY Id) AS rn
                                    FROM IMAGENES
                                ) I ON A.Id = I.IdArticulo AND I.rn = 1";

                string where = "";
                object valorParam = null;

                if (campo == "Cod.Articulo")
                    where = "A.Codigo LIKE @filtro";
                else if (campo == "Nombre")
                    where = "A.Nombre LIKE @filtro";
                else if (campo == "Descripcion")
                    where = "A.Descripcion LIKE @filtro";
                else if (campo == "Marca")
                    where = "M.Descripcion LIKE @filtro";
                else if (campo == "Categoria")
                    where = "C.Descripcion LIKE @filtro";
                else // Precio
                {
                    if (!decimal.TryParse(filtro, out decimal precio))
                        return lista;
                    switch (criterio)
                    {
                        case "Mayor a": where = "A.Precio > @filtro"; break;
                        case "Menor a": where = "A.Precio < @filtro"; break;
                        default: where = "A.Precio = @filtro"; break;
                    }
                    valorParam = precio;
                }

                if (!string.IsNullOrEmpty(where) && campo != "Precio")
                {
                    string pattern = "";
                    switch (criterio)
                    {
                        case "Comienza con": pattern = filtro + "%"; break;
                        case "Termina con": pattern = "%" + filtro; break;
                        default: pattern = "%" + filtro + "%"; break;
                    }
                    valorParam = pattern;
                }

                if (!string.IsNullOrEmpty(where))
                {
                    consulta += " WHERE " + where;
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@filtro", valorParam);
                }
                else
                {
                    datos.setearConsulta(consulta);
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.CodigoDeArtculo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();
                    art.Descripcion = datos.Lector["Descripcion"].ToString();
                    art.Precio = (decimal)datos.Lector["Precio"];

                    art.Marca = new Marca { Descripcion = datos.Lector["Marca"].ToString() };
                    art.Categoria = new Categoria { Descripcion = datos.Lector["Categoria"].ToString() };

                    if (datos.Lector["ImagenId"] != DBNull.Value)
                    {
                        art.Imagen = new Imagen { UrlImagen = datos.Lector["ImagenUrl"].ToString() };
                    }

                    lista.Add(art);
                }
                return lista;
            }
            catch (Exception ex) { 
                throw ex; 
            }
            finally { 
                datos.cerrarConexion(); 
            }
        }
    }
}