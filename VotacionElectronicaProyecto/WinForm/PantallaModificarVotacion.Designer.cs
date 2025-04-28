using System.Windows.Forms;

namespace WinForm
{
    partial class PantallaModificarVotacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvListadoEleccion = new DataGridView();
            Eliminar = new DataGridViewButtonColumn();
            btnVolverMV = new CPresentacion.Boton();
            tbNombreEleccion = new TextBox();
            lbNombreEleccion = new Label();
            tbDescripcionEleccion = new TextBox();
            lbDescripcion = new Label();
            tbCantidadListas = new TextBox();
            lbCantidad = new Label();
            btModificar = new CPresentacion.Boton();
            btnBuscarME = new CPresentacion.Boton();
            tbBuscarElecciones = new TextBox();
            label1 = new Label();
            btRefrescar = new CPresentacion.Boton();
            lbFechaFin = new Label();
            dtFechafin = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvListadoEleccion).BeginInit();
            SuspendLayout();
            // 
            // dgvListadoEleccion
            // 
            dgvListadoEleccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListadoEleccion.Columns.AddRange(new DataGridViewColumn[] { Eliminar });
            dgvListadoEleccion.Location = new Point(48, 220);
            dgvListadoEleccion.Name = "dgvListadoEleccion";
            dgvListadoEleccion.Size = new Size(718, 195);
            dgvListadoEleccion.TabIndex = 0;
            dgvListadoEleccion.CellContentClick += dgvListadoEleccion_CellContentClick;
            dgvListadoEleccion.DataBindingComplete += dataGridView1_DataBindingComplete;
            dgvListadoEleccion.RowHeaderMouseClick += dgvListadoEleccion_RowHeaderMouseClick;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "Eliminar";
            // 
            // btnVolverMV
            // 
            btnVolverMV.BackColor = SystemColors.ActiveBorder;
            btnVolverMV.BackgroundColor = SystemColors.ActiveBorder;
            btnVolverMV.BorderColor = Color.Black;
            btnVolverMV.BorderRadius = 30;
            btnVolverMV.BorderSize = 1;
            btnVolverMV.FlatAppearance.BorderSize = 0;
            btnVolverMV.FlatStyle = FlatStyle.Flat;
            btnVolverMV.ForeColor = Color.Black;
            btnVolverMV.Location = new Point(704, 11);
            btnVolverMV.Margin = new Padding(3, 2, 3, 2);
            btnVolverMV.Name = "btnVolverMV";
            btnVolverMV.Size = new Size(84, 24);
            btnVolverMV.TabIndex = 8;
            btnVolverMV.Text = "Volver";
            btnVolverMV.TextColor = Color.Black;
            btnVolverMV.UseVisualStyleBackColor = false;
            btnVolverMV.Click += btnVolverMV_Click;
            // 
            // tbNombreEleccion
            // 
            tbNombreEleccion.Location = new Point(158, 80);
            tbNombreEleccion.Name = "tbNombreEleccion";
            tbNombreEleccion.Size = new Size(147, 23);
            tbNombreEleccion.TabIndex = 11;
            // 
            // lbNombreEleccion
            // 
            lbNombreEleccion.AutoSize = true;
            lbNombreEleccion.BackColor = Color.FromArgb(192, 192, 255);
            lbNombreEleccion.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNombreEleccion.Location = new Point(59, 85);
            lbNombreEleccion.Name = "lbNombreEleccion";
            lbNombreEleccion.Size = new Size(93, 15);
            lbNombreEleccion.TabIndex = 10;
            lbNombreEleccion.Text = "Nombre Eleccion:";
            // 
            // tbDescripcionEleccion
            // 
            tbDescripcionEleccion.Location = new Point(133, 109);
            tbDescripcionEleccion.Multiline = true;
            tbDescripcionEleccion.Name = "tbDescripcionEleccion";
            tbDescripcionEleccion.Size = new Size(172, 65);
            tbDescripcionEleccion.TabIndex = 13;
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.BackColor = Color.FromArgb(192, 192, 255);
            lbDescripcion.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDescripcion.Location = new Point(59, 114);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(68, 15);
            lbDescripcion.TabIndex = 12;
            lbDescripcion.Text = "Descripcion:";
            // 
            // tbCantidadListas
            // 
            tbCantidadListas.Location = new Point(416, 78);
            tbCantidadListas.Name = "tbCantidadListas";
            tbCantidadListas.Size = new Size(99, 23);
            tbCantidadListas.TabIndex = 15;
            // 
            // lbCantidad
            // 
            lbCantidad.AutoSize = true;
            lbCantidad.BackColor = Color.FromArgb(192, 192, 255);
            lbCantidad.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCantidad.Location = new Point(317, 83);
            lbCantidad.Name = "lbCantidad";
            lbCantidad.Size = new Size(88, 15);
            lbCantidad.TabIndex = 14;
            lbCantidad.Text = "Cantidad Listas:";
            // 
            // btModificar
            // 
            btModificar.BackColor = SystemColors.ActiveBorder;
            btModificar.BackgroundColor = SystemColors.ActiveBorder;
            btModificar.BorderColor = Color.Black;
            btModificar.BorderRadius = 30;
            btModificar.BorderSize = 1;
            btModificar.FlatAppearance.BorderSize = 0;
            btModificar.FlatStyle = FlatStyle.Flat;
            btModificar.ForeColor = Color.Black;
            btModificar.Location = new Point(664, 71);
            btModificar.Margin = new Padding(3, 2, 3, 2);
            btModificar.Name = "btModificar";
            btModificar.Size = new Size(96, 31);
            btModificar.TabIndex = 17;
            btModificar.Text = "Modificar";
            btModificar.TextColor = Color.Black;
            btModificar.UseVisualStyleBackColor = false;
            btModificar.Click += btModificar_Click;
            // 
            // btnBuscarME
            // 
            btnBuscarME.BackColor = SystemColors.ActiveBorder;
            btnBuscarME.BackgroundColor = SystemColors.ActiveBorder;
            btnBuscarME.BorderColor = Color.Black;
            btnBuscarME.BorderRadius = 30;
            btnBuscarME.BorderSize = 1;
            btnBuscarME.FlatAppearance.BorderSize = 0;
            btnBuscarME.FlatStyle = FlatStyle.Flat;
            btnBuscarME.ForeColor = Color.Black;
            btnBuscarME.Location = new Point(485, 10);
            btnBuscarME.Margin = new Padding(3, 2, 3, 2);
            btnBuscarME.Name = "btnBuscarME";
            btnBuscarME.Size = new Size(84, 24);
            btnBuscarME.TabIndex = 20;
            btnBuscarME.Text = "Buscar";
            btnBuscarME.TextColor = Color.Black;
            btnBuscarME.UseVisualStyleBackColor = false;
            btnBuscarME.Click += btnBuscarME_Click;
            // 
            // tbBuscarElecciones
            // 
            tbBuscarElecciones.Location = new Point(177, 13);
            tbBuscarElecciones.Name = "tbBuscarElecciones";
            tbBuscarElecciones.Size = new Size(303, 23);
            tbBuscarElecciones.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 192, 255);
            label1.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 16);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 18;
            label1.Text = "BUSCAR ELECCIONES:";
            // 
            // btRefrescar
            // 
            btRefrescar.BackColor = SystemColors.ActiveBorder;
            btRefrescar.BackgroundColor = SystemColors.ActiveBorder;
            btRefrescar.BorderColor = Color.Black;
            btRefrescar.BorderRadius = 30;
            btRefrescar.BorderSize = 1;
            btRefrescar.FlatAppearance.BorderSize = 0;
            btRefrescar.FlatStyle = FlatStyle.Flat;
            btRefrescar.ForeColor = Color.Black;
            btRefrescar.Location = new Point(664, 112);
            btRefrescar.Margin = new Padding(3, 2, 3, 2);
            btRefrescar.Name = "btRefrescar";
            btRefrescar.Size = new Size(96, 31);
            btRefrescar.TabIndex = 21;
            btRefrescar.Text = "Refrescar";
            btRefrescar.TextColor = Color.Black;
            btRefrescar.UseVisualStyleBackColor = false;
            btRefrescar.Click += btRefrescar_Click;
            // 
            // lbFechaFin
            // 
            lbFechaFin.AutoSize = true;
            lbFechaFin.BackColor = Color.FromArgb(192, 192, 255);
            lbFechaFin.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFechaFin.Location = new Point(317, 112);
            lbFechaFin.Name = "lbFechaFin";
            lbFechaFin.Size = new Size(99, 15);
            lbFechaFin.TabIndex = 22;
            lbFechaFin.Text = "Fecha fin eleccion:";
            // 
            // dtFechafin
            // 
            dtFechafin.Location = new Point(422, 108);
            dtFechafin.Name = "dtFechafin";
            dtFechafin.Size = new Size(167, 23);
            dtFechafin.TabIndex = 23;
            // 
            // PantallaModificarVotacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(dtFechafin);
            Controls.Add(lbFechaFin);
            Controls.Add(btRefrescar);
            Controls.Add(btnBuscarME);
            Controls.Add(tbBuscarElecciones);
            Controls.Add(label1);
            Controls.Add(btModificar);
            Controls.Add(tbCantidadListas);
            Controls.Add(lbCantidad);
            Controls.Add(tbDescripcionEleccion);
            Controls.Add(lbDescripcion);
            Controls.Add(tbNombreEleccion);
            Controls.Add(lbNombreEleccion);
            Controls.Add(btnVolverMV);
            Controls.Add(dgvListadoEleccion);
            Name = "PantallaModificarVotacion";
            Text = "PantallaModificarVotacion";
            Load += PantallaModificarVotacion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListadoEleccion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListadoEleccion;
        private DataGridViewButtonColumn Eliminar;
        private CPresentacion.Boton btnVolverMV;
        private TextBox tbNombreEleccion;
        private Label lbNombreEleccion;
        private TextBox tbDescripcionEleccion;
        private Label lbDescripcion;
        private TextBox tbCantidadListas;
        private Label lbCantidad;
        private CPresentacion.Boton btModificar;
        private CPresentacion.Boton btnBuscarME;
        private TextBox tbBuscarElecciones;
        private Label label1;
        private CPresentacion.Boton btRefrescar;
        private Label lbFechaFin;
        private DateTimePicker dtFechafin;
    }
}