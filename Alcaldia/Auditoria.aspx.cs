using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace Alcaldia
{
    public partial class Auditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                    LlenarTablaAuditoria();
                
            }
        }

        [WebMethod(EnableSession = true)]
        public static string LlenarTablaAuditoria()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CnxServerVanguardia"].ConnectionString;
                string query = "SELECT Id_auditoria, Tabla, Accion, Fecha, Usuario FROM tbl_auditoria";
                string tablaHtml = string.Empty;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tablaHtml += "<tr>" +
                                             $"<td>{reader["Id_auditoria"]}</td>" +
                                             $"<td>{reader["Tabla"]}</td>" +
                                             $"<td>{reader["Accion"]}</td>" +
                                             $"<td>{reader["Fecha"]}</td>" +
                                             $"<td>{reader["Usuario"]}</td>" +
                                             "</tr>";
                            }
                        }
                    }
                }
                return tablaHtml;
            }
            catch (Exception ex)
            {

                return $"<tr><td colspan='6'>Error: {ex.Message}</td></tr>";
            };
            }
        }
    }


