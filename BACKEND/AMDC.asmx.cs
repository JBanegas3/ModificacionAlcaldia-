using BACKEND.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace BACKEND
{
    /// <summary>
    /// Descripción breve de AMDC
    /// </summary>
    [WebService]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class AMDC : System.Web.Services.WebService
    {

        [WebMethod]
        public string consultaTipoUsuarios(string token)
        {
            if (token == ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString()))
            {
                var TipoUsuariosLista = new List<TipoUsuario>();
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                    string query = "SELECT [id_tipo_usuario],[txt_tipo_usuario] FROM [dbo].[tbl_tipo_usuario]";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var TipoUsuariosFila = new TipoUsuario
                                    {
                                        ID = Convert.ToInt32(reader["id_tipo_usuario"]),
                                        Tipo = reader["txt_tipo_usuario"].ToString(),
                                    };
                                    TipoUsuariosLista.Add(TipoUsuariosFila);
                                }
                            }
                        }

                    }
                    return JsonConvert.SerializeObject(new { Datos = TipoUsuariosLista });
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
        public string consultaUsuarios(string token)
        {
            if (token == ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString()))
            {
                var UsuarioLista = new List<Usuario>();
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                    string query = "select id_usuario, usua_login, contrasena,usua_nombre,txt_tipo_usuario,tbl_Usuarios.id_tipo_usuario,convert(int,usua_estado)as usua_estado from dbo.tbl_Usuarios inner join tbl_tipo_usuario on tbl_Usuarios.id_tipo_usuario=tbl_tipo_usuario.id_tipo_usuario";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    var UsuarioFila = new Usuario
                                    {
                                        ID = Convert.ToInt32(reader["id_usuario"]),
                                        Nombre = reader["usua_nombre"].ToString(),
                                        Contrasenia = reader["contrasena"].ToString(),
                                        Estado = Convert.ToInt32(reader["usua_estado"].ToString()),
                                        Tipo = Convert.ToInt32(reader["id_tipo_usuario"].ToString()),
                                        User = reader["usua_login"].ToString(),
                                        Tipo_S = reader["txt_tipo_usuario"].ToString()
                                    };
                                    UsuarioLista.Add(UsuarioFila);
                                }
                            }
                        }

                    }
                    return JsonConvert.SerializeObject(new { Datos = UsuarioLista });
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
        public string ConvertToSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return JsonConvert.SerializeObject(builder.ToString());
            }
        }

        [WebMethod]
        public string AgregarUsuario(string login, string contrasenia, string nombre, int estado, int tipo, int usuacrea, string token)
        {
            if (token == ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString()))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("sp_InsertarUsuario", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@usua_login", login);
                            command.Parameters.AddWithValue("@contrasena", contrasenia);
                            command.Parameters.AddWithValue("@usua_nombre", nombre);
                            command.Parameters.AddWithValue("@usua_estado", Convert.ToByte(estado));
                            command.Parameters.AddWithValue("@usua_creacion", usuacrea);
                            command.Parameters.AddWithValue("@id_tipo_usuario", tipo);

                            int rowsAffected = command.ExecuteNonQuery();
                            Debug.WriteLine("Filas Afectadas:" + rowsAffected);
                            if (rowsAffected > 0)
                            {
                                var respuesta = new { CodigoError = 1, Mensaje = "Usuario Agregado Correctamente" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                            else
                            {
                                var respuesta = new { CodigoError = -1, Mensaje = "Error al ingresar el usuario" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new { CodigoError = -1, Mensaje = ex.Message };
                    return JsonConvert.SerializeObject(respuesta);
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        }

        [WebMethod]
        public string ActualizarUsuario(int id, string login, string contrasenia, string nombre, int estado, int tipo, int usuacrea, string token)
        {
            if (token == ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString()))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("sp_ActualizarUsuario", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@id_usuario", id);
                            command.Parameters.AddWithValue("@usua_login", login);
                            command.Parameters.AddWithValue("@contrasena", contrasenia);
                            command.Parameters.AddWithValue("@usua_nombre", nombre);
                            command.Parameters.AddWithValue("@usua_estado", Convert.ToByte(estado));
                            command.Parameters.AddWithValue("@id_tipo_usuario", tipo);
                            command.Parameters.AddWithValue("@usua_ult_mod", usuacrea);
                            command.Parameters.AddWithValue("@fec_ult_mod", DateTime.Now);

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected);
                            if (rowsAffected > 0)
                            {
                                var respuesta = new { CodigoError = 1, Mensaje = "Usuario Modificado Correctamente" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                            else
                            {
                                var respuesta = new { CodigoError = -1, Mensaje = "Error al Modificar el usuario" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new { CodigoError = -1, Mensaje = ex.Message };
                    return JsonConvert.SerializeObject(respuesta);
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        }

        [WebMethod]
        public string EliminarUsuario(int id, string token)
        {
            if (token == ConvertToSHA256(ConfigurationManager.AppSettings["Token"].ToString()))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("sp_EliminarUsuario", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@id_usuario", id);

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected);
                            if (rowsAffected > 0)
                            {
                                var respuesta = new { CodigoError = 1, Mensaje = "Usuario Eliminado Correctamente" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                            else
                            {
                                var respuesta = new { CodigoError = -1, Mensaje = "Error al Eliminado el usuario" };
                                return JsonConvert.SerializeObject(respuesta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new { CodigoError = -1, Mensaje = ex.Message };
                    return JsonConvert.SerializeObject(respuesta);
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { Error = "Token Incorrecto" });
            }
        }

        [WebMethod(EnableSession = true)]
        public string validaLogin(string usuario, string password)
        {
            string hash = ConvertToSHA256(password);
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;

                string query = "SELECT id_usuario,usua_login,usua_nombre,tbl_Usuarios.id_tipo_usuario,tbl_tipo_usuario.txt_tipo_usuario FROM dbo.tbl_Usuarios inner join tbl_tipo_usuario on tbl_Usuarios.id_tipo_usuario = tbl_tipo_usuario.id_tipo_usuario WHERE usua_login = @Usuario and contrasena = @Clave";

                var Lusuarios = new List<LoginUsuarios>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Clave", hash);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var Vusuario = new LoginUsuarios
                                {
                                    U_codigo = Convert.ToInt32(reader["id_usuario"]),   
                                    U_nombre= reader["usua_nombre"].ToString(),
                                    U_TipoU= Convert.ToInt32(reader["id_tipo_usuario"]),
                                    U_TipoUString = reader["txt_tipo_usuario"].ToString()
                                };
                                Lusuarios.Add(Vusuario);
                            }
                        }
                    }
                }
                if (Lusuarios.Count > 0)
                {
                    return JsonConvert.SerializeObject(new { CodigoError = 1, Mensaje = "Usuario encontrado", Codigo = Lusuarios[0].U_codigo, Nombre= Lusuarios[0].U_nombre, Tipo= Lusuarios[0].U_TipoU, Tipo_String = Lusuarios[0].U_TipoUString });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { CodigoError = -1, Mensaje = "Usuario o clave incorrecta"});
                }

            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { CodigoError = -1, Mensaje = "Se presentó un error en el método: " + ex.Message });
            }
        }
    }
}
