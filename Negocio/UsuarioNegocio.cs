using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class UsuarioNegocio
    {
        //Al listar indicando parametros se utiliza el metodo con filtro

        AccesoDatos.AccesoDatos datos;
        public UsuarioNegocio() { datos = new AccesoDatos.AccesoDatos(); }
        public int agregar(Usuario usuario, bool admin)
        {
            try
            {
                datos.setearConsulta("Insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, @admin)");
          
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Contraseña);
                datos.setearParametros("@admin", admin);
                return datos.ejecutarAccionSacalar();
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

        public bool CheckLogIn(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("Select id, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                datos.setearParametros("@pass", usuario.Contraseña);
                datos.setearParametros("@email", usuario.Email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = datos.Lector["nombre"].ToString();

                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = datos.Lector["apellido"].ToString();

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.Imagen = datos.Lector["urlImagenPerfil"].ToString();

                    return true;
                }
                return false;

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

        public void actualizar(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagenPerfil where id = @id");
                datos.setearParametros("@nombre", (object)usuario.Nombre ?? DBNull.Value);
                datos.setearParametros("@apellido", (object)usuario.Apellido ?? DBNull.Value);
                datos.setearParametros("@imagenPerfil", (object)usuario.Imagen ?? DBNull.Value);
                datos.setearParametros("@id", usuario.Id);

                datos.insertarDatos();


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

        public void changePass(Usuario usuario, string newpass)
        {
            try
            {
                datos.setearConsulta("Update USERS set pass = @newpass where id = @id");
                datos.setearParametros("@newpass", newpass);
                datos.setearParametros("@id", usuario.Id);
                datos.insertarDatos();
                usuario.Contraseña = newpass;
            }
            catch (Exception)
            {
                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("delete from USERS where id = @id");
                datos.setearParametros("@id", id);
                datos.insertarDatos();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Usuario> listarUsuarios(string criterioId, string id, string nombre, string criterioCorreo, string correo) 
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            string consulta = "Select id, email, nombre, apellido, urlImagenPerfil, admin from USERS ";

            try
            {
                //ID
                string condiciones = "";
                if (!string.IsNullOrEmpty(id) || criterioId == "Todos")
                {
                    switch (criterioId)
                    {
                        case "Mayor a":
                            condiciones += " Id > " + id + " and ";
                            break;
                        case "Menor a":
                            condiciones += " Id < " + id + " and ";
                            break;
                    }
                }

                //Nombre
                if (nombre != "")
                {
                    condiciones += " Nombre = '" + nombre + "' and ";
                }

                //Correo
                if(!string.IsNullOrEmpty(correo) || criterioCorreo == "Todos"){
                    switch (criterioCorreo)
                    {
                        case "Todos":
                            break;
                        case "Igual":
                            condiciones += " email = '" + correo + "'";
                            break;
                        case "Terminacion":
                            condiciones += " email like '%" + correo + "'";
                            break;
                    }
                }

                //Agrega las condiciones de busqueda
                if (!string.IsNullOrEmpty(condiciones))
                {
                    condiciones = removerAndSobrante(condiciones);
                    consulta += " where " + condiciones;
                }

                
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuarioAux = new Usuario();
                    usuarioAux.Id = (int)datos.Lector["id"];
                    usuarioAux.Email = (string)datos.Lector["email"];
                    if (datos.Lector["nombre"] != DBNull.Value)
                        usuarioAux.Nombre = (string)datos.Lector["nombre"];

                    if (datos.Lector["apellido"] != DBNull.Value)
                        usuarioAux.Apellido = (string)datos.Lector["apellido"];

                    if (datos.Lector["urlImagenPerfil"] != DBNull.Value)
                        usuarioAux.Imagen = (string)datos.Lector["urlImagenPerfil"];

                    usuarioAux.Admin = (bool)datos.Lector["admin"];

                    lista.Add(usuarioAux);

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

        public bool consultarExistenciaEmail(string email)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("Select id from USERS where email = '" + email +"'");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
