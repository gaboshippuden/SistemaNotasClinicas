using sysNotasClinicas.Entidades;
using sysNotasClinicas.Negocio;

namespace sysNotasClinicas.Presentacion;

// Diálogo para crear, editar o ver (si está FIRMADA) una nota clínica
public partial class FrmNotaClinica : Form
{
    private readonly NegocioNotasClinicas negocio = new NegocioNotasClinicas();
    private readonly NotaClinica? nota;   // null = nota nueva

    public FrmNotaClinica(NotaClinica? nota)
    {
        InitializeComponent();
        this.nota = nota;
    }

    private bool SoloLectura => nota?.Estado == EstadoNota.FIRMADA;

    private void FrmNotaClinica_Load(object sender, EventArgs e)
    {
        List<Paciente> pacientes = new List<Paciente>();
        List<Medico> medicos = new List<Medico>();

        bool cargado = Mensajes.Ejecutar(() =>
        {
            pacientes = new NegocioPacientes().Listar();
            medicos = new NegocioMedicos().Listar();
        });

        if (!cargado)
        {
            Close();
            return;
        }

        if (pacientes.Count == 0 || medicos.Count == 0)
        {
            Mensajes.Advertencia("Debe registrar al menos un paciente y un médico antes de crear notas clínicas.");
            Close();
            return;
        }

        cboPaciente.DisplayMember = nameof(Paciente.NombreCompleto);
        cboPaciente.ValueMember = nameof(Paciente.PacienteId);
        cboPaciente.DataSource = pacientes;

        cboMedico.DisplayMember = nameof(Medico.NombreCompleto);
        cboMedico.ValueMember = nameof(Medico.MedicoId);
        cboMedico.DataSource = medicos;

        if (nota == null)
        {
            Text = "Nueva nota clínica";
            dtpFecha.Value = DateTime.Now;
            return;
        }

        Text = SoloLectura
            ? $"Nota clínica N° {nota.NotaClinicaId} (FIRMADA - solo lectura)"
            : $"Editar nota clínica N° {nota.NotaClinicaId}";

        cboPaciente.SelectedValue = nota.PacienteId;
        cboMedico.SelectedValue = nota.MedicoId;
        dtpFecha.Value = nota.FechaConsulta;
        txtDiagnostico.Text = nota.Diagnostico;
        txtNotas.Text = nota.NotasPaciente;

        if (SoloLectura)
        {
            cboPaciente.Enabled = false;
            cboMedico.Enabled = false;
            dtpFecha.Enabled = false;
            txtDiagnostico.ReadOnly = true;
            txtNotas.ReadOnly = true;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Cerrar";
        }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        NotaClinica datos = new NotaClinica
        {
            NotaClinicaId = nota?.NotaClinicaId ?? 0,
            PacienteId = cboPaciente.SelectedValue is int pacienteId ? pacienteId : 0,
            MedicoId = cboMedico.SelectedValue is int medicoId ? medicoId : 0,
            FechaConsulta = dtpFecha.Value,
            Diagnostico = txtDiagnostico.Text,
            NotasPaciente = txtNotas.Text,
            Estado = nota?.Estado ?? EstadoNota.BORRADOR
        };

        bool guardado = Mensajes.Ejecutar(() =>
        {
            if (nota == null)
                negocio.Crear(datos);
            else
                negocio.Actualizar(datos);
        });

        // Si hubo un error el diálogo queda abierto para corregir
        if (guardado)
            DialogResult = DialogResult.OK;
    }
}
