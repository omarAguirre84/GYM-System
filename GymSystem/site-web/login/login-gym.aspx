<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login-gym.aspx.cs" Inherits="login_login_gym" %>

<!doctype html>
<html lang="en" >
  <head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Signin Template for Bootstrap</title>

   <!-- Bootstrap -->
    <link href="../../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../../vendors/animate.css/animate.min.css" rel="stylesheet">
      <!-- bootstrap-daterangepicker -->
    <link href="../../vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <!-- bootstrap-datetimepicker -->
    <link href="../../vendors/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../../build/css/custom.css" rel="stylesheet">
  </head>

  <body class="login">   
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form id="form1" runat="server">
              <h1>Gym System Login</h1>
              <div>
                <input type="text" ID="username" class="form-control" placeholder="Username" required=""  runat="server" />
              </div>
              <div>
                <input type="password" ID="password"  class="form-control" placeholder="Password" required="" runat="server"/>
              </div>
              <div>
                  <asp:Button ID="btnEntrarLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="BotonCabecera" />
                <%--<a class="reset_pass" href="#">Lost your password?</a>--%>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Nuevo en el sitio?
                  <a href="#signup" class="to_register"> Crea tu usuario </a>
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
        </div>

        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
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
                <a class="btn btn-default submit" href="SuccesCreateUser.aspx">Crear Usuario</a>
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
            </form>
          </section>
        </div>
      </div>
    </div>
      <!-- jQuery -->
    <script src="../../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../../vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="../../vendors/moment/min/moment.min.js"></script>
    <script src="../../vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap-datetimepicker -->    
    <script src="../../vendors/bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
    <!-- Ion.RangeSlider -->
    <script src="../../vendors/ion.rangeSlider/js/ion.rangeSlider.min.js"></script>
    <!-- Bootstrap Colorpicker -->
    <script src="../../vendors/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
    <!-- jquery.inputmask -->
    <script src="../../vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
    <!-- jQuery Knob -->
    <script src="../../vendors/jquery-knob/dist/jquery.knob.min.js"></script>
    <!-- Cropper -->
    <script src="../../vendors/cropper/dist/cropper.min.js"></script>


      <script>
          $('#fechaNacimiento').datetimepicker({
              format: 'DD.MM.YYYY'
          });
      </script>
         
  </body>
</html>