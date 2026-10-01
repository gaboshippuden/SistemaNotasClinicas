namespace sysNotasClinicas.Entidades
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Útil para mostrar el paciente en un ComboBox
        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}