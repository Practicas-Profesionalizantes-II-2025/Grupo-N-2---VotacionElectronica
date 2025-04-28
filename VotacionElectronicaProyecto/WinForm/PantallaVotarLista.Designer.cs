namespace WinForm
{
    partial class PantallaVotarLista
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
            pictureBox1 = new PictureBox();
            Listas = new ComboBox();
            label1 = new Label();
            ImagenLista = new PictureBox();
            DGLista = new DataGridView();
            ColumnaIntegrantes = new DataGridViewTextBoxColumn();
            ColumnaPuesto = new DataGridViewTextBoxColumn();
            btnVolverVL = new CPresentacion.Boton();
            btnVotoBlancoVL = new CPresentacion.Boton();
            btnVotarVL = new CPresentacion.Boton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagenLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGLista).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(119, 98);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(557, 265);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Listas
            // 
            Listas.FormattingEnabled = true;
            Listas.Location = new Point(315, 49);
            Listas.Name = "Listas";
            Listas.Size = new Size(156, 23);
            Listas.TabIndex = 4;
            Listas.Text = "Seleccionar Lista";
            Listas.SelectedIndexChanged += Listas_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(191, 187);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 5;
            label1.Text = "Lista";
            // 
            // ImagenLista
            // 
            ImagenLista.BackColor = Color.Red;
            ImagenLista.BackgroundImage = Properties.Resources.Imagen_Votante;
            ImagenLista.BackgroundImageLayout = ImageLayout.None;
            ImagenLista.Location = new Point(169, 205);
            ImagenLista.Name = "ImagenLista";
            ImagenLista.Size = new Size(88, 66);
            ImagenLista.TabIndex = 6;
            ImagenLista.TabStop = false;
            // 
            // DGLista
            // 
            DGLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGLista.Columns.AddRange(new DataGridViewColumn[] { ColumnaIntegrantes, ColumnaPuesto });
            DGLista.Location = new Point(323, 120);
            DGLista.Name = "DGLista";
            DGLista.RowHeadersWidth = 51;
            DGLista.Size = new Size(302, 223);
            DGLista.TabIndex = 11;
            DGLista.DataBindingComplete += DGLista_DataBindingComplete;
            // 
            // ColumnaIntegrantes
            // 
            ColumnaIntegrantes.HeaderText = "Integrantes";
            ColumnaIntegrantes.MinimumWidth = 6;
            ColumnaIntegrantes.Name = "ColumnaIntegrantes";
            ColumnaIntegrantes.Width = 125;
            // 
            // ColumnaPuesto
            // 
            ColumnaPuesto.HeaderText = "Puesto";
            ColumnaPuesto.MinimumWidth = 6;
            ColumnaPuesto.Name = "ColumnaPuesto";
            ColumnaPuesto.Width = 125;
            // 
            // btnVolverVL
            // 
            btnVolverVL.BackColor = SystemColors.ActiveBorder;
            btnVolverVL.BackgroundColor = SystemColors.ActiveBorder;
            btnVolverVL.BorderColor = Color.Black;
            btnVolverVL.BorderRadius = 40;
            btnVolverVL.BorderSize = 1;
            btnVolverVL.FlatAppearance.BorderSize = 0;
            btnVolverVL.FlatStyle = FlatStyle.Flat;
            btnVolverVL.ForeColor = Color.Black;
            btnVolverVL.Location = new Point(636, 32);
            btnVolverVL.Margin = new Padding(3, 2, 3, 2);
            btnVolverVL.Name = "btnVolverVL";
            btnVolverVL.Size = new Size(107, 29);
            btnVolverVL.TabIndex = 12;
            btnVolverVL.Text = "Volver";
            btnVolverVL.TextColor = Color.Black;
            btnVolverVL.UseVisualStyleBackColor = false;
            btnVolverVL.Click += btnVolverVL_Click;
            // 
            // btnVotoBlancoVL
            // 
            btnVotoBlancoVL.BackColor = SystemColors.ActiveBorder;
            btnVotoBlancoVL.BackgroundColor = SystemColors.ActiveBorder;
            btnVotoBlancoVL.BorderColor = Color.Black;
            btnVotoBlancoVL.BorderRadius = 40;
            btnVotoBlancoVL.BorderSize = 1;
            btnVotoBlancoVL.FlatAppearance.BorderSize = 0;
            btnVotoBlancoVL.FlatStyle = FlatStyle.Flat;
            btnVotoBlancoVL.ForeColor = Color.Black;
            btnVotoBlancoVL.Location = new Point(184, 397);
            btnVotoBlancoVL.Margin = new Padding(3, 2, 3, 2);
            btnVotoBlancoVL.Name = "btnVotoBlancoVL";
            btnVotoBlancoVL.Size = new Size(107, 29);
            btnVotoBlancoVL.TabIndex = 13;
            btnVotoBlancoVL.Text = "Votar en Blanco";
            btnVotoBlancoVL.TextColor = Color.Black;
            btnVotoBlancoVL.UseVisualStyleBackColor = false;
            btnVotoBlancoVL.Click += btnVotoBlancoVL_Click;
            // 
            // btnVotarVL
            // 
            btnVotarVL.BackColor = SystemColors.ActiveBorder;
            btnVotarVL.BackgroundColor = SystemColors.ActiveBorder;
            btnVotarVL.BorderColor = Color.Black;
            btnVotarVL.BorderRadius = 40;
            btnVotarVL.BorderSize = 1;
            btnVotarVL.FlatAppearance.BorderSize = 0;
            btnVotarVL.FlatStyle = FlatStyle.Flat;
            btnVotarVL.ForeColor = Color.Black;
            btnVotarVL.Location = new Point(513, 397);
            btnVotarVL.Margin = new Padding(3, 2, 3, 2);
            btnVotarVL.Name = "btnVotarVL";
            btnVotarVL.Size = new Size(107, 29);
            btnVotarVL.TabIndex = 14;
            btnVotarVL.Text = "Votar";
            btnVotarVL.TextColor = Color.Black;
            btnVotarVL.UseVisualStyleBackColor = false;
            btnVotarVL.Click += BtnVotarVL_Click;
            // 
            // PantallaVotarLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVotarVL);
            Controls.Add(btnVotoBlancoVL);
            Controls.Add(btnVolverVL);
            Controls.Add(DGLista);
            Controls.Add(ImagenLista);
            Controls.Add(label1);
            Controls.Add(Listas);
            Controls.Add(pictureBox1);
            Name = "PantallaVotarLista";
            Text = " ";
            Load += PantallaVotarLista_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagenLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox Listas;
        private Label label1;
        private PictureBox ImagenLista;
        private DataGridView DGLista;
        private DataGridViewTextBoxColumn ColumnaIntegrantes;
        private DataGridViewTextBoxColumn ColumnaPuesto;
        private CPresentacion.Boton btnVolverVL;
        private CPresentacion.Boton btnVotoBlancoVL;
        private CPresentacion.Boton btnVotarVL;
    }
}