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
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        cargarDropDownMarcaYCategoria();
                        cargarArticulo();
                    }
                    else
                    {

                        Response.Redirect("Administrar.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void cargarArticulo()
        {
            try
            {
                if (Request.QueryString["id"] != "agregar")
                {
                    List<Articulo> listaArticulo = Session["listaArticulos"] as List<Articulo>;
                    Articulo articulo = listaArticulo.Find(o => o.Id == int.Parse(Request.QueryString["id"]));
                    tboxCodigo.Text = articulo.Codigo;
                    tboxNombre.Text = articulo.Nombre;
                    ddownMarca.SelectedValue = articulo.Marca.Id.ToString();
                    ddownCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                    tboxPrecio.Text = articulo.Precio;
                    tboxDescripcion.Text = articulo.Descripcion;
                    if (!string.IsNullOrEmpty(articulo.UrlImagen))
                    {
                        if (articulo.UrlImagen.ToUpper().Contains("HTTP"))
                            imagen.ImageUrl = articulo.UrlImagen;
                        else
                            imagen.ImageUrl = "./Images/ImagenesArticulos/" + articulo.UrlImagen;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == "agregar")
                {
                    return;
                }
                else
                {
                    if (cboxEliminar.Checked == true)
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        ArticuloNegocio negocio = new ArticuloNegocio();
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
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                bool formato = true;

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();

                if(tboxCodigo.Text != "")
                {
                    articulo.Codigo = tboxCodigo.Text;
                    tboxCodigo.CssClass = "form-control is-valid";
                }
                else
                {
                    tboxCodigo.CssClass = "form-control is-invalid";
                    formato = false;
                }

                if (tboxNombre.Text != "")
                {
                    articulo.Nombre = tboxNombre.Text;
                    tboxNombre.CssClass = "form-control is-valid";
                }
                else
                {
                    tboxNombre.CssClass = "form-control is-invalid";
                    formato = false;
                }
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddownMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddownCategoria.SelectedValue);
                if(int.TryParse(tboxPrecio.Text, out int precio))
                {
                    articulo.Precio = tboxPrecio.Text;
                    tboxPrecio.CssClass = "form-control is-valid";
                }
                else
                {
                    tboxPrecio.CssClass = "form-control is-invalid";
                    formato = false;
                }
                articulo.Descripcion = tboxDescripcion.Text;
                if(tboxUrlImagen.PostedFile.FileName != "")
                {
                    if (tboxUrlImagen.PostedFile.FileName.ToUpper().Contains("HTTP"))
                    {
                        articulo.UrlImagen = tboxUrlImagen.PostedFile.FileName;
                    }
                    else
                    {
                        string ruta = Server.MapPath("~/Images/ImagenesArticulos/");
                        tboxUrlImagen.PostedFile.SaveAs(ruta + "articulo-" + articulo.Id + ".jpg");
                        articulo.UrlImagen = "articulo-" + articulo.Id + ".jpg";
                    }
                }

                if (formato == true)
                {
                    if (id == "agregar")
                    {
                        negocio.agregar(articulo);
                    }
                    else
                    {
                        articulo.Id = int.Parse(id);
                        negocio.modificar(articulo);
                    }
                    Response.Redirect("Administrar.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarDropDownMarcaYCategoria()
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                List<Marca> lista = negocio.listarMarcas("", "", "");// Se pasa el parametro vacio para que liste sin filtrar
                //lista.Insert(0, new Marca("Todos", 0)); // Insertar la categoría "Todos" al inicio de la lista

                ddownMarca.DataSource = lista;
                ddownMarca.DataValueField = "id";
                ddownMarca.DataTextField = "descripcion";
                ddownMarca.DataBind();

                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                List<Categoria> listaCategoria = negocioCategoria.listarCategorias("", "", "");
                //listaCategoria.Insert(0, new Categoria("Todos", 0));

                ddownCategoria.DataSource = listaCategoria;
                ddownCategoria.DataValueField = "id";
                ddownCategoria.DataTextField = "descripcion";
                ddownCategoria.DataBind();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}