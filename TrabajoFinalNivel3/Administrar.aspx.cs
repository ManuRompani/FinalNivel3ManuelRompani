using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Xml.Linq;

namespace TrabajoFinalNivel3
{
    public partial class Administrar : System.Web.UI.Page
    {
        public int tipoFiltro = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarDropDownMarcaYCategoria();
                    cargarGrilla(ddwnAdministrar.SelectedValue);
                }
                tipoFiltro = ddwnAdministrar.SelectedIndex;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarGrilla(string criterio)
        {
            try
            {
                switch (criterio)
                {
                    case "Articulos":
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        List<Articulo> listaArticulos = articuloNegocio.listarArticulos(dropdownPrecio.SelectedItem.Text, tboxPrecio.Text, dropdownMarca.SelectedItem.Text, dropdownCategoria.SelectedItem.Text, tboxCodigo.Text);
                        Session["listaArticulos"] = listaArticulos;
                        gridviewAdministrarArticulos.DataSource = listaArticulos;
                        gridviewAdministrarArticulos.DataBind();
                        break;
                    case "Usuarios":
                        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                        List<Usuario> listaUsuario = usuarioNegocio.listarUsuarios(dropdownIdUsuario.SelectedItem.Text, tboxIdUsuario.Text, tboxNombreUsuario.Text, dropdownEmail.SelectedItem.Text, tboxEmailUsuario.Text);
                        Session["listaUsuarios"] = listaUsuario;
                        Session["listaModificar"] = listaUsuario;
                        gridviewAdministrarUsuarios.DataSource = listaUsuario;
                        gridviewAdministrarUsuarios.DataBind();
                        break;
                    case "Marcas":
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        List<Marca> listaMarcas = marcaNegocio.listarMarcas(tboxIdMarcaCategoria.Text, dropdownIdMarcaCategoria.SelectedItem.Text, tboxNombreMarcaCategoria.Text);
                        Session["listaMarcas"] = listaMarcas;
                        Session["listaModificar"] = listaMarcas;
                        gridviewAdministrarCategoriasYMarcas.DataSource = listaMarcas;
                        gridviewAdministrarCategoriasYMarcas.DataBind();
                        break;
                    case "Categorias":
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        List<Categoria> listaCategorias = categoriaNegocio.listarCategorias(tboxIdMarcaCategoria.Text, dropdownIdMarcaCategoria.SelectedItem.Text, tboxNombreMarcaCategoria.Text);
                        Session["listaCategorias"] = listaCategorias;
                        Session["listaModificar"] = listaCategorias;
                        gridviewAdministrarCategoriasYMarcas.DataSource = listaCategorias;
                        gridviewAdministrarCategoriasYMarcas.DataBind();
                        break;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddwnAdministrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tipoFiltro = ddwnAdministrar.SelectedIndex;
                cargarGrilla(ddwnAdministrar.SelectedValue);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cargarDropDownMarcaYCategoria()
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                List<Marca> lista = negocio.listarMarcas("","","");// Se pasa el parametro vacio para que liste sin filtrar
                lista.Insert(0, new Marca("Todos", 0)); // Insertar la categoría "Todos" al inicio de la lista

                dropdownMarca.DataSource = lista;
                dropdownMarca.DataValueField = "id";
                dropdownMarca.DataTextField = "descripcion";
                dropdownMarca.DataBind();

                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                List<Categoria> listaCategoria = negocioCategoria.listarCategorias("","","");
                listaCategoria.Insert(0, new Categoria("Todos", 0));

                dropdownCategoria.DataSource = listaCategoria;
                dropdownCategoria.DataValueField = "id"; 
                dropdownCategoria.DataTextField = "descripcion"; 
                dropdownCategoria.DataBind(); 
            }
            catch (Exception ex) 
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarGrilla(ddwnAdministrar.SelectedItem.Text);
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                tboxCodigo.Text = "";
                dropdownPrecio.SelectedIndex = 0;
                tboxPrecio.Text = "";
                dropdownMarca.SelectedIndex = 0;
                dropdownCategoria.SelectedIndex = 0;
                dropdownIdUsuario.SelectedIndex = 0;
                tboxIdUsuario.Text = "";
                tboxNombreUsuario.Text = "";
                dropdownEmail.SelectedIndex = 0;
                tboxEmailUsuario.Text = "";
                dropdownIdMarcaCategoria.SelectedIndex = 0;
                tboxIdMarcaCategoria.Text = "";
                tboxNombreMarcaCategoria.Text = "";
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        //Usa el mismo metodo en las 3 grillas
        protected void gridviewAdministrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tipoFiltro)
                {
                    case 0:
                        Response.Redirect("Articulos.aspx?id=" + gridviewAdministrarArticulos.SelectedDataKey.Value.ToString(), false);
                        break;
                    case 1:
                        Response.Redirect("Usuarios.aspx?id=" + gridviewAdministrarUsuarios.SelectedDataKey.Value.ToString(), false);
                        break;
                    case 2:
                        Response.Redirect("Categorias.aspx?id=" + gridviewAdministrarCategoriasYMarcas.SelectedDataKey.Value.ToString(), false);
                        break;
                    case 3:
                        Response.Redirect("Marcas.aspx?id=" + gridviewAdministrarCategoriasYMarcas.SelectedDataKey.Value.ToString(), false);
                        break;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
           
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ddwnAdministrar.SelectedIndex)
                {
                    case 0:
                        Response.Redirect("Articulos.aspx?id=agregar", false);
                        break;
                    case 1:
                        //No se puede agregar usuarios
                        break;
                    case 2:
                        Response.Redirect("Categorias.aspx?id=agregar", false);
                        break;
                    case 3:
                        Response.Redirect("Marcas.aspx?id=agregar", false);
                        break;
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