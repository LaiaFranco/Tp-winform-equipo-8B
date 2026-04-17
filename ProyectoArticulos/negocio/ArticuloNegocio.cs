using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar()
        {   
            List<Articulo> ListaArticulo = new List<Articulo> ();
            AccesoDatos datos = new AccesoDatos();

            try {
                datos.setearConsulta(@"SELECT A.Id AS ArticuloId, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, 
                              A.Precio, A.IdMarca, M.Descripcion AS MarcaDescripcion, 
                              A.IdCategoria, C.Descripcion AS CategoriaDescripcion, 
                              I.Id AS ImagenId, I.ImagenUrl 
                       FROM ARTICULOS A
                       LEFT JOIN MARCAS M ON A.IdMarca = M.Id 
                       LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                       LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo 
                       ORDER BY A.Id");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo nuevoArticulo = new Articulo();

                    nuevoArticulo.Id = (int)datos.Lector["ArticuloId"];
                    nuevoArticulo.Nombre = (string)datos.Lector["Nombre"];
                    nuevoArticulo.Descripcion = (string)datos.Lector["ArticuloDescripcion"];
                    nuevoArticulo.Precio = (decimal)datos.Lector["Precio"];

                    // Marca
                    nuevoArticulo.Marca = new Marca();
                    nuevoArticulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    nuevoArticulo.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    // Categoría
                    nuevoArticulo.Categoria = new Categoria();  
                    nuevoArticulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    nuevoArticulo.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    // Imagen 
                    if (datos.Lector["ImagenId"] != DBNull.Value)
                    {
                        nuevoArticulo.Imagen = new Imagen();
                        nuevoArticulo.Imagen.Id = (int)datos.Lector["ImagenId"];
                        nuevoArticulo.Imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }


                    ListaArticulo.Add(nuevoArticulo);
   
            }

                datos.cerrarConexion();
                return ListaArticulo;

            } catch (Exception ex) {
                throw ex;
            }
           
        }
    }
}
