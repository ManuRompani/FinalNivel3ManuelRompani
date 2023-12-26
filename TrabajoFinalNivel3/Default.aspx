<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrabajoFinalNivel3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/defaultStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno container-fluid ocultar-div">
        <div class="row">
        <div id="carouselExampleControls" class="carousel slide " data-bs-ride="carousel">
            <div class="carousel-inner ">
                <%for (int i = 0; i < 3; i++)
                    {
                        if (i == 0)
                        { %>
                <div class="carousel-item active ">
                    <a href="Buscar.aspx?id=<%:i %>">
                        <img src="https://www.ceupe.com/images/easyblog_articles/4002/b2ap3_amp_lnea-de-productos.jpg" class="rounded d-block ">
                    </a>
                </div>
                <%}
                    else
                    {%>
                <div class="carousel-item ">
                    <a href="Buscar.aspx?id=<%:i %>">
                        <img src="https://www.ceupe.com/images/easyblog_articles/4002/b2ap3_amp_lnea-de-productos.jpg" class="rounded d-block ">
                    </a>
                </div>
                <%} %>
                <% } %>
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
                <%for (int i = 0; i < 6; i++)
                    { %>
                <div class="col-xl-4 col-md-6 col-sm-12">
                    <div class="card m-3">
                        <a href="Buscar.aspx?id=<%:i %>" id="idTipo" style="text-decoration: none !important; color:black;">
                            <div class="card-body">
                                <h5 class="card-title">Celulares</h5>
                            </div>
                            <img src="https://img.lagaceta.com.ar/fotos/notas/2022/08/19/600x400_celulares-imagen-ilustrativa-957490-083807.webp" class="card-img-bottom" alt="Celulares">
                        </a>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </section>
</asp:Content>
