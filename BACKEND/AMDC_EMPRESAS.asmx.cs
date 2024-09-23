using BACKEND.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using BACKEND.AMDC_API;

namespace BACKEND
{
    /// <summary>
    /// Descripción breve de AMDC_EMPRESAS
    /// </summary>
    [WebService]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class AMDC_EMPRESAS : System.Web.Services.WebService
    {
        [WebMethod]
        public string consultaDeclaracion(string token)
        {
            var client = new AMDCSoapClient();
            if (token == client.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString()))
            {
                var Declaracionlista = new List<Declaracion>();
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                    string query = "Select s.id_sucursal,s.txt_nombre_sucursal, s.identificacion, d.txt_calle,"
                        + "dr.impuesto_anio, f.Balance , f.Multa, f.Balance +f.Multa  total from tbl_Sucursal s " +
                        "join tbl_declaracion_renta dr on dr.id_sucursal = s.id_sucursal " +
                        "join tbl_facturable f on f.id_sucursal = s.id_sucursal " +
                        "Join tbl_Direccion d on d.id_direccion = s.id_direccion";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    var declaracionFila = new Declaracion()
                                    {
                                        id_sucursal = Convert.ToInt32(reader["id_sucursal"]),
                                        txt_nombre_sucursal = reader["txt_nombre_sucursal"].ToString(),
                                        identificacion = reader["identificacion"].ToString(),
                                        txt_calle = reader["txt_calle"].ToString(),
                                        impuesto_anio = Convert.ToDouble(reader["impuesto_anio"].ToString()),
                                        balance = Convert.ToDouble(reader["Balance"].ToString()),
                                        multa = Convert.ToDouble(reader["Multa"].ToString()),
                                        total = Convert.ToDouble(reader["total"].ToString()),
                                    };
                                    Declaracionlista.Add(declaracionFila);
                                }
                            }
                        }

                    }
                    return JsonConvert.SerializeObject(new { Datos = Declaracionlista });
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { Error = ex.Message });
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string consultaDeclaracionesTotales(string token)
        {
            var client = new AMDCSoapClient();
            if (token == client.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString()))
            {
                var DeclaracionesTotaleslista = new List<DeclaracionesTotales>();
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                    string query = "Select sum(dr.impuesto_anio) v1,sum(f.Balance) v2, sum(f.Multa) v3, sum(f.Balance) + sum(f.Multa) v4 from tbl_Sucursal s "
                        + "join tbl_declaracion_renta dr on dr.id_sucursal = s.id_sucursal "
                        + "join tbl_facturable f on f.id_sucursal = s.id_sucursal "
                        + "Join tbl_Direccion d on d.id_direccion = s.id_direccion ";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    var declaracionesTotalesFila = new DeclaracionesTotales()
                                    {

                                        impuesto_anio = Convert.ToDouble(reader["v1"].ToString()),
                                        balance = Convert.ToDouble(reader["v2"].ToString()),
                                        multa = Convert.ToDouble(reader["v3"].ToString()),
                                        total = Convert.ToDouble(reader["v4"].ToString()),
                                    };
                                    DeclaracionesTotaleslista.Add(declaracionesTotalesFila);
                                }
                            }
                        }

                    }
                    return JsonConvert.SerializeObject(new { Datos = DeclaracionesTotaleslista });
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { Error = ex.Message });
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CalculaDeclaracionRenta(string jsonParams, string token)
        {
            var client = new AMDCSoapClient();
            if (token == client.ConvertToSHA256(ConfigurationManager.AppSettings["Token_API"].ToString()))
            {
                // Deserialize the JSON parameters
                dynamic parametros = JsonConvert.DeserializeObject<dynamic>(jsonParams);

                // Extract the parameters
                string identidad = parametros.Identidad;
                string nombre = parametros.Nombre;
                decimal monto = parametros.Monto;

                // Cadena de conexión a la base de datos
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                try
                {
                    // Crear y abrir la conexión a la base de datos
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Crear y ejecutar el comando SQL
                        using (SqlCommand command = new SqlCommand("sp_Calcula_Declaracion_renta", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            // Asignar los parámetros
                            command.Parameters.AddWithValue("@Identificacion", identidad);
                            command.Parameters.AddWithValue("@Nombre", nombre);
                            command.Parameters.AddWithValue("@Monto", monto);

                            // Ejecutar el comando
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected);
                            if (rowsAffected == -1)
                            {
                                // Ejecutar el select para obtener el monto total a pagar
                                using (SqlCommand commandSelect = new SqlCommand("select sum(Balance)+sum(Multa) from tbl_facturable f Inner Join tbl_Sucursal s on s.id_sucursal = f.id_sucursal where s.identificacion = @Identificacion", connection))
                                {
                                    commandSelect.Parameters.AddWithValue("@Identificacion", identidad);
                                    decimal montoTotal = (decimal)commandSelect.ExecuteScalar();

                                    var respuesta = new { CodigoError = 1, Mensaje = "Declaración realizada correctamente Monto a Pagar", MontoTotal = montoTotal };
                                    return JsonConvert.SerializeObject(respuesta);
                                }
                            }
                            else
                            {
                                var respuesta = new { CodigoError = -1, Mensaje = "No se logró realizar la declaracion Favor validar que se ingresaron los parametros de forma correcta " };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, devolver un mensaje de error en formato JSON
                    var respuesta = new { CodigoError = -1, Mensaje = ex.Message };
                    return JsonConvert.SerializeObject(respuesta);
                }

            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        } 
    }
}
