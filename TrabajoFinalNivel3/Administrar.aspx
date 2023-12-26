<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TrabajoFinalNivel3.Administrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <seccion class="uno container-fluid">
     <div class="row justify-content-between">
         <div class="filtro col-md-3 col-xs-12">
             <label>Precio</label>
             <asp:DropDownList runat="server" ID="ddwnPrecio" class="btn-group dropdown-menu mb-1">
                 <asp:ListItem Text="Mayor a" class="dropdown-item" />
                 <asp:ListItem Text="Menor a" class="dropdown-item" />
             </asp:DropDownList>
             <div class="input-group mb-3">
                 <span class="input-group-text">$</span>
                 <asp:TextBox runat="server" ID="tboxPrecio" class="form-control" />
             </div>
             <label>Marca</label>
             <asp:DropDownList runat="server" ID="ddwnMarca" class="btn-group dropdown-menu mb-3">
                 <asp:ListItem Text="Samsung" class="dropdown-item" />
                 <asp:ListItem Text="Motorola" class="dropdown-item" />
             </asp:DropDownList>
             <label>Categoría</label>
             <asp:DropDownList runat="server" ID="ddwnCategoria" class="btn-group dropdown-menu mb-4">
                 <asp:ListItem Text="Multimedia" class="dropdown-item" />
                 <asp:ListItem Text="Celular" class="dropdown-item" />
             </asp:DropDownList>
             <div class="mb-3">
                 <asp:Button Text="Aplicar" ID="btnAplicar" CssClass="btn btn-primary mb-1" runat="server" />
                 <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-primary mb-1" runat="server" />
             </div>
         </div>
         <div class="col-md-8 col-xs-12">
             <%for (int i = 0; i < 8; i++)
                 { %>
             <div class="card mb-3">
                 <a href="Buscar.aspx?id=<%:i %>" id="idTipo" style="text-decoration: none !important; color:black;">
                 <div class="row g-0">
                     <div class="col-md-4 p-4">
                         <img src="https://www.megatone.net/Images/Articulos/zoom2x/209/02/KIT1326MOT.jpg" class="img-fluid rounded-start" alt="Celular">
                     </div>
                     <div class="col-md-8">
                         <div class="card-body">
                             <h5 class="card-title">Celular</h5>
                             <p class="card-text mb-5">$230.000</p>
                            <asp:ImageButton class="imagen-btn-favorito" ImageUrl="Images/icons8-estrella-50.png" runat="server" />
                         </div>
                     </div>
                 </div>
                     </a>
             </div>
             <%} %>
         </div>
     </div>
 </seccion>
</asp:Content>
