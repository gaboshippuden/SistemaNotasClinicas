using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace sysNotasClinicas.Negocio
{
    // Validaciones y utilidades compartidas por las clases de negocio
    internal static class Validaciones
    {
        // Número que SQL Server asigna a los RAISERROR con mensaje propio (SPs y trigger)
        private const int ErrorDeUsuarioSql = 50000;

        // Texto obligatorio: quita espacios y controla el largo de la columna en la BD
        public static string Requerido(string? valor, string campo, int largoMaximo)
        {
            string texto = (valor ?? string.Empty).Trim();

            if (texto.Length == 0)
                throw new ReglaNegocioException($"El campo {campo} es obligatorio.");

            if (texto.Length > largoMaximo)
                throw new ReglaNegocioException($"El campo {campo} no puede superar {largoMaximo} caracteres.");

            return texto;
        }

        // Texto opcional: vacío se guarda como NULL
        public static string? Opcional(string? valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }

        public static string Telefono(string? valor)
        {
            string telefono = Requerido(valor, "Teléfono", 20);

            // Ej: +56911111111 o 22 345 6789
            if (!Regex.IsMatch(telefono, @"^\+?[0-9 ]{7,19}$"))
                throw new ReglaNegocioException(
                    "El teléfono solo puede contener números, espacios y un '+' inicial (mínimo 7 caracteres).");

            return telefono;
        }

        // Ejecuta una llamada a la capa de datos y convierte los RAISERROR
        // de los SPs en ReglaNegocioException con el mismo mensaje.
        public static T TraducirErroresSql<T>(Func<T> accion)
        {
            try
            {
                return accion();
            }
            catch (SqlException ex) when (ex.Number == ErrorDeUsuarioSql)
            {
                throw new ReglaNegocioException(ex.Errors[0].Message);
            }
        }

        public static void TraducirErroresSql(Action accion)
        {
            TraducirErroresSql(() => { accion(); return 0; });
        }
    }
}
