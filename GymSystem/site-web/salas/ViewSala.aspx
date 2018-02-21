<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="ViewSala.aspx.cs" Inherits="ViewSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                      <span class="section">Crear Sala</span>
                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Nombre <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input ID="nombre" class="form-control col-md-7 col-xs-12" maxlength="50" data-validate-length-range="6" data-validate-words="2" name="nombre" placeholder="Socrates" required="required" type="text" data-parsley-error-message="my message" runat="server">
                              <asp:RequiredFieldValidator ID="nombreNoVacio"
                                    runat="server" ControlToValidate="nombre"
                                    ErrorMessage="Por favor ingrese Nombre"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                        </div>
                      </div>
                      
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Piso<span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="numero" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="numero" placeholder="1" required="required" type="number" data-parsley-error-message="" runat="server">
                                 <asp:RequiredFieldValidator ID="numeroNoVacio"
                                    runat="server" ControlToValidate="numero"
                                    ErrorMessage="Por favor ingrese Piso"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                            </div>
                        </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Capacidad<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="capacidad" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="capacidad" placeholder="10" required="required" type="number" data-parsley-error-message="" runat="server">
                             <asp:RequiredFieldValidator ID="capacidadNovacía"
                                    runat="server" ControlToValidate="capacidad"
                                    ErrorMessage="Por favor ingrese Capacidad"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RangeValidator runat="server" ID="rangoValidacion" Type="Integer"
                                    MinimumValue="1" MaximumValue="99" ControlToValidate="capacidad"
                                    ErrorMessage="La capacidad mínima es 1 máxima es 99" />
                        </div>
                      </div>

                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Cancelar" CausesValidation="false" OnClick="btnCancelar_Click" />
                          <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Actualizar" OnClick="btnActualizar_Click" />
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>

