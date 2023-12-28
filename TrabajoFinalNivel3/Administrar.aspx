<%@ Page Title="Administrar" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TrabajoFinalNivel3.Administrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/administrarStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="uno">
     <div class="container">
         <div class="row justify-content-between">
             <div class="filtro col-md-3 col-xs-12">
                 <label>Precio</label>
                 <asp:DropDownList runat="server" ID="DropDownList1" class="btn-group dropdown-menu mb-1">
                     <asp:ListItem Text="Mayor a" class="dropdown-item" />
                     <asp:ListItem Text="Menor a" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="input-group mb-3">
                     <span class="input-group-text">$</span>
                     <asp:TextBox runat="server" ID="TextBox1" class="form-control" />
                 </div>
                 <label>Marca</label>
                 <asp:DropDownList runat="server" ID="DropDownList2" class="btn-group dropdown-menu mb-3">
                     <asp:ListItem Text="Samsung" class="dropdown-item" />
                     <asp:ListItem Text="Motorola" class="dropdown-item" />
                 </asp:DropDownList>
                 <label>Categoría</label>
                 <asp:DropDownList runat="server" ID="DropDownList3" class="btn-group dropdown-menu mb-4">
                     <asp:ListItem Text="Multimedia" class="dropdown-item" />
                     <asp:ListItem Text="Celular" class="dropdown-item" />
                 </asp:DropDownList>
                 <div class="mb-3">
                     <asp:Button Text="Aplicar" ID="Button1" CssClass="btn mb-1" runat="server" />
                     <asp:Button Text="Limpiar" ID="Button2" CssClass="btn mb-1" runat="server" />
                 </div>
             </div>

             <div class="col-xs-12 col-md-8 justify-content-start">
                 <asp:GridView runat="server" CssClass="table" AutoGenerateColumns="false" ID="gridview" DataKeyNames="Id" PageSize="5">
                     <Columns>
                         <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                         <asp:BoundField HeaderText="Código" DataField="Codigo" />
                         <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                         <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                         <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                         <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                         <asp:BoundField HeaderText="Precio" DataField="Precio" />
                         <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                         <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />
                     </Columns>
                 </asp:GridView>
             </div>
         </div>

     </div>
 </section>
</asp:Content>
