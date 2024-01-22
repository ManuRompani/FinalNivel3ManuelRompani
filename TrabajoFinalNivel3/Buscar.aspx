<%@ Page Title="Buscar" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="TrabajoFinalNivel3.Buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/buscarStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="uno">
        <div class="container">
            <div class="row justify-content-between">
                <div class="col-md-1 col-xs-0"></div>
                <div class="filtro col-md-3 col-xs-12">
                    <label class="form-label">Precio</label>
                    <asp:DropDownList runat="server" ID="ddwnPrecio" class="btn-group dropdown-menu mb-1">
                        <asp:ListItem Text="Todos" class="dropdown-item" />
                        <asp:ListItem Text="Mayor a" class="dropdown-item" />
                        <asp:ListItem Text="Menor a" class="dropdown-item" />
                    </asp:DropDownList>
                    <div class="input-group mb-3">
                        <span class="input-group-text">$</span>
                        <asp:TextBox runat="server" ID="tboxPrecio" class="form-control" />
                    </div>
                    <label class="form-label">Marca</label>
                    <asp:DropDownList runat="server" ID="ddwnMarca" class="btn-group dropdown-menu mb-3">
                    </asp:DropDownList>
                    <label class="form-label">Categoría</label>
                    <asp:DropDownList runat="server" ID="ddwnCategoria" class="btn-group dropdown-menu mb-3">
                    </asp:DropDownList>
                    <div class="mb-3">
                        <asp:Button Text="Aplicar" ID="btnAplicar" OnClick="btnAplicar_Click" CssClass="btn mb-1" runat="server" />
                        <asp:Button Text="Limpiar" OnClick="btnLimpiar_Click" ID="btnLimpiar" CssClass="btn mb-1" runat="server" />
                    </div>
                </div>
                 <div class="col-md-1 col-xs-0"></div>
                <div class="col-md-5 col-xs-12">
                    <asp:Repeater runat="server" ID="repetidorArticulos" OnItemDataBound="repetidorArticulos_ItemDataBound">
                        <ItemTemplate>
                            <div class="card mb-3">
                                <a href="VerProducto.aspx?id=<%# Eval("Id") %>" style="text-decoration: none !important; color: black;">
                                    <div class="row g-0">
                                        <div class="p-3">
                                            <asp:Image ImageUrl='<%# Eval("UrlImagen") %>' runat="server"  id="imagenArticulo" onerror="this.src='Images/not-image-found.png'" class="img-fluid rounded-start mx-auto d-block" style="height: 220px;" />
                                            <div>
                                                <h5 class="card-title" style="margin-top: 25px;"><%# Eval("Nombre") %></h5>
                                                <p class="card-text"><%# Eval("Precio") %></p>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="display:width:100%; flex; justify-content: center; align-items: center; color: #fafbfc;" id="mensajeSinProductos" runat="server" visible="false">
                        <label style="text-align: center; font-size:18px;">Lo sentimos! En este momento no contamos con productos de este tipo :(</label>
                    </div>
                </div>
                <div class="col-md-2 col-xs-0"></div>
            </div>
        </div>
    </section>
</asp:Content>
