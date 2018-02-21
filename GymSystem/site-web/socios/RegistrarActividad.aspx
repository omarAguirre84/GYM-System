<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="RegistrarActividad.aspx.cs" Inherits="site_web_template_master_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div class="">
                <form id="uno" runat="server">
            <div class="page-title">
              <div class="title_left">
                <h3>Registrar Actividad</h3>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                  <div class="x_content">
                    <div class="row">
                      <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                      </div>

                      <div class="clearfix"></div>
                      <% if (listActividad.Count != 0)
                          { %>
                        <%foreach (var actividad in listActividad)
                            {%>
                      <div class="col-md-4 col-sm-4 col-xs-12 profile_details">
                        <div class="well profile_view">
                          <div class="col-sm-12">
                            <h4 class="brief"><i>Actividad</i></h4>
                            <div class="left col-xs-7">
                              <h2><%=actividad.name %></h2>
                              <p><strong>Profesores: </strong>
                                  <%foreach (var profesor in actividad.listPersonas)
                                      {%>
                                  <%=profesor.Nombre %> <%=profesor.Apellido %>,
                                  <%} %>
                              </p>
                              <ul class="list-unstyled">
                                <li><i class="fa fa-building"></i> Sala: <%=actividad.sala.Nombre %> </li>
                                <li><i class="fa fa-phone"></i> Dia : <%=actividad.dia %></li>
                                  <li><i class="fa fa-phone"></i> Horario:  <%=actividad.horaInicio %>  a   <%=actividad.horaFin %></li>
                              </ul>
                            </div>
                            <div class="right col-xs-5 text-center">
                              <img src="../../Imagenes/img-perfil.png" alt="" class="img-circle img-responsive">
                            </div>
                          </div>
                          <div class="col-xs-12 bottom text-center">
                            <div class="col-xs-12 col-sm-6 emphasis">

                            </div>
                            <div class="col-xs-12 col-sm-6 emphasis">
                                <% if (isRegistrado(actividad.idActividad))
                                    { %>
                              <a href="./RegistrarActividad.aspx?id=<%=actividad.idActividad%>&action=alta" type="button"  class="btn btn-primary btn-xs">
                                <i class="fa fa-thumbs-o-up"> </i> Seguir Actividad
                              </a>
                                
                                <%}
                                    else
                                    { %>
                                 <a href="./RegistrarActividad.aspx?id=<%=actividad.idActividad%>&action=baja" type="button" class="btn btn-danger btn-xs">
                                    <i class="fa fa-thumbs-o-down"> </i> Dejar Actividad
                                  </a>
                                <%} %>
                            </div>
                          </div>
                        </div>
                      </div>
                        
                        <%} %>
                        <%} %>
                    </div>
                  </div>
                </div>
              </div>
            </div>
                    </form>
          </div>
</asp:Content>

