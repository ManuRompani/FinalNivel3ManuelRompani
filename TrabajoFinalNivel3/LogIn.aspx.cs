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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(tboxEmail.Text) && !string.IsNullOrEmpty(tboxPass.Text)) 
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = new Usuario();
                    usuario.Email = tboxEmail.Text;
                    usuario.Contraseña = tboxPass.Text;
                    if (negocio.CheckLogIn(usuario))
                    {
                        Session["Usuario"] = usuario;
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        tboxEmail.CssClass = "form-control is-invalid";
                        tboxPass.CssClass = "form-control is-invalid";
                    }
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