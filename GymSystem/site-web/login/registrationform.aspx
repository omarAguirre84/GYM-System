<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/LoginRegister.master" AutoEventWireup="true" CodeFile="registrationform.aspx.cs" Inherits="site_web_login_registrationform" %>

<asp:Content ID="Content2" ContentPlaceHolderID="registration_form" Runat="Server">
    <%--<form id="Form1" runat="server">--%>
              <h1>Registrarse</h1>
              <div>
                <label style="align-content: left; display: flex;">Email *:</label>
                <input type="email" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                <label style="align-content: left; display: flex;"> Nombre *:</label>
                <input type="text" class="form-control" placeholder="Nombre" required="" />
              </div>
              <div>
                  <label style="align-content: left; display: flex;"> Apellido *:</label>
                <input type="text" class="form-control" placeholder="Apellido" required="" />
              </div>
              <div>
                 <label style="align-content: left; display: flex;"> Contraseña *:</label>
                <input type="password" class="form-control" placeholder="Contraseña" required="" />
              </div>
              <div>
                  <label style="align-content: left; display: flex;"> Confirmar Contraseña *:</label>
                <input type="password" class="form-control" placeholder="Confirmar Contraseña" required="" />
              </div>
              <div class="form-group">
                <label style="align-content: left; display: flex;"> Fecha Nacimiento *:</label>
                <input type="date" name="fechanacimiento" class="form-control"  required="" />
              </div>
              <div>
                 <label style="align-content: left; display: flex;">Género *:</label>
                <p>
                   Masculino:
                    <input type="radio" class="flat" name="gender" id="genderM" value="M" checked="" required /> Femenino:
                    <input type="radio" class="flat" name="gender" id="genderF" value="F" />
                </p>
              </div>
              <div>
                 <label style="align-content: left; display: flex;"> Tipo de Usuario *:</label>
                 <select id="heard" class="form-control" required>
                            <option value="">Elije tipo de usuario</option>
                            <option value="press">Socio</option>
                            <option value="net">Profesor</option>
                            <option value="mouth">Empleado</option>
                 </select>
              </div>
              <div>
                  <asp:Button ID="Button1" runat="server" Text="Crear Usuario" OnClick="btnRegister_Click" />
                <a class="btn btn-default submit" ID="A1" runat="server" onclick="btnRegister_Click">Crear Usuario</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Ya esta registrado ?
                  <a href="#signin" class="to_register"> Inicio sesion </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><img style="width: 50%; display: block;margin: auto;" src="../../Imagenes/logo-company-gymsystem2.png" alt="image" /></h1>
                  <p><img style="position: relative;width: 50px;" src="http://www.ort.edu.ar/img/LogoOrtArgWeb2017.jpg"/>   ©2016 All Rights Reserved. GymSystem Privacy and Terms</p>
                </div>
              </div>
            <%--</form>--%>
</asp:Content>

