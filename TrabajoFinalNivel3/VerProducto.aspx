<%@ Page Title="VerProducto" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="TrabajoFinalNivel3.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/verProductoStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container justify-content-center">
            <div class="row justify-content-center" style="padding-top: calc(10vh); align-items: center;">
                <div class="col-xs-12 col-md-6 ajustar-imagen">
                    <asp:Image ImageUrl="https://www.ideahogar.com.ar/10967-medium_default/celular-motorola-g42-rosa-metalico-ean-994220.jpg" class="d-block rounded" runat="server" Style="max-height: 400px;" />
                </div>
                <div class="col-xs-12 col-md-6 margen-top">
                    <h3>Moto G9 Power</h3>
                    <div class="contenedor-caracteristicas">
                        <ul>
                            <li>Motorola</li>
                            <li>Celular</li>
                        </ul>
                    </div>
                    <div class="contenedor-descripcion">
                        <p>
                            Este es un celular con una batería de alta duración. Preparado para estar cuando mas lo necesites
                        </p>
                    </div>
                    <div class="favoritos">
                        <img class="estrella" src="Images/icons8-estrella-50.png" />
                        <p>Agregar a favoritos</p>
                    </div>
                </div>
            </div>
            <div class="row justify-content-start" style="margin-top:100px;">
                <h5>Productos similares</h5>
            </div>
            <div class="row justify-content-center">
                <%for (int i = 0; i < 3; i++)
                    { %>
                <div class="col-xs-12 col-md-4">
                    <div class="card m-3 col-xs-12 col-md-5" style="width: 300px;">
                        <a href="Buscar.aspx?id=<%:i %>" id="idTipo" style="text-decoration: none !important; color: black;">
                            <img src="https://www.ideahogar.com.ar/10967-medium_default/celular-motorola-g42-rosa-metalico-ean-994220.jpg" class="d-block rounded" alt="Celular" style="max-height:150px; margin:auto;">
                            <div class="card-body p-2">
                                <h5 class="card-title">Celular</h5>
                            </div>
                        </a>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </section>
</asp:Content>
