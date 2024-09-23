<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pagina_Maestra.Master" CodeBehind="Principal.aspx.cs" Inherits="Alcaldia.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-image: url('Complementos CSS/Fondo.jpg');
            background-repeat: no-repeat;
            background-size: 40% 50%;
            background-color: white;
            background-position: center;
        }
    </style>
    <title>AMDC</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="Scripts/jquery-3.7.1.min.js"></script>
      <%--<script src="Scripts/Principal.js?v=@DateTime.Now.Ticks"></script>--%>
</asp:Content>
