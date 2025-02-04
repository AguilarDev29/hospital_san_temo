using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    internal class Conexion
    {
        private static string server = "MATIAS\\SQLEXPRESS";
        private static string URL = $"Server={server};Database=hospital_san_telmo;Trusted_Connection=True;TrustServerCertificate=True;";


        public static SqlConnection Conectar()
        {
            SqlConnection conn = new SqlConnection(URL);
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }
    }
}
