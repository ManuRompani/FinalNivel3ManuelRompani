using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        cargarUsuario();
                    }
                    else
                    {
                        Response.Redirect("Administrar.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.ToString();
                Response.Redirect("Error", false);
            }
        }

        protected void cargarUsuario()
        {
            try
            {
                if (Request.QueryString["id"] != "agregar")
                {
                    List<Usuario> listaUsuario = Session["listaUsuarios"] as List<Usuario>;
                    Usuario usuario = listaUsuario.Find(o => o.Id == int.Parse(Request.QueryString["id"]));
                    tboxEmail.Text = usuario.Email;
                    tboxNombreUsuario.Text = usuario.Nombre;
                    tboxApellidoUsuario.Text = usuario.Apellido;
                    tboxAdmin.Text = usuario.Admin.ToString();
                    if (!string.IsNullOrEmpty(usuario.Imagen))
                        imagenUsuario.ImageUrl = usuario.Imagen;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error", false);
            }
        }
    }
}