using Microsoft.Data.SqlClient;

namespace   sysNotasClinicas.data
{
    public class Conexion
    {
        private string connectionString = 
        "Server=Gabo-Laptop\\SQLEXPRESS;" +
        "Database=NotasClinicasDB;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

    }
}