using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Services;

namespace TrabajoFinalNivel3
{
    public partial class SingUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                if(tboxEmail.Text != "" && tboxPass.Text != "" && tboxPassConfirm.Text != "" && tboxPass.Text == tboxPassConfirm.Text)
                {
                    if (negocio.consultarExistenciaEmail(tboxEmail.Text))
                    {
                        usuario.Email = tboxEmail.Text;
                        usuario.Contraseña = tboxPass.Text;

                        usuario.Id = negocio.agregar(usuario, false);

                        EmailService email = new EmailService();
                        email.crearCorreo(usuario.Email, "Muchas gracias por unirte...♥", "Bienvenido!");
                        email.enviarCorreo();

                        Session["Usuario"] = usuario;

                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        tboxEmail.CssClass = "form-control is-invalid";
                        mensajeEmail.InnerText = "El email ya existe";
                    }
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