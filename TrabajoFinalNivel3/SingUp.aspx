<%@ Page Title="SingUp" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="SingUp.aspx.cs" Inherits="TrabajoFinalNivel3.SingUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/singupStyles.css" rel="stylesheet" />
    <script src="JS/valicaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <section class="uno">
      <h1 class="titulo">Crear cuenta</h1>
      <div class="row contenedor">
          <div class="mb-3">
              <label  for="tboxMail" class="form-label">Mail</label>
              <asp:TextBox runat="server"  class="form-control" ClientIDMode="Static" id="tboxEmail"/>
              <label class="invalid-feedback" id="mensajeEmail"></label>
          </div>
          <div class="mb-3">
              <label  for="tboxPass" class="form-label">Contraseña</label>
              <asp:TextBox runat="server"  class="form-control" type="password" ClientIDMode="Static" ID="tboxPass" />
               <label class="invalid-feedback" id="mensajePass"></label>
          </div>
          <div class="mb-4">
              <label for="tboxPass" class="form-label">Confirmar contraseña</label>
              <asp:TextBox runat="server" class="form-control" ClientIDMode="Static" type="password" ID="tboxPassConfirm" />
              <label class="invalid-feedback" id="mensajePassConfirm"></label>
          </div>
          <div class="mb-4">
              <asp:Button Text="Aceptar" CssClass="btn" OnClientClick="return validarSingUp()" runat="server" ID="btnAceptar" />
              <a href="LogIn.aspx" class="btn link">Iniciar sesión</a>
          </div>
      </div>
      </section>
</asp:Content>
