<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewSalas.aspx.cs" Inherits="ViewSocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Administración de Salas<small></small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <a class="btn btn-app", href="../salas/CreateSala.aspx">
                        <span class="badge bg-green"></span>
                      <i class="fa fa-users"></i> Crear Sala
                    </a>
                    </ul>
                <div class="clearfix"></div>
                </div>
                <div class="x_content">
                <p class="text-muted font-13 m-b-30">
                   <%-- DataTables has most features enabled by default, so all you need to do to use it with your own tables is to call the construction function: <code>$().DataTable();</code>--%>
                </p>

                <form id="form1" runat="server">  
                    <table id="datatable" class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Piso</th>
                                <th>Capacidad</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                        <% foreach (var sala in listaSalas) { %>
                                <tr>
                                    <td><%= sala.Nombre %></td>
                                    <td><%= 
                                            sala.Numero 
                                    %></td>
                                    <td><%= sala.Capacidad %></td>
                                    <td>
                                        <a href="./ViewSala.aspx?id=<%=sala.IdSala%>&accion=actualizar"  class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i> Ver / Editar </a>
                                        <a href="./ViewSala.aspx?id=<%=sala.IdSala%>&accion=eliminar" class="btn btn-danger btn-xs" ><i class="fa fa-pencil"></i> Eliminar </a>
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

