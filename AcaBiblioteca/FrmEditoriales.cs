
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Datos;

namespace AcaBiblioteca
{
    public partial class FrmEditoriales : Form
    {
        private int? idEditorialSeleccionada = null;

        public FrmEditoriales()
        {
            InitializeComponent();

            ConfigurarTabla();
        }

        // Configuración de la tabla
        private void ConfigurarTabla()
        {
            dgvEditoriales.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEditoriales.MultiSelect = false;
            dgvEditoriales.ReadOnly = true;
            dgvEditoriales.AllowUserToAddRows = false;
            dgvEditoriales.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Cargar editoriales
        private void CargarEditoriales()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta =
                        "SELECT IdEditorial, Nombre FROM Editoriales";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dgvEditoriales.DataSource = tabla;
                    }
                }

                dgvEditoriales.ClearSelection();
                idEditorialSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las editoriales:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Limpiar campos
        private void LimpiarCampos()
        {
            txtNombre.Clear();

            idEditorialSeleccionada = null;

            dgvEditoriales.ClearSelection();

            txtNombre.Focus();
        }

        // Validar información
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre de la editorial.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();

                return false;
            }

            return true;
        }

        // Seleccionar editorial en la tabla
        private void dgvEditoriales_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvEditoriales.Rows[e.RowIndex];

            if (fila.Cells["IdEditorial"].Value == null)
                return;

            idEditorialSeleccionada = Convert.ToInt32(
                fila.Cells["IdEditorial"].Value);

            txtNombre.Text =
                Convert.ToString(fila.Cells["Nombre"].Value);
        }

        // Guardar editorial
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta =
                        "INSERT INTO Editoriales (Nombre) VALUES (@Nombre)";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.Add(
                            "@Nombre",
                            SqlDbType.NVarChar).Value =
                            txtNombre.Text.Trim();

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show(
                                "Editorial guardada correctamente.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                CargarEditoriales();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos al guardar la editorial:\n"
                    + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar la editorial:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Nuevo registro
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Editar editorial
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada == null)
                {
                    MessageBox.Show(
                        "Seleccione una editorial de la tabla.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!ValidarCampos())
                    return;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta =
                        @"UPDATE Editoriales
                          SET Nombre = @Nombre
                          WHERE IdEditorial = @IdEditorial";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.Add(
                            "@Nombre",
                            SqlDbType.NVarChar).Value =
                            txtNombre.Text.Trim();

                        comando.Parameters.Add(
                            "@IdEditorial",
                            SqlDbType.Int).Value =
                            idEditorialSeleccionada.Value;

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado == 0)
                        {
                            MessageBox.Show(
                                "No se encontró la editorial para actualizar.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Editorial actualizada correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEditoriales();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar la editorial:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Eliminar editorial
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada == null)
                {
                    MessageBox.Show(
                        "Seleccione una editorial para eliminar.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar esta editorial?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta =
                        "DELETE FROM Editoriales WHERE IdEditorial = @IdEditorial";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.Add(
                            "@IdEditorial",
                            SqlDbType.Int).Value =
                            idEditorialSeleccionada.Value;

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado == 0)
                        {
                            MessageBox.Show(
                                "No se encontró la editorial para eliminar.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Editorial eliminada correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEditoriales();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar la editorial. Es posible que "
                    + "esté relacionada con uno o varios libros.\n\n"
                    + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar la editorial:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Cancelar operación
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Doble clic en la tabla
        private void dgvEditoriales_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEditoriales_CellClick(sender, e);
            }
        }

        // Cargar datos al abrir el formulario
        private void FrmEditoriales_Load(object sender, EventArgs e)
        {
            CargarEditoriales();
        }
    }
}
