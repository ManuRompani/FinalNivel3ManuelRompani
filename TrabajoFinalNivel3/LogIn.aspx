<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TrabajoFinalNivel3.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/loginStyles.css" rel="stylesheet" />
    <script src="JS/validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <h1 class="titulo">Iniciar sesión</h1>
        <div class="contenedor">
            <div class="row justify-content-center">
                <div class="col">
                    <div class="mb-3">
                        <label class="form-label">Mail</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" type="Email" ID="tboxEmail" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" type="password" ID="tboxPass" />
                        <label class="invalid-feedback" id="mensajeLogIn" runat="server">Las credenciales son incorrectas</label>
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" CssClass="btn mb-1" OnClientClick="return validarLogIn();" ClientIDMode="Static" OnClick="btnAceptar_Click" runat="server" ID="btnAceptar" />
                        <a href="SingUp.aspx" class="link-dark" style="margin: 0 0 0 10px;">Registrarse</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
