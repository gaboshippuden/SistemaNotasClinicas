namespace sysNotasClinicas;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        if (new data.Conexion().TestConnection())
        MessageBox.Show("¡Conectado a la base de datos!");
    }
}
