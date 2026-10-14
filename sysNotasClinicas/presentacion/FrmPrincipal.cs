using sysNotasClinicas.Entidades;
using sysNotasClinicas.Negocio;

namespace sysNotasClinicas.Presentacion;

// Pantalla principal: listado de notas clínicas y acciones RF-01 a RF-05
public partial class FrmPrincipal : Form
{
    private readonly NegocioNotasClinicas negocio = new NegocioNotasClinicas();

    public FrmPrincipal()
    {
        InitializeComponent();
        dgvNotas.AutoGenerateColumns = false;
    }

    private NotaClinica? NotaSeleccionada => dgvNotas.CurrentRow?.DataBoundItem as NotaClinica;

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        CargarNotas();
    }

    private void CargarNotas()
    {
        List<NotaClinica> notas = new List<NotaClinica>();
        Mensajes.Ejecutar(() => notas = negocio.Listar());

        dgvNotas.DataSource = notas;
        lblEstado.Text = $"{notas.Count} nota(s) clínica(s)";
        ActualizarBotones();
    }

    // Editar/Eliminar/Firmar solo para BORRADOR; una FIRMADA solo se puede ver
    private void ActualizarBotones()
    {
        NotaClinica? nota = NotaSeleccionada;
        bool borrador = nota?.Estado == EstadoNota.BORRADOR;

        btnEditar.Enabled = nota != null;
        btnEditar.Text = nota?.Estado == EstadoNota.FIRMADA ? "Ver" : "Editar";
        btnEliminar.Enabled = borrador;
        btnFirmar.Enabled = borrador;
    }

    private void AbrirNota(NotaClinica? nota)
    {
        using FrmNotaClinica frm = new FrmNotaClinica(nota);
        if (frm.ShowDialog(this) == DialogResult.OK)
            CargarNotas();
    }

    // ---------- Eventos ----------

    private void btnNueva_Click(object sender, EventArgs e)
    {
        AbrirNota(null);
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (NotaSeleccionada != null)
            AbrirNota(NotaSeleccionada);
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        NotaClinica? nota = NotaSeleccionada;
        if (nota == null)
            return;

        if (!Mensajes.Confirmar($"¿Eliminar la nota N° {nota.NotaClinicaId} de {nota.Paciente}?"))
            return;

        if (Mensajes.Ejecutar(() => negocio.Eliminar(nota)))
            CargarNotas();
    }

    private void btnFirmar_Click(object sender, EventArgs e)
    {
        NotaClinica? nota = NotaSeleccionada;
        if (nota == null)
            return;

        if (!Mensajes.Confirmar($"¿Firmar la nota N° {nota.NotaClinicaId}?\n\n" +
                                "Una nota FIRMADA ya no se puede editar ni eliminar."))
            return;

        if (Mensajes.Ejecutar(() => negocio.Firmar(nota)))
            CargarNotas();
    }

    private void btnRefrescar_Click(object sender, EventArgs e)
    {
        CargarNotas();
    }

    private void btnPacientes_Click(object sender, EventArgs e)
    {
        using FrmPacientes frm = new FrmPacientes();
        frm.ShowDialog(this);
        CargarNotas();
    }

    private void btnMedicos_Click(object sender, EventArgs e)
    {
        using FrmMedicos frm = new FrmMedicos();
        frm.ShowDialog(this);
        CargarNotas();
    }

    private void dgvNotas_SelectionChanged(object sender, EventArgs e)
    {
        ActualizarBotones();
    }

    private void dgvNotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnEditar_Click(sender, e);
    }

    // Las notas FIRMADAS se muestran en gris
    private void dgvNotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvNotas.Rows[e.RowIndex].DataBoundItem is NotaClinica { Estado: EstadoNota.FIRMADA })
            e.CellStyle!.ForeColor = Color.Gray;
    }
}
