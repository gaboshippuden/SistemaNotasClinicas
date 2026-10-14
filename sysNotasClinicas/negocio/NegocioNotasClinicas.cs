using sysNotasClinicas.data;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.Negocio
{
    // Reglas de negocio de NotaClinica. Valida los datos antes de llamar a la
    // capa de datos; la BD (SPs + trigger) vuelve a proteger las notas FIRMADAS.
    public class NegocioNotasClinicas
    {
        private readonly registroNotasClinicas registro = new registroNotasClinicas();

        // RF-02 Listar
        public List<NotaClinica> Listar()
        {
            return registro.Listar();
        }

        // RF-01 Crear: la nota siempre nace en BORRADOR
        public int Crear(NotaClinica n)
        {
            ValidarDatos(n);
            n.Estado = EstadoNota.BORRADOR;

            return Validaciones.TraducirErroresSql(() => registro.Insertar(n));
        }

        // RF-03 Editar: solo notas en BORRADOR
        public void Actualizar(NotaClinica n)
        {
            ValidarSeleccion(n);
            ValidarEditable(n, "editar");
            ValidarDatos(n);

            Validaciones.TraducirErroresSql(() => registro.Actualizar(n));
        }

        // RF-04 Eliminar: solo notas en BORRADOR
        public void Eliminar(NotaClinica n)
        {
            ValidarSeleccion(n);
            ValidarEditable(n, "eliminar");

            Validaciones.TraducirErroresSql(() => registro.Eliminar(n.NotaClinicaId));
        }

        // RF-05 Firmar: BORRADOR -> FIRMADA
        public void Firmar(NotaClinica n)
        {
            ValidarSeleccion(n);
            if (n.Estado == EstadoNota.FIRMADA)
                throw new ReglaNegocioException("La nota clínica ya está FIRMADA.");

            Validaciones.TraducirErroresSql(() => registro.Firmar(n.NotaClinicaId));
            n.Estado = EstadoNota.FIRMADA;
        }

        // ---------- Métodos de apoyo ----------

        private static void ValidarSeleccion(NotaClinica n)
        {
            if (n.NotaClinicaId <= 0)
                throw new ReglaNegocioException("Debe seleccionar una nota clínica.");
        }

        private static void ValidarEditable(NotaClinica n, string accion)
        {
            if (n.Estado == EstadoNota.FIRMADA)
                throw new ReglaNegocioException($"No se puede {accion} una nota clínica FIRMADA.");
        }

        // Datos comunes de Crear y Actualizar (normaliza los textos)
        private static void ValidarDatos(NotaClinica n)
        {
            if (n.PacienteId <= 0)
                throw new ReglaNegocioException("Debe seleccionar un paciente.");

            if (n.MedicoId <= 0)
                throw new ReglaNegocioException("Debe seleccionar un médico.");

            if (n.FechaConsulta > DateTime.Now)
                throw new ReglaNegocioException("La fecha de consulta no puede ser futura.");

            n.Diagnostico = Validaciones.Requerido(n.Diagnostico, "Diagnóstico", 500);
            n.NotasPaciente = Validaciones.Opcional(n.NotasPaciente);
        }
    }
}
