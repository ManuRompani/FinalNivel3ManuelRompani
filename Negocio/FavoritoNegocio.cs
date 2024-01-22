using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public void agregar(int idUsuario, int idArticulo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try 
            {
                datos.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo)values(@idUsuario,@idArticulo)");
                datos.setearParametros("@idUsuario", idUsuario);
                datos.setearParametros("@idArticulo", idArticulo);
                datos.insertarDatos();
            } 
            catch (Exception ex) 
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<int> listar(int idUsuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<int> lista = new List<int>();
            try
            {
                datos.setearConsulta("Select idArticulo from FAVORITOS where idUser=@idUsuario");
                datos.setearParametros("@idUsuario", idUsuario);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add((int)datos.Lector["idArticulo"]);
                }

                return lista;
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

        public void eliminar(int idUsuario, int idArticulo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdUser=@idUsuario and IdArticulo=@idArticulo");
                datos.setearParametros("@idUsuario", idUsuario);
                datos.setearParametros("@idArticulo", idArticulo);
                datos.insertarDatos();
            }
            catch (Exception ex)
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
