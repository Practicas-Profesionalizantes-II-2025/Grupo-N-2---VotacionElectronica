namespace WinForm
{
    partial class ContraseñaIncorrecta
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
            TextoArriba = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnAceptaCI = new CPresentacion.Boton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TextoArriba
            // 
            TextoArriba.AutoSize = true;
            TextoArriba.Font = new Font("Modern No. 20", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextoArriba.Location = new Point(278, 165);
            TextoArriba.Name = "TextoArriba";
            TextoArriba.Size = new Size(240, 25);
            TextoArriba.TabIndex = 8;
            TextoArriba.Text = "No se encontró ningún ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(220, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(354, 179);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(263, 197);
            label1.Name = "label1";
            label1.Size = new Size(268, 25);
            label1.TabIndex = 9;
            label1.Text = "votante con esa contraseña";
            // 
            // btnAceptaCI
            // 
            btnAceptaCI.BackColor = SystemColors.ActiveBorder;
            btnAceptaCI.BackgroundColor = SystemColors.ActiveBorder;
            btnAceptaCI.BorderColor = Color.Black;
            btnAceptaCI.BorderRadius = 40;
            btnAceptaCI.BorderSize = 1;
            btnAceptaCI.FlatAppearance.BorderSize = 0;
            btnAceptaCI.FlatStyle = FlatStyle.Flat;
            btnAceptaCI.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptaCI.ForeColor = Color.Black;
            btnAceptaCI.Location = new Point(321, 244);
            btnAceptaCI.Margin = new Padding(3, 2, 3, 2);
            btnAceptaCI.Name = "btnAceptaCI";
            btnAceptaCI.Size = new Size(146, 34);
            btnAceptaCI.TabIndex = 11;
            btnAceptaCI.Text = "Aceptar";
            btnAceptaCI.TextColor = Color.Black;
            btnAceptaCI.UseVisualStyleBackColor = false;
            // 
            // ContraseñaIncorrecta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAceptaCI);
            Controls.Add(label1);
            Controls.Add(TextoArriba);
            Controls.Add(pictureBox1);
            Name = "ContraseñaIncorrecta";
            Text = "ContraseñaIncorrecta";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TextoArriba;
        private PictureBox pictureBox1;
        private Label label1;
        private CPresentacion.Boton btnAceptaCI;
    }
}