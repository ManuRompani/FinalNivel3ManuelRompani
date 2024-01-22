using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarcas(string id, string criterioId, string nombre)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<Marca> lista = new List<Marca>();
            try
            {
                string consulta = "Select Id, Descripcion from MARCAS";
                string condiciones = "";

                //Id
                if (criterioId != "Todos" && id != "")
                {
                    switch (criterioId)
                    {
                        case "Mayor a":
                            condiciones += " Id > " + id;
                            break;
                        case "Menor a":
                            condiciones += " Id < " + id;
                            break;
                    }
                    condiciones += " and ";
                }
                //Nombre | Descripcion
                if (!string.IsNullOrEmpty(nombre))
                {
                    condiciones += " Descripcion = '" + nombre + "'";
                }

                //Prepara la consulta
                if (!string.IsNullOrEmpty(condiciones))
                {
                    condiciones = removerAndSobrante(condiciones);
                    consulta += " where " + condiciones;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["Id"];
                    marca.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(marca);
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
        private string removerAndSobrante(string consulta)
        {
            consulta = consulta.TrimEnd();
            string and = "and";
            if (consulta.EndsWith(and))
            {
                return consulta.Substring(0, consulta.Length - and.Length).TrimEnd();
            }
            return consulta;
        }

        public void agregar(Marca marca)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion)values(@descripcion)");
                datos.setearParametros("@descripcion", marca.Descripcion);
                datos.insertarDatos();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("delete from MARCAS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificar(Marca marca)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("update MARCAS set Descripcion=@descripcion where id=@id");
                datos.setearParametros("@descripcion", marca.Descripcion);
                datos.setearParametros("@id", marca.Id);
                datos.ejecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
