<%@ Page Title="SingUp" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="SingUp.aspx.cs" Inherits="TrabajoFinalNivel3.SingUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/singupStyles.css" rel="stylesheet" />
    <script src="JS/validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="uno">
        <h1 class="titulo">Crear cuenta</h1>
        <div class="contenedor">
            <div class="row justify-content-center">
                <div class="col">
                    <div class="mb-3">
                        <label class="form-label">Mail</label>
                        <asp:TextBox runat="server" class="form-control" ClientIDMode="Static" ID="tboxEmail" />
                        <label class="invalid-feedback" runat="server" id="mensajeEmail"></label>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" class="form-control" type="password" ClientIDMode="Static" ID="tboxPass" />
                        <label class="invalid-feedback" id="mensajePass"></label>
                    </div>
                    <div class="mb-4">
                        <label class="form-label">Confirmar contraseña</label>
                        <asp:TextBox runat="server" class="form-control" ClientIDMode="Static" type="password" ID="tboxPassConfirm" />
                        <label class="invalid-feedback" id="mensajePassConfirm"></label>
                    </div>
                    <div class="mb-4">
                        <asp:Button Text="Aceptar" CssClass="btn mb-1" OnClick="btnAceptar_Click" OnClientClick="return validarSingUp();" ClientIDMode="Static" runat="server" ID="btnAceptar" />
                        <a href="LogIn.aspx" class="link-dark" style="margin: 0 0 0 10px;">Iniciar sesión</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
