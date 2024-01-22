using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoFinalNivel3
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        cargarCategoria();
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
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarCategoria()
        {
            try
            {
                if (Request.QueryString["id"] != "agregar")
                {
                    List<Categoria> listaCategoria = Session["listaCategorias"] as List<Categoria>;
                    Categoria categoria = listaCategoria.Find(o => o.Id == int.Parse(Request.QueryString["id"]));
                    tboxIdCategoria.Text = categoria.Id.ToString();
                    tboxDescripcion.Text = categoria.Descripcion;
                    if (!string.IsNullOrEmpty(categoria.Imagen))
                    {
                        if (categoria.Imagen.ToUpper().Contains("HTTP"))
                        {
                            imagenASP.ImageUrl = categoria.Imagen;
                        }
                        else
                        {
                            imagenASP.ImageUrl = "Images/ImagenesCategorias/" + categoria.Imagen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != "agregar")
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.eliminar(id);
                    Response.Redirect("Administrar.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                Categoria categoria = new Categoria();
                CategoriaNegocio negocio1 = new CategoriaNegocio();
                categoria.Descripcion = tboxDescripcion.Text;
                if (imagenCategoria.PostedFile.FileName != "")
                {
                    if (imagenCategoria.PostedFile.FileName.ToUpper().Contains("HTTP"))
                    {
                        categoria.Imagen = imagenCategoria.PostedFile.FileName;
                    }
                    else
                    {
                        string ruta = Server.MapPath("Images/ImagenesCategorias/");
                        imagenCategoria.PostedFile.SaveAs(ruta + "categoria-" + categoria.Descripcion + ".jpg");
                        categoria.Imagen = "categoria-" + categoria.Descripcion + ".jpg";
                    }
                }
                if (!string.IsNullOrEmpty(categoria.Descripcion))
                {
                    if (id == "agregar")
                    {
                        negocio1.agregar(categoria);
                    }
                    else
                    {
                        categoria.Id = int.Parse(id);
                        negocio1.modificar(categoria);
                    }
                }
                Response.Redirect("Administrar.aspx", false);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}