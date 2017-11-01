<%@ Page Title="" Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="Biografia.aspx.cs" Inherits="Biografia" %>

<asp:Content ID="cphCuerpo" ContentPlaceHolderID="Cuerpo" Runat="Server">
    <div class="vertical-menu">
      <a href="#" class="active">Home</a>
      <a href="Autenticacion.aspx"> Autenticacion</a>
      <a href="#">Link 2</a>
      <a href="#">Link 3</a>
      <a href="#">Link 4</a>
    </div>
    <asp:Menu ID="Menu1" runat="server">
    </asp:Menu>
</asp:Content>


