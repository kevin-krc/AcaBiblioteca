

using AcaBiblioteca.Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AcaBiblioteca
{
    public partial class FrmAutores : Form
    {
        private int? idAutorSeleccionado = null;

        public FrmAutores()
        {
            InitializeComponent();

            ConfigurarTabla();
            CargarAutores();
        }

        // CONFIGURAR TABLA
        private void ConfigurarTabla()
        {
            dgvAutores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAutores.MultiSelect = false;
            dgvAutores.ReadOnly = true;
            dgvAutores.AllowUserToAddRows = false;

            dgvAutores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // CARGAR AUTORES
        private void CargarAutores()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        SELECT IdAutor, Nombre, Apellido
                        FROM Autores";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dgvAutores.DataSource = tabla;
                    }
                }

                dgvAutores.ClearSelection();
                idAutorSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los autores:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();

            idAutorSeleccionado = null;

            dgvAutores.ClearSelection();

            txtNombre.Focus();
        }

        // VALIDAR CAMPOS
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show(
                    "Complete todos los campos antes de continuar.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // SELECCIONAR AUTOR
        private void dgvAutores_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvAutores.Rows[e.RowIndex];

            if (fila.Cells["IdAutor"].Value == null ||
                fila.Cells["IdAutor"].Value == DBNull.Value)
                return;

            idAutorSeleccionado = Convert.ToInt32(
                fila.Cells["IdAutor"].Value);

            txtNombre.Text = Convert.ToString(
                fila.Cells["Nombre"].Value);

            txtApellido.Text = Convert.ToString(
                fila.Cells["Apellido"].Value);
        }

        // GUARDAR AUTOR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        INSERT INTO Autores (Nombre, Apellido)
                        VALUES (@Nombre, @Apellido)";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@Nombre", txtNombre.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Apellido", txtApellido.Text.Trim());

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Autor guardado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAutores();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos al guardar:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el autor:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // NUEVO AUTOR
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // EDITAR AUTOR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAutorSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un autor de la tabla para editar.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        UPDATE Autores
                        SET Nombre = @Nombre,
                            Apellido = @Apellido
                        WHERE IdAutor = @IdAutor";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@Nombre", txtNombre.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Apellido", txtApellido.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@IdAutor", idAutorSeleccionado.Value);

                        int filas = comando.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                "No se encontró el autor seleccionado.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Autor actualizado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAutores();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos al editar:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el autor:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ELIMINAR AUTOR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAutorSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un autor de la tabla para eliminar.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este autor?",
                "Biblioteca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta =
                        "DELETE FROM Autores WHERE IdAutor = @IdAutor";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@IdAutor", idAutorSeleccionado.Value);

                        int filas = comando.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                "No se encontró el autor seleccionado.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Autor eliminado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAutores();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos al eliminar:\n" + ex.Message +
                    "\n\nSi el autor tiene libros asociados, puede existir " +
                    "una restricción de clave foránea.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el autor:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // DOBLE CLIC EN TABLA
        private void dgvAutores_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            dgvAutores_CellClick(sender, e);
        }

        // CARGA DEL FORMULARIO
        private void FrmAutores_Load(object sender, EventArgs e)
        {
        }
    }
}

