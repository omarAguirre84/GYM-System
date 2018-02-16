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
                        <img class="img-responsive avatar-view" src="images/picture.jpg" alt="Avatar" title="Change the avatar">
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
                                        %> EMPLEADO<%
                                        break;
 
                                }%>
                        </li>
                    </ul>

                    <a  href="#" class="btn btn-success"><i class="fa fa-edit m-right-xs"></i>Edit Profile</a>
                    <br />

                </div>
                <div class="col-md-9 col-sm-9 col-xs-12">

                    <div class="" role="tabpanel" data-example-id="togglable-tabs">
                    <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Actividades Registradas</a>
                        </li>
                        <li role="presentation" class=""><a href="#tab_content2" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">Actividades</a>
                        </li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">

                        <!-- start recent activity -->
                        <ul class="messages">
                            <li>
                            <img src="images/img.jpg" class="avatar" alt="Avatar">
                            <div class="message_date">
                                <h3 class="date text-info">24</h3>
                                <p class="month">May</p>
                            </div>
                            <div class="message_wrapper">
                                <h4 class="heading">Desmond Davison</h4>
                                <blockquote class="message">Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua butcher retro keffiyeh dreamcatcher synth.</blockquote>
                                <br />
                                <p class="url">
                                <span class="fs1 text-info" aria-hidden="true" data-icon=""></span>
                                <a href="#"><i class="fa fa-paperclip"></i> User Acceptance Test.doc </a>
                                </p>
                            </div>
                            </li>
                        </ul>
                        <!-- end recent activity -->

                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="profile-tab">

                        <!-- start user projects -->
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
                        <!-- end user projects -->

                        </div>
                    </div>
                    </div>
                </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>