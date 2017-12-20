<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/LoginRegister.master" AutoEventWireup="true" CodeFile="registrationform.aspx.cs" Inherits="site_web_login_registrationform" %>

<asp:Content ID="Content2" ContentPlaceHolderID="registration_form" Runat="Server">
        <section class="login_content">
    <form id="register_form" runat="server">
              <h1>Registrarse</h1>
              <div class="form-group">
                <label  style="align-content: left; display: flex;">Email *:</label>
                <input id="RegEmail" name="RegEmail" type="email" class="form-control" placeholder="Email" required="" runat="server" />
<%--                  <asp:CustomValidator id="CustomValidator1" runat="server" 
                      OnServerValidate="TextValidate" 
                      ControlToValidate="RegEmail" 
                      ErrorMessage="Text must be 8 or more characters.">
                   </asp:CustomValidator>--%>
              </div>
              <div class="form-group">
                <label style="align-content: left; display: flex;"> Nombre *:</label>
                <input id="RegName" name="RegName" type="text" class="form-control" placeholder="Nombre" required="" runat="server" />
              </div>
              <div class="form-group">
                  <label style="align-content: left; display: flex;"> Apellido *:</label>
                <input id="RegApell" name="RegApell" type="text" class="form-control" placeholder="Apellido" required="" runat="server"/>
              </div>
              <div class="form-group">
                 <label style="align-content: left; display: flex;"> Contraseña *:</label>
                <input id="RegPass" name="RegPass" type="password" class="form-control" placeholder="Contraseña" required="" runat="server" />
              </div>
              <div class="form-group">
                  <label style="align-content: left; display: flex;"> Confirmar Contraseña *:</label>
                <input id="RegRepetPass" name="RegRepetPass" type="password" class="form-control" placeholder="Confirmar Contraseña" required="" runat="server" />
              </div>
              <div class="form-group">
                <label style="align-content: left; display: flex;"> Fecha Nacimiento *:</label>
                <input id="RegfechaNac" name="RegfechaNac" type="date" class="form-control"  required="" runat="server" />
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
                 <label style="align-content: left; display: flex;"> Tipo de Usuario *:</label>
                 <select id="RegTypeUser" name="RegTypeUser" class="form-control" runat="server" required>
                            <option value="">Elije tipo de usuario</option>
                            <option value="S">Socio</option>
                            <option value="P">Profesor</option>
                            <option value="E">Empleado</option>
                 </select>
              </div>
              <div class="form-group">
                  <asp:Button class="btn btn-default submit" ID="buttonregister" runat="server" Text="Crear Usuario" onclick="btnRegister_Click" />
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Ya esta registrado ?
                  <a href="loginform.aspx" class="to_register"> Inicio sesion </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><img style="width: 50%; display: block;margin: auto;" src="../../Imagenes/logo-company-gymsystem2.png" alt="image" /></h1>
                  <p><img style="position: relative;width: 50px;" src="http://www.ort.edu.ar/img/LogoOrtArgWeb2017.jpg"/>   ©2016 All Rights Reserved. GymSystem Privacy and Terms</p>
                </div>
              </div>
            </form>
            </section>
</asp:Content>

