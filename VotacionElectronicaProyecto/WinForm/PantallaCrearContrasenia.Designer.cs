namespace WinForm
{
    partial class PantallaCrearContrasenia
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
            btnAceptarCG = new CPresentacion.Boton();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblContrasenia = new Label();
            lblNombre = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAceptarCG);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblContrasenia);
            panel1.Controls.Add(lblNombre);
            panel1.Location = new Point(136, 56);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(581, 307);
            panel1.TabIndex = 0;
            // 
            // btnAceptarCG
            // 
            btnAceptarCG.BackColor = SystemColors.ActiveBorder;
            btnAceptarCG.BackgroundColor = SystemColors.ActiveBorder;
            btnAceptarCG.BorderColor = Color.Black;
            btnAceptarCG.BorderRadius = 45;
            btnAceptarCG.BorderSize = 1;
            btnAceptarCG.FlatAppearance.BorderSize = 0;
            btnAceptarCG.FlatStyle = FlatStyle.Flat;
            btnAceptarCG.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptarCG.ForeColor = Color.Black;
            btnAceptarCG.Location = new Point(184, 242);
            btnAceptarCG.Margin = new Padding(3, 2, 3, 2);
            btnAceptarCG.Name = "btnAceptarCG";
            btnAceptarCG.Size = new Size(207, 44);
            btnAceptarCG.TabIndex = 6;
            btnAceptarCG.Text = "Aceptar";
            btnAceptarCG.TextColor = Color.Black;
            btnAceptarCG.UseVisualStyleBackColor = false;
            btnAceptarCG.Click += btnAceptarCG_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 184);
            label3.Name = "label3";
            label3.Size = new Size(355, 29);
            label3.TabIndex = 4;
            label3.Text = "CONTRASEÑA GENERADA:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 132);
            label2.Name = "label2";
            label2.Size = new Size(454, 29);
            label2.TabIndex = 3;
            label2.Text = "HA SIDO REGISTRADO CON ÉXITO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(194, 36);
            label1.Name = "label1";
            label1.Size = new Size(182, 29);
            label1.TabIndex = 2;
            label1.Text = "EL VOTANTE";
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.BackColor = Color.Transparent;
            lblContrasenia.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasenia.Location = new Point(386, 184);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(175, 29);
            lblContrasenia.TabIndex = 1;
            lblContrasenia.Text = "lblContrasenia";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(222, 79);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(131, 29);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "lblNombre";
            // 
            // PantallaCrearContrasenia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(859, 416);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PantallaCrearContrasenia";
            Text = "PantallaContraseñaGenerada";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNombre;
        private Label lblContrasenia;
        private Label label1;
        private Label label3;
        private Label label2;
        private CPresentacion.Boton btnAceptarCG;
    }
}