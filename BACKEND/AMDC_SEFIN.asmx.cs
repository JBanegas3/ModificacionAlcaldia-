using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using BACKEND.AMDC_API;
using System.Web.UI.WebControls;

namespace BACKEND
{
    /// <summary>
    /// Descripción breve de AMDC_SEFIN
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class AMDC_SEFIN : System.Web.Services.WebService
    {
        [WebMethod]
        public string Enviar_SEFIN(string token)
        {
            try
            {
                var client = new AMDCSoapClient();
                if (token == client.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString()))
                {
                    var SEFIN = new AMDCSoapClient();
                    return JsonConvert.SerializeObject(new { Mensaje = "Enviado Correctamente a SEFIN" });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
                }
            }
            catch (Exception ex)
            {
                var respuesta = new { CodigoError = -1, Mensaje = ex.Message };
                return JsonConvert.SerializeObject(respuesta);
            }
        }
    }
}
