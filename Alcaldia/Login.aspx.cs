using Alcaldia.AMDC_API;
using Alcaldia.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alcaldia
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static object validaLogin(string usuario, string password)
        {
            var client = new AMDCSoapClient();
            var json = client.validaLogin(usuario, password);
            var jsonobject =JsonConvert.DeserializeObject<dynamic>(json);
            if (jsonobject["CodigoError"] == -1)
            {
                return json;
            }
                HttpContext.Current.Session["Usuario"] = jsonobject["Codigo"];
                HttpContext.Current.Session["Nombre"] = jsonobject["Nombre"];
                HttpContext.Current.Session["Tipo"] = jsonobject["Tipo"];
                HttpContext.Current.Session["Tipo_String"] = jsonobject["Tipo_String"];

            return json;
        }

    }
}


