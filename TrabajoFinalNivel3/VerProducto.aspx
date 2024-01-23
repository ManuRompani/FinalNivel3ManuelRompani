<%@ Page Title="VerProducto" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="TrabajoFinalNivel3.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/verProductoStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container justify-content-center">
            <div class="row justify-content-center" style="padding-top: calc(10vh); align-items: center;">
                <div class="col-xs-12 col-md-6 ajustar-imagen">
                    <%if (Session["listaArticulos"] != null && Request.QueryString["id"] != null)
                        { %>
                    <img src="<%= articulo.UrlImagen %>" onerror="this.src='Images/not-image-found.png'" class="d-block rounded" Style="max-height: 400px;"/>
                </div>
                <div class="col-xs-12 col-md-6 margen-top">
                    <h3><%= articulo.Nombre %></h3>
                    <div class="contenedor-caracteristicas">
                        <ul>
                            <li><%= articulo.Precio %></li>
                            <li><%= articulo.Marca.Descripcion %></li>
                            <li><%= articulo.Categoria.Descripcion %></li>
                        </ul>
                    </div>
                    <div >
                        <p>
                            <%= articulo.Descripcion %>
                        </p>
                    </div>
                    <div class="favoritos">
                        <asp:ImageButton ImageUrl="Images/icons8-estrella-50(blanca).png" ID="estrellaBlanca" visible="true" OnClick="estrellaBlanca_Click" runat="server" CssClass="estrella"/>
                        <asp:ImageButton ImageUrl="Images/icons8-estrella-50(negra).png" Visible="false" ID="estrellaNegra" OnClick="estrellaNegra_Click" runat="server" CssClass="estrella" />
                        <asp:Label Text="Agregar a favoritos" ID="labelFavoritos" class="p" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row justify-content-start" style="margin-top:100px;">
                <h5>Productos similares</h5>
            </div>
            <div class="row justify-content-center">
                <%if (articulosRelacionados != null && articulosRelacionados.Count > 0)
                    {
                        for (int i = 0; i < articulosRelacionados.Count && i < 3; i++)
                        {
                            if (articulosRelacionados[i].Id != articulo.Id)
                            { %>
                <div class="col-xs-12 col-md-4">
                    <div class="card m-3 col-xs-12 col-md-5" style="width: 300px;">
                        <a href="VerProducto.aspx?id=<%:articulosRelacionados[i].Id %>" id="idTipo" style="text-decoration: none !important; color: black;">
                            <img src="<%:articulosRelacionados[i].UrlImagen %>" onerror="this.src='Images/not-image-found.png'" class="d-block rounded" alt="Celular" style="max-height:150px; margin:auto;">
                            <div class="card-body p-2">
                                <h5 class="card-title"><%: articulosRelacionados[i].Nombre %></h5>
                            </div>
                        </a>
                    </div>
                </div>
                <%}
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }%>
            </div>
        </div>
    </section>
</asp:Content>
