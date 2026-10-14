namespace sysNotasClinicas.Presentacion;

partial class FrmPacientes
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
        dgvPacientes = new DataGridView();
        colNombres = new DataGridViewTextBoxColumn();
        colApellidos = new DataGridViewTextBoxColumn();
        colTelefono = new DataGridViewTextBoxColumn();
        pnlAlta = new Panel();
        lblNombres = new Label();
        txtNombres = new TextBox();
        lblApellidos = new Label();
        txtApellidos = new TextBox();
        lblTelefono = new Label();
        txtTelefono = new TextBox();
        btnAgregar = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
        pnlAlta.SuspendLayout();
        SuspendLayout();
        //
        // dgvPacientes
        //
        dgvPacientes.AllowUserToAddRows = false;
        dgvPacientes.AllowUserToDeleteRows = false;
        dgvPacientes.AllowUserToResizeRows = false;
        dgvPacientes.BackgroundColor = SystemColors.Window;
        dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPacientes.Columns.AddRange(new DataGridViewColumn[] { colNombres, colApellidos, colTelefono });
        dgvPacientes.Dock = DockStyle.Fill;
        dgvPacientes.Location = new Point(0, 0);
        dgvPacientes.MultiSelect = false;
        dgvPacientes.Name = "dgvPacientes";
        dgvPacientes.ReadOnly = true;
        dgvPacientes.RowHeadersVisible = false;
        dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPacientes.Size = new Size(664, 340);
        dgvPacientes.TabIndex = 1;
        //
        // colNombres
        //
        colNombres.DataPropertyName = "Nombres";
        colNombres.HeaderText = "Nombres";
        colNombres.Name = "colNombres";
        colNombres.ReadOnly = true;
        colNombres.Width = 200;
        //
        // colApellidos
        //
        colApellidos.DataPropertyName = "Apellidos";
        colApellidos.HeaderText = "Apellidos";
        colApellidos.Name = "colApellidos";
        colApellidos.ReadOnly = true;
        colApellidos.Width = 200;
        //
        // colTelefono
        //
        colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colTelefono.DataPropertyName = "Telefono";
        colTelefono.HeaderText = "Teléfono";
        colTelefono.Name = "colTelefono";
        colTelefono.ReadOnly = true;
        //
        // pnlAlta
        //
        pnlAlta.Controls.Add(lblNombres);
        pnlAlta.Controls.Add(txtNombres);
        pnlAlta.Controls.Add(lblApellidos);
        pnlAlta.Controls.Add(txtApellidos);
        pnlAlta.Controls.Add(lblTelefono);
        pnlAlta.Controls.Add(txtTelefono);
        pnlAlta.Controls.Add(btnAgregar);
        pnlAlta.Dock = DockStyle.Bottom;
        pnlAlta.Location = new Point(0, 340);
        pnlAlta.Name = "pnlAlta";
        pnlAlta.Size = new Size(664, 70);
        pnlAlta.TabIndex = 0;
        //
        // lblNombres
        //
        lblNombres.AutoSize = true;
        lblNombres.Location = new Point(12, 12);
        lblNombres.Name = "lblNombres";
        lblNombres.Size = new Size(57, 15);
        lblNombres.TabIndex = 0;
        lblNombres.Text = "Nombres:";
        //
        // txtNombres
        //
        txtNombres.Location = new Point(12, 30);
        txtNombres.MaxLength = 80;
        txtNombres.Name = "txtNombres";
        txtNombres.Size = new Size(180, 23);
        txtNombres.TabIndex = 1;
        //
        // lblApellidos
        //
        lblApellidos.AutoSize = true;
        lblApellidos.Location = new Point(204, 12);
        lblApellidos.Name = "lblApellidos";
        lblApellidos.Size = new Size(59, 15);
        lblApellidos.TabIndex = 2;
        lblApellidos.Text = "Apellidos:";
        //
        // txtApellidos
        //
        txtApellidos.Location = new Point(204, 30);
        txtApellidos.MaxLength = 80;
        txtApellidos.Name = "txtApellidos";
        txtApellidos.Size = new Size(180, 23);
        txtApellidos.TabIndex = 3;
        //
        // lblTelefono
        //
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(396, 12);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(55, 15);
        lblTelefono.TabIndex = 4;
        lblTelefono.Text = "Teléfono:";
        //
        // txtTelefono
        //
        txtTelefono.Location = new Point(396, 30);
        txtTelefono.MaxLength = 20;
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(140, 23);
        txtTelefono.TabIndex = 5;
        //
        // btnAgregar
        //
        btnAgregar.Location = new Point(548, 28);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(100, 27);
        btnAgregar.TabIndex = 6;
        btnAgregar.Text = "Agregar";
        btnAgregar.UseVisualStyleBackColor = true;
        btnAgregar.Click += btnAgregar_Click;
        //
        // FrmPacientes
        //
        AcceptButton = btnAgregar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(664, 410);
        Controls.Add(dgvPacientes);
        Controls.Add(pnlAlta);
        MinimizeBox = false;
        MinimumSize = new Size(680, 300);
        Name = "FrmPacientes";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Pacientes";
        Load += FrmPacientes_Load;
        ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
        pnlAlta.ResumeLayout(false);
        pnlAlta.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvPacientes;
    private DataGridViewTextBoxColumn colNombres;
    private DataGridViewTextBoxColumn colApellidos;
    private DataGridViewTextBoxColumn colTelefono;
    private Panel pnlAlta;
    private Label lblNombres;
    private TextBox txtNombres;
    private Label lblApellidos;
    private TextBox txtApellidos;
    private Label lblTelefono;
    private TextBox txtTelefono;
    private Button btnAgregar;
}
