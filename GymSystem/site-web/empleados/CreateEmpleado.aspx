<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="CreateEmpleado.aspx.cs" Inherits="CreateEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="clearfix"></div>
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                      <span class="section">Crear Empleado</span>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Nombre <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="nombre" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="name" placeholder="John" required="required" type="text" data-parsley-error-message="my message" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Apellido <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="apellido" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="apellido" placeholder="Doe" required="required" type="text" data-parsley-error-message="my message" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Email <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="email" id="email" name="email" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                        <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Telefono<span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="number" id="telefono" name="telefono" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">DNI <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="number" id="dni" name="dni" required="required" class="form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                      
                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="passw1" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Repetir Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="passw2" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">Fecha de nacimiento <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="fechaNacimiento" type="date" name="fechaNacimiento" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">Fecha de Ingreso <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="fechaIngreso" type="date" name="fechaIngreso" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                      
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="gender">Genero <span class="required"></span></label>
                        <div class="col-md-6 col-sm-6 col-xs-12" >
                          <div class="btn-group" data-toggle="buttons" >
                            <div>
                                <asp:RadioButtonList id="sexos" class="flat" runat="server">
                                    <asp:ListItem Value="M" Text="Masculino" Selected="True"/>
                                    <asp:ListItem Value="F" Text="Femenino"/>
                                </asp:RadioButtonList>
                          </div>
                        </div>
                      </div>
                    </div>

                      <div class="item form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12" for="days">Actividades<span class="required"></span>
                      </label>
                      <div class="btn-group" data-toggle="buttons">
                          <div class="btn-group" data-toggle="buttons">
                            <div>
                                <asp:ListBox ID="actividades" CssClass="select--multiple" runat="server" SelectionMode="Multiple" multiple="multiple">
                                </asp:ListBox>
                              </div>
                            </div>
                          </div>
                      </div>
                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Cancelar" OnClick="BtnCancelar_click"/>
                          <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Generar" OnClick="btnRegister_Click" />
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>

