namespace sysNotasClinicas.Negocio
{
    // Error esperado de una regla de negocio (dato inválido, nota FIRMADA, etc.).
    // La capa de presentación lo muestra al usuario como advertencia, no como fallo.
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje) { }
    }
}
