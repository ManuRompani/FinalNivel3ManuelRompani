<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TrabajoFinalNivel3.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/modificarStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div classs="container">
            <div class="row justify-content-center">
                <div class="col-xs-11 col-md-5">
                    <div class="mb-3">
                        <label>Email</label>
                        <asp:TextBox ID="tboxEmail" ReadOnly="true" class="form-control" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Nombre</label>
                        <asp:TextBox ID="tboxNombreUsuario" class="form-control" ReadOnly="true" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Apellido</label>
                        <asp:TextBox ID="tboxApellidoUsuario" class="form-control" ReadOnly="true" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label>Admin</label>
                        <asp:TextBox runat="server" id="tboxAdmin" CssClass="form-control"/>
                    </div>
                </div>
                <div class="col-xs-12 col-md-5">
                    <div class="m-4">
                        <asp:Image ImageUrl="Images/not-image-found.png" ID="imagenUsuario" Style="height: 200px;" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row justify-content-start">
                <div class="col-md-1 col-xs-0"></div>
                <div class="col-xs-11 col-md-5">
                    <div class="mb-3" style="margin-top: 50px;">
                        <a href="Administrar.aspx" style="color: #FFFFFF; margin: 5px 5px 5px 10px;">Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
