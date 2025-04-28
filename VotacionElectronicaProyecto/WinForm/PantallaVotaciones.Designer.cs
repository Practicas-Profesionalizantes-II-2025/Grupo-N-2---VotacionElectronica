namespace WinForm
{
    partial class PantallaVotaciones
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
            CBVotacion = new ComboBox();
            btnVotarPV = new CPresentacion.Boton();
            botonSalir = new CPresentacion.Boton();
            label1 = new Label();
            SuspendLayout();
            // 
            // CBVotacion
            // 
            CBVotacion.FormattingEnabled = true;
            CBVotacion.Location = new Point(260, 141);
            CBVotacion.Name = "CBVotacion";
            CBVotacion.Size = new Size(197, 23);
            CBVotacion.TabIndex = 0;
            CBVotacion.Text = "Elegir Votación";
            // 
            // btnVotarPV
            // 
            btnVotarPV.BackColor = SystemColors.ActiveBorder;
            btnVotarPV.BackgroundColor = SystemColors.ActiveBorder;
            btnVotarPV.BorderColor = Color.Black;
            btnVotarPV.BorderRadius = 40;
            btnVotarPV.BorderSize = 1;
            btnVotarPV.FlatAppearance.BorderSize = 0;
            btnVotarPV.FlatStyle = FlatStyle.Flat;
            btnVotarPV.ForeColor = Color.Black;
            btnVotarPV.Location = new Point(531, 136);
            btnVotarPV.Margin = new Padding(3, 2, 3, 2);
            btnVotarPV.Name = "btnVotarPV";
            btnVotarPV.Size = new Size(89, 29);
            btnVotarPV.TabIndex = 2;
            btnVotarPV.Text = "Votar";
            btnVotarPV.TextColor = Color.Black;
            btnVotarPV.UseVisualStyleBackColor = false;
            btnVotarPV.Click += btnVotarPV_Click;
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ActiveBorder;
            botonSalir.BackgroundColor = SystemColors.ActiveBorder;
            botonSalir.BorderColor = Color.Black;
            botonSalir.BorderRadius = 40;
            botonSalir.BorderSize = 1;
            botonSalir.FlatAppearance.BorderSize = 0;
            botonSalir.FlatStyle = FlatStyle.Flat;
            botonSalir.ForeColor = Color.Black;
            botonSalir.Location = new Point(29, 29);
            botonSalir.Margin = new Padding(3, 2, 3, 2);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(89, 29);
            botonSalir.TabIndex = 3;
            botonSalir.Text = "Salir";
            botonSalir.TextColor = Color.Black;
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(682, 41);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // PantallaVotaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(botonSalir);
            Controls.Add(btnVotarPV);
            Controls.Add(CBVotacion);
            Name = "PantallaVotaciones";
            Text = "PantallaVotaciones";
            Load += PantallaVotaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CBVotacion;
        private CPresentacion.Boton btnVotarPV;
        private CPresentacion.Boton botonSalir;
        private Label label1;
    }
}