<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pagina_Maestra.Master" CodeBehind="DeclaracionesTotales.aspx.cs"
    Inherits="Alcaldia.DeclaracionesTotales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consulta de Declaraciones Totales</title>
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
                            <th width="20%" class="text-nowrap">Total Monto Declarado</th>
                            <th width="20%" class="text-nowrap">Total Impuesto</th>
                            <th width="20%" class="text-nowrap">Total Multa</th>
                            <th width="20%" class="text-nowrap">Total Recuadado</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <button class="btn btn-default "id="btnSEFIN">Enviar a SEFIN</button>
            
        </div>
        <br />
    </form>
    <script src="Scripts/jquery-3.7.1.min.js"></script>
    <script src="Scripts/DeclaracionesTotales.js?v=@DateTime.Now.Ticks"></script>
</asp:Content>
