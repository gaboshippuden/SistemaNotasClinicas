using System.Data;
using Microsoft.Data.SqlClient;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.data
{
    public class registroPacientes
    {
        private readonly Conexion conexion = new Conexion();

        public int Insertar(Paciente p)
        {
            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_Paciente_Insertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = p.Nombres;
            cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 80).Value = p.Apellidos;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = p.Telefono;

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());   // Id del paciente creado
        }

        public List<Paciente> Listar()
        {
            List<Paciente> lista = new List<Paciente>();

            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_Paciente_Listar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Paciente
                {
                    PacienteId = dr.GetInt32(dr.GetOrdinal("PacienteId")),
                    Nombres = dr.GetString(dr.GetOrdinal("Nombres")),
                    Apellidos = dr.GetString(dr.GetOrdinal("Apellidos")),
                    Telefono = dr.GetString(dr.GetOrdinal("Telefono"))
                });
            }
            return lista;
        }
    }
}