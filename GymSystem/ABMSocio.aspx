﻿<%@ Page Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="ABMSocio.aspx.cs" Inherits="ABMSocio" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" Runat="Server">
    <form id="form1" Runat="Server">
    <div class="container">
      <div class="row">
        <div class="col-sm">
            <div class="card" style="width: 100%;">
              <div class="card-body">
                <h4 class="card-title">Gestion de Socios</h4>
                <h6 class="card-subtitle mb-2 text-muted">Listado de Socios</h6>
                <table class="table">
                    <thead>
                    <tr>
                        <th scope="col">ID del Socio</th>
                        <th scope="col">Tarjeta de Identificación</th>
                        <th scope="col">Estado</th>
                        <th scope="col">Cuota</th>
                        <th scope="col">Saldo</th>
                        <th scope="col"></th>
                    </tr>
                    </thead>
<%--                    <tbody>
                        <% foreach(var x in socios) { %>
                        <tr>
                            <th scope="row"><%= x.IdSocio %></th>
                            <td><%= x.nroTarjetaIdentificacion %></td>
                            <td><%= x.idEstado %></td>
                            <td><%= x.cuota %></td>
                            <td><%= x.saldo %></td>
                            <td>
                                <asp:Button ID="Button1" OnClick="modificarSocio" Text="Modificar" Runat="Server"/>
                                <asp:Button ID="Button2" OnClick="alterEstadoSocio" Text="DarBaja"  Runat="Server"/>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>--%>
                </table>
              </div>
            </div>
        </div>
      </div>
        <asp:Button ID="Button4" href="Biografia.aspx" Text="Volver" Runat="Server"/>
    </div>
        
    </form>
</asp:Content>

