<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewActividades.aspx.cs" Inherits="ViewActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Listas de Actividades<small></small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <a class="btn btn-app", href="EditCreateActividad.aspx">
                        <span class="badge bg-green"></span>
                        <i class="fa fa-users"></i> Alta Actividades
                       </a>
                    </ul>
                <div class="clearfix"></div>
                </div>
                <div class="x_content">
                <p class="text-muted font-13 m-b-30">
                   <%-- DataTables has most features enabled by default, so all you need to do to use it with your own tables is to call the construction function: <code>$().DataTable();</code>--%>
                </p>
                <asp:Table ID="Table1" runat="server"></asp:Table>
                <table id="datatable" class="table table-striped table-bordered">
                    <thead>
                    <tr>
                        <th>Descripción</th>
                        <th>Tarifa</th>
                        <th>Horario Inicio</th>
                        <th>Horario Fin</th>
                        <th>Dia Semana</th>
                        <th>Sala</th>
                        <th>Acciones</th>
                    </tr>
                    </thead>


                    <tbody>
                        <% foreach (var actividad in listaActividades) { %>
                                <tr>
                                    <td><%= actividad.name %></td>
                                    <td><%= actividad.tarifa %></td>
                                    <td><%= actividad.horaInicio %></td>
                                    <td><%= actividad.horaFin %></td>
                                    <td><%= actividad.dia %></td>
                                    <td><%= actividad.sala.Nombre %></td>
                                    <td>
                                        <a href="./EditCreateActividad.aspx?id=<%=actividad.idActividad%>&action=edit"  class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Ver / Editar </a>
                                        <a href="./ViewActividades.aspx?id=<%=actividad.idActividad%>&action=delete"  class="btn btn-danger btn-xs"><i class="fa fa-trash"></i> Eliminar </a>
                                    </td>
                                </tr>
                        <% } %>
                        
                    </tbody>
                </table>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

