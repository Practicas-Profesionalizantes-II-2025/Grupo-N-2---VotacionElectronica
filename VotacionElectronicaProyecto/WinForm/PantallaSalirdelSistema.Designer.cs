namespace WinForm
{
    partial class PantallaSalirdelSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaSalirdelSistema));
            panel1 = new Panel();
            btnAceptarSS = new CPresentacion.Boton();
            btnCancelarSS = new CPresentacion.Boton();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAceptarSS);
            panel1.Controls.Add(btnCancelarSS);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(179, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(463, 249);
            panel1.TabIndex = 0;
            // 
            // btnAceptarSS
            // 
            btnAceptarSS.BackColor = SystemColors.ActiveBorder;
            btnAceptarSS.BackgroundColor = SystemColors.ActiveBorder;
            btnAceptarSS.BorderColor = Color.Black;
            btnAceptarSS.BorderRadius = 40;
            btnAceptarSS.BorderSize = 1;
            btnAceptarSS.FlatAppearance.BorderSize = 0;
            btnAceptarSS.FlatStyle = FlatStyle.Flat;
            btnAceptarSS.ForeColor = Color.Black;
            btnAceptarSS.Location = new Point(263, 151);
            btnAceptarSS.Margin = new Padding(3, 2, 3, 2);
            btnAceptarSS.Name = "btnAceptarSS";
            btnAceptarSS.Size = new Size(115, 38);
            btnAceptarSS.TabIndex = 2;
            btnAceptarSS.Text = "Aceptar";
            btnAceptarSS.TextColor = Color.Black;
            btnAceptarSS.UseVisualStyleBackColor = false;
            btnAceptarSS.Click += btnAceptarSS_Click;
            // 
            // btnCancelarSS
            // 
            btnCancelarSS.BackColor = SystemColors.ActiveBorder;
            btnCancelarSS.BackgroundColor = SystemColors.ActiveBorder;
            btnCancelarSS.BorderColor = Color.Black;
            btnCancelarSS.BorderRadius = 40;
            btnCancelarSS.BorderSize = 1;
            btnCancelarSS.FlatAppearance.BorderSize = 0;
            btnCancelarSS.FlatStyle = FlatStyle.Flat;
            btnCancelarSS.ForeColor = Color.Black;
            btnCancelarSS.Location = new Point(88, 151);
            btnCancelarSS.Margin = new Padding(3, 2, 3, 2);
            btnCancelarSS.Name = "btnCancelarSS";
            btnCancelarSS.Size = new Size(115, 38);
            btnCancelarSS.TabIndex = 1;
            btnCancelarSS.Text = "Cancelar";
            btnCancelarSS.TextColor = Color.Black;
            btnCancelarSS.UseVisualStyleBackColor = false;
            btnCancelarSS.Click += btnCancelarSS_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 80);
            label1.Name = "label1";
            label1.Size = new Size(368, 22);
            label1.TabIndex = 0;
            label1.Text = "¿Estás seguro de que deseas salir del sistema?";
            // 
            // PantallaSalirdelSistema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "PantallaSalirdelSistema";
            Text = "PantallaSalirdelSistema";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CPresentacion.Boton btnCancelarSS;
        private CPresentacion.Boton btnAceptarSS;
    }
}