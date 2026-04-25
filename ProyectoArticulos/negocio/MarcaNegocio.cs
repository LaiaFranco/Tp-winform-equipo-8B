using dominio;  
using System;
using System.Collections.Generic;
using System.Data;
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
                datos.setearConsulta(@"SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @id");
                datos.setearParametro("@id",marca.Id);
                return (int)datos.EjecutarScalar()>0;
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

        public void Modificar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET " +
                    "Descripcion = @nombre" +
                    "WHERE Id = @id"
                    );
                datos.setearParametro("@nombre",nuevo.Descripcion);

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

        public void Eliminar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (!existe(marca)) { 
                    datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @id");
                    datos.setearParametro("@id", marca.Id);
                    datos.ejecutarAccion();
                }
                else
                {
                    throw new Exception("No se puede eliminar porque hay articulos asociados"); 
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
    }
}
