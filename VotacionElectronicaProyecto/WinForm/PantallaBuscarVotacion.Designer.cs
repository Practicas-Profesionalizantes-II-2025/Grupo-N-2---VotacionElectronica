namespace WinForm
{
    partial class PantallaBuscarVotacion
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
            VotacionSeleccionada = new ComboBox();
            btnVerResultadosBV = new CPresentacion.Boton();
            btnVolverBV = new CPresentacion.Boton();
            dgvResultados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // VotacionSeleccionada
            // 
            VotacionSeleccionada.FormattingEnabled = true;
            VotacionSeleccionada.Location = new Point(187, 35);
            VotacionSeleccionada.Margin = new Padding(3, 4, 3, 4);
            VotacionSeleccionada.Name = "VotacionSeleccionada";
            VotacionSeleccionada.Size = new Size(230, 28);
            VotacionSeleccionada.TabIndex = 2;
            VotacionSeleccionada.Text = "Seleccionar Votación";
            // 
            // btnVerResultadosBV
            // 
            btnVerResultadosBV.BackColor = SystemColors.ActiveBorder;
            btnVerResultadosBV.BackgroundColor = SystemColors.ActiveBorder;
            btnVerResultadosBV.BorderColor = Color.Black;
            btnVerResultadosBV.BorderRadius = 38;
            btnVerResultadosBV.BorderSize = 1;
            btnVerResultadosBV.FlatAppearance.BorderSize = 0;
            btnVerResultadosBV.FlatStyle = FlatStyle.Flat;
            btnVerResultadosBV.ForeColor = Color.Black;
            btnVerResultadosBV.Location = new Point(488, 29);
            btnVerResultadosBV.Name = "btnVerResultadosBV";
            btnVerResultadosBV.Size = new Size(162, 36);
            btnVerResultadosBV.TabIndex = 6;
            btnVerResultadosBV.Text = "Ver Resultados";
            btnVerResultadosBV.TextColor = Color.Black;
            btnVerResultadosBV.UseVisualStyleBackColor = false;
            btnVerResultadosBV.Click += btnVerResultadosBV_Click;
            // 
            // btnVolverBV
            // 
            btnVolverBV.BackColor = SystemColors.ActiveBorder;
            btnVolverBV.BackgroundColor = SystemColors.ActiveBorder;
            btnVolverBV.BorderColor = Color.Black;
            btnVolverBV.BorderRadius = 35;
            btnVolverBV.BorderSize = 1;
            btnVolverBV.FlatAppearance.BorderSize = 0;
            btnVolverBV.FlatStyle = FlatStyle.Flat;
            btnVolverBV.ForeColor = Color.Black;
            btnVolverBV.Location = new Point(773, 35);
            btnVolverBV.Name = "btnVolverBV";
            btnVolverBV.Size = new Size(93, 35);
            btnVolverBV.TabIndex = 7;
            btnVolverBV.Text = "Volver";
            btnVolverBV.TextColor = Color.Black;
            btnVolverBV.UseVisualStyleBackColor = false;
            btnVolverBV.Click += btnVolverBV_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(52, 151);
            dgvResultados.Margin = new Padding(3, 4, 3, 4);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(814, 371);
            dgvResultados.TabIndex = 8;
           // 
           // PantallaBuscarVotacion
           // 
           AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(914, 600);
            Controls.Add(dgvResultados);
            Controls.Add(btnVolverBV);
            Controls.Add(btnVerResultadosBV);
            Controls.Add(VotacionSeleccionada);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PantallaBuscarVotacion";
            Text = "PantallaBuscarVotacion";
            Load += PantallaBuscarVotacion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox VotacionBuscada;
        private ComboBox VotacionSeleccionada;
        private CPresentacion.Boton btnVerResultadosBV;
        private CPresentacion.Boton btnVolverBV;
        private DataGridView dgvResultados;
    }
}