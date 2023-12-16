<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TrabajoFinalNivel3.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/favoritosStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row col-12 justify-content-start m-3">
                <%for (int i = 0; i < 5; i++)
                    { %>
                <div class="col-4">
                    <div class="card m-3">
                        <img src="https://www.ideahogar.com.ar/10967-medium_default/celular-motorola-g42-rosa-metalico-ean-994220.jpg" class="" alt="Celular">
                        <div class="card-body">
                            <h5 class="card-title">Celular</h5>
                            <a href="#" class="link-primary">Ver</a>
                            <asp:ImageButton class="imagen-btn-eliminar" ImageUrl="Images/icons8-eliminar-50.png" runat="server" />
                        </div>
                    </div>
                </div>
                <%} %>
            </div>

        </div>
    </section>
</asp:Content>
