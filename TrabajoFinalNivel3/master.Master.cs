using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TrabajoFinalNivel3
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Error"] == null)
                    Session["Error"] = "Generico";
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = Session["Usuario"] as Usuario;
                    if(usuario.Admin)
                        linkAdmin.Visible = true;
                }
                if (Page is Administrar || Page is Articulos || Page is Categorias || Page is Usuarios || Page is Marcas)
                {
                    if(Session["Usuario"] != null)
                    {
                        Usuario usuario = Session["Usuario"] as Usuario;
                        if (!usuario.Admin)
                        {
                            Response.Redirect("Default.aspx", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Buscar.aspx?buscar=" + tboxBuscar.Text, false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}