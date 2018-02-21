<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" MasterPageFile="~/site-web/template-master/HomePrincipal.master" Inherits="site_web_profile_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">            
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_content">
                <div class="col-md-3 col-sm-3 col-xs-12 profile_left">
                    <div class="profile_img">
                    <div id="crop-avatar">
                        <!-- Current avatar -->
                        <img src="../../Imagenes/img-perfil.png" alt="..." class="img-circle profile_img">
                    </div>
                    </div>
                    <h3><%=persona.Nombre %>, <%=persona.Apellido %></h3>

                    <ul class="list-unstyled user_data">
                        <li><i class="fa fa-map-marker user-profile-icon"></i>
                            <% switch (persona.tipoPersona) {
                                    case 'P':
                                        %> PROFESOR<% 
                                        break;

                                    case 'S':
                                        %> SOCIO<%
                                        break;

                                    default:
                                        %> ADMINISTRADOR<%
                                        break;
 
                                }%>
                        </li>
                        <li><i class="fa fa-birthday-cake user-profile-icon"><%=persona.FechaNacimiento.ToString("dd/MM/yyyy") %></i></li>
                        <li><i class="fa fa-book user-profile-icon"><%=persona.dni%></i></li>
                        <%if(persona.Sexo == 'M'){ %>
                            <li><i class="fa fa-male user-profile-icon">Masculino</i></li>
                            <%}else{ %>
                            <li><i class="fa fa-female user-profile-icon">Femenino</i></li>
                            <%} %>
                            
                    </ul>

                    <a  href="EditProfile.aspx" class="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Edit Profile</a>
                    <br />

                </div>
                <%if (persona.tipoPersona != 'A') {%>
                <div class="col-md-9 col-sm-9 col-xs-12">

                    <div class="" role="tabpanel" data-example-id="togglable-tabs">
                    <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Actividades Registradas</a>
                        </li>
                        <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Todas las actividades</a>
                        </li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">

                        <!-- start recent activity -->
                        <% if (listActivSelect.Count != 0)
                            {%>
                        <table class="data table table-striped no-margin">
                            <thead>
                            <tr>
                                <th>Nombre de la actividad</th>
                                <th>Dia</th>
                                <th>Hora de Inicio</th>
                                <th>Hora de Fin</th>
                                <th>Tarifa</th>
                            </tr>
                            </thead>
                            <tbody>
                                 <% foreach (var actividad in listActivSelect)
                                                              { %>
                                <tr>
                                    <td><%= actividad.name %></td>
                                    <td><%= actividad.dia %></td>
                                    <td><%= actividad.horaInicio %></td>
                                    <td><%= actividad.horaFin %></td>
                                    <td><%= actividad.tarifa %></td>
                                    
                                <%} %>
                            </tbody>
                        </table>
                            <%}else{ %>
                                <span> No hay actividades Registradas</span>
                            <%} %>
                        <!-- end recent activity -->

                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">

                        <!-- start user projects -->
                            <% if (listActiv.Count != 0)
                            {%>
                        <table class="data table table-striped no-margin">
                            <thead>
                            <tr>
                                <th>Nombre de la actividad</th>
                                <th>Dia</th>
                                <th>Hora de Inicio</th>
                                <th>Hora de Fin</th>
                                <th>Tarifa</th>
                            </tr>
                            </thead>
                            <tbody>
                                 <% foreach (var actividad in listActiv)
                                     { %>
                                <tr>
                                    <td><%= actividad.name %></td>
                                    <td><%= actividad.dia %></td>
                                    <td><%= actividad.horaInicio %></td>
                                    <td><%= actividad.horaFin %></td>
                                    <td><%= actividad.tarifa %></td>
                                    
                                <%} %>
                            </tbody>
                        </table>
                            <%}else{ %>
                                <span> No hay actividades Disponible</span>
                            <%} %>
                        <!-- end user projects -->

                        </div>
                    </div>
                    </div>
                </div>
                <%} %>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>