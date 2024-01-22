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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {   
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        cargarMarca();
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

        protected void cargarMarca()
        {
            try
            {
                if (Request.QueryString["id"] != "agregar")
                {
                    List<Marca> listaMarca = Session["listaMarcas"] as List<Marca>;
                    Marca marca = listaMarca.Find(o => o.Id == int.Parse(Request.QueryString["id"]));
                    tboxIdMarca.Text = marca.Id.ToString();
                    tboxDescripcion.Text = marca.Descripcion;
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
                if (Request.QueryString["id"] == "agregar")
                {
                }
                else
                {
                    if(cboxEliminar.Checked)
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        MarcaNegocio negocio = new MarcaNegocio();
                        negocio.eliminar(id);
                        Response.Redirect("Administrar.aspx", false);
                    }
                    else
                    {
                        cboxEliminar.Visible = true;
                    }
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
                Marca marca = new Marca();
                MarcaNegocio negocio = new MarcaNegocio();
                marca.Descripcion = tboxDescripcion.Text;
                if (!string.IsNullOrEmpty(marca.Descripcion))
                {
                    if (id == "agregar")
                    {
                        negocio.agregar(marca);
                    }
                    else
                    {
                        marca.Id = int.Parse(id);
                        negocio.modificar(marca);
                    }
                    Response.Redirect("Administrar.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}