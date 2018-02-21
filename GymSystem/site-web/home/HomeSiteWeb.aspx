    <%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="HomeSiteWeb.aspx.cs" Inherits="HomeSiteWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
        <div class="x_title">
            <div class="clearfix"></div>
        </div>
        <div class="x_content">
            <div class="bs-example" data-example-id="simple-jumbotron">
            <div class="jumbotron">
                <h1>Bienvenido <%=persona.Apellido%> , <%=persona.Nombre%></h1>
                <p></p>
            </div>
            </div>
        </div>
        </div>
    </div>
     <%if (true) {%>
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
        <div class="x_title">
            <h2>Actividades activas<small></small></h2>
            <div class="clearfix"></div>
        </div>
        <div class="x_content">
            <%if (actividadesUser.Count != 0)
                { %>     
            <ul class="list-unstyled timeline">
                
                    <% foreach (var actiUser in actividadesUser)
                        { %>
                <li>
                    <div class="block">
                    <div class="tags">
                        <a class="tag">
                        <span><%=actiUser.dia %></span>
                        </a>
                    </div>
                    <div class="block_content">
                        <h2 class="title">
                            <a><%=actiUser.name %></a>
                        </h2>
                        <div class="byline">
                        <span><%=actiUser.horaInicio %> a <%=actiUser.horaFin %>  </span> 
                             <%if (actiUser.listPersonas.Count != 0)
                                 { %>     
                            Por <a> <% foreach (var profesor in actiUser.listPersonas)
                                        {%>
                            <%=profesor.Nombre %> <%=profesor.Apellido %> ,
                            <%} %></a> 
                             <%}
                                 else
                                 {%> 
                                No hay un profesor asignado por el momento
                            <%} %>
                        </div>
                        <p class="excerpt">Precio de la Actividad $ <%=actiUser.tarifa %><a>
                    </div>
                    </div>
                </li>
                <%} %>
                
            </ul>
            <%}
                else
                {%> 
                No hay Actividades registradas
            <%} %>
        </div>
        </div>
    </div>
    <%} %>

    <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel" >
                  <div class="x_title">
                    <h2>Información Resumen de Adminitración</h2>
                    <div class="clearfix"></div>
                  </div>

                  <div class="x_content">
                    <div class="row">

                      <div class="col-md-12">

                        <!-- price element -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                          <div class="pricing">
                            <div class="title">
                              <h2>SOCIOS</h2>
                              <h1><%=listAdmin.Socios %></h1>
                            </div>
                            <div class="x_content">
                              <div class="pricing_footer">
                                <a href="../socios/ViewSocios.aspx" class="btn btn-success btn-block" role="button">Ir a Socios <span> </span></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- price element -->
                          <!-- price element -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                          <div class="pricing">
                            <div class="title">
                              <h2>PROFESORES</h2>
                              <h1><%=listAdmin.Profesores %></h1>
                            </div>
                            <div class="x_content">
                              <div class="pricing_footer">
                                <a href="../empleados/ViewEmpleados.aspx" class="btn btn-success btn-block" role="button">Ir a Empleados <span> </span></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- price element -->
                          <!-- price element -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                          <div class="pricing">
                            <div class="title">
                              <h2>ADMINISTRADORES</h2>
                             <h1><%=listAdmin.Adminitradores %></h1>
                            </div>
                            <div class="x_content">
                              <div class="pricing_footer">
                                <a href="../empleados/ViewEmpleados.aspx" class="btn btn-success btn-block" role="button">Ir a Empleados <span> </span></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- price element -->
                          <!-- price element -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                          <div class="pricing">
                            <div class="title">
                              <h2>ACTIVIDADES</h2>
                              <h1><%=listAdmin.Actividades %></h1>
                            </div>
                            <div class="x_content">
                              <div class="pricing_footer">
                                <a href="../actividades/ViewActividades.aspx" class="btn btn-success btn-block" role="button">Ir a Actividades <span> </span></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- price element -->
                          <!-- price element -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                          <div class="pricing">
                            <div class="title">
                              <h2>SALAS</h2>
                              <h1><%=listAdmin.Salas %></h1>
                            </div>
                            <div class="x_content">
                              <div class="pricing_footer">
                                <a href="#" class="btn btn-success btn-block" role="button">Ir a Salas <span> </span></a>
                              </div>
                            </div>
                          </div>
                        </div>
                        <!-- price element -->

                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

</asp:Content>

