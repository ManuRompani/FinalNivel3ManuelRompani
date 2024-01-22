using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class Buscar : System.Web.UI.Page
    {
        Usuario usuario;
        List<int> listaFavoritos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] != null)
                    {
                        usuario = new Usuario();
                        usuario = Session["Usuario"] as Usuario;
                        FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                        List<int> listaFavoritos = new List<int>();
                        listaFavoritos = favoritoNegocio.listar(usuario.Id);
                    }
                    cargarDropDownMarcaYCategoria();
                    if (!string.IsNullOrEmpty(Request.QueryString["categoria"]))
                        cargarProductos(Request.QueryString["categoria"]);
                    else
                    {
                        if (Request.QueryString["buscar"] == null)
                        {
                            cargarProductos("");
                        }
                        else
                        {
                            List<Articulo> lista = new List<Articulo>();
                            ArticuloNegocio negocio = new ArticuloNegocio();
                            lista = negocio.busquedaRapida(Request.QueryString["buscar"]);
                            Session["listaArticulos"] = lista;
                            repetidorArticulos.DataSource = lista;
                            repetidorArticulos.DataBind();
                            if (lista == null || lista.Count <= 0)
                            {
                                mensajeSinProductos.Visible = true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarDropDownMarcaYCategoria()
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                List<Marca> lista = negocio.listarMarcas("", "", "");// Se pasa el parametro vacio para que liste sin filtrar
                lista.Insert(0, new Marca("Todos", 0)); // Insertar la categoría "Todos" al inicio de la lista

                ddwnMarca.DataSource = lista;
                ddwnMarca.DataValueField = "id";
                ddwnMarca.DataTextField = "descripcion";
                ddwnMarca.DataBind();

                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                List<Categoria> listaCategoria = negocioCategoria.listarCategorias("", "", "");
                listaCategoria.Insert(0, new Categoria("Todos", 0));

                ddwnCategoria.DataSource = listaCategoria;
                ddwnCategoria.DataValueField = "id";
                ddwnCategoria.DataTextField = "descripcion";
                ddwnCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarProductos(string categoria)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listarArticulos("", "", "", categoria, "");
                Session["listaArticulos"] = lista;
                repetidorArticulos.DataSource = lista;
                repetidorArticulos.DataBind();
                if(lista==null || lista.Count <= 0)
                {
                    mensajeSinProductos.Visible = true;
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void repetidorArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Articulo rowView = (Articulo)e.Item.DataItem;
                    string urlImagen = rowView.UrlImagen;
                    if (urlImagen != null)
                    {
                        if (!urlImagen.ToUpper().Contains("HTTP"))
                        {
                            Image img = (Image)e.Item.FindControl("imagenArticulo");
                            img.ImageUrl = "Images/ImagenesCategorias/" + urlImagen;
                        }
                        else
                        {
                            Image img = (Image)e.Item.FindControl("imagenArticulo");
                            img.ImageUrl = urlImagen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> lista = articuloNegocio.listarArticulos(ddwnPrecio.SelectedItem.Text, tboxPrecio.Text, ddwnMarca.SelectedItem.Text, ddwnCategoria.SelectedItem.Text, "");
                repetidorArticulos.DataSource = lista;
                repetidorArticulos.DataBind();
                if (lista == null || lista.Count<=0)
                {
                    mensajeSinProductos.Visible = true;
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                ddwnPrecio.SelectedIndex = 0;
                tboxPrecio.Text = "";
                ddwnMarca.SelectedIndex = 0;
                ddwnCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}