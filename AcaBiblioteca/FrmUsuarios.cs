
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Datos;

namespace AcaBiblioteca
{
    public partial class FrmUsuarios : Form
    {
        private int? idUsuarioSeleccionado = null;

        public FrmUsuarios()
        {
            InitializeComponent();

            ConfigurarTabla();
            CargarUsuarios();
        }

        // CONFIGURAR TABLA
        private void ConfigurarTabla()
        {
            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // CARGAR USUARIOS
        private void CargarUsuarios()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        SELECT IdUsuario, Nombre, Apellido,
                               Documento, Telefono, Correo
                        FROM Usuarios";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        dgvUsuarios.DataSource = tabla;
                    }
                }

                dgvUsuarios.ClearSelection();
                idUsuarioSeleccionado = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar usuarios:\n" + ex.Message,
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
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            idUsuarioSeleccionado = null;

            dgvUsuarios.ClearSelection();

            txtNombre.Focus();
        }

        // VALIDAR CAMPOS
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
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

        // SELECCIONAR USUARIO DE LA TABLA
        private void dgvUsuarios_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

            if (fila.Cells["IdUsuario"].Value == null ||
                fila.Cells["IdUsuario"].Value == DBNull.Value)
                return;

            idUsuarioSeleccionado = Convert.ToInt32(
                fila.Cells["IdUsuario"].Value);

            txtNombre.Text = Convert.ToString(
                fila.Cells["Nombre"].Value);

            txtApellido.Text = Convert.ToString(
                fila.Cells["Apellido"].Value);

            txtDocumento.Text = Convert.ToString(
                fila.Cells["Documento"].Value);

            txtTelefono.Text = Convert.ToString(
                fila.Cells["Telefono"].Value);

            txtCorreo.Text = Convert.ToString(
                fila.Cells["Correo"].Value);
        }

        // GUARDAR
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
                        INSERT INTO Usuarios
                        (Nombre, Apellido, Documento, Telefono, Correo)
                        VALUES
                        (@Nombre, @Apellido, @Documento, @Telefono, @Correo)";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@Nombre", txtNombre.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Apellido", txtApellido.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Documento", txtDocumento.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Telefono", txtTelefono.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Correo", txtCorreo.Text.Trim());

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Usuario guardado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
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
                    "Error al guardar:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla para editar.",
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
                        UPDATE Usuarios SET
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            Documento = @Documento,
                            Telefono = @Telefono,
                            Correo = @Correo
                        WHERE IdUsuario = @IdUsuario";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@Nombre", txtNombre.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Apellido", txtApellido.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Documento", txtDocumento.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Telefono", txtTelefono.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@Correo", txtCorreo.Text.Trim());

                        comando.Parameters.AddWithValue(
                            "@IdUsuario", idUsuarioSeleccionado.Value);

                        int filas = comando.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                "No se encontró el usuario.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
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
                    "Error al editar:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla para eliminar.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
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
                        "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                    using (SqlCommand comando =
                           new SqlCommand(consulta, cn))
                    {
                        comando.Parameters.AddWithValue(
                            "@IdUsuario", idUsuarioSeleccionado.Value);

                        int filas = comando.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show(
                                "No se encontró el usuario.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Usuario eliminado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Error de base de datos al eliminar:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" + ex.Message,
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

        // DOBLE CLIC EN LA TABLA
        private void dgvUsuarios_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            dgvUsuarios_CellClick(sender, e);
        }

        // CARGA DEL FORMULARIO
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
        }
    }
}
