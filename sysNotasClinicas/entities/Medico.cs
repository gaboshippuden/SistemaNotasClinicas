namespace sysNotasClinicas.Entidades
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;

        // Útil para mostrar el médico en un ComboBox
        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}