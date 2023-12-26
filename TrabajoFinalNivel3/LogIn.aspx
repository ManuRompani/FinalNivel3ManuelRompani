<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TrabajoFinalNivel3.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/loginStyles.css" rel="stylesheet" />
    <script src="JS/valicaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <h1 class="titulo">Iniciar sesión</h1>
        <div class="row contenedor">
            <div class="mb-3">
                <label  for="tboxMail" class="form-label">Mail</label>
                <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" type="Email" ID="tboxEmail" />
            </div>
            <div class="mb-3">
                <label for="tboxPass" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" type="password" ID="tboxPass" />
                <label class="invalid-feedback" id="mensajeLogIn"></label>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" OnClientClick="return validarLogIn()" runat="server" id="btnAceptar"/>
                <a href="SingUp.aspx" class="btn btn-link">Registrarse</a>
            </div>
        </div>
    </section>
</asp:Content>
