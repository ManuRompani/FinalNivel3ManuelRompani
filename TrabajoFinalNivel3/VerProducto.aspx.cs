using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class VerProducto : System.Web.UI.Page
    {
        Usuario usuario;
        List<int> favoritos = new List<int>();
        public List<Articulo> articulosRelacionados;
        public Articulo articulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    usuario = Session["Usuario"] as Usuario;
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    favoritos = negocio.listar(usuario.Id);
                    if (favoritos.Contains(int.Parse(Request.QueryString["id"])))
                    {
                        estrellaBlanca.Visible = false;
                        labelFavoritos.Text = "Eliminar de favoritos";
                        estrellaNegra.Visible = true;
                    }
                }
                if (!IsPostBack && Session["listaArticulos"] != null && Request.QueryString["id"] != null)
                {
                    List<Articulo> listaProductos = Session["listaArticulos"] as List<Articulo>;
                    articulo = new Articulo();
                    articulo = listaProductos.Find(o => o.Id == int.Parse(Request.QueryString["id"]));
                    Session["Articulo"] = articulo;
                    if (!string.IsNullOrEmpty(articulo.UrlImagen))
                    {
                        articulo.UrlImagen = validarImagen(articulo.UrlImagen);
                    }
                    articulosRelacionados = new List<Articulo>();
                    articulosRelacionados = listaProductos.FindAll(a => a.Categoria.Descripcion == articulo.Categoria.Descripcion);
                    for (int i=0; i<articulosRelacionados.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(articulosRelacionados[i].UrlImagen))
                            articulosRelacionados[i].UrlImagen = validarImagen(articulosRelacionados[i].UrlImagen);

                    }

                }
                else
                {

                    if (Session["Articulo"] != null)
                    {
                        articulo = Session["Articulo"] as Articulo;
                        articulosRelacionados = Session["listaArticulos"] as List<Articulo>;
                        articulosRelacionados = articulosRelacionados.FindAll(a => a.Categoria.Descripcion == articulo.Categoria.Descripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void estrellaBlanca_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    negocio.agregar(usuario.Id, articulo.Id);
                    estrellaBlanca.Visible = false;
                    estrellaNegra.Visible = true;
                    labelFavoritos.Text = "Eliminar de favoritos";
                }
                else
                {
                    Response.Redirect("LogIn.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected string validarImagen(string url)
        {
            if (!url.ToUpper().Contains("HTTP"))
            {
                return "Images/ImagenesCategorias/" + url;
            }
            else
            {
                return url;
            }
        }

        protected void estrellaNegra_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    negocio.eliminar(usuario.Id, articulo.Id);
                    estrellaBlanca.Visible = true;
                    estrellaNegra.Visible = false;
                    labelFavoritos.Text = "Agregar a favoritos";
                }
                else
                {
                    Response.Redirect("LogIn.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}