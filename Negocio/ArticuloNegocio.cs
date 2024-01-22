using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    int id = datos.Lector.GetInt32(0);
                    articuloAux.Id = id;
                    if(!(datos.Lector["Codigo"] is DBNull))
                        articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.GetString(3) is DBNull))
                    {
                        string descripcion = datos.Lector.GetString(3);
                        articuloAux.Descripcion = descripcion;
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articuloAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        articuloAux.Precio = ((decimal)datos.Lector["Precio"]).ToString("C");
                    articuloAux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        articuloAux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAux);

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

        public void modificar(Articulo articulo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, ImagenUrl=@urlimagen, Precio=@precio, IdMarca=@marca, IdCategoria=@categoria where Id=@id");
                datos.setearParametros("@codigo", articulo.Codigo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@urlimagen", articulo.UrlImagen);
                datos.setearParametros("@precio", articulo.Precio);
                datos.setearParametros("@marca", articulo.Marca.Id);
                datos.setearParametros("@categoria", articulo.Categoria.Id);
                datos.setearParametros("@id", articulo.Id);

                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, idMarca, idCategoria, ImagenUrl, Precio)values(@codigo, @nombre, @descripcion, @idMarca , @idCategoria, @urlImagen, @precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                if (nuevo.UrlImagen != null)
                {
                    datos.setearParametros("@urlImagen", nuevo.UrlImagen);
                }
                else
                {
                    datos.setearParametros("@urlImagen", DBNull.Value);
                }
                datos.setearParametros("@precio", nuevo.Precio);
                datos.insertarDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }

        }

        public List<Articulo> listarArticulos(string criterioPrecio, string precio, string marca, string categoria, string codigo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id ";

                if (codigo != "")
                    consulta += " and Codigo = '" + codigo + "'";

                if(criterioPrecio != "Todos" && criterioPrecio != "" && precio != "")
                {
                    switch (criterioPrecio)
                    {
                        case "Mayor a":
                            consulta += " and Precio > " + precio;
                            break;
                        case "Menor a":
                            consulta += " and Precio < " + precio;
                            break;
                    }
                }
                if (marca != "Todos" && marca != "")
                {
                    consulta += " and M.Descripcion = '" + marca + "'";
                }
               if(categoria != "Todos" && categoria != "")
               {
                    consulta += " and C.Descripcion = '" + categoria + "'";
               }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    int id = datos.Lector.GetInt32(0);
                    articuloAux.Id = id;
                    if (!(datos.Lector["Codigo"] is DBNull))
                        articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.GetString(3) is DBNull))
                    {
                        string descripcion = datos.Lector.GetString(3);
                        articuloAux.Descripcion = descripcion;
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articuloAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        articuloAux.Precio = ((decimal)datos.Lector["Precio"]).ToString("C");
                    articuloAux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        articuloAux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAux);
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


        public Articulo listarFavoritos(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            Articulo articulo = new Articulo();
            try
            {
                datos.setearConsulta("Select Id, Nombre, ImagenUrl from ARTICULOS where id=" + id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    articulo.Id = id;
                    articulo.Nombre = datos.Lector["Nombre"].ToString();
                    articulo.UrlImagen = datos.Lector["ImagenUrl"].ToString();
                }

                return articulo;
                
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public List<Articulo> busquedaRapida(string parametro)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id and (nombre like '%" + parametro + "%' or C.Descripcion like '%" + parametro + "%' or M.Descripcion like '%" + parametro + "%')");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    int id = datos.Lector.GetInt32(0);
                    articuloAux.Id = id;
                    if (!(datos.Lector["Codigo"] is DBNull))
                        articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.GetString(3) is DBNull))
                    {
                        string descripcion = datos.Lector.GetString(3);
                        articuloAux.Descripcion = descripcion;
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articuloAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        articuloAux.Precio = ((decimal)datos.Lector["Precio"]).ToString("C");
                    articuloAux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        articuloAux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAux);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }



    }
}
