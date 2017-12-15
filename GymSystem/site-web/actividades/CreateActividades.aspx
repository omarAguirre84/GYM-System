<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="CreateActividades.aspx.cs" Inherits="CreateSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--            <div class="page-title">
              <div class="title_left">
                <h3>Crear Actividad</h3>
              </div>
            </div>--%>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate>
                      <span class="section">Crear Actividad</span>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="descripcion">Descripción <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="descripcion" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="descripcion" placeholder="Zumba" required="required" type="text" data-parsley-error-message="my message">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="tarifa">Tarifa <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="tarifa" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="tarifa" placeholder="5000" required="required" type="float" data-parsley-error-message="my message">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="timein">Horario Inicio <span class="required">*</span>
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                          <input id="datein" type="time" name="timein" data-validate-length-range="5,20" class="optional form-control col-md-3 col-sm-3 col-xs-12">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="timeout">Horario Fin <span class="required">*</span>
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                          <input id="dateout" type="time" name="timeout" data-validate-length-range="5,20" class="optional form-control col-md-3 col-sm-3 col-xs-12">
                        </div>
                       </div>
                         <label class="control-label col-md-3 col-sm-3 col-xs-12" for="dia">Dia Semana <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="dia" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="dia" placeholder="Lunes" required="required" type="text" data-parsley-error-message="my message">
                        </div>
                      </div>
                      <div class="item form-group">

                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <button type="submit" class="btn btn-primary">Cancelar</button>
                          <button id="send" type="submit" class="btn btn-success">Generar</button>
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>

