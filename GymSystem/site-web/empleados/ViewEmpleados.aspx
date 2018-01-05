<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewEmpleados.aspx.cs" Inherits="ViewSocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Administración de Profesores<small></small></h2>
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
                                <th>Actividad</th>
                                <th>Dia</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!--Table rows-->
                            <asp:PlaceHolder ID="TablaPlaceHolder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>  
                </form>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

