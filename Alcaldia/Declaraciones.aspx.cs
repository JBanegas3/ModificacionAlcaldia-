using Alcaldia.AMDC_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


using Alcaldia.Clases;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceModel.Configuration;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Alcaldia.AMDC_EMPRESAS_API;


namespace Alcaldia
{
    public partial class Declaraciones : System.Web.UI.Page
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
        public static object ConsultaDeclaraciones()
        {
            //var client = new AMDCSoapClient(); // Paso a API independiente
            var client = new AMDC_EMPRESASSoapClient();
            var client2 = new AMDCSoapClient();
            string token = client2.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString());

            return client.consultaDeclaracion(token);
        }
        /*
        [WebMethod(EnableSession = true)]
        public static object consultaUsuarios()
        {
            var client = new AMDCSoapClient();
            return client.consultaUsuarios();
        }
        */
    }
}