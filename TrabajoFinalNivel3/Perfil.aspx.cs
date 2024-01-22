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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (Session["Usuario"] != null)
				{
                    if (!IsPostBack)
                    {
                        Usuario usuario = Session["Usuario"] as Usuario;
                        tboxEmail.Text = usuario.Email;
                        tboxNombre.Text = (!string.IsNullOrEmpty(usuario.Nombre)) ? usuario.Nombre : "";
                        tboxApellido.Text = (!string.IsNullOrEmpty(usuario.Apellido)) ? usuario.Apellido : "";
                        if (!string.IsNullOrEmpty(usuario.Imagen))
                        {
                            if (usuario.Imagen.ToUpper().Contains("HTTP"))
                                imagenUsuario.ImageUrl = usuario.Imagen;
                            else
                                imagenUsuario.ImageUrl = "Images/ImagenesUsuarios/" + usuario.Imagen;
                        }
                        else
                        {
                            imagenUsuario.ImageUrl = "Images/icons8-usuario-not-img-96.png";
                        }
                    }
                }
                else
                {
                    Response.Redirect("LogIn.aspx", false);
                }
			}
			catch (Exception ex)
			{
				Session["Error"] = ex.Message;
				Response.Redirect("Error", false);
			}
        }

        protected void btnSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    Session["Usuario"] = null;
                    Response.Redirect("LogIn.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    usuario = Session["Usuario"] as Usuario;
                    usuario.Nombre = tboxNombre.Text;
                    usuario.Apellido = tboxApellido.Text;
                    if (cambiarImagen.PostedFile.FileName != "")
                    {
                        if (cambiarImagen.PostedFile.FileName.ToUpper().Contains("HTTP"))
                        {
                            usuario.Imagen = cambiarImagen.PostedFile.FileName;
                        }
                        else
                        {
                            string ruta = Server.MapPath("~/Images/ImagenesUsuarios/");
                            cambiarImagen.PostedFile.SaveAs(ruta + "usuario-" + usuario.Id + ".jpg");
                            usuario.Imagen = "usuario-" + usuario.Id + ".jpg";
                        }
                    }
                    negocio.actualizar(usuario);
                    Session["Usuario"] = usuario;
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