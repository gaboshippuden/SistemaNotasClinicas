namespace sysNotasClinicas.Presentacion;

partial class FrmPrincipal
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        pnlAcciones = new FlowLayoutPanel();
        btnNueva = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        btnFirmar = new Button();
        btnRefrescar = new Button();
        btnPacientes = new Button();
        btnMedicos = new Button();
        dgvNotas = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colFecha = new DataGridViewTextBoxColumn();
        colPaciente = new DataGridViewTextBoxColumn();
        colMedico = new DataGridViewTextBoxColumn();
        colDiagnostico = new DataGridViewTextBoxColumn();
        colEstado = new DataGridViewTextBoxColumn();
        ssEstado = new StatusStrip();
        lblEstado = new ToolStripStatusLabel();
        pnlAcciones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvNotas).BeginInit();
        ssEstado.SuspendLayout();
        SuspendLayout();
        //
        // pnlAcciones
        //
        pnlAcciones.Controls.Add(btnNueva);
        pnlAcciones.Controls.Add(btnEditar);
        pnlAcciones.Controls.Add(btnEliminar);
        pnlAcciones.Controls.Add(btnFirmar);
        pnlAcciones.Controls.Add(btnRefrescar);
        pnlAcciones.Controls.Add(btnPacientes);
        pnlAcciones.Controls.Add(btnMedicos);
        pnlAcciones.Dock = DockStyle.Top;
        pnlAcciones.Location = new Point(0, 0);
        pnlAcciones.Name = "pnlAcciones";
        pnlAcciones.Padding = new Padding(6);
        pnlAcciones.Size = new Size(984, 48);
        pnlAcciones.TabIndex = 0;
        //
        // btnNueva
        //
        btnNueva.Name = "btnNueva";
        btnNueva.Size = new Size(100, 30);
        btnNueva.TabIndex = 0;
        btnNueva.Text = "Nueva nota";
        btnNueva.UseVisualStyleBackColor = true;
        btnNueva.Click += btnNueva_Click;
        //
        // btnEditar
        //
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(100, 30);
        btnEditar.TabIndex = 1;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = true;
        btnEditar.Click += btnEditar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(100, 30);
        btnEliminar.TabIndex = 2;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnFirmar
        //
        btnFirmar.Name = "btnFirmar";
        btnFirmar.Size = new Size(100, 30);
        btnFirmar.TabIndex = 3;
        btnFirmar.Text = "Firmar";
        btnFirmar.UseVisualStyleBackColor = true;
        btnFirmar.Click += btnFirmar_Click;
        //
        // btnRefrescar
        //
        btnRefrescar.Name = "btnRefrescar";
        btnRefrescar.Size = new Size(100, 30);
        btnRefrescar.TabIndex = 4;
        btnRefrescar.Text = "Refrescar";
        btnRefrescar.UseVisualStyleBackColor = true;
        btnRefrescar.Click += btnRefrescar_Click;
        //
        // btnPacientes
        //
        btnPacientes.Margin = new Padding(40, 3, 3, 3);
        btnPacientes.Name = "btnPacientes";
        btnPacientes.Size = new Size(100, 30);
        btnPacientes.TabIndex = 5;
        btnPacientes.Text = "Pacientes...";
        btnPacientes.UseVisualStyleBackColor = true;
        btnPacientes.Click += btnPacientes_Click;
        //
        // btnMedicos
        //
        btnMedicos.Name = "btnMedicos";
        btnMedicos.Size = new Size(100, 30);
        btnMedicos.TabIndex = 6;
        btnMedicos.Text = "Médicos...";
        btnMedicos.UseVisualStyleBackColor = true;
        btnMedicos.Click += btnMedicos_Click;
        //
        // dgvNotas
        //
        dgvNotas.AllowUserToAddRows = false;
        dgvNotas.AllowUserToDeleteRows = false;
        dgvNotas.AllowUserToResizeRows = false;
        dgvNotas.BackgroundColor = SystemColors.Window;
        dgvNotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvNotas.Columns.AddRange(new DataGridViewColumn[] { colId, colFecha, colPaciente, colMedico, colDiagnostico, colEstado });
        dgvNotas.Dock = DockStyle.Fill;
        dgvNotas.Location = new Point(0, 48);
        dgvNotas.MultiSelect = false;
        dgvNotas.Name = "dgvNotas";
        dgvNotas.ReadOnly = true;
        dgvNotas.RowHeadersVisible = false;
        dgvNotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvNotas.Size = new Size(984, 491);
        dgvNotas.TabIndex = 1;
        dgvNotas.CellDoubleClick += dgvNotas_CellDoubleClick;
        dgvNotas.CellFormatting += dgvNotas_CellFormatting;
        dgvNotas.SelectionChanged += dgvNotas_SelectionChanged;
        //
        // colId
        //
        colId.DataPropertyName = "NotaClinicaId";
        colId.HeaderText = "N°";
        colId.Name = "colId";
        colId.ReadOnly = true;
        colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //
        // colFecha
        //
        colFecha.DataPropertyName = "FechaConsulta";
        dataGridViewCellStyle1.Format = "dd-MM-yyyy HH:mm";
        colFecha.DefaultCellStyle = dataGridViewCellStyle1;
        colFecha.HeaderText = "Fecha consulta";
        colFecha.Name = "colFecha";
        colFecha.ReadOnly = true;
        colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //
        // colPaciente
        //
        colPaciente.DataPropertyName = "Paciente";
        colPaciente.HeaderText = "Paciente";
        colPaciente.Name = "colPaciente";
        colPaciente.ReadOnly = true;
        colPaciente.Width = 180;
        //
        // colMedico
        //
        colMedico.DataPropertyName = "Medico";
        colMedico.HeaderText = "Médico";
        colMedico.Name = "colMedico";
        colMedico.ReadOnly = true;
        colMedico.Width = 180;
        //
        // colDiagnostico
        //
        colDiagnostico.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colDiagnostico.DataPropertyName = "Diagnostico";
        colDiagnostico.HeaderText = "Diagnóstico";
        colDiagnostico.Name = "colDiagnostico";
        colDiagnostico.ReadOnly = true;
        //
        // colEstado
        //
        colEstado.DataPropertyName = "Estado";
        colEstado.HeaderText = "Estado";
        colEstado.Name = "colEstado";
        colEstado.ReadOnly = true;
        colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //
        // ssEstado
        //
        ssEstado.Items.AddRange(new ToolStripItem[] { lblEstado });
        ssEstado.Location = new Point(0, 539);
        ssEstado.Name = "ssEstado";
        ssEstado.Size = new Size(984, 22);
        ssEstado.TabIndex = 2;
        //
        // lblEstado
        //
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(0, 17);
        //
        // FrmPrincipal
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 561);
        Controls.Add(dgvNotas);
        Controls.Add(pnlAcciones);
        Controls.Add(ssEstado);
        MinimumSize = new Size(800, 400);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema de Notas Clínicas";
        Load += FrmPrincipal_Load;
        pnlAcciones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvNotas).EndInit();
        ssEstado.ResumeLayout(false);
        ssEstado.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel pnlAcciones;
    private Button btnNueva;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnFirmar;
    private Button btnRefrescar;
    private Button btnPacientes;
    private Button btnMedicos;
    private DataGridView dgvNotas;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colFecha;
    private DataGridViewTextBoxColumn colPaciente;
    private DataGridViewTextBoxColumn colMedico;
    private DataGridViewTextBoxColumn colDiagnostico;
    private DataGridViewTextBoxColumn colEstado;
    private StatusStrip ssEstado;
    private ToolStripStatusLabel lblEstado;
}
