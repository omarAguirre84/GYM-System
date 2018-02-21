<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/LoginRegister.master" AutoEventWireup="true" CodeFile="registrationform.aspx.cs" Inherits="site_web_login_registrationform" %>

<asp:Content ID="Content2" ContentPlaceHolderID="registration_form" runat="Server">
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-sm-12">
            <%--<section class="login_content">--%>
                <div class="x_panel">
                    <div class="x_content">
                        <%--<form id="register_form" runat="server">
                            <h1>Registrarse</h1>--%>
                        <form class="form-horizontal form-label-left" novalidate runat="server">
                            <span class="section">Registrate</span>
                    
                            <div class="form-group">

                                <label for="RegEmail">Email *</label>
                                <input id="RegEmail" name="RegEmail" type="email" class="form-control" placeholder="Email" required="required" maxlength="50" runat="server" />
                                <asp:RequiredFieldValidator ID="emailNoVacio"
                                    runat="server" ControlToValidate="RegEmail"
                                    ErrorMessage="Por favor ingrese email"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator runat="server" ID="emailValido"
                                    ControlToValidate="RegEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="Por favor verifique el email"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">

                                <label  for="RegName"> Nombre *<span class="required"></span> </label>
                                <input id="RegName" name="RegName" type="text" class="form-control" placeholder="Nombre" required="required" maxlength="50" runat="server" />
                                <asp:RequiredFieldValidator ID="nombreNoVacio"
                                    runat="server" ControlToValidate="RegName"
                                    ErrorMessage="Por favor ingrese Nombre"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="caracteres" runat="server"
                                    ErrorMessage="Solo puede ingresar caracteres alfabéticos"
                                    ControlToValidate="RegName"
                                    ValidationExpression="^[a-zA-Z]+$"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegApell" >Apellido * </label>
                                <input id="RegApell" name="RegApell" type="text" class="form-control" placeholder="Apellido" required="" runat="server" />
                                <asp:RequiredFieldValidator ID="apellidoNoVacio"
                                    runat="server" ControlToValidate="RegApell"
                                    ErrorMessage="Por favor ingrese Apellido"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="validaCaracteres" runat="server"
                                    ErrorMessage="Solo puede ingresar caracteres alfabéticos"
                                    ControlToValidate="RegApell"
                                    ValidationExpression="^[a-zA-Z]+$"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegTel" >Teléfono *</label>
                                <input id="RegTel" name="RegTel" type="text" class="form-control" placeholder="Telefono" required="required" runat="server" />
                                  <asp:RequiredFieldValidator ID="telefonoNoVacio"
                                    runat="server" ControlToValidate="RegTel"
                                    ErrorMessage="Por favor ingrese telefono"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ID="validaTelefono"
                                    ControlToValidate="RegTel"
                                    ValidationExpression="^[\d\d]{8,10}$"
                                    ErrorMessage="El telefono debe contener entre 8 y 10 dígitos"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegDni" >DNI *</label>
                                <input id="RegDni" name="RegDni" type="number" class="form-control" placeholder="DNI" required="required" runat="server" />
                                 <asp:RequiredFieldValidator ID="noVacio"
                                    runat="server" ControlToValidate="RegDni"
                                    ErrorMessage="Por favor ingrese DNI"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ID="valInput"
                                    ControlToValidate="RegDni"
                                    ValidationExpression="^[\d\d]{8,8}$"
                                    ErrorMessage="Por favor verifique el DNI"
                                    Display="Dynamic">
                               </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegPass">Contraseña *</label>
                                <input id="RegPass" name="RegPass" type="password" class="form-control" placeholder="Contraseña" required="required" maxlength="50" runat="server" />
                                <asp:RequiredFieldValidator ID="contraseñaNoVacia"
                                    runat="server" ControlToValidate="RegPass"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegRepetPass">Confirmar Contraseña *</label>
                                <input id="RegRepetPass" name="RegRepetPass" type="password" class="form-control" placeholder="Confirmar Contraseña" maxlength="50" required="" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ControlToValidate="RegRepetPass"
                                    ErrorMessage="Por favor ingrese Contraseña"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="RegfechaNac">Fecha Nacimiento *</label>
                                <input id="RegfechaNac" name="RegfechaNac" type="date" class="form-control" required="required" runat="server" />
                                <asp:RequiredFieldValidator ID="fechaNoVacia"
                                    runat="server" ControlToValidate="RegfechaNac"
                                    ErrorMessage="Por favor ingrese Fecha de Nacimiento"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server" ID="rangoFecha"
                                    ControlToValidate="RegfechaNac" Type="Date" MinimumValue="01-01-1900"
                                    MaximumValue="21-02-2018"
                                    ErrorMessage="Por favor ingrese una fecha válida">
                                </asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <label style="align-content: left; display: flex;">Género *:</label>
                                <select id="RegGender" name="RegGender" class="form-control" runat="server" required>
                                    <option value="-1">Elije tipo el género</option>
                                    <option value="F">Femenino</option>
                                    <option value="M">Masculino</option>
                                    <option value="O">Otro</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label style="align-content: left; display: flex;">Tipo de Usuario *:</label>
                                <select id="RegTypeUser" name="RegTypeUser" class="form-control" runat="server" required>
                                    <option value="">Elije tipo de usuario</option>
                                    <option value="S">Socio</option>
                                    <option value="P">Profesor</option>
                                    <option value="E">Empleado</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <asp:Button class="btn btn-default submit" ID="buttonregister" runat="server" Text="Crear Usuario" OnClick="btnRegister_Click" />
                            </div>

                            <div class="clearfix"></div>

                            <div class="separator">
                                <p class="change_link">
                                    Ya esta registrado ?
                  <a href="loginform.aspx" class="to_register">Inicio sesion </a>
                                </p>

                                <div class="clearfix"></div>
                                <br />

                                <div>
                                    <h1>
                                        <img style="width: 50%; display: block; margin: auto;" src="../../Imagenes/logo-company-gymsystem2.png" alt="image" /></h1>
                                    <p>
                                        <img style="position: relative; width: 50px;" src="http://www.ort.edu.ar/img/LogoOrtArgWeb2017.jpg" />
                                        ©2016 All Rights Reserved. GymSystem Privacy and Terms
                                    </p>
                                </div>
                            </div>
                            <%-- </form>--%>
                        </form>
           <%-- </section>--%>
        </div>
    </div>
    </div>
    </div>
</asp:Content>

