namespace WinForm
{
    partial class PantallaInicio
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
            panel1 = new Panel();
            textoBienvenida = new Label();
            buttonVotacion = new Button();
            buttonVerResultados = new Button();
            buttonConfiguracion = new Button();
            btnSalirPI = new CPresentacion.Boton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textoBienvenida);
            panel1.Location = new Point(38, 54);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 231);
            panel1.TabIndex = 0;
            // 
            // textoBienvenida
            // 
            textoBienvenida.AutoSize = true;
            textoBienvenida.BackColor = Color.Transparent;
            textoBienvenida.Font = new Font("Modern No. 20", 25.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textoBienvenida.Location = new Point(21, 46);
            textoBienvenida.Name = "textoBienvenida";
            textoBienvenida.Size = new Size(287, 140);
            textoBienvenida.TabIndex = 0;
            textoBienvenida.Text = "BIENVENIDO AL\r\nSISTEMA DE\r\nVOTACIÓN\r\nELLECTRÓNICA";
            textoBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonVotacion
            // 
            buttonVotacion.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonVotacion.Location = new Point(396, 54);
            buttonVotacion.Margin = new Padding(3, 2, 3, 2);
            buttonVotacion.Name = "buttonVotacion";
            buttonVotacion.Size = new Size(274, 49);
            buttonVotacion.TabIndex = 1;
            buttonVotacion.Text = "VOTACIÓN";
            buttonVotacion.UseVisualStyleBackColor = true;
            buttonVotacion.Click += btnVotacion_Click;
            // 
            // buttonVerResultados
            // 
            buttonVerResultados.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonVerResultados.Location = new Point(396, 148);
            buttonVerResultados.Margin = new Padding(3, 2, 3, 2);
            buttonVerResultados.Name = "buttonVerResultados";
            buttonVerResultados.Size = new Size(274, 49);
            buttonVerResultados.TabIndex = 2;
            buttonVerResultados.Text = "VER RESULTADOS";
            buttonVerResultados.UseVisualStyleBackColor = true;
            buttonVerResultados.Click += buttonVerResultados_Click;
            // 
            // buttonConfiguracion
            // 
            buttonConfiguracion.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonConfiguracion.Location = new Point(396, 236);
            buttonConfiguracion.Margin = new Padding(3, 2, 3, 2);
            buttonConfiguracion.Name = "buttonConfiguracion";
            buttonConfiguracion.Size = new Size(274, 49);
            buttonConfiguracion.TabIndex = 3;
            buttonConfiguracion.Text = "CONFIGURACIÓN";
            buttonConfiguracion.UseVisualStyleBackColor = true;
            buttonConfiguracion.Click += buttonConfiguracion_Click;
            // 
            // btnSalirPI
            // 
            btnSalirPI.BackColor = SystemColors.ActiveBorder;
            btnSalirPI.BackgroundColor = SystemColors.ActiveBorder;
            btnSalirPI.BorderColor = Color.Black;
            btnSalirPI.BorderRadius = 35;
            btnSalirPI.BorderSize = 1;
            btnSalirPI.FlatAppearance.BorderSize = 0;
            btnSalirPI.FlatStyle = FlatStyle.Flat;
            btnSalirPI.ForeColor = Color.Black;
            btnSalirPI.Location = new Point(589, 302);
            btnSalirPI.Margin = new Padding(3, 2, 3, 2);
            btnSalirPI.Name = "btnSalirPI";
            btnSalirPI.Size = new Size(97, 27);
            btnSalirPI.TabIndex = 5;
            btnSalirPI.Text = "Salir";
            btnSalirPI.TextColor = Color.Black;
            btnSalirPI.UseVisualStyleBackColor = false;
            btnSalirPI.Click += btnSalirPI_Click;
            // 
            // PantallaInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(700, 338);
            Controls.Add(btnSalirPI);
            Controls.Add(buttonConfiguracion);
            Controls.Add(buttonVerResultados);
            Controls.Add(buttonVotacion);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PantallaInicio";
            Text = "PantallaInicio";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label textoBienvenida;
        private Button buttonVotacion;
        private Button buttonVerResultados;
        private Button buttonConfiguracion;
        private CPresentacion.Boton btnSalirPI;
    }
}