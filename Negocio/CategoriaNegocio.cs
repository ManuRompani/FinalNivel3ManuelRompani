using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CategoriaNegocio
    {
        // Se pasa el parametro vacio para que liste sin filtrar
        public List<Categoria> listarCategorias(string id, string criterioId, string nombre)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<Categoria> lista = new List<Categoria>();
            try
            {
                string consulta = "Select Id, Descripcion, UrlImagen from CATEGORIAS";
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
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["Id"];
                    if(!(datos.Lector["Descripcion"] is DBNull))
                        categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    if(!(datos.Lector["UrlImagen"] is DBNull))
                        categoria.Imagen = (string)datos.Lector["UrlImagen"];
                    lista.Add(categoria);
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

        public void agregar(Categoria categoria)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion, UrlImagen)values(@descripcion, @UrlImagen)");
                datos.setearParametros("@descripcion", categoria.Descripcion);
                datos.setearParametros("@UrlImagen", categoria.Imagen);
                datos.insertarDatos();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public void eliminar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("delete from CATEGORIAS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificar(Categoria categoria)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("update CATEGORIAS set Descripcion=@descripcion, UrlImagen=@UrlImagen where id=@id");
                datos.setearParametros("@descripcion", categoria.Descripcion);
                datos.setearParametros("@id", categoria.Id);
                datos.setearParametros("@UrlImagen", categoria.Imagen);
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
    }
}
