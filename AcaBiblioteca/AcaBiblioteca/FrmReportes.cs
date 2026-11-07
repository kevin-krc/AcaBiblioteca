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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();

            CargarTiposReporte();

            Load += FrmReportes_Load;
        }


        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();

            cmbTipoReporte.Items.Add("Préstamos activos");
            cmbTipoReporte.Items.Add("Préstamos devueltos");
            cmbTipoReporte.Items.Add("Inventario de libros");

            cmbTipoReporte.SelectedIndex = 1;
        }

   
        private void FrmReportes_Load(object? sender, EventArgs e)
        {
            GenerarReporte();
        }

   
        private void btnGenerar_Click(object? sender, EventArgs e)
        {
            GenerarReporte();
        }

 
        private void GenerarReporte()
        {
            if (cmbTipoReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un tipo de reporte.",
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string consulta = "";

                if (cmbTipoReporte.Text == "Préstamos activos")
                {
                    consulta = @"
                        SELECT
                            p.IdPrestamo,
                            u.Nombre + ' ' + u.Apellido AS Usuario,
                            l.ISBN,
                            l.Titulo,
                            p.FechaPrestamo,
                            p.Estado
                        FROM Prestamos p
                        INNER JOIN Usuarios u
                            ON p.IdUsuario = u.IdUsuario
                        INNER JOIN Libros l
                            ON p.ISBN = l.ISBN
                        WHERE p.Estado = 'Prestado'
                        ORDER BY p.FechaPrestamo DESC";
                }
                else if (cmbTipoReporte.Text == "Préstamos devueltos")
                {
                    consulta = @"
                        SELECT
                            p.IdPrestamo,
                            u.Nombre + ' ' + u.Apellido AS Usuario,
                            l.ISBN,
                            l.Titulo,
                            p.FechaPrestamo,
                            p.FechaDevolucion,
                            p.Estado
                        FROM Prestamos p
                        INNER JOIN Usuarios u
                            ON p.IdUsuario = u.IdUsuario
                        INNER JOIN Libros l
                            ON p.ISBN = l.ISBN
                        WHERE p.Estado = 'Devuelto'
                        ORDER BY p.FechaDevolucion DESC";
                }
                else if (cmbTipoReporte.Text == "Inventario de libros")
                {
                    consulta = @"
                        SELECT
                            l.ISBN,
                            l.Titulo,
                            a.Nombre + ' ' + a.Apellido AS Autor,
                            e.Nombre AS Editorial,
                            l.Categoria,
                            l.Anio,
                            l.Existencias
                        FROM Libros l
                        INNER JOIN Autores a
                            ON l.IdAutor = a.IdAutor
                        INNER JOIN Editoriales e
                            ON l.IdEditorial = e.IdEditorial
                        ORDER BY l.Titulo";
                }

                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dgvReportes.DataSource = null;
                        dgvReportes.DataSource = tabla;

                        if (dgvReportes.Columns.Contains("FechaPrestamo"))
                        {
                            dgvReportes.Columns["FechaPrestamo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        if (dgvReportes.Columns.Contains("FechaDevolucion"))
                        {
                            dgvReportes.Columns["FechaDevolucion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        }

                        if (tabla.Rows.Count == 0)
                        {
                            MessageBox.Show(
                                "No existen registros para este reporte.",
                                "Biblioteca",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar el reporte:\n" + ex.Message,
                    "Biblioteca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            cmbTipoReporte.SelectedIndex = -1;
            dgvReportes.DataSource = null;
        }
    }
}
