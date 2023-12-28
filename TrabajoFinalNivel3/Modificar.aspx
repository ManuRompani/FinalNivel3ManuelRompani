<%@ Page Title="Modificar" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="TrabajoFinalNivel3.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/modificarStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xs-12 col-md-5">
                    <div class="mb-3">
                        <label>Codigo</label>
                        <asp:TextBox ID="tboxCodigo" class="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Nombre</label>
                        <asp:TextBox ID="tboxNombre" class="form-control" runat="server" />
                    </div>

                    <div class="mb-3">
                        <label>Maca</label>
                        <asp:DropDownList runat="server" ID="ddownMarca" class="form-select">
                            <asp:ListItem Text="Samsung" class="dropdown-item" />
                            <asp:ListItem Text="Motorola" class="dropdown-item" />
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label>Categoría</label>
                        <asp:DropDownList runat="server" ID="ddownCategoria" class="form-select">
                            <asp:ListItem Text="Multimedia" class="dropdown-item" />
                            <asp:ListItem Text="Celular" class="dropdown-item" />
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label>Precio</label>
                        <div class="input-group mb-3">
                            <span class="input-group-text">$</span>
                            <asp:TextBox runat="server" ID="tboxPrecio" class="form-control" />
                        </div>
                    </div>

                </div>
                <div class="col-xs-12 col-md-5">
                    <div class="mb-3">
                        <label>Descripción</label>
                        <asp:TextBox ID="tboxDescripcion" class="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Imagen</label>
                        <asp:TextBox type="file" runat="server" ID="tboxImagen" class="form-control" />
                    </div>
                    <div class="m-4 mb-5" style="display:flex; justify-content:center;">
                        <asp:Image ImageUrl="Images/not-image-found.png" style="height:200px;" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row justify-content-start">
                <div class="col-md-1 col-xs-0"></div>
                <div class="col-xs-12 col-md-5">
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAplicar" CssClass="btn mb-1" runat="server" />
                        <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn mb-1" runat="server" />
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
