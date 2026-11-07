
using AcaBiblioteca.Datos;
using System;
using System.Windows.Forms;

namespace AcaBiblioteca
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            //Conexion conexion = new Conexion();
            //try
            //{
                //using (var conn = conexion.ObtenerConexion())
                //{
                    //conn.Open();
                    // La conexión se ha establecido correctamente
                    //MessageBox.Show("Conexión a la base de datos establecida correctamente.",
                        //"AcaBiblioteca",
                        //MessageBoxButtons.OK,
                        //MessageBoxIcon.Information);
                //}
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("Error al conectar a la base de datos: " + ex.Message,
                //"AcaBiblioteca",
                //MessageBoxButtons.OK,
                //MessageBoxIcon.Error);

            //}
            AbrirFormulario(new FrmInicio());
        }

        // Método para abrir formularios dentro del panel principal
        private void AbrirFormulario(Form formulario)
        {
            pnlContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }

        // Botón Inicio
        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInicio());
        }

        // Botón Libros
        private void btnLibros_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLibros());
        }

        // Botón Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        // Botón Autores
        private void btnAutores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAutores());
        }

        // Botón Editoriales
        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEditoriales());
        }

        // Botón Préstamos
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
         AbrirFormulario(new FrmPrestamos());
        }

        // Botón Reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes());
        }

        // Botón Salir
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}