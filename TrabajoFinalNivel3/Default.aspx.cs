using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocioArticulo = new ArticuloNegocio();
                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    Session["Categorias"] = negocioCategoria.listarCategorias("", "", "");
                    Session["listaArticulos"] = negocioArticulo.listarArticulos();
                    repetidorCategorias.DataSource = Session["Categorias"];
                    repetidorCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.Message;
                Response.Redirect("Error", false);
            }
        }
    }
}