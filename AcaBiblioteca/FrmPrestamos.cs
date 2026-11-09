using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Datos;

namespace AcaBiblioteca
{
    public partial class FrmPrestamos : Form
    {
        public FrmPrestamos()
        {
            InitializeComponent();

            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();

            LimpiarCampos();
        }

       

        private void CargarPrestamos()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        SELECT
                            IdPrestamo,
                            IdUsuario,
                            ISBN,
                            FechaPrestamo,
                            FechaDevolucion,
                            Estado
                        FROM Prestamos
                        ORDER BY IdPrestamo";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dgvPrestamos.DataSource = tabla;

                        if (dgvPrestamos.Columns.Contains("FechaPrestamo"))
                        {
                            dgvPrestamos.Columns["FechaPrestamo"]
                                .DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        if (dgvPrestamos.Columns.Contains("FechaDevolucion"))
                        {
                            dgvPrestamos.Columns["FechaDevolucion"]
                                .DefaultCellStyle.Format = "dd/MM/yyyy";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los préstamos:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

  

        private void CargarUsuarios()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        SELECT
                            IdUsuario,
                            Nombre,
                            Apellido,
                            Nombre + ' ' + Apellido AS NombreCompleto
                        FROM Usuarios
                        ORDER BY Nombre, Apellido";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        cmbUsuario.DataSource = tabla;
                        cmbUsuario.DisplayMember = "NombreCompleto";
                        cmbUsuario.ValueMember = "IdUsuario";

                        cmbUsuario.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los usuarios:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

     

        private void CargarLibros()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string consulta = @"
                        SELECT ISBN, Titulo
                        FROM Libros
                        ORDER BY Titulo";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        cmbLibro.DataSource = tabla;
                        cmbLibro.DisplayMember = "Titulo";
                        cmbLibro.ValueMember = "ISBN";

                        cmbLibro.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los libros:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

 

        private void LimpiarCampos()
        {
            cmbUsuario.SelectedIndex = -1;
            cmbLibro.SelectedIndex = -1;

            dtpFechaPrestamo.Value = DateTime.Now;

            dtpFechaDevolucion.Value = DateTime.Now;
            dtpFechaDevolucion.Checked = false;
        }

    

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

    

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex == -1 ||
                cmbLibro.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un usuario y un libro antes de guardar.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                int idUsuario = Convert.ToInt32(
                    cmbUsuario.SelectedValue);

                string isbn = cmbLibro.SelectedValue.ToString();

                DateTime fechaPrestamo = dtpFechaPrestamo.Value;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        try
                        {
     

                            string actualizarExistencias = @"
                                UPDATE Libros
                                SET Existencias = Existencias - 1
                                WHERE ISBN = @ISBN
                                AND Existencias > 0";

                            using (SqlCommand comando =
                                   new SqlCommand(
                                       actualizarExistencias,
                                       cn,
                                       transaccion))
                            {
                                comando.Parameters.AddWithValue("@ISBN", isbn);

                                int filas = comando.ExecuteNonQuery();

                                if (filas == 0)
                                {
                                    MessageBox.Show(
                                        "No hay existencias disponibles de este libro.",
                                        "Biblioteca",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    transaccion.Rollback();
                                    return;
                                }
                            }

              

                            string consulta = @"
                                INSERT INTO Prestamos
                                (IdUsuario, ISBN, FechaPrestamo,
                                 FechaDevolucion, Estado)
                                VALUES
                                (@IdUsuario, @ISBN, @FechaPrestamo,
                                 NULL, 'Prestado')";

                            using (SqlCommand comando =
                                   new SqlCommand(
                                       consulta,
                                       cn,
                                       transaccion))
                            {
                                comando.Parameters.AddWithValue(
                                    "@IdUsuario", idUsuario);

                                comando.Parameters.AddWithValue(
                                    "@ISBN", isbn);

                                comando.Parameters.AddWithValue(
                                    "@FechaPrestamo", fechaPrestamo);

                                comando.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Préstamo registrado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar el préstamo:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void dgvPrestamos_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvPrestamos.Rows[e.RowIndex];

            cmbUsuario.SelectedValue =
                Convert.ToInt32(fila.Cells["IdUsuario"].Value);

            cmbLibro.SelectedValue =
                fila.Cells["ISBN"].Value.ToString();

            dtpFechaPrestamo.Value =
                Convert.ToDateTime(fila.Cells["FechaPrestamo"].Value);

            if (fila.Cells["FechaDevolucion"].Value != DBNull.Value)
            {
                dtpFechaDevolucion.Value =
                    Convert.ToDateTime(fila.Cells["FechaDevolucion"].Value);

                dtpFechaDevolucion.Checked = true;
            }
            else
            {
                dtpFechaDevolucion.Value = DateTime.Now;
                dtpFechaDevolucion.Checked = false;
            }
        }

  

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvPrestamos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleccione un préstamo para eliminar.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int idPrestamo = Convert.ToInt32(
                    dgvPrestamos.CurrentRow.Cells["IdPrestamo"].Value);

                string isbn =
                    dgvPrestamos.CurrentRow.Cells["ISBN"].Value.ToString();

                string estado =
                    dgvPrestamos.CurrentRow.Cells["Estado"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar este préstamo?",
                    "Biblioteca",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        try
                        {
                         

                            string consulta = @"
                                DELETE FROM Prestamos
                                WHERE IdPrestamo = @IdPrestamo";

                            using (SqlCommand comando =
                                   new SqlCommand(
                                       consulta,
                                       cn,
                                       transaccion))
                            {
                                comando.Parameters.AddWithValue(
                                    "@IdPrestamo", idPrestamo);

                                int filas = comando.ExecuteNonQuery();

                                if (filas == 0)
                                    throw new Exception(
                                        "No se encontró el préstamo seleccionado.");
                            }

                 

                            if (estado == "Prestado")
                            {
                                string actualizar = @"
                                    UPDATE Libros
                                    SET Existencias = Existencias + 1
                                    WHERE ISBN = @ISBN";

                                using (SqlCommand comando =
                                       new SqlCommand(
                                           actualizar,
                                           cn,
                                           transaccion))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@ISBN", isbn);

                                    comando.ExecuteNonQuery();
                                }
                            }

                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Préstamo eliminado correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el préstamo:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

   

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvPrestamos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Seleccione un préstamo para registrar la devolución.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int idPrestamo = Convert.ToInt32(
                    dgvPrestamos.CurrentRow.Cells["IdPrestamo"].Value);

                string isbn =
                    dgvPrestamos.CurrentRow.Cells["ISBN"].Value.ToString();

                string estado =
                    dgvPrestamos.CurrentRow.Cells["Estado"].Value.ToString();

                if (estado == "Devuelto")
                {
                    MessageBox.Show(
                        "Este préstamo ya fue devuelto.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!dtpFechaDevolucion.Checked)
                {
                    MessageBox.Show(
                        "Seleccione la fecha de devolución antes de continuar.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DateTime fechaDevolucion =
                    dtpFechaDevolucion.Value;

                if (fechaDevolucion.Date < dtpFechaPrestamo.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha de devolución no puede ser anterior a la fecha del préstamo.",
                        "Biblioteca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de registrar la devolución de este libro?",
                    "Biblioteca",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        try
                        {
    

                            string consulta = @"
                                UPDATE Prestamos
                                SET FechaDevolucion = @FechaDevolucion,
                                    Estado = 'Devuelto'
                                WHERE IdPrestamo = @IdPrestamo
                                AND Estado = 'Prestado'";

                            using (SqlCommand comando =
                                   new SqlCommand(
                                       consulta,
                                       cn,
                                       transaccion))
                            {
                                comando.Parameters.AddWithValue(
                                    "@FechaDevolucion", fechaDevolucion);

                                comando.Parameters.AddWithValue(
                                    "@IdPrestamo", idPrestamo);

                                int filas = comando.ExecuteNonQuery();

                                if (filas == 0)
                                    throw new Exception(
                                        "El préstamo ya fue devuelto o no existe.");
                            }

                   

                            string actualizarExistencias = @"
                                UPDATE Libros
                                SET Existencias = Existencias + 1
                                WHERE ISBN = @ISBN";

                            using (SqlCommand comando =
                                   new SqlCommand(
                                       actualizarExistencias,
                                       cn,
                                       transaccion))
                            {
                                comando.Parameters.AddWithValue(
                                    "@ISBN", isbn);

                                comando.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Devolución registrada correctamente.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar la devolución:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
