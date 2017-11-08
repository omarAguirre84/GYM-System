
<%@ Page Language="C#" MasterPageFile="~/Autenticado.master" AutoEventWireup="true" CodeFile="ABMSocio.aspx.cs" Inherits="ABMSocio" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Cuerpo" Runat="Server">

    <div class="container">
      <div class="row">
        <div class="col-sm">
            <div class="card" style="width: 100%;">
              <div class="card-body">
                <h4 class="card-title">Gestion de Socios</h4>
                <h6 class="card-subtitle mb-2 text-muted">Listado de Socios</h6>
                <table class="table">
                    <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">First Name</th>
                        <th scope="col">Last Name</th>
                        <th scope="col">Username</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Larry</td>
                        <td>the Bird</td>
                        <td>@twitter</td>
                    </tr>
                    </tbody>
                </table>
              </div>
            </div>
        </div>
      </div>
    </div>
</asp:Content>

