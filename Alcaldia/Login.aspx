<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Alcaldia.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Sesion</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" lang="es" />
    <link href="Complementos CSS/app.min.css" rel="stylesheet" />
    <link href="Complementos CSS/datatables.net-bs4/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link href="Complementos CSS/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css" rel="stylesheet" />
    <link href="CSS/login_style.css" rel="stylesheet" />
</head>
<body class="pace-top">
    <div id="page-loader" class="fade show">
        <span class="spinner"></span>
    </div>
    <div id="page-container" class="fade">
        <div class="login-container">
            <div class="login-box">
                <div class="login-logo">
                    <img src="./Complementos CSS/Fondo.jpg" alt="Logo Empresa" />
                </div>
                <h2>Iniciar Sesión</h2>
                <form id="formulario" action="#" method="post" onsubmit="return false;" runat="server">
                    <div class="form-group">
                        <label for="username">Usuario</label>
                        <input type="text" id="usuario" name="username" placeholder="Ingrese su usuario" required />
                    </div>
                    <div class="form-group">
                        <label for="password">Contraseña</label>
                        <input type="password" id="clave" name="password" placeholder="Ingrese su contraseña" required />
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn-login">Ingresar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="Scripts/Login.js?v=@DateTime.Now.Ticks"></script>
    <script type="text/javascript" src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Complementos CSS/js/app.min.js"></script>
    <script src="Complementos CSS/js/theme/default.min.js"></script>
</body>
</html>
