<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="TrabajoFinalNivel3.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/changePassStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="row contenedor">
            <div class="mb-3">
                <label for="tboxMail" class="form-label">Mail</label>
                <asp:TextBox runat="server" type="mail" class="form-control" ID="tboxMail" />
            </div>
            <div class="mb-3">
                <label for="tboxPassActual" class="form-label" >Contraseña actual</label>
                <asp:TextBox runat="server" type="password" class="form-control" ID="tboxPassActual" />
            </div>
            <div class="mb-3">
                <label for="tboxNewPass" class="form-label" >Nueva contraseña</label>
                <asp:TextBox runat="server" type="pass" class="form-control" ID="tboxNewPass" />
            </div>
            <div class="mb-3">
                <label for="tboxNewPassConfirm" class="form-label" >Confirmar nueva contraseña</label>
                <asp:TextBox runat="server" class="form-control" type="pass" ID="tboxNewPassConfirm" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" class="btn btn-primary" id="btnAceptar" runat="server" />
                <a href="Perfil.aspx" class="btn btn-link">Cancelar</a>
            </div>
        </div>
    </section>
</asp:Content>
