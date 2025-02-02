using System.Data;
using System.Data.SqlClient;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    internal class Conexion
    {
        private const string URL = "Server=matias\\SQLEXPRESS;Database=hospital_san_telmo;User Id=root;Password=42664539;TrustServerCertificate=True;";

        public static SqlConnection Conectar()
        {
            SqlConnection conn = new SqlConnection(URL);
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }
    }
}
