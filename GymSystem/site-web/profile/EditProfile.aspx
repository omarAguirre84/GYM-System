<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" MasterPageFile="~/site-web/template-master/HomePrincipal.master" Inherits="site_web_profile_EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
        <div class="x_title">
        <h2>Editar Perfil <small> </small></h2>
        <div class="clearfix"></div>
        </div>
        <div class="x_content">
        <br />
        <form id="editprofile" runat="server" novalidate data-parsley-validate class="form-horizontal form-label-left">

            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Nombre <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <input type="text" runat="server" id="nombre" required="required" class="form-control col-md-7 col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Apellido <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <input type="text" runat="server" id="apellido" name="last-name" required="required" class="form-control col-md-7 col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">DNI <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <input type="number" runat="server" id="dni" name="dni" required="required" class="form-control col-md-7 col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Fecha de Nacimiento <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox TextMode="date" runat="server" id="fechanacimiento" name="fechanacimiento" required="required" class="form-control col-md-7 col-xs-12"/>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Contraseña <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="contrasenia"  Font-Names="contrasenia" runat="server" TextMode="Password" CssClass="form-control col-md-7 col-xs-12" />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Confirmar Contraseña <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="confirmcontrasenia" Font-Names="confirmcontrasenia" runat="server" TextMode="Password" CssClass="form-control col-md-7 col-xs-12" />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Género <span class="required">*</span>
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:RadioButton ID="genderM" CssClass="flat" runat="server" GroupName="genero" Text="Masculino"  OnCheckedChanged="rbtn_CheckedChanged" />
                  <asp:RadioButton ID="genderF" CssClass="flat" runat="server" GroupName="genero" Text="Femenino"  OnCheckedChanged="rbtn_CheckedChanged" />
<%--                <input type="radio"  runat="server" class="flat" name="genderM" id="genderM" value="M" /> 
                <input type="radio"  runat="server" class="flat" name="genderF" id="genderF" value="F" />--%>
                </div>
            </div>
            <div class="ln_solid"></div>
            <div class="form-group">
                <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                    <asp:Button id="cancel" runat="server"  OnClick="btn_returnProfile" CssClass="btn btn-primary" type="button" Text="Cancelar"/>
                    <asp:Button id="save" runat="server" OnClick="btn_saveProfile"  CssClass="btn btn-success" Text="Guardar"/>
                </div>
            </div>

        </form>
        </div>
    </div>
        </div>
    </div>
</asp:Content>
