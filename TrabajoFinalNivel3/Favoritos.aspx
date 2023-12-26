<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TrabajoFinalNivel3.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/favoritosStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row justify-content-between">
                <div class="filtro col-md-3 col-xs-12">
                    <label>Precio</label>
                    <asp:DropDownList runat="server" ID="ddwnPrecio" class="btn-group dropdown-menu mb-1">
                        <asp:ListItem Text="Mayor a" class="dropdown-item" />
                        <asp:ListItem Text="Menor a" class="dropdown-item" />
                    </asp:DropDownList>
                    <div class="input-group mb-3">
                        <span class="input-group-text">$</span>
                        <asp:TextBox runat="server" ID="tboxPrecio" class="form-control" />
                    </div>
                    <label>Marca</label>
                    <asp:DropDownList runat="server" ID="ddwnMarca" class="btn-group dropdown-menu mb-3">
                        <asp:ListItem Text="Samsung" class="dropdown-item" />
                        <asp:ListItem Text="Motorola" class="dropdown-item" />
                    </asp:DropDownList>
                    <label>Categoría</label>
                    <asp:DropDownList runat="server" ID="ddwnCategoria" class="btn-group dropdown-menu mb-4">
                        <asp:ListItem Text="Multimedia" class="dropdown-item" />
                        <asp:ListItem Text="Celular" class="dropdown-item" />
                    </asp:DropDownList>
                    <div class="mb-3">
                        <asp:Button Text="Aplicar" ID="btnAplicar" CssClass="btn btn-primary mb-1" runat="server" />
                        <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-primary mb-1" runat="server" />
                    </div>
                </div>

                <div class="col-xs-12 col-md-8 justify-content-start">
                     <div class="row">
                    <%for (int i = 0; i < 5; i++)
                        { %>
                    <div class="card m-3 col-xs-12 col-md-5">
                        <a href="Buscar.aspx?id=<%:i %>" id="idTipo" style="text-decoration: none !important; color: black;">
                            <img src="https://www.ideahogar.com.ar/10967-medium_default/celular-motorola-g42-rosa-metalico-ean-994220.jpg" class="d-block rounded-start" alt="Celular" style="width:200px; height:200px;">
                            <div class="card-body p-2">
                                <h5 class="card-title">Celular</h5>
                                <asp:ImageButton class="imagen-btn-eliminar" ImageUrl="Images/icons8-eliminar-50.png" runat="server" />
                            </div>
                        </a>
                    </div>
                    <%} %>
                         </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
