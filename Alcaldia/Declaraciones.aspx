<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pagina_Maestra.Master" CodeBehind="Declaraciones.aspx.cs"
    Inherits="Alcaldia.Declaraciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consulta de Declaraciones</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <br />
    <br />
    <form runat="server" action="#" method="post">
        
        <br />
        <div class="panel panel-inverse">
            <div class="panel-body">
                <table id="data-table-default" class="table table-striped table-bordered table-td-valign-middle">
                    <thead>
                        <tr>
                            <th width="1%">ID</th>
                            <th width="20%" class="text-nowrap">Nombre Sucursal</th>
                            <th width="20%" class="text-nowrap">Identificacion</th>
                            <th width="20%" class="text-nowrap">Direccion</th>
                            <th width="1%" class="text-nowrap">Monto Declarado</th>
                            <th width="1%" class="text-nowrap">Impuesto</th>
                            <th width="1%" class="text-nowrap">Multa</th>
                            <th width="1%" class="text-nowrap">Total</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-3.7.1.min.js"></script>
    <script src="Scripts/Declaraciones.js?v=@DateTime.Now.Ticks"></script>
</asp:Content>
