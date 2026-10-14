namespace sysNotasClinicas.Presentacion;

partial class FrmNotaClinica
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
        lblPaciente = new Label();
        cboPaciente = new ComboBox();
        lblMedico = new Label();
        cboMedico = new ComboBox();
        lblFecha = new Label();
        dtpFecha = new DateTimePicker();
        lblDiagnostico = new Label();
        txtDiagnostico = new TextBox();
        lblNotas = new Label();
        txtNotas = new TextBox();
        btnGuardar = new Button();
        btnCancelar = new Button();
        SuspendLayout();
        //
        // lblPaciente
        //
        lblPaciente.AutoSize = true;
        lblPaciente.Location = new Point(12, 15);
        lblPaciente.Name = "lblPaciente";
        lblPaciente.Size = new Size(55, 15);
        lblPaciente.TabIndex = 0;
        lblPaciente.Text = "Paciente:";
        //
        // cboPaciente
        //
        cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPaciente.Location = new Point(130, 12);
        cboPaciente.Name = "cboPaciente";
        cboPaciente.Size = new Size(370, 23);
        cboPaciente.TabIndex = 1;
        //
        // lblMedico
        //
        lblMedico.AutoSize = true;
        lblMedico.Location = new Point(12, 48);
        lblMedico.Name = "lblMedico";
        lblMedico.Size = new Size(50, 15);
        lblMedico.TabIndex = 2;
        lblMedico.Text = "Médico:";
        //
        // cboMedico
        //
        cboMedico.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMedico.Location = new Point(130, 45);
        cboMedico.Name = "cboMedico";
        cboMedico.Size = new Size(370, 23);
        cboMedico.TabIndex = 3;
        //
        // lblFecha
        //
        lblFecha.AutoSize = true;
        lblFecha.Location = new Point(12, 81);
        lblFecha.Name = "lblFecha";
        lblFecha.Size = new Size(92, 15);
        lblFecha.TabIndex = 4;
        lblFecha.Text = "Fecha consulta:";
        //
        // dtpFecha
        //
        dtpFecha.CustomFormat = "dd-MM-yyyy HH:mm";
        dtpFecha.Format = DateTimePickerFormat.Custom;
        dtpFecha.Location = new Point(130, 78);
        dtpFecha.Name = "dtpFecha";
        dtpFecha.Size = new Size(200, 23);
        dtpFecha.TabIndex = 5;
        //
        // lblDiagnostico
        //
        lblDiagnostico.AutoSize = true;
        lblDiagnostico.Location = new Point(12, 114);
        lblDiagnostico.Name = "lblDiagnostico";
        lblDiagnostico.Size = new Size(73, 15);
        lblDiagnostico.TabIndex = 6;
        lblDiagnostico.Text = "Diagnóstico:";
        //
        // txtDiagnostico
        //
        txtDiagnostico.Location = new Point(130, 111);
        txtDiagnostico.MaxLength = 500;
        txtDiagnostico.Multiline = true;
        txtDiagnostico.Name = "txtDiagnostico";
        txtDiagnostico.Size = new Size(370, 60);
        txtDiagnostico.TabIndex = 7;
        //
        // lblNotas
        //
        lblNotas.AutoSize = true;
        lblNotas.Location = new Point(12, 182);
        lblNotas.Name = "lblNotas";
        lblNotas.Size = new Size(98, 15);
        lblNotas.TabIndex = 8;
        lblNotas.Text = "Notas (opcional):";
        //
        // txtNotas
        //
        txtNotas.AcceptsReturn = true;
        txtNotas.Location = new Point(130, 179);
        txtNotas.Multiline = true;
        txtNotas.Name = "txtNotas";
        txtNotas.ScrollBars = ScrollBars.Vertical;
        txtNotas.Size = new Size(370, 180);
        txtNotas.TabIndex = 9;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(314, 372);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(90, 30);
        btnGuardar.TabIndex = 10;
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = true;
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnCancelar
        //
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.Location = new Point(410, 372);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(90, 30);
        btnCancelar.TabIndex = 11;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        //
        // FrmNotaClinica
        //
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(514, 414);
        Controls.Add(lblPaciente);
        Controls.Add(cboPaciente);
        Controls.Add(lblMedico);
        Controls.Add(cboMedico);
        Controls.Add(lblFecha);
        Controls.Add(dtpFecha);
        Controls.Add(lblDiagnostico);
        Controls.Add(txtDiagnostico);
        Controls.Add(lblNotas);
        Controls.Add(txtNotas);
        Controls.Add(btnGuardar);
        Controls.Add(btnCancelar);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmNotaClinica";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Nota clínica";
        Load += FrmNotaClinica_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPaciente;
    private ComboBox cboPaciente;
    private Label lblMedico;
    private ComboBox cboMedico;
    private Label lblFecha;
    private DateTimePicker dtpFecha;
    private Label lblDiagnostico;
    private TextBox txtDiagnostico;
    private Label lblNotas;
    private TextBox txtNotas;
    private Button btnGuardar;
    private Button btnCancelar;
}
