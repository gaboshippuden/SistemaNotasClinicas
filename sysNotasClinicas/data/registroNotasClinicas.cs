using System.Data;
using Microsoft.Data.SqlClient;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.data
{
    // Acceso a datos de NotaClinica: SOLO mediante Stored Procedures
    // con parámetros tipados (control ISO 27001 A.8.28).
    // Si un SP hace RAISERROR (ej: nota FIRMADA), aquí se lanza una SqlException.
    public class registroNotasClinicas
    {
        private readonly Conexion conexion = new Conexion();

        // RF-01 Crear
        public int Insertar(NotaClinica n)
        {
            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_NotaClinica_Insertar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            AgregarParametrosDatos(cmd, n);

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());   // Id de la nota creada
        }

        // RF-02 Listar
        public List<NotaClinica> Listar()
        {
            List<NotaClinica> lista = new List<NotaClinica>();

            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_NotaClinica_Listar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int idxNotas = dr.GetOrdinal("NotasPaciente");

                lista.Add(new NotaClinica
                {
                    NotaClinicaId = dr.GetInt32(dr.GetOrdinal("NotaClinicaId")),
                    PacienteId = dr.GetInt32(dr.GetOrdinal("PacienteId")),
                    Paciente = dr.GetString(dr.GetOrdinal("Paciente")),
                    MedicoId = dr.GetInt32(dr.GetOrdinal("MedicoId")),
                    Medico = dr.GetString(dr.GetOrdinal("Medico")),
                    FechaConsulta = dr.GetDateTime(dr.GetOrdinal("FechaConsulta")),
                    Diagnostico = dr.GetString(dr.GetOrdinal("Diagnostico")),
                    NotasPaciente = dr.IsDBNull(idxNotas) ? null : dr.GetString(idxNotas),
                    Estado = Enum.Parse<EstadoNota>(dr.GetString(dr.GetOrdinal("Estado")))
                });
            }
            return lista;
        }

        // RF-03 Editar
        public void Actualizar(NotaClinica n)
        {
            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_NotaClinica_Actualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NotaClinicaId", SqlDbType.Int).Value = n.NotaClinicaId;
            AgregarParametrosDatos(cmd, n);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // RF-04 Eliminar
        public void Eliminar(int notaClinicaId)
        {
            EjecutarPorId("sp_NotaClinica_Eliminar", notaClinicaId);
        }

        // RF-05 Firmar
        public void Firmar(int notaClinicaId)
        {
            EjecutarPorId("sp_NotaClinica_Firmar", notaClinicaId);
        }

        // ---------- Métodos de apoyo ----------

        // Parámetros comunes de Insertar y Actualizar
        private static void AgregarParametrosDatos(SqlCommand cmd, NotaClinica n)
        {
            cmd.Parameters.Add("@PacienteId", SqlDbType.Int).Value = n.PacienteId;
            cmd.Parameters.Add("@MedicoId", SqlDbType.Int).Value = n.MedicoId;
            cmd.Parameters.Add("@FechaConsulta", SqlDbType.DateTime2).Value = n.FechaConsulta;
            cmd.Parameters.Add("@Diagnostico", SqlDbType.VarChar, 500).Value = n.Diagnostico;
            cmd.Parameters.Add("@NotasPaciente", SqlDbType.VarChar, -1).Value =
                (object?)n.NotasPaciente ?? DBNull.Value;   // -1 = VARCHAR(MAX)
        }

        // Para los SPs que solo reciben el Id de la nota
        private void EjecutarPorId(string nombreSp, int notaClinicaId)
        {
            using SqlConnection con = conexion.GetConnection();
            using SqlCommand cmd = new SqlCommand(nombreSp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NotaClinicaId", SqlDbType.Int).Value = notaClinicaId;

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}