<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewProfesor.aspx.cs" Inherits="ViewSocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="clearfix"></div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Administración de Profesores<small></small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <a class="btn btn-app", href="../profesor/CreateProfesor.aspx">
                        <span class="badge bg-green"></span>
                      <i class="fa fa-users"></i> Crear Profesor
                    </a>
                    </ul>
                <div class="clearfix"></div>
                </div>
                <div class="x_content">
                <p class="text-muted font-13 m-b-30">
                   <%-- DataTables has most features enabled by default, so all you need to do to use it with your own tables is to call the construction function: <code>$().DataTable();</code>--%>
                </p>
                <table id="datatable" class="table table-striped table-bordered">
                    <thead>
                    <tr>
                        <th>Name</th>
                        <th>Position</th>
                        <th>Office</th>
                        <th>Age</th>
                        <th>Start date</th>
                        <th>Salary</th>
                        <th>Estado</th>
                        <th>Acciones</th>
                    </tr>
                    </thead>


                    <tbody>
                        <tr>
                            <td>Juan Ramirez</td>
                            <td>Musculacion</td>
                            <td>Edinburgh</td>
                            <td>23</td>
                            <td>2001/05/13</td>
                            <td>$13,600</td>
                            <td>
                                <a href="#" class="btn btn-danger btn-xs"><i class="fa fa-thumbs-o-down"></i> no activo </a>
                            </td>
                            <td>
                                <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-eye"></i> Ver </a>
                                <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                            </td>
                         </tr>
                        <tr>
                            <td>Pedro Alfonso</td>
                            <td>Step</td>
                            <td>Edinburgh</td>
                            <td>24</td>
                            <td>2007/06/13</td>
                            <td>$25,600</td>
                            <td>
                                <a href="#" class="btn btn-warning btn-xs"><i class="fa fa-pause"></i> suspendido </a>
                            </td>
                            <td>
                                <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-eye"></i> Ver </a>
                                <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                            </td>
                         </tr>
                        <tr>
                            <td>Sonya Frost</td>
                            <td>Software Engineer</td>
                            <td>Edinburgh</td>
                            <td>23</td>
                            <td>2008/12/13</td>
                            <td>$103,600</td>
                            <td>
                                <a href="#" class="btn btn-success btn-xs"><i class="fa fa-thumbs-o-up"></i> activo </a>
                            </td>
                            <td>
                                <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-eye"></i> Ver </a>
                                <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                            </td>
                         </tr>
                    </tbody>
                </table>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

