<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pagina_Maestra.Master" CodeBehind="Usuarios.aspx.cs"
    Inherits="Alcaldia.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mantenimiento de Usuarios</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <form runat="server" action="#" method="post">
        <div class="panel-body">
            <h1>Administrador de usuarios</h1>
            <input id="txtID" type="hidden" />
            <table>
                <tr>
                    <td><strong id="lblUsuario" />Usuario:</td>
                    <td>
                        <input id="txtUduario" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td><strong id="lblClave" />Password:</td>
                    <td>
                        <input id="txtClave" type="password" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td><strong id="lblNombre" />Nombre:</td>
                    <td>
                        <input id="txtNombre" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong id="lblEstado" />Estado:
                    </td>
                    <td>
                        <select id="txtEstado" class="form-control">
                            <option value="1" selected="selected">Activo</option>
                            <option value="0">Inactivo</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong id="lblTipo" />Tipo de Usuario:
                    </td>
                    <td>
                        <select id="txtTipo" class="form-control">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <button id="btnAgregar" class="btn btn-default ">Agregar</button>
            <button id="btnModificar" class="btn btn-default ">Modificar</button>
            <button id="btnEliminar" class="btn btn-default ">Eliminar</button>
            <button id="btnLimpiar" class="btn btn-default ">Limpiar</button>
        </div>
        <br />
        <div class="panel panel-inverse">
            <div class="panel-body">
                <table id="data-table-default" class="table table-striped table-bordered table-td-valign-middle">
                    <thead>
                        <tr>
                            <th width="1%">ID</th>
                            <th width="20%" class="text-nowrap">Usuario</th>
                            <th width="20%" class="text-nowrap">Nombre</th>
                            <th width="1%" class="text-nowrap">Estado</th>
                            <th width="1%" class="text-nowrap">Tipo</th>
                            <th width="5%"></th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
        </div>
    <script src="Scripts/jquery-3.7.1.min.js"></script>
    <script src="Scripts/Usuarios.js?v=@DateTime.Now.Ticks"></script>
</asp:Content>
