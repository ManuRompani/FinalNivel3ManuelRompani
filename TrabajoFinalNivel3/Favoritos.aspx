<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TrabajoFinalNivel3.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/favoritosStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="repetidorFavoritos" OnItemDataBound="repetidorFavoritos_ItemDataBound">
                    <ItemTemplate>
                        <div class="card mb-3 col-xs-12 col-md-4">
                            <a href="VerProducto.aspx?id=<%# Eval("Id") %>" style="text-decoration: none !important; color: black;">
                                <asp:Image ImageUrl='<%# Eval("UrlImagen") %>' runat="server" ID="imagenArticulo" onerror="this.src='Images/not-image-found.png'" class="d-block rounded" Style="margin: auto; max-height: 150px;" />
                                <div class="card-body p-2">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <asp:ImageButton class="imagen-btn-eliminar" CommandArgument='<%# Eval("Id") %>' OnClick="eliminar_Click" ImageUrl="Images/icons8-eliminar-50.png" runat="server" />
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row justify-content-center">
                <div style="display: flex; justify-content: center; text-align: center; align-items: center; color: #fafbfc;" class="col" runat="server" visible="false" id="noFavoritos">
                    No tienes favoritos
                </div>
            </div>

        </div>
    </section>
</asp:Content>
