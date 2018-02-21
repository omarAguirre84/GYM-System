<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/HomePrincipal.master" AutoEventWireup="true" CodeFile="CreateSocio.aspx.cs" Inherits="CreateSocio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix"></div>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_content">
                    <form class="form-horizontal form-label-left" novalidate runat="server">
                        <span class="section">Crear Socio</span>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="nombre">
                                Nombre <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="nombre" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="nombre" placeholder="Willy" required="required" type="text" data-parsley-error-message="my message" maxlength="50" runat="server">

                                <asp:RequiredFieldValidator ID="nombreNoVacio"
                                    runat="server" ControlToValidate="nombre"
                                    ErrorMessage="Por favor ingrese Nombre"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="caracteres" runat="server"
                                    ErrorMessage="Solo se puede ingresar caracteres alfabéticos"
                                    ControlToValidate="nombre"
                                    ValidationExpression="^[a-zA-Z]+$"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="apellido">
                                Apellido <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="apellido" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="apellido" placeholder="Wonka" required="required" type="text" data-parsley-error-message="my message" maxlength="50" runat="server">

                                <asp:RequiredFieldValidator ID="apellidoNoVacio"
                                    runat="server" ControlToValidate="apellido"
                                    ErrorMessage="Por favor ingrese Apellido"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="validaCaracteres" runat="server"
                                    ErrorMessage="Solo se puede ingresar caracteres alfabéticos"
                                    ControlToValidate="apellido"
                                    ValidationExpression="^[a-zA-Z]+$"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="DNI">
                                DNI  <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="dni" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="2" name="DNI" placeholder="12345678" required="required" type="number" data-parsley-error-message="dni incorrecto" runat="server">
                                <asp:RequiredFieldValidator ID="noVacio"
                                    runat="server" ControlToValidate="dni"
                                    ErrorMessage="Por favor ingrese DNI"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator runat="server" ID="valInput"
                                    ControlToValidate="dni"
                                    ValidationExpression="^[\d\d]{8,8}$"
                                    ErrorMessage="El DNI debetener 8 dígitos"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                Email <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="email" type="email" name="email" required="required" class="form-control col-md-7 col-xs-12" placeholder="willy@wonka.com" data-parsley-error-message="email incorrecto" maxlength="50" runat="server">
                                <asp:RequiredFieldValidator ID="emailNoVacio"
                                    runat="server" ControlToValidate="email"
                                    ErrorMessage="Por favor ingrese email"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator runat="server" ID="emailValido"
                                    ControlToValidate="email"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="Por favor verifique el email"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telefono">
                                Teléfono <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input type="tel" id="telefono" name="telefono" required="required" class="form-control col-md-7 col-xs-12" placeholder="1147689022" runat="server">

                                <asp:RequiredFieldValidator ID="telefonoNoVacio"
                                    runat="server" ControlToValidate="telefono"
                                    ErrorMessage="Por favor ingrese telefono"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ID="validaTelefono"
                                    ControlToValidate="telefono"
                                    ValidationExpression="^[\d\d]{8,10}$"
                                    ErrorMessage="El telefono debe contener entre 8 y 10 dígitos"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label for="password" class="control-label col-md-3">Contraseña  *</label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="passw1" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required" placeholder="****" maxlength="50" runat="server">

                                <asp:RequiredFieldValidator ID="contraseñaNoVacia"
                                    runat="server" ControlToValidate="passw1"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label for="password2" class="control-label col-md-3 col-sm-3 col-xs-12">Repetir Contraseña * </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="passw2" type="password" name="password2" data-validate-linked="password" class="form-control col-md-7 col-xs-12" required="required" placeholder="****" maxlength="50" runat="server">
                                <asp:RequiredFieldValidator ID="contraseña2NoVacia"
                                    runat="server" ControlToValidate="passw2"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="comparaContraseñas" runat="server"
                                    ControlToValidate="passw2"
                                    CssClass="ValidationError"
                                    ControlToCompare="passw1"
                                    ErrorMessage="Las Contraseñas no coinciden" />
                            </div>

                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="datebirth">
                                Fecha de nacimiento <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input id="fechaNacimiento" type="date" name="datebirth" data-validate-length-range="5,20" class="optional form-control col-md-7 col-xs-12" runat="server">

                                <asp:RequiredFieldValidator ID="fechaNoVacia"
                                    runat="server" ControlToValidate="fechaNacimiento"
                                    ErrorMessage="Por favor ingrese Fecha de Nacimiento"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RangeValidator runat="server" ID="rngDate"
                                    ControlToValidate="fechaNacimiento" Type="Date" MinimumValue="01-01-1900"
                                    MaximumValue="31-12-2017"
                                    ErrorMessage="Por favor ingrese una fecha válida">
                                </asp:RangeValidator>
                            </div>
                        </div>

                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="gender">
                                Sexo<span class="required"></span>
                            </label>
                            <div class="col-md-6 col-xs-12">
                                <div class="btn-group" data-toggle="buttons">
                                    <label id="masculinoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                                        <input id="masculino" type="radio" name="gender" class="btn btn-default" value="male" runat="server">
                                        Masculino
                                    </label>
                                    <label id="femeninoLbl" class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-primary" runat="server">
                                        <input id="femenino" type="radio" name="gender" value="female" runat="server">
                                        Femenino
                                    </label>
                                </div>
                                <br>
                                <br>
                                <asp:CustomValidator ID="validaSexo" runat="server"
                                    ErrorMessage="Por Favor seleccione"
                                    ClientValidationFunction="CustomValidator1_ClientValidate"
                                    OnServerValidate="CustomValidator1_ServerValidate"
                                    Display="Dynamic">
                                </asp:CustomValidator>
                            </div>
                        </div>
                        <!--
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="days">Actividades<span class="required"></span></label>
                                <div class="btn-group" data-toggle="buttons">
                                    <div class="btn-group" data-toggle="buttons">
                                        <div>
                                            <asp:ListBox ID="actividades" CssClass="select--multiple" runat="server" SelectionMode="Multiple" multiple="multiple">
                                            </asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                        </div>
                        -->
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-6 col-md-offset-3">
                                <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                                <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Generar" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

