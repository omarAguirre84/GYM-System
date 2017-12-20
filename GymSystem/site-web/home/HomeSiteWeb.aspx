<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="HomeSiteWeb.aspx.cs" Inherits="HomeSiteWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Bienvenido <%=persona.Apellido%> , <%=persona.Nombre%>
</asp:Content>

