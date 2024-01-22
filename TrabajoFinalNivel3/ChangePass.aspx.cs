using Dominio;
using Negocio;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class ChangePass : System.Web.UI.Page
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
                string newPass = "";
                usuario.Email = tboxEmail.Text;
                usuario.Contraseña = tboxPass.Text;
                if(tboxNewPass.Text != "" && tboxNewPass.Text == tboxNewPassConfirm.Text)
                {
                    if(negocio.CheckLogIn(usuario))
                    {
                        if (tboxPass.Text != tboxNewPass.Text)
                        {
                            newPass = tboxNewPass.Text;
                            negocio.changePass(usuario, newPass);
                            usuario.Contraseña = newPass;

                            EmailService email = new EmailService();
                            email.crearCorreo(usuario.Email, "Su contraseña ha sido modificada", "Cambio de contraseña");
                            email.enviarCorreo();

                            Session["Usuario"] = usuario;
                            Response.Redirect("Perfil.aspx", false);
                        }
                        else
                        {
                            tboxNewPass.CssClass = "form-control is-invalid";
                            mensajeNewPass.InnerText = "La nueva contraseña no puede ser igual a la anterior";
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
    }
}