<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TrabajoFinalNivel3.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/perfilStyles.css" rel="stylesheet" />
    <script src="JS/valicaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="contenedor">
            <asp:Image ImageUrl="Images/icons8-usuario-not-img-96.png" Height="70px" CssClass="imagen-usuario" runat="server" />
            <asp:ImageButton ImageUrl="Images/icons8-foto-50.png" Height="30px" CssClass="imagen-camara" runat="server" />
            <div class="row">
                <div class="mb-3">
                    <label for="tboxEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" type="email" class="form-control" ClientIDMode="Static" ReadOnly="true" ID="tboxEmail" />
                </div>
                <div class="mb-3">
                    <label for="tboxNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ClientIDMode="Static" ID="tboxNombre" />
                    <label class="invalid-feedback" id="mensajeNombre"></label>
                </div>
                <div class="mb-4">
                    <label for="tboxApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ClientIDMode="Static" ID="tboxApellido" />
                    <label class="invalid-feedback" id="mensajeApellido"></label>
                </div>
                <div class="mb-4">
                    <a href="ChangePass.aspx" CssClass="btn btn-link" style="color:#252b28;">Cambiar contraseña</a>
                </div>
                <div class="mb-4">
                    <asp:Button Text="Cerrar sesión" runat="server" ID="btnSesion" CssClass="btn mb-2" />
                    <asp:Button Text="Guardar cambios" runat="server" ID="btnGuardar" OnClientClick='return validarPerfil()' CssClass="btn mb-2" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
