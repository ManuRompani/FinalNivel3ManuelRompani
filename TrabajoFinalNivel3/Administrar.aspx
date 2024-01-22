<%@ Page Title="Administrar" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TrabajoFinalNivel3.Administrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/administrarStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
     <section class="uno">
     <div class="container">
         <div class="row justify-content-between">
            <div class="filtro col-md-3 col-xs-12">
                 <%if (tipoFiltro == 0)
                     { %>
                 <div class="mb-3">
                     <label class="form-label">Codigo</label>
                     <asp:TextBox runat="server" class="form-control" ID="tboxCodigo" />
                 </div>
                 <label class="form-label">Precio</label>
                 <asp:DropDownList runat="server" ID="dropdownPrecio" class="btn-group dropdown-menu mb-1">
                     <asp:ListItem Text="Todos" class="dropdown-item" />
                     <asp:ListItem Text="Mayor a" class="dropdown-item" />
                     <asp:ListItem Text="Menor a" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="input-group mb-3">
                     <span class="input-group-text">$</span>
                     <asp:TextBox runat="server" ID="tboxPrecio" type="number" class="form-control" />
                 </div>
                 <label class="form-label">Marca</label>
                 <asp:DropDownList runat="server" ID="dropdownMarca" class="btn-group dropdown-menu mb-3">
                     
                 </asp:DropDownList>
                 <label class="form-label">Categoría</label>
                 <asp:DropDownList runat="server" ID="dropdownCategoria" class="btn-group dropdown-menu mb-4">
                 </asp:DropDownList>
                 <%}
                     else if (tipoFiltro == 1)
                     {
%>
                 <label class="form-label">Id</label>
                 <asp:DropDownList runat="server" ID="dropdownIdUsuario" class="btn-group dropdown-menu mb-1">
                     <asp:ListItem Text="Todos" class="dropdown-item" />
                     <asp:ListItem Text="Mayor a" class="dropdown-item" />
                     <asp:ListItem Text="Menor a" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="input-group mb-3">
                     <asp:TextBox runat="server" ID="tboxIdUsuario" class="form-control" type="number" />
                 </div>
                 <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="tboxNombreUsuario" class="form-control mb-3" />
                 <label class="form-label">Email</label>
                 <asp:DropDownList runat="server" ID="dropdownEmail" class="btn-group dropdown-menu mb-1">
                     <asp:ListItem Text="Todos" class="dropdown-item" />
                     <asp:ListItem Text="Igual" class="dropdown-item" />
                     <asp:ListItem Text="Terminacion" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="input-group mb-3">
                     <asp:TextBox runat="server" ID="tboxEmailUsuario" class="form-control" />
                 </div>
                 <%}
                     else
                     { %>
                 <label class="form-label">Id</label>
                 <asp:DropDownList runat="server" ID="dropdownIdMarcaCategoria" class="btn-group dropdown-menu mb-1">
                     <asp:ListItem Text="Todos" class="dropdown-item" />
                     <asp:ListItem Text="Mayor a" class="dropdown-item" />
                     <asp:ListItem Text="Menor a" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="input-group mb-3">
                     <asp:TextBox runat="server" ID="tboxIdMarcaCategoria" type="number" class="form-control" />
                 </div>
                 <label class="form-label">Nombre</label>
                 <asp:TextBox runat="server" ID="tboxNombreMarcaCategoria" class="form-control mb-3" />
                 <%} %>
                 <asp:Label id="campoInvalido" runat="server" />
                 <div class="mb-3">
                     <asp:Button Text="Aplicar" AutoPostBack="true" ID="btnAplicar" OnClick="btnAplicar_Click" CssClass="btn mb-1" runat="server" />
                     <asp:Button Text="Limpiar" ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass="btn mb-1" runat="server" />
                 </div>
             </div>
               
             <div class="col-xs-12 col-md-8 justify-content-start">
                 <asp:DropDownList ID="ddwnAdministrar" AutoPostBack="true" OnSelectedIndexChanged="ddwnAdministrar_SelectedIndexChanged" runat="server" class="btn-group dropdown-menu mb-3">
                     <asp:ListItem Text="Articulos" />
                     <asp:ListItem Text="Usuarios" />
                     <asp:ListItem Text="Categorias" />
                     <asp:ListItem Text="Marcas" />
                 </asp:DropDownList>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                         <%if (ddwnAdministrar.SelectedIndex == 0)
                             { %>
                         <asp:GridView runat="server" EnablePartialRendering="true" CssClass="table" OnSelectedIndexChanged="gridviewAdministrar_SelectedIndexChanged" ClientIDMode="Static" AutoGenerateColumns="false" ID="gridviewAdministrarArticulos" DataKeyNames="Id" PageSize="5">
                             <Columns>
                                 <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                                 <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                 <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                 <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                                 <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                                 <asp:BoundField HeaderText="Precio" DataField="Precio" />
                                 <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />
                             </Columns>
                         </asp:GridView>
                         <%}
                             else if (ddwnAdministrar.SelectedIndex == 1)
                             { %>
                         <asp:GridView runat="server" CssClass="table" ClientIDMode="Static" OnSelectedIndexChanged="gridviewAdministrar_SelectedIndexChanged" AutoGenerateColumns="false" ID="gridviewAdministrarUsuarios" DataKeyNames="Id" PageSize="5">
                             <Columns>
                                 <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                                 <asp:BoundField HeaderText="Email" DataField="Email" />
                                 <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                 <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                 <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Ver" />
                             </Columns>
                         </asp:GridView>
                         <%}
                             else
                             {%>
                         <asp:GridView runat="server" CssClass="table" ClientIDMode="Static" AutoGenerateColumns="false" OnSelectedIndexChanged="gridviewAdministrar_SelectedIndexChanged" ID="gridviewAdministrarCategoriasYMarcas" DataKeyNames="Id" PageSize="5">
                             <Columns>
                                 <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                                 <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                 <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />
                             </Columns>
                         </asp:GridView>
                         <%} %>
                     </ContentTemplate>
                 </asp:UpdatePanel>
                 <div class="row justify-content-start">
                     <div class="col">
                         <asp:Button Text="Agregar" OnClick="agregar_Click" ID="agregar" CssClass="btn mb-1" runat="server" />
                     </div>
                 </div>
             </div>
         </div>

     </div>
 </section>
</asp:Content>
