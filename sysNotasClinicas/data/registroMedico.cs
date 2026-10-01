using System.Data;
using Microsoft.Data.SqlClient;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.data
{
    public class registroMedicos
    {
        private readonly Conexion conexion = new Conexion();

        public int Insertar(Medico m)
        {
            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_Medico_Insertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = m.Nombres;
            cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 80).Value = m.Apellidos;
            cmd.Parameters.Add("@Especialidad", SqlDbType.VarChar, 80).Value = m.Especialidad;

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());   // Id del médico creado
        }

        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();

            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_Medico_Listar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Medico
                {
                    MedicoId = dr.GetInt32(dr.GetOrdinal("MedicoId")),
                    Nombres = dr.GetString(dr.GetOrdinal("Nombres")),
                    Apellidos = dr.GetString(dr.GetOrdinal("Apellidos")),
                    Especialidad = dr.GetString(dr.GetOrdinal("Especialidad"))
                });
            }
            return lista;
        }
    }
}