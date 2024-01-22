<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TrabajoFinalNivel3.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
       body{
           background-image: linear-gradient(rgb(131, 180, 158), rgb(131, 180, 158));
       }
       .relleno {
           height: 90vh;
           display: flex;
           text-align: center;
       }
       h1{
           font-size:2.9em;
           margin: 10% 0 2% 0;
       }
       p{
           font-size:1.3em;
       }
       label{
           margin-top:2%;
           font-size:1.5em;
       }
   </style>
    <div class="container">
        <div class="row justify-content-center">
            <div class="relleno">
                <div class="col">
                    <h1>Error</h1>
                    <p>Tipo de error: <%= Session["Error"].ToString() %></p>
                    <label>┐(シ)┌</label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
