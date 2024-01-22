<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrabajoFinalNivel3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/defaultStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno container-fluid ocultar-div">
        <div class="row justify-content-center">
            <div id="carouselExampleControls" class="carousel slide " data-bs-ride="carousel">
                <div class="carousel-inner">
                    <% if (Session["listaArticulos"] != null)
                        {
                            List<Dominio.Articulo> listaArticulos = Session["listaArticulos"] as List<Dominio.Articulo>;
                            string cargarImagen(string url)
                            {
                                if (url.ToUpper().Contains("HTTP"))
                                    return url;
                                else
                                    return "Images/ImagenesArticulos/" + url;
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                if (i == 0)
                                { %>
                    <div class="carousel-item active">
                        <a href="VerProducto.aspx?id=<%= listaArticulos[i].Id.ToString() %>">
                            <img src="<%= cargarImagen(listaArticulos[i].UrlImagen) %>" id="imagenCarrusel" onerror="this.src='Images/not-image-found.png'" class=" d-block">
                        </a>
                    </div>
                    <% }
                        else
                        { %>
                    <div class="carousel-item">
                        <a href="VerProducto.aspx?id=<%= listaArticulos[i].Id.ToString() %>">
                            <img src="<%= cargarImagen(listaArticulos[i].UrlImagen) %>" id="imagenCarrusel1" onerror="this.src='Images/not-image-found.png'" class=" d-block">
                        </a>
                    </div>
                    <% }
                            }
                        } %>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
    </section>
    <section class="dos">
        <div class="container justify-content-start">
            <div class="row">
                <asp:Repeater runat="server" ID="repetidorCategorias">
                    <ItemTemplate>
                        <div class="col-xl-4 col-md-6 col-sm-12">
                            <div class="card m-3">
                                <a href="Buscar.aspx?categoria=<%#Eval("Descripcion") %>" style="text-decoration: none !important; color: black;">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Descripcion") %></h5>
                                    </div>
                                    <img src="Images/ImagenesCategorias/<%#Eval("Imagen")%>" onerror="this.src='Images/not-image-found.png'" class="card-img-bottom" alt="Celulares" style="height:230px;object-fit: cover;">
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
