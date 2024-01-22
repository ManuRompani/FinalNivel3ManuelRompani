<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TrabajoFinalNivel3.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/modificarStyles.css" rel="stylesheet" />
    <script src="JS/valicaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="uno">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xs-11 col-md-5">
                    <div class="mb-3">
                        <label>Codigo</label>
                        <asp:TextBox ID="tboxCodigo" class="form-control" runat="server" ClientIDMode="Static"/>
                    </div>
                    <div class="mb-3">
                        <label>Nombre</label>
                        <asp:TextBox ID="tboxNombre" class="form-control" runat="server" ClientIDMode="Static"/>
                    </div>

                    <div class="mb-3">
                        <label>Maca</label>
                        <asp:DropDownList runat="server" ID="ddownMarca" class="form-select">
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label>Categoría</label>
                        <asp:DropDownList runat="server" ID="ddownCategoria" class="form-select">
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label>Precio</label>
                        <div class="input-group mb-3">
                            <span class="input-group-text">$</span>
                            <asp:TextBox runat="server" ID="tboxPrecio" class="form-control" ClientIDMode="Static" />
                        </div>
                    </div>

                </div>
                <div class="col-xs-12 col-md-5">
                    <div class="mb-3">
                        <label>Descripción</label>
                        <asp:TextBox ID="tboxDescripcion" class="form-control" TextMode="MultiLine" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Imagen</label>
                        <input type="file" runat="server" accept="image/*" ID="tboxUrlImagen" class="form-control" />
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="m-4 mb-5" style="display: flex; justify-content: center;">
                                <asp:Image ImageUrl="Images/not-image-found.png" ID="imagen" onerror="this.src='Images/not-image-found.png'" Style="height: 200px;" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row justify-content-start">
                <div class="col-md-1 col-xs-0"></div>
                <div class="col-xs-11 col-md-5">
                    <div class="mb-3" style="margin-top: 0px;">
                        <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn mb-1" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn mb-1" runat="server" />
                        <asp:CheckBox Text="Confirmar" for="btnEliminar" ID="cboxEliminar" Visible="false" runat="server" />
                        <a href="Administrar.aspx" style="color: #FFFFFF; margin: 5px 5px 5px 10px;">Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
