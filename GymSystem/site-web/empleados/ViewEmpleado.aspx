<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewEmpleado.aspx.cs" Inherits="ViewEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                      <span class="section">Actualizar Datos Empleado</span>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Nombre <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" ID="nombre" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="nombre" placeholder="Willy" required="required" type="text" data-parsley-error-message="my message" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Apellido <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" ID="apellido" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="apellido" placeholder="Wonka" required="required" type="text" data-parsley-error-message="my message" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">DNI <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="dni" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="DNI" placeholder="12345678" required="required" type="number" data-parsley-error-message="dni incorrecto" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Email <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="email" type="email" name="email" required="required" class="form-control col-md-7 col-xs-12" placeholder="willy@wonka.com" data-parsley-error-message="email incorrecto" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Telefono <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" type="tel" id="telefono" name="telefono" required="required" class="form-control col-md-7 col-xs-12" value="****" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="passw1" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" value="****" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label for="password2" class="control-label col-md-3 col-sm-3 col-xs-12">Repetir Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="passw2" type="password" name="password2" data-validate-linked="password" class="form-control col-md-7 col-xs-12" required="required" value="****" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">Fecha de nacimiento <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <input id="fechaNacimiento" type="date" name="datebirth" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" runat="server">
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
                                    <asp:ListItem Value="masculino" Text="Masculino" Selected="True"/>
                                    <asp:ListItem Value="femenino" Text="Femenino"/>
                                </asp:RadioButtonList>
                          </div>
                        </div>
                      </div>
                          </div>
                        <br />
                         <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">Actividades<span class="required"></span>
                        </label>
                          <div class="btn-group" data-toggle="buttons">
                            <div>
                                <asp:ListBox ID="actividades" CssClass="select--multiple"   runat="server" SelectionMode="Multiple" multiple="multiple">
                                </asp:ListBox>
                              </div>
                            </div>
                          </div>

                      <br />
                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-6">
                          <asp:Button ID="Button2" OnClick="Btn_cancelar" runat="server" class="btn btn-primary" Text="< Volver" />
                          <asp:Button ID="Button1" OnClick="Btn_actualizar" runat="server" class="btn btn-success" Text="Actualizar" />
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>

