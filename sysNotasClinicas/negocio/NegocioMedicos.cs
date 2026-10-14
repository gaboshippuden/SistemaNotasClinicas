using sysNotasClinicas.data;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.Negocio
{
    public class NegocioMedicos
    {
        private readonly registroMedicos registro = new registroMedicos();

        public List<Medico> Listar()
        {
            return registro.Listar();
        }

        public int Crear(Medico m)
        {
            m.Nombres = Validaciones.Requerido(m.Nombres, "Nombres", 80);
            m.Apellidos = Validaciones.Requerido(m.Apellidos, "Apellidos", 80);
            m.Especialidad = Validaciones.Requerido(m.Especialidad, "Especialidad", 80);

            return Validaciones.TraducirErroresSql(() => registro.Insertar(m));
        }
    }
}
