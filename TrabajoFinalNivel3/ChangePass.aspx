<%@ Page Title="ChangePass" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="TrabajoFinalNivel3.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/changePassStyles.css" rel="stylesheet" />
     <script src="JS/valicaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
         <h1 class="titulo">Cambiar contraseña</h1>
        <div class="row contenedor">
            <div class="mb-3">
                <label for="tboxMail" class="form-label">Mail</label>
                <asp:TextBox runat="server" type="email" ClientIDMode="Static" class="form-control" ID="tboxEmail" />
                 <label class="invalid-feedback" id="mensajeEmail"></label>
            </div>
            <div class="mb-3">
                <label for="tboxPassActual" class="form-label" >Contraseña actual</label>
                <asp:TextBox runat="server" type="password" ClientIDMode="Static" class="form-control" ID="tboxPass" />
                 <label class="invalid-feedback" id="mensajePass"></label>
            </div>
            <div class="mb-3">
                <label for="tboxNewPass" class="form-label" >Nueva contraseña</label>
                <asp:TextBox runat="server" type="password" ClientIDMode="Static" class="form-control" ID="tboxNewPass" />
                <label class="invalid-feedback" id="mensajeNewPass"></label>
            </div>
            <div class="mb-3">
                <label for="tboxNewPassConfirm" class="form-label" >Confirmar nueva contraseña</label>
                <asp:TextBox runat="server" class="form-control" type="password" ClientIDMode="Static" ID="tboxNewPassConfirm" />
                 <label class="invalid-feedback" id="mensajeNewPassConfirm"></label>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" class="btn " OnClientClick='return validarChangePass()' id="btnAceptar" runat="server"/>
                <a href="Perfil.aspx" class="btn">Cancelar</a>
            </div>
        </div>
    </section>
</asp:Content>
