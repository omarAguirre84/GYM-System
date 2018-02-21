<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewEmpleados.aspx.cs" Inherits="ViewSocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Administración de Empleados<small></small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <a class="btn btn-app", href="../empleados/CreateEmpleado.aspx">
                        <span class="badge bg-green"></span>
                      <i class="fa fa-users"></i> Crear Profesor
                    </a>
                    </ul>
                <div class="clearfix"></div>
                </div>
                <div class="x_content">
                <p class="text-muted font-13 m-b-30">
                </p>
                <form id="form1" runat="server">  
                    <table id="datatable" class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>Email</th>
                                <th>Telefono</th>
                                <th>Tipo Empleado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                        <% foreach (var empleado in listaEmpleados) { %>
                                <tr>
                                    <td><%= empleado.Nombre %></td>
                                    <td><%= empleado.Apellido %></td>
                                    <td><%= empleado.Email%></td>
                                    <td><%= empleado.Telefono %></td>
                                    <td><%=filterEmpleado(empleado)%>
                                    </td>
                                    <td>
                                        <a href="../empleados/ViewEmpleado.aspx?id=<%= empleado.Id %>" +  + class="btn btn-primary btn-xs" ><i class="fa fa-eye" ></i> Ver / Editar </a>
                                    </td>
                                </tr>
                        <% } %>
                    </tbody>
                    </table>  
                </form>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

