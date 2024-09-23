using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alcaldia
{
    public partial class Principal : System.Web.UI.Page
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
        public static object inicioTipoUsuarios()
        {
            try
            {
                var codigo = HttpContext.Current.Session["Usuario"];
                var nombre = HttpContext.Current.Session["Nombre"];
                var tipo = HttpContext.Current.Session["Tipo"];
                var tipo_string= HttpContext.Current.Session["Tipo_String"];

                return JsonConvert.SerializeObject(new { Codigo = codigo, Nombre = nombre, Tipo = tipo , Tipo_String=tipo_string});
            }
            catch (Exception ex )
            {
                return JsonConvert.SerializeObject(new { Error = ex.ToString() });
            }


        }
    }
}