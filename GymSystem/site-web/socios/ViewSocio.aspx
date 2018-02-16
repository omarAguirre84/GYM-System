﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewSocio.aspx.cs" Inherits="ViewSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                      <span class="section">Actualizar Datos de Socio</span>
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
                          <asp:TextBox rows="1" type="tel" id="telefono" name="telefono" required="required" class="form-control col-md-7 col-xs-12" placeholder="1147689022" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="passw1" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" value="********" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label for="password2" class="control-label col-md-3 col-sm-3 col-xs-12">Repetir Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:TextBox rows="1" id="passw2" type="password" name="password2" data-validate-linked="password" class="form-control col-md-7 col-xs-12" required="required" value="********" runat="server"/>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">Fecha de nacimiento <span class="required"></span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <input id="fechaNacimiento" type="date" name="datebirth" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" runat="server">
                        </div>
                      </div>
                      
                      <div class="col-md-6 col-md-offset-3">
                          <div class="btn-group" data-toggle="buttons">
                            <label id="masculinoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                              <input ID="masculino" type="radio" name="gender" class="btn btn-default" value="male" runat="server"> Masculino
                            </label>
                            <label id="femeninoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                              <input ID="femenino" type="radio" name="gender" value="female" runat="server"> Femenino
                            </label>
                          </div>
                      </div>
                        <br />
                        <br />

                        <div class="col-md-6 col-md-offset-3">
                          <div class="btn-group" data-toggle="buttons">
                            <label id="activoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                              <input id="activo" type="radio" class="btn btn-success btn-xs" value="activo" runat="server"><i class="fa fa-thumbs-o-up"></i> activo
                            </label>
                            <label id="inactivoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                              <input id="inactivo" type="radio" class="btn btn-danger btn-xs" value="Inactivo" runat="server"><i class="fa fa-thumbs-o-down"></i> Inactivo
                            </label>
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
