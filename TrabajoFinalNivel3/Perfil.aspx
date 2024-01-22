<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TrabajoFinalNivel3.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/perfilStyles.css" rel="stylesheet" />
    <script src="JS/validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="contenedor">
            <div class="row justify-content-center">
                <div class="contenedor-imagen">
                    <asp:Image onerror="this.src='Images/not-image-found.png'" ID="imagenUsuario" CssClass="imagen-usuario" runat="server" />
                </div>
                <div class="col-xs-10">
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox runat="server" type="email" class="form-control" ClientIDMode="Static" ReadOnly="true" ID="tboxEmail" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox runat="server" type="text" class="form-control" ClientIDMode="Static" ID="tboxNombre" />
                        <label class="invalid-feedback" id="mensajeNombre"></label>
                    </div>
                    <div class="mb-4">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox runat="server" type="text" class="form-control" ClientIDMode="Static" ID="tboxApellido" />
                        <label class="invalid-feedback" id="mensajeApellido"></label>
                    </div>
                    <div class="mb-4">
                        <label class="form-label">Cambiar imagen de Perfil</label>
                        <input type="file" accept="image/*" runat="server" id="cambiarImagen" class="form-control" />
                    </div>
                    <div class="mb-5">
                        <a href="ChangePass.aspx" cssclass="btn btn-link" style="color: #252b28;">Cambiar contraseña</a>
                    </div>
                    <div class="mb-4">
                        <asp:Button Text="Guardar cambios" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick='return validarPerfil();' ClientIDMode="Static" CssClass="btn mb-2" />
                        <asp:Button Text="Cerrar sesión" runat="server" ID="btnSesion" OnClick="btnSesion_Click" CssClass="btn mb-2" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
