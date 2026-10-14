using sysNotasClinicas.Entidades;
using sysNotasClinicas.Negocio;

namespace sysNotasClinicas.Presentacion;

// Listado y alta de pacientes
public partial class FrmPacientes : Form
{
    private readonly NegocioPacientes negocio = new NegocioPacientes();

    public FrmPacientes()
    {
        InitializeComponent();
        dgvPacientes.AutoGenerateColumns = false;
    }

    private void FrmPacientes_Load(object sender, EventArgs e)
    {
        CargarPacientes();
    }

    private void CargarPacientes()
    {
        Mensajes.Ejecutar(() => dgvPacientes.DataSource = negocio.Listar());
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Paciente paciente = new Paciente
        {
            Nombres = txtNombres.Text,
            Apellidos = txtApellidos.Text,
            Telefono = txtTelefono.Text
        };

        if (!Mensajes.Ejecutar(() => negocio.Crear(paciente)))
            return;

        txtNombres.Clear();
        txtApellidos.Clear();
        txtTelefono.Clear();
        txtNombres.Focus();
        CargarPacientes();
    }
}
