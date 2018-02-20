<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="DetalleActividadesDelProfesor.aspx.cs" Inherits="DetalleActividadesDelProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Socios registrados</h3>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                 <div class="x_title">
                    <h2>Actividad <%=actividad.name %><small> </small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="btn btn-app", href="ListaActividadesDelProfesor.aspx">
                        <span class="badge bg-green"></span>
                      <i class="fa fa-rebel"></i> Volver Actividades
                    </a>
                        </li>
                        <li><a class="btn btn-app", href="DetalleActividadesDelProfesor.aspx?id=<%=actividad.idActividad %>">
                        <span class="badge bg-green"></span>
                      <i class="fa fa-refresh"></i> Actualizar
                    </a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                  <div class="x_content">
                    <div class="row">
                      <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                      </div>

                      <div class="clearfix"></div>
                        <%foreach (var socio in listsocios)
                            {%>
                      <div class="col-md-4 col-sm-4 col-xs-12 profile_details">
                        <div class="well profile_view">
                          <div class="col-sm-12">
                            <h4 class="brief"><i>Socio</i></h4>
                            <div class="left col-xs-7">
                              <h2><%=socio.Nombre %>, <%=socio.Apellido %></h2>
                              <ul class="list-unstyled">
                                <li><i class="fa fa-building"></i> DNI: <%=socio.dni %> </li>
                                <li><i class="fa fa-phone"></i> Email : <%=socio.Email %></li>
                                  <li><i class="fa fa-phone"></i> Fecha Nacimiento:  <%=socio.FechaNacimiento %> </li>
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
          </div>
</asp:Content>

