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
using Alcaldia.AMDC_SEFIN_API;


namespace Alcaldia
{
    public partial class DeclaracionesTotales : System.Web.UI.Page
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
        public static object ConsultaDeclaracionesTotales()
        {
            //var client = new AMDCSoapClient();
            var client = new AMDC_EMPRESASSoapClient();
            var client2 = new AMDCSoapClient();
            string token = client2.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString());
            return client.consultaDeclaracionesTotales(token);
        }
        [WebMethod(EnableSession = true)]
        public static object Enviar_SEFIN()
        {
            var client = new AMDC_SEFINSoapClient();
            var client2 = new AMDCSoapClient();
            string token = client2.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString());
            return client.Enviar_SEFIN(token);
        }
    }
}
