
using System.Drawing;
using System.Windows.Forms;

namespace AcaBiblioteca
{
    partial class FrmPrestamos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTitulo = new Panel();
            lblTitulo = new Label();

            pnlFormulario = new Panel();

            lblUsuario = new Label();
            cmbUsuario = new ComboBox();

            lblLibro = new Label();
            cmbLibro = new ComboBox();

            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();

            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();

            flpBotones = new FlowLayoutPanel();

            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();

            dgvPrestamos = new DataGridView();

            pnlTitulo.SuspendLayout();
            pnlFormulario.SuspendLayout();
            flpBotones.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();

            SuspendLayout();

   

            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Height = 45;
            pnlTitulo.Controls.Add(lblTitulo);

       

            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Text = "GESTIÓN DE PRÉSTAMOS";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

           

            pnlFormulario.Dock = DockStyle.Top;
            pnlFormulario.Height = 310;
            pnlFormulario.BackColor = Color.WhiteSmoke;

       

            lblUsuario.Text = "Usuario:";
            lblUsuario.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblUsuario.Size = new Size(150, 30);
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;

            cmbUsuario.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbUsuario.Font = new Font("Segoe UI", 10F);
            cmbUsuario.Size = new Size(180, 30);

    

            lblLibro.Text = "Libro:";
            lblLibro.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblLibro.Size = new Size(150, 30);
            lblLibro.TextAlign = ContentAlignment.MiddleRight;

            cmbLibro.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbLibro.Font = new Font("Segoe UI", 10F);
            cmbLibro.Size = new Size(180, 30);


            lblFechaPrestamo.Text = "Fecha Préstamo:";
            lblFechaPrestamo.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblFechaPrestamo.Size = new Size(150, 30);
            lblFechaPrestamo.TextAlign = ContentAlignment.MiddleRight;

            dtpFechaPrestamo.Format =
                DateTimePickerFormat.Short;
            dtpFechaPrestamo.Font = new Font("Segoe UI", 9F);
            dtpFechaPrestamo.Size = new Size(180, 30);


            lblFechaDevolucion.Text = "Fecha Devolución:";
            lblFechaDevolucion.Font = new Font(
                "Segoe UI", 11F, FontStyle.Bold);
            lblFechaDevolucion.Size = new Size(150, 30);
            lblFechaDevolucion.TextAlign = ContentAlignment.MiddleRight;

            dtpFechaDevolucion.Format =
                DateTimePickerFormat.Short;
            dtpFechaDevolucion.Font = new Font("Segoe UI", 9F);
            dtpFechaDevolucion.Size = new Size(180, 30);


            dtpFechaDevolucion.ShowCheckBox = true;
            dtpFechaDevolucion.Checked = false;


            flpBotones.FlowDirection =
                FlowDirection.LeftToRight;

            flpBotones.WrapContents = false;
            flpBotones.Size = new Size(690, 45);

            ConfigurarBoton(btnNuevo, "Nuevo");
            ConfigurarBoton(btnGuardar, "Guardar");
            ConfigurarBoton(btnEditar, "Editar");
            ConfigurarBoton(btnEliminar, "Eliminar");
            ConfigurarBoton(btnCancelar, "Cancelar");

            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            flpBotones.Controls.Add(btnNuevo);
            flpBotones.Controls.Add(btnGuardar);
            flpBotones.Controls.Add(btnEditar);
            flpBotones.Controls.Add(btnEliminar);
            flpBotones.Controls.Add(btnCancelar);


            dgvPrestamos.Dock = DockStyle.Fill;
            dgvPrestamos.Name = "dgvPrestamos";

            dgvPrestamos.BackgroundColor = Color.White;
            dgvPrestamos.BorderStyle = BorderStyle.FixedSingle;

            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dgvPrestamos.ReadOnly = true;

            dgvPrestamos.MultiSelect = false;

            dgvPrestamos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPrestamos.AutoGenerateColumns = true;

            dgvPrestamos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPrestamos.RowHeadersWidth = 40;
            dgvPrestamos.ColumnHeadersHeight = 35;
            dgvPrestamos.RowTemplate.Height = 30;

            dgvPrestamos.Font = new Font("Segoe UI", 9F);

            dgvPrestamos.EnableHeadersVisualStyles = false;

            dgvPrestamos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.LightBlue;

            dgvPrestamos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Black;

            dgvPrestamos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvPrestamos.DefaultCellStyle.SelectionBackColor =
                Color.DodgerBlue;

            dgvPrestamos.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvPrestamos.CellDoubleClick +=
                dgvPrestamos_CellDoubleClick;



            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1100, 650);
            MinimumSize = new Size(850, 500);

            Name = "FrmPrestamos";
            Text = "Gestión de Préstamos";

            BackColor = Color.WhiteSmoke;

            Controls.Add(dgvPrestamos);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlTitulo);

            
            pnlFormulario.Controls.Add(lblUsuario);
            pnlFormulario.Controls.Add(cmbUsuario);

            pnlFormulario.Controls.Add(lblLibro);
            pnlFormulario.Controls.Add(cmbLibro);

            pnlFormulario.Controls.Add(lblFechaPrestamo);
            pnlFormulario.Controls.Add(dtpFechaPrestamo);

            pnlFormulario.Controls.Add(lblFechaDevolucion);
            pnlFormulario.Controls.Add(dtpFechaDevolucion);

            pnlFormulario.Controls.Add(flpBotones);

            pnlFormulario.Resize +=
                pnlFormulario_Resize;

            pnlFormulario_Resize(null, EventArgs.Empty);

            pnlTitulo.ResumeLayout(false);
            pnlFormulario.ResumeLayout(false);
            flpBotones.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();

            ResumeLayout(false);
        }

       
        private void ConfigurarBoton(Button boton, string texto)
        {
            boton.Text = texto;
            boton.Font = new Font("Segoe UI", 9F);
            boton.Size = new Size(100, 35);
            boton.Margin = new Padding(10, 5, 10, 5);
            boton.UseVisualStyleBackColor = true;
        }

        private void pnlFormulario_Resize(object? sender, System.EventArgs e)
        {
            int centro = pnlFormulario.ClientSize.Width / 2;

            int xEtiqueta = centro - 260;
            int xControl = centro - 90;

            lblUsuario.Location = new Point(xEtiqueta, 30);
            cmbUsuario.Location = new Point(xControl, 33);

            lblLibro.Location = new Point(xEtiqueta, 80);
            cmbLibro.Location = new Point(xControl, 83);

            lblFechaPrestamo.Location = new Point(xEtiqueta, 135);
            dtpFechaPrestamo.Location = new Point(xControl, 138);

            lblFechaDevolucion.Location = new Point(xEtiqueta, 190);
            dtpFechaDevolucion.Location = new Point(xControl, 193);

            flpBotones.Location = new Point(
                centro - flpBotones.Width / 2, 255);
        }

        private Panel pnlTitulo;
        private Label lblTitulo;

        private Panel pnlFormulario;

        private Label lblUsuario;
        private ComboBox cmbUsuario;

        private Label lblLibro;
        private ComboBox cmbLibro;

        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;

        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;

        private FlowLayoutPanel flpBotones;

        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;

        private DataGridView dgvPrestamos;
    }
}
