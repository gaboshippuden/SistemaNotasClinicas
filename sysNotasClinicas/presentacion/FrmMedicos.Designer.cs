namespace sysNotasClinicas.Presentacion;

partial class FrmMedicos
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
        dgvMedicos = new DataGridView();
        colNombres = new DataGridViewTextBoxColumn();
        colApellidos = new DataGridViewTextBoxColumn();
        colEspecialidad = new DataGridViewTextBoxColumn();
        pnlAlta = new Panel();
        lblNombres = new Label();
        txtNombres = new TextBox();
        lblApellidos = new Label();
        txtApellidos = new TextBox();
        lblEspecialidad = new Label();
        txtEspecialidad = new TextBox();
        btnAgregar = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvMedicos).BeginInit();
        pnlAlta.SuspendLayout();
        SuspendLayout();
        //
        // dgvMedicos
        //
        dgvMedicos.AllowUserToAddRows = false;
        dgvMedicos.AllowUserToDeleteRows = false;
        dgvMedicos.AllowUserToResizeRows = false;
        dgvMedicos.BackgroundColor = SystemColors.Window;
        dgvMedicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMedicos.Columns.AddRange(new DataGridViewColumn[] { colNombres, colApellidos, colEspecialidad });
        dgvMedicos.Dock = DockStyle.Fill;
        dgvMedicos.Location = new Point(0, 0);
        dgvMedicos.MultiSelect = false;
        dgvMedicos.Name = "dgvMedicos";
        dgvMedicos.ReadOnly = true;
        dgvMedicos.RowHeadersVisible = false;
        dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMedicos.Size = new Size(664, 340);
        dgvMedicos.TabIndex = 1;
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
        // colEspecialidad
        //
        colEspecialidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colEspecialidad.DataPropertyName = "Especialidad";
        colEspecialidad.HeaderText = "Especialidad";
        colEspecialidad.Name = "colEspecialidad";
        colEspecialidad.ReadOnly = true;
        //
        // pnlAlta
        //
        pnlAlta.Controls.Add(lblNombres);
        pnlAlta.Controls.Add(txtNombres);
        pnlAlta.Controls.Add(lblApellidos);
        pnlAlta.Controls.Add(txtApellidos);
        pnlAlta.Controls.Add(lblEspecialidad);
        pnlAlta.Controls.Add(txtEspecialidad);
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
        // lblEspecialidad
        //
        lblEspecialidad.AutoSize = true;
        lblEspecialidad.Location = new Point(396, 12);
        lblEspecialidad.Name = "lblEspecialidad";
        lblEspecialidad.Size = new Size(55, 15);
        lblEspecialidad.TabIndex = 4;
        lblEspecialidad.Text = "Especialidad:";
        //
        // txtEspecialidad
        //
        txtEspecialidad.Location = new Point(396, 30);
        txtEspecialidad.MaxLength = 80;
        txtEspecialidad.Name = "txtEspecialidad";
        txtEspecialidad.Size = new Size(140, 23);
        txtEspecialidad.TabIndex = 5;
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
        // FrmMedicos
        //
        AcceptButton = btnAgregar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(664, 410);
        Controls.Add(dgvMedicos);
        Controls.Add(pnlAlta);
        MinimizeBox = false;
        MinimumSize = new Size(680, 300);
        Name = "FrmMedicos";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Médicos";
        Load += FrmMedicos_Load;
        ((System.ComponentModel.ISupportInitialize)dgvMedicos).EndInit();
        pnlAlta.ResumeLayout(false);
        pnlAlta.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvMedicos;
    private DataGridViewTextBoxColumn colNombres;
    private DataGridViewTextBoxColumn colApellidos;
    private DataGridViewTextBoxColumn colEspecialidad;
    private Panel pnlAlta;
    private Label lblNombres;
    private TextBox txtNombres;
    private Label lblApellidos;
    private TextBox txtApellidos;
    private Label lblEspecialidad;
    private TextBox txtEspecialidad;
    private Button btnAgregar;
}
