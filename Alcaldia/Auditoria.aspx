<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pagina_Maestra.Master" CodeBehind="Auditoria.aspx.cs" Inherits="Alcaldia.Auditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap4.min.js"></script>
    <script src="Scripts/Auditoria.js"></script>
    <title>Tabla de Auditoría</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 18px;
            text-align: left;
        }

        th, td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #f2f2f2;
        }

        tr:hover {
            background-color: #f5f5f5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="text-center">Tabla de Auditoría</h2>
        <table id="tb_Auditoria" class="table table-striped table-bordered">
            <thead class="thead-dark">
                <tr>
                    <th>Registro</th>
                    <th>Tabla Afectada</th>
                    <th>Acción</th>
                    <th>Fecha de Modificación</th>
                    <th>Usuario que Afectado</th>
                </tr>
            </thead>
            <tbody>
                <!-- Aquí se llenarán las filas dinámicamente -->
            </tbody>
        </table>
    </div>
</asp:Content>
