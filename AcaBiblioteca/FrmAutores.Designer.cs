
namespace AcaBiblioteca
{
    partial class FrmAutores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            pnlDatos = new Panel();
            panel1 = new Panel();

            btnNuevo = new FontAwesome.Sharp.IconButton();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();

            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblApellido = new Label();
            lblNombre = new Label();
            dgvAutores = new DataGridView();

            pnlTitulo.SuspendLayout();
            pnlDatos.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            SuspendLayout();

            // pnlTitulo
            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Margin = new Padding(2);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1075, 56);
            pnlTitulo.TabIndex = 0;

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(433, 7);
            lblTitulo.Margin = new Padding(2, 0, 2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(336, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE AUTORES";

            // pnlDatos
            pnlDatos.BackColor = Color.WhiteSmoke;
            pnlDatos.Controls.Add(panel1);
            pnlDatos.Controls.Add(txtNombre);
            pnlDatos.Controls.Add(txtApellido);
            pnlDatos.Controls.Add(lblApellido);
            pnlDatos.Controls.Add(lblNombre);
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Location = new Point(0, 56);
            pnlDatos.Margin = new Padding(2);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(1075, 320);
            pnlDatos.TabIndex = 1;

            // panel1
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnEditar);
            panel1.Location = new Point(258, 230);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 48);
            panel1.TabIndex = 17;

            // btnNuevo
            btnNuevo.BackColor = Color.Transparent;
            btnNuevo.Font = new Font("Segoe Fluent Icons", 12F);
            btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuevo.IconSize = 25;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(22, 7);
            btnNuevo.Margin = new Padding(2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(117, 34);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;

            // btnCancelar
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe Fluent Icons", 12F);
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 25;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(556, 7);
            btnCancelar.Margin = new Padding(2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 34);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // btnGuardar
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.Font = new Font("Segoe Fluent Icons", 12F);
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 25;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(160, 7);
            btnGuardar.Margin = new Padding(2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(117, 34);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // btnEliminar
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Font = new Font("Segoe Fluent Icons", 12F);
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 25;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(430, 7);
            btnEliminar.Margin = new Padding(2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(117, 34);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // btnEditar
            btnEditar.BackColor = Color.Transparent;
            btnEditar.Font = new Font("Segoe Fluent Icons", 12F);
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            btnEditar.IconColor = Color.Black;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 25;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(294, 7);
            btnEditar.Margin = new Padding(2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(117, 34);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;

            // txtNombre
            txtNombre.Location = new Point(502, 65);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(274, 27);
            txtNombre.TabIndex = 4;

            // txtApellido
            txtApellido.Location = new Point(502, 152);
            txtApellido.Margin = new Padding(2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(274, 27);
            txtApellido.TabIndex = 3;

            // lblApellido
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApellido.Location = new Point(372, 152);
            lblApellido.Margin = new Padding(2, 0, 2, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(102, 28);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido: ";

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(372, 64);
            lblNombre.Margin = new Padding(2, 0, 2, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(94, 28);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";

            // dgvAutores
            dgvAutores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutores.Dock = DockStyle.Fill;
            dgvAutores.Location = new Point(0, 376);
            dgvAutores.Margin = new Padding(2);
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersWidth = 62;
            dgvAutores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.MultiSelect = false;
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.Size = new Size(1075, 384);
            dgvAutores.TabIndex = 2;

            dgvAutores.CellClick += dgvAutores_CellClick;
            dgvAutores.CellDoubleClick += dgvAutores_CellDoubleClick;

            // FrmAutores
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 760);
            Controls.Add(dgvAutores);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Margin = new Padding(2);
            Name = "FrmAutores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAutores";
            WindowState = FormWindowState.Maximized;
            Load += FrmAutores_Load;

            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlDatos;
        private DataGridView dgvAutores;
        private Label lblApellido;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Panel panel1;

        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}
