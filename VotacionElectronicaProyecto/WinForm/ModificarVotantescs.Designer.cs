namespace WinForm
{
    partial class ModificarVotantescs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarVotantescs));
            label1 = new Label();
            tbBuscar = new TextBox();
            btnBuscarMV = new CPresentacion.Boton();
            btnVolverMV = new CPresentacion.Boton();
            dgvListaVotantes = new DataGridView();
            Eliminar = new DataGridViewButtonColumn();
            lbnroIden = new Label();
            tbNroIdentificacion = new TextBox();
            tbNombre = new TextBox();
            lbNombre = new Label();
            tbApellido = new TextBox();
            lbApellido = new Label();
            tbContrasenia = new TextBox();
            lbContrasenia = new Label();
            btModificar = new CPresentacion.Boton();
            btRefrescar = new CPresentacion.Boton();
            ((System.ComponentModel.ISupportInitialize)dgvListaVotantes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 192, 255);
            label1.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "BUSCAR VOTANTES";
            // 
            // tbBuscar
            // 
            tbBuscar.Location = new Point(139, 19);
            tbBuscar.Name = "tbBuscar";
            tbBuscar.Size = new Size(303, 23);
            tbBuscar.TabIndex = 1;
            // 
            // btnBuscarMV
            // 
            btnBuscarMV.BackColor = SystemColors.ActiveBorder;
            btnBuscarMV.BackgroundColor = SystemColors.ActiveBorder;
            btnBuscarMV.BorderColor = Color.Black;
            btnBuscarMV.BorderRadius = 30;
            btnBuscarMV.BorderSize = 1;
            btnBuscarMV.FlatAppearance.BorderSize = 0;
            btnBuscarMV.FlatStyle = FlatStyle.Flat;
            btnBuscarMV.ForeColor = Color.Black;
            btnBuscarMV.Location = new Point(447, 16);
            btnBuscarMV.Margin = new Padding(3, 2, 3, 2);
            btnBuscarMV.Name = "btnBuscarMV";
            btnBuscarMV.Size = new Size(84, 24);
            btnBuscarMV.TabIndex = 6;
            btnBuscarMV.Text = "Buscar";
            btnBuscarMV.TextColor = Color.Black;
            btnBuscarMV.UseVisualStyleBackColor = false;
            btnBuscarMV.Click += btnBuscarMV_Click;
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
            btnVolverMV.Location = new Point(705, 16);
            btnVolverMV.Margin = new Padding(3, 2, 3, 2);
            btnVolverMV.Name = "btnVolverMV";
            btnVolverMV.Size = new Size(84, 24);
            btnVolverMV.TabIndex = 7;
            btnVolverMV.Text = "Volver";
            btnVolverMV.TextColor = Color.Black;
            btnVolverMV.UseVisualStyleBackColor = false;
            btnVolverMV.Click += btnVolverMV_Click;
            // 
            // dgvListaVotantes
            // 
            dgvListaVotantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaVotantes.Columns.AddRange(new DataGridViewColumn[] { Eliminar });
            dgvListaVotantes.Location = new Point(37, 171);
            dgvListaVotantes.Name = "dgvListaVotantes";
            dgvListaVotantes.RowHeadersWidth = 51;
            dgvListaVotantes.Size = new Size(727, 257);
            dgvListaVotantes.TabIndex = 0;
            dgvListaVotantes.CellContentClick += dgvListaVotantes_CellContentClick;
            dgvListaVotantes.RowHeaderMouseClick += dgvListaVotantes_RowHeaderMouseClick;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "Eliminar";
            Eliminar.Resizable = DataGridViewTriState.True;
            // 
            // lbnroIden
            // 
            lbnroIden.AutoSize = true;
            lbnroIden.BackColor = Color.FromArgb(192, 192, 255);
            lbnroIden.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnroIden.Location = new Point(43, 84);
            lbnroIden.Name = "lbnroIden";
            lbnroIden.Size = new Size(100, 15);
            lbnroIden.TabIndex = 8;
            lbnroIden.Text = "Nro Identificación:";
            // 
            // tbNroIdentificacion
            // 
            tbNroIdentificacion.Location = new Point(149, 79);
            tbNroIdentificacion.Name = "tbNroIdentificacion";
            tbNroIdentificacion.Size = new Size(132, 23);
            tbNroIdentificacion.TabIndex = 9;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(97, 108);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(184, 23);
            tbNombre.TabIndex = 11;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.FromArgb(192, 192, 255);
            lbNombre.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNombre.Location = new Point(43, 113);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(48, 15);
            lbNombre.TabIndex = 10;
            lbNombre.Text = "Nombre:";
            // 
            // tbApellido
            // 
            tbApellido.Location = new Point(366, 77);
            tbApellido.Name = "tbApellido";
            tbApellido.Size = new Size(183, 23);
            tbApellido.TabIndex = 13;
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.BackColor = Color.FromArgb(192, 192, 255);
            lbApellido.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbApellido.Location = new Point(311, 81);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(52, 15);
            lbApellido.TabIndex = 12;
            lbApellido.Text = "Apellido:";
            // 
            // tbContrasenia
            // 
            tbContrasenia.Location = new Point(380, 105);
            tbContrasenia.Name = "tbContrasenia";
            tbContrasenia.Size = new Size(168, 23);
            tbContrasenia.TabIndex = 15;
            // 
            // lbContrasenia
            // 
            lbContrasenia.AutoSize = true;
            lbContrasenia.BackColor = Color.FromArgb(192, 192, 255);
            lbContrasenia.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbContrasenia.Location = new Point(310, 110);
            lbContrasenia.Name = "lbContrasenia";
            lbContrasenia.Size = new Size(64, 15);
            lbContrasenia.TabIndex = 14;
            lbContrasenia.Text = "Contraseña:";
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
            btModificar.Location = new Point(668, 65);
            btModificar.Margin = new Padding(3, 2, 3, 2);
            btModificar.Name = "btModificar";
            btModificar.Size = new Size(96, 31);
            btModificar.TabIndex = 16;
            btModificar.Text = "Modificar";
            btModificar.TextColor = Color.Black;
            btModificar.UseVisualStyleBackColor = false;
            btModificar.Click += btModificar_Click;
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
            btRefrescar.Location = new Point(668, 105);
            btRefrescar.Margin = new Padding(3, 2, 3, 2);
            btRefrescar.Name = "btRefrescar";
            btRefrescar.Size = new Size(96, 31);
            btRefrescar.TabIndex = 17;
            btRefrescar.Text = "Refrescar";
            btRefrescar.TextColor = Color.Black;
            btRefrescar.UseVisualStyleBackColor = false;
            btRefrescar.Click += btRefrescar_Click;
            // 
            // ModificarVotantescs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btRefrescar);
            Controls.Add(btModificar);
            Controls.Add(tbContrasenia);
            Controls.Add(lbContrasenia);
            Controls.Add(tbApellido);
            Controls.Add(lbApellido);
            Controls.Add(tbNombre);
            Controls.Add(lbNombre);
            Controls.Add(tbNroIdentificacion);
            Controls.Add(lbnroIden);
            Controls.Add(dgvListaVotantes);
            Controls.Add(btnVolverMV);
            Controls.Add(btnBuscarMV);
            Controls.Add(tbBuscar);
            Controls.Add(label1);
            Name = "ModificarVotantescs";
            Text = "ModificarVotantescs";
            Load += FormVotantes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaVotantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbBuscar;
        private CPresentacion.Boton btnBuscarMV;
        private CPresentacion.Boton btnVolverMV;
        private DataGridView dgvListaVotantes;
        private DataGridViewButtonColumn Eliminar;
        private Label lbnroIden;
        private TextBox tbNroIdentificacion;
        private TextBox tbNombre;
        private Label lbNombre;
        private TextBox tbApellido;
        private Label lbApellido;
        private TextBox tbContrasenia;
        private Label lbContrasenia;
        private CPresentacion.Boton btModificar;
        private CPresentacion.Boton btRefrescar;
    }
}