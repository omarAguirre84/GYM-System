<%@ Page Title="" Language="C#" MasterPageFile="~/site-web/template-master/LoginRegister.master" AutoEventWireup="true" CodeFile="loginform.aspx.cs" Inherits="site_web_login_loginform" %>

<asp:Content ID="Content2" ContentPlaceHolderID="registration_form" Runat="Server">
        <section class="login_content">
        <form id="form_login" runat="server">
            <h1>Gym System Login</h1>
                <div>
                <input type="email" ID="username" class="form-control" placeholder="Username" required=""  runat="server" />
                </div>
                <div>
                <input type="password" ID="password"  class="form-control" placeholder="Password" required="" runat="server"/>
                </div>
                <div>
                    <asp:Button ID="Button2" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn btn-default submit" />
                <%--<a class="reset_pass" href="#">Lost your password?</a>--%>
                </div>

                <div class="clearfix"></div>
                <div class="separator">
                <p class="change_link">Nuevo en el sitio?

                    <asp:HyperLink ID="HyperLink1" href="registrationform.aspx" runat="server" NavigateUrl="~/site-web/login/registrationform.aspx">Crea tu usuario</asp:HyperLink>
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

