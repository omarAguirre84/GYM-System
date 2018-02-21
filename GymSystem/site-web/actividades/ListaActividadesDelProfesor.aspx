<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ListaActividadesDelProfesor.aspx.cs" Inherits="ListaActividadesDelProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
            <h3>Listado de Actividades <small></small></h3>
            </div>

            <div class="title_right">
            </div>
        </div>
            
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                <h2>Actividades</h2>
                <div class="clearfix"></div>
                </div>
                <div class="x_content">

                <p>Todas las actividades activas del GymSystem</p>

                <!-- start project list -->
                <table class="table table-striped projects">
                    <thead>
                    <tr>
                        <th style="width: 20%">Nombre de la Actividad</th>
                        <th>Profesores</th>
                        <th>Cantidad de Socios</th>
                        <th>Sala</th>
                        <%--<th>Status</th>--%>
                        <th style="width: 20%">Acciones</th>
                    </tr>
                    </thead>
                    <tbody>
                    <%foreach(var actividad in listActividad){ %>
                    <tr>
                        <td>
                        <a><%=actividad.name %></a>
                        <br />
                        <small>Dia: <%=actividad.dia %></small>
                        <br />
                        <small>Hora Inicio: <%=actividad.horaInicio %></small>
                        <br />
                        <small>Hora Fin: <%=actividad.horaFin %></small>
                        </td>
                        <td>
                        <%if (actividad.listPersonas.Count != 0)
                          {
                                foreach (var profesor in actividad.listPersonas)
                                {%>
                        <ul class="list-inline">
                            <li>
                            <img src="../../Imagenes/img-perfil.png" class="avatar" alt="Avatar">
                            </li>
                        </ul>
                                <% }
                          } else {%>
                            No hay profesores
                        <%} %>
                        </td>
                        <td class="project_progress">
                        <div class="progress progress_sm">
                            <div class="progress-bar bg-green" role="progressbar" data-transitiongoal="<%=calcularPorcentaje(actividad) %>"></div>
                        </div>
                        <small><%=calcularSiHayLugar(actividad) %>,</small>
                            <br />
                        <small><%=calcularPorcentaje(actividad) %>% Completado</small>
                        </td>
                        <td>
                            <%=actividad.sala.Nombre %>
                        </td>
                        <%--<td>
                        <button type="button" class="btn btn-success btn-xs">Success</button>
                        </td>--%>
                        <td>
                        <% if(actividad.cantSocios != 0){%>
                        <a href="DetalleActividadesDelProfesor.aspx?id=<%=actividad.idActividad%>" class="btn btn-primary btn-xs"><i class="fa fa-eye"></i> Ver Socios </a>
                        <%} else {%>
                            <a class="btn btn-warning btn-xs"><i class="fa fa-eye-slash"></i> Ver Socios </a>
                            <%} %>
                        <% if (isRegistrado(actividad.idActividad)){ %>
                            <a href="ListaActividadesDelProfesor.aspx?id=<%=actividad.idActividad%>&action=alta" class="btn btn-success btn-xs"><i class="fa fa-check"></i> Anotarse </a>
                        <%} else {%>
                            <a href="ListaActividadesDelProfesor.aspx?id=<%=actividad.idActividad%>&action=baja" class="btn btn-danger btn-xs"><i class="fa fa-times"></i> Dejar </a>
                        <%} %>
                        </td>
                    </tr>
                     <%} %>
                    </tbody>
                </table>
                <!-- end project list -->

                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>

