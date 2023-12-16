<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TrabajoFinalNivel3.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/perfilStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="contenedor">
            <asp:Image ImageUrl="Images/icons8-usuario-not-img-96.png" Height="70px" CssClass="imagen-usuario" runat="server" />
            <asp:ImageButton ImageUrl="Images/icons8-foto-50.png" Height="30px" CssClass="imagen-camara" runat="server" />
            <div class="row">
                <div class="m-0">
                    <label for="tboxEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" type="email" class="form-control" ID="tboxEmail" />
                </div>
                <div class="m-0">
                    <label for="tboxNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="tboxNombre" />
                </div>
                <div class="m-0">
                    <label for="tboxApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="tboxApellido" />
                </div>
                <div class="m-0">
                    <a href="ChangePass.aspx" CssClass="link-primary">Cambiar contraseña</a>
                </div>
                <div class="m-0">
                    <asp:Button Text="Cerrar sesión" runat="server" ID="btnSesion" CssClass="btn btn-danger" />
                    <asp:Button Text="Guardar cambios" runat="server" ID="btnGuardar" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
