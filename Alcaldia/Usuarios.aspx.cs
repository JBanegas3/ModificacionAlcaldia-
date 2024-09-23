using Alcaldia.AMDC_API;
using Alcaldia.Clases;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Services;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Alcaldia
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["Usuario"] == null)
                {
                    Response.Redirect(String.Format("Login.aspx"));
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static object consultaTipoUsuarios()
        {
            var client = new AMDCSoapClient();
            string token = client.ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString());
            var resp = client.consultaTipoUsuarios(token);

            return resp;
        }

        [WebMethod(EnableSession = true)]
        public static object consultaUsuarios()
        {
            var client = new AMDCSoapClient();
            string token = client.ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString());
            return client.consultaUsuarios(token);
        }

        [WebMethod(EnableSession = true)]
        public static object agregarUsuarios(string login, string contrasenia, string nombre, int estado, int tipo, int usuacrea)
        {
            var client = new AMDCSoapClient();
            string hash = client.ConvertToSHA256(contrasenia);
            string token = client.ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString());
            return client.AgregarUsuario(login,hash,nombre,estado, tipo, usuacrea,token);
        }

        [WebMethod(EnableSession = true)]
        public static object modificarUsuarios(int id, string login, string contrasenia, string nombre, int estado, int tipo, int usuacrea)
        {
            var client = new AMDCSoapClient();
            string hash = client.ConvertToSHA256(contrasenia);
            string token = client.ConvertToSHA256(ConfigurationManager.AppSettings["Token"]);
            return client.ActualizarUsuario(id,login,hash,nombre,estado, tipo, usuacrea, token);
        }

        [WebMethod(EnableSession = true)]
        public static object eliminarUsuarios(int id)
        {
            var client = new AMDCSoapClient();
            string token = client.ConvertToSHA256(ConfigurationManager.AppSettings["Token"]);
            return client.EliminarUsuario(id,  token);
        }

    }
}
