using dominio;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
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

        public bool existe(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT COUNT(*) FROM MARCAS WHERE Descripcion = @descripcion";
                datos.setearConsulta(consulta);
                datos.setearParametro("@descripcion", marca.Descripcion);
                return (int)datos.EjecutarScalar() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Marca nuevo)
        {
           

            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (!existe(nuevo))
                {
                    datos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@descripcion)");
                    datos.setearParametro("@descripcion", nuevo.Descripcion);

                    datos.ejecutarAccion();
                }
              
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
            try
            {
                datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @id");
                datos.setearParametro("@id",id);

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
    }
}
