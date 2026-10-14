using sysNotasClinicas.data;
using sysNotasClinicas.Entidades;

namespace sysNotasClinicas.Negocio
{
    public class NegocioPacientes
    {
        private readonly registroPacientes registro = new registroPacientes();

        public List<Paciente> Listar()
        {
            return registro.Listar();
        }

        public int Crear(Paciente p)
        {
            p.Nombres = Validaciones.Requerido(p.Nombres, "Nombres", 80);
            p.Apellidos = Validaciones.Requerido(p.Apellidos, "Apellidos", 80);
            p.Telefono = Validaciones.Telefono(p.Telefono);

            return Validaciones.TraducirErroresSql(() => registro.Insertar(p));
        }
    }
}
