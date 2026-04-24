using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio; 

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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

        public void Agregar(Categoria nuevaCategoria)
        {

            AccesoDatos datos = new AccesoDatos();

           try {

                datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion)" + 
                    "VALUES(@descripcion)");

                datos.setearParametro("@descripcion",nuevaCategoria.Descripcion);
                
                datos.ejecutarAccion();

            }catch(Exception ex){
                throw ex;
            }
            finally { datos.cerrarConexion();}

        }

        public void Actualizar(Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try {

                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @id");

                datos.setearParametro("@id", nuevaCategoria.Id);
                datos.setearParametro("@descripcion", nuevaCategoria.Descripcion);

                datos.ejecutarAccion();
           

            } catch (Exception ex) {

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

            try
            {

                datos.setearConsulta("DELETE FROM CATEGORIAS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }


    }

    
}

