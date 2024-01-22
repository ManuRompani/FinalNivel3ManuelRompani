using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TrabajoFinalNivel3
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if(Session["Usuario"] != null) 
                {
                    if (!IsPostBack)
                    {
                        cargarFavoritos();
                    }
                }
                else
                {
                    Response.Redirect("LogIn.aspx", false);
                }
			}
			catch (Exception ex)
			{

                Session["Error"] = ex.ToString();
                Response.Redirect("Error", false);
            }
        }

        public void cargarFavoritos()
        {
            Usuario usuario = Session["Usuario"] as Usuario;
            FavoritoNegocio negocioFavoritos = new FavoritoNegocio();
            List<int> idFavoritos = negocioFavoritos.listar(usuario.Id);
            List<Articulo> listaArticulos = new List<Articulo>();
            if (idFavoritos.Count > 0)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                for (int i = 0; i < idFavoritos.Count; i++)
                {
                    listaArticulos.Add(articuloNegocio.listarFavoritos(idFavoritos[i]));
                }
            }
            else
            {
                noFavoritos.Visible = true;
            }
            repetidorFavoritos.DataSource = listaArticulos;
            repetidorFavoritos.DataBind();
        }

        protected void repetidorFavoritos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Articulo rowView = (Articulo)e.Item.DataItem;
                    string urlImagen = rowView.UrlImagen;
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
            catch (Exception ex)
            {

                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void eliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = Session["Usuario"] as Usuario;
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    ImageButton boton = (ImageButton)sender;
                    
                    negocio.eliminar(usuario.Id, int.Parse(boton.CommandArgument));
                    cargarFavoritos();
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