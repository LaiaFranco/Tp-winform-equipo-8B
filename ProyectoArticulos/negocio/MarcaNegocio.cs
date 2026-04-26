using System.Collections.Generic;
using dominio;

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
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add(new Marca
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"]
                    });
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool existe(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE IdMarca = @id");
                datos.setearParametro("@id", marca.Id);
                return (int)datos.EjecutarScalar() > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (!existe(nueva))
                {
                    datos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@descripcion)");
                    datos.setearParametro("@descripcion", nueva.Descripcion);
                    datos.ejecutarAccion();
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion = @nombre WHERE Id = @id");
                datos.setearParametro("@nombre", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(Marca marca)
        {
            if (existe(marca))
                throw new System.Exception("No se puede eliminar porque hay artículos asociados");

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @id");
                datos.setearParametro("@id", marca.Id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}