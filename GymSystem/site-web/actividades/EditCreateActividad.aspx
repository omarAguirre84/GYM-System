<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="EditCreateActividad.aspx.cs" Inherits="EditCreateActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="clearfix"></div>
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                         <% if (Request.QueryString["action"] == "edit") { %>
                                <span class="section"> Editar Actividad</span>             
                         <% } else if(Request.QueryString["action"] == "view") { %>
                                <span class="section"> Ver Actividad</span>
                            <% } else {%>
                            <span class="section"> Crear Actividad</span>
                            <%} %>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="descripcion">Descripción <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="descripcion" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="descripcion" placeholder="Zumba" runat="server" required="required" type="text" data-parsley-error-message="my message">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="tarifa">Tarifa <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="tarifa" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" runat="server" name="tarifa" placeholder="5000" required="required" type="number" data-parsley-error-message="my message">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="timein">Horario Inicio <span class="required">*</span>
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                          <input id="datein" type="time" name="timein" data-validate-length-range="5,20" runat="server" class="optional form-control col-md-3 col-sm-3 col-xs-12">
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="timeout">Horario Fin <span class="required">*</span>
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                          <input id="dateout" type="time" runat="server" name="timeout" data-validate-length-range="5,20" class="optional form-control col-md-3 col-sm-3 col-xs-12">
                        </div>
                      </div>
                      <div class="item form-group">
                         <label class="control-label col-md-3 col-sm-3 col-xs-12" for="dia">Dia Semana <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                         <asp:DropDownList ID="diaSelectList" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="item form-group">
                         <label class="control-label col-md-3 col-sm-3 col-xs-12" for="dia">Sala <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <asp:DropDownList ID="salasListItems" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <asp:Button ID="cancel" runat="server" Text="Cancelar" OnClick="btnReturnListActiv"  CssClass="btn btn-primary"/>
                          <asp:Button ID="confirm" runat="server" Text="Confirmar" OnClick="btnConfirmSaveActividad"  CssClass="btn btn-success"/>
                        </div>
                      </div>
                    </form>                  
                </div>
              </div>
             </div>
            </div>
</asp:Content>

