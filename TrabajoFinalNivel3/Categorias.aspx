<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TrabajoFinalNivel3.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/modificarStyles.css" rel="stylesheet" />
    <script src="JS/validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xs-12 col-md-5">
                    <div class="mb-3">
                        <label>Id</label>
                        <asp:TextBox Text="Asignación automatica" ID="tboxIdCategoria" ReadOnly="true" class="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Descripcion</label>
                        <asp:TextBox ID="tboxDescripcion" ClientIDMode="Static" class="form-control" runat="server" />
                        <label class="invalid-feedback">
                            El campo no puede quedar vacío
                        </label>
                    </div>
                    <div class="mb-3">
                        <input type="file" runat="server" accept="image/*" class="form-control mb-3" id="imagenCategoria"/>
                        <asp:Image ImageUrl="/Images/not-image-found.png" onerror="this.src='Images/not-image-found.png'" style="height:200px;" id="imagenASP" CssClass="mx-auto d-block" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row justify-content-start">
                <div class="col-md-1 col-xs-0"></div>
                <div class="col-xs-12 col-md-5">
                    <label id="mensajeDeError" style="color: #FF0000;"></label>
                    <div class="mb-3" >
                        <asp:Button Text="Guardar" OnClientClick='return validarCategoriaMarca();' OnClick="btnGuardar_Click" ID="btnGuardar"  CssClass="btn" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn" runat="server" />
                        <asp:CheckBox Text="Confirmar" ID="cboxEliminar" Visible="false" runat="server" />
                        <a href="Administrar.aspx" style="color: #FFFFFF; margin: 5px 5px 5px 10px;">Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
