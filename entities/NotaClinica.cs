namespace sysNotasClinicas.Entidades
{
    public class NotaClinica
    {
        public int NotaClinicaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Diagnostico { get; set; } = string.Empty;
        public string? NotasPaciente { get; set; }   // puede ser NULL en la BD
        public EstadoNota Estado { get; set; } = EstadoNota.BORRADOR;

        // Solo para mostrar en la grilla (vienen del JOIN en sp_NotaClinica_Listar)
        public string Paciente { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
    }
}