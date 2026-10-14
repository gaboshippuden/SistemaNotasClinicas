using Microsoft.Data.SqlClient;
using sysNotasClinicas.Negocio;

namespace sysNotasClinicas.Presentacion;

// Cuadros de mensaje comunes de la capa de presentación
internal static class Mensajes
{
    // Ejecuta una acción de negocio mostrando cualquier error al usuario.
    // Devuelve true si la acción terminó bien.
    public static bool Ejecutar(Action accion)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            accion();
            return true;
        }
        catch (ReglaNegocioException ex)
        {
            Advertencia(ex.Message);
        }
        catch (SqlException ex)
        {
            Error("Error de base de datos. Verifique que SQL Server esté disponible.\n\n" + ex.Message);
        }
        finally
        {
            Cursor.Current = Cursors.Default;
        }
        return false;
    }

    public static void Informacion(string mensaje)
    {
        MessageBox.Show(mensaje, "Notas Clínicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Advertencia(string mensaje)
    {
        MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void Error(string mensaje)
    {
        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool Confirmar(string mensaje)
    {
        return MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;
    }
}
