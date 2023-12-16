<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrabajoFinalNivel3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/defaultStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="https://www.ceupe.com/images/easyblog_articles/4002/b2ap3_amp_lnea-de-productos.jpg" class="d-block">
                </div>
                <div class="carousel-item">
                    <img src="https://unilimpio.com/static/26a6c74db94ae2d6bb03973a04306a06/dce6a/prueba-banner-productos.jpg" class="d-block">
                </div>
                <div class="carousel-item">
                    <img src="https://cdn-3.expansion.mx/62/c9/b4fa9d784717b9d10424390183ca/productos-coca-cola-femsa.jpeg" class="d-block">
                </div>
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
    </section>
    <section class="dos">
        <div class="container">
            <div class="row col-12 justify-content-start">
                <%for (int i = 0; i < 6; i++)
                    { %>
                <div class="col-4">
                    <div class="card m-3">
                        <div class="card-body">
                            <h5 class="card-title">Celulares</h5>
                        </div>
                        <img src="https://img.lagaceta.com.ar/fotos/notas/2022/08/19/600x400_celulares-imagen-ilustrativa-957490-083807.webp" class="card-img-bottom" alt="Celulares">
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </section>
</asp:Content>
