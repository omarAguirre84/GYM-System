<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/LoginRegister.master" AutoEventWireup="true" CodeFile="registrationform.aspx.cs" Inherits="registrationForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="registration_form" Runat="Server">
              <h1>Registrarse</h1>
              <div>
                <label style="align-content: left; display: flex;"> Nombre *:</label>
                <input ID="nombre" type="text" class="form-control" placeholder="Nombre" required runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;"> Apellido *:</label>
                <input ID="apellido" type="text" class="form-control" placeholder="Apellido" required runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;"> DNI *:</label>
                <input ID="dni" type="number" class="form-control" placeholder="DNI" required runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;">Email *:</label>
                <input ID="email" type="email" class="form-control" placeholder="Email" required runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;">Telefono *:</label>
                <input ID="telefono" type="number" class="form-control" placeholder="Telefono" required runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;"> Contraseña *:</label>
                <input ID="passw1" type="password" class="form-control" placeholder="Contraseña" required="" runat="server"/>
              </div>
              <div>
                <label style="align-content: left; display: flex;"> Confirmar Contraseña *:</label>
                <input ID="passw2" type="password" class="form-control" placeholder="Confirmar Contraseña" required="" runat="server"/>
              </div>
              <div class="form-group">
                <label style="align-content: left; display: flex;"> Fecha Nacimiento *:</label>
                <input ID="fechaNacimiento" type="date" name="fechanacimiento" class="form-control"  required="" runat="server"/>
              </div>
              <div runat="server">
                 <label style="align-content: left; display: flex;" runat="server">Género *:</label>
                    <asp:RadioButtonList id="sexos" class="flat" runat="server">
                        <asp:ListItem Value="M" Text="Masculino" />
                        <asp:ListItem Value="F" Text="Femenino" />
                    </asp:RadioButtonList>
              </div>

              <div>
                <label style="align-content: left; display: flex;"> Tipo de Usuario *:</label>
                <asp:DropDownList id="tipoPersona" runat="server" AutoPostback="False">
                    <asp:ListItem Value="" Text="Elije tipo de usuario"/>
                    <asp:ListItem Value="Socio" Text="Socio"/>
                    <asp:ListItem Value="Empleado" Text="Empleado"/>
                    <asp:ListItem Value="Profesor" Text="Profesor"/>
                </asp:DropDownList>
              </div>
              <p></p>
              <div>
                  <asp:Button ID="Button1" runat="server" Text="Crear Usuario" OnClick="btnRegister_Click" />
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
</asp:Content>

