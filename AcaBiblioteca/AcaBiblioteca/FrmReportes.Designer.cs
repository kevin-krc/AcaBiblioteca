

using System.Drawing;
using System.Windows.Forms;

namespace AcaBiblioteca
{
    partial class FrmReportes
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
            pnlFiltros = new Panel();
            lblTipoReporte = new Label();
            cmbTipoReporte = new ComboBox();
            btnGenerar = new Button();
            btnLimpiar = new Button();
            dgvReportes = new DataGridView();

            pnlTitulo.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();


            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Height = 70;
            pnlTitulo.Controls.Add(lblTitulo);



            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Text = "GESTIÓN DE REPORTES";
            lblTitulo.Font = new Font(
                "Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;



            pnlFiltros.BackColor = Color.WhiteSmoke;
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 313;



            lblTipoReporte.Text = "Tipo De Reporte:";
            lblTipoReporte.Font = new Font(
                "Segoe UI", 13F, FontStyle.Bold);
            lblTipoReporte.TextAlign =
                ContentAlignment.MiddleRight;

            lblTipoReporte.Location = new Point(350, 103);
            lblTipoReporte.Size = new Size(230, 42);


            cmbTipoReporte.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbTipoReporte.Font = new Font(
                "Segoe UI", 12F);

            cmbTipoReporte.Location = new Point(610, 105);
            cmbTipoReporte.Size = new Size(420, 38);



            btnGenerar.Text = "Generar Reporte";
            btnGenerar.Font = new Font(
                "Segoe UI", 10F);

            btnGenerar.Location = new Point(610, 198);
            btnGenerar.Size = new Size(190, 42);
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;



            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Font = new Font(
                "Segoe UI", 10F);

            btnLimpiar.Location = new Point(845, 198);
            btnLimpiar.Size = new Size(170, 42);
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;



            pnlFiltros.Controls.Add(lblTipoReporte);
            pnlFiltros.Controls.Add(cmbTipoReporte);
            pnlFiltros.Controls.Add(btnGenerar);
            pnlFiltros.Controls.Add(btnLimpiar);



            dgvReportes.Dock = DockStyle.Fill;
            dgvReportes.Name = "dgvReportes";

            dgvReportes.BackgroundColor = Color.White;
            dgvReportes.BorderStyle = BorderStyle.FixedSingle;

            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.ReadOnly = true;
            dgvReportes.MultiSelect = false;

            dgvReportes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReportes.AutoGenerateColumns = true;

            dgvReportes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReportes.RowHeadersWidth = 40;
            dgvReportes.ColumnHeadersHeight = 35;
            dgvReportes.RowTemplate.Height = 33;

            dgvReportes.Font = new Font(
                "Segoe UI", 10F);

            dgvReportes.EnableHeadersVisualStyles = false;

            dgvReportes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.LightBlue;

            dgvReportes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Black;

            dgvReportes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvReportes.DefaultCellStyle.SelectionBackColor =
                Color.DodgerBlue;

            dgvReportes.DefaultCellStyle.SelectionForeColor =
                Color.White;


            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.WhiteSmoke;

            ClientSize = new Size(1100, 607);
            MinimumSize = new Size(900, 450);

            Name = "FrmReportes";
            Text = "Gestión de Reportes";

            Controls.Add(dgvReportes);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlTitulo);

            pnlTitulo.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();

            ResumeLayout(false);
        }

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlFiltros;
        private Label lblTipoReporte;
        private ComboBox cmbTipoReporte;
        private Button btnGenerar;
        private Button btnLimpiar;
        private DataGridView dgvReportes;
    }
}

