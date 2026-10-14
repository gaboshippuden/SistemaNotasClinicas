using sysNotasClinicas.Entidades;
using sysNotasClinicas.Negocio;

namespace sysNotasClinicas.Presentacion;

// Listado y alta de médicos
public partial class FrmMedicos : Form
{
    private readonly NegocioMedicos negocio = new NegocioMedicos();

    public FrmMedicos()
    {
        InitializeComponent();
        dgvMedicos.AutoGenerateColumns = false;
    }

    private void FrmMedicos_Load(object sender, EventArgs e)
    {
        CargarMedicos();
    }

    private void CargarMedicos()
    {
        Mensajes.Ejecutar(() => dgvMedicos.DataSource = negocio.Listar());
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Medico medico = new Medico
        {
            Nombres = txtNombres.Text,
            Apellidos = txtApellidos.Text,
            Especialidad = txtEspecialidad.Text
        };

        if (!Mensajes.Ejecutar(() => negocio.Crear(medico)))
            return;

        txtNombres.Clear();
        txtApellidos.Clear();
        txtEspecialidad.Clear();
        txtNombres.Focus();
        CargarMedicos();
    }
}
