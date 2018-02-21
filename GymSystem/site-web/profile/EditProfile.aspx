<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" MasterPageFile="~/site-web/template-master/HomePrincipal.master" Inherits="site_web_profile_EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Editar Perfil <small></small></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <br />
                    <form id="editprofile" runat="server" novalidate data-parsley-validate class="form-horizontal form-label-left">

                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                Nombre <span class="required">*</span>
                            </label>

                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input type="text" placeholder="Willy" maxlength="50" runat="server" id="nombre" required="required" class="form-control col-md-7 col-xs-12">
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
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Apellido <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input type="text" maxlength="50" placeholder="Wonka" runat="server" id="apellido" name="last-name" required="required" class="form-control col-md-7 col-xs-12">
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
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                DNI <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <input type="number" placeholder="12345678" runat="server" id="dni" name="dni" required="required" class="form-control col-md-7 col-xs-12">
                                <asp:RequiredFieldValidator ID="noVacio"
                                    runat="server" ControlToValidate="dni"
                                    ErrorMessage="Por favor ingrese DNI"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator runat="server" ID="valInput"
                                    ControlToValidate="dni"
                                    ValidationExpression="^[\d\d]{8,8}$"
                                    ErrorMessage="Por Favor Verifique el DNI"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Fecha de Nacimiento <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox TextMode="date" runat="server" ID="fechanacimiento" name="fechanacimiento" required="required" class="form-control col-md-7 col-xs-12" />
                                <asp:RequiredFieldValidator ID="fechaNoVacia"
                                    runat="server" ControlToValidate="fechanacimiento"
                                    ErrorMessage="Por favor ingrese Fecha de Nacimiento"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RangeValidator runat="server" ID="rangoFecha"
                                    ControlToValidate="fechanacimiento" Type="Date" MinimumValue="01-01-1900"
                                    MaximumValue="21-02-2018"
                                    ErrorMessage="Por favor ingrese una fecha válida">
                                </asp:RangeValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Contraseña <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="contrasenia" placeholder="****" Font-Names="contrasenia" runat="server" TextMode="Password" CssClass="form-control col-md-7 col-xs-12" />
                                <asp:RequiredFieldValidator ID="contraseña1NoVacia"
                                    runat="server" ControlToValidate="contrasenia"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Confirmar Contraseña <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="confirmcontrasenia" MaxLength="50" Font-Names="confirmcontrasenia" runat="server" placeholder="****" TextMode="Password" CssClass="form-control col-md-7 col-xs-12" />

                                <asp:RequiredFieldValidator ID="contraseña2NoVacia"
                                    runat="server" ControlToValidate="confirmcontrasenia"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                        <asp:CompareValidator ID="comparaContraseñas" runat="server"
                                    ControlToValidate="confirmcontrasenia"
                                    CssClass="ValidationError"
                                    ControlToCompare="contrasenia"
                                    ErrorMessage="Las Contraseñas no coinciden" />

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Género <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:RadioButton ID="genderM" CssClass="flat" runat="server" GroupName="genero" Text="Masculino" OnCheckedChanged="rbtn_CheckedChanged" />
                                <asp:RadioButton ID="genderF" CssClass="flat" runat="server" GroupName="genero" Text="Femenino" OnCheckedChanged="rbtn_CheckedChanged" />
                                <%--                <input type="radio"  runat="server" class="flat" name="genderM" id="genderM" value="M" /> 
                <input type="radio"  runat="server" class="flat" name="genderF" id="genderF" value="F" />--%>
                            </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                <asp:Button ID="cancel" runat="server" OnClick="btn_returnProfile" CssClass="btn btn-primary" type="button" Text="Cancelar" CausesValidation="false"/>
                                <asp:Button ID="save" runat="server" OnClick="btn_saveProfile" CssClass="btn btn-success" Text="Guardar" />
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
