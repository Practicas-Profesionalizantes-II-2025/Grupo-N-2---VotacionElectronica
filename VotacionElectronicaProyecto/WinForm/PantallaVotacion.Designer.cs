namespace WinForm
{
    partial class PantallaVotacion
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
            btnSalirPV = new CPresentacion.Boton();
            btnVotarPV = new CPresentacion.Boton();
            btnAutenticarPV = new CPresentacion.Boton();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalirPV);
            panel1.Controls.Add(btnVotarPV);
            panel1.Controls.Add(btnAutenticarPV);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(176, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 232);
            panel1.TabIndex = 0;
            // 
            // btnSalirPV
            // 
            btnSalirPV.BackColor = SystemColors.ActiveBorder;
            btnSalirPV.BackgroundColor = SystemColors.ActiveBorder;
            btnSalirPV.BorderColor = Color.Black;
            btnSalirPV.BorderRadius = 40;
            btnSalirPV.BorderSize = 1;
            btnSalirPV.FlatAppearance.BorderSize = 0;
            btnSalirPV.FlatStyle = FlatStyle.Flat;
            btnSalirPV.ForeColor = Color.Black;
            btnSalirPV.Location = new Point(322, 182);
            btnSalirPV.Margin = new Padding(3, 2, 3, 2);
            btnSalirPV.Name = "btnSalirPV";
            btnSalirPV.Size = new Size(103, 32);
            btnSalirPV.TabIndex = 8;
            btnSalirPV.Text = "Salir";
            btnSalirPV.TextColor = Color.Black;
            btnSalirPV.UseVisualStyleBackColor = false;
            btnSalirPV.Click += btnSalirPV_Click;
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
            btnVotarPV.Location = new Point(132, 182);
            btnVotarPV.Margin = new Padding(3, 2, 3, 2);
            btnVotarPV.Name = "btnVotarPV";
            btnVotarPV.Size = new Size(103, 32);
            btnVotarPV.TabIndex = 7;
            btnVotarPV.Text = "Votar";
            btnVotarPV.TextColor = Color.Black;
            btnVotarPV.UseVisualStyleBackColor = false;
            btnVotarPV.Click += btnVotarPV_Click;
            // 
            // btnAutenticarPV
            // 
            btnAutenticarPV.BackColor = SystemColors.ActiveBorder;
            btnAutenticarPV.BackgroundColor = SystemColors.ActiveBorder;
            btnAutenticarPV.BorderColor = Color.Black;
            btnAutenticarPV.BorderRadius = 40;
            btnAutenticarPV.BorderSize = 1;
            btnAutenticarPV.FlatAppearance.BorderSize = 0;
            btnAutenticarPV.FlatStyle = FlatStyle.Flat;
            btnAutenticarPV.ForeColor = Color.Black;
            btnAutenticarPV.Location = new Point(15, 182);
            btnAutenticarPV.Margin = new Padding(3, 2, 3, 2);
            btnAutenticarPV.Name = "btnAutenticarPV";
            btnAutenticarPV.Size = new Size(103, 32);
            btnAutenticarPV.TabIndex = 6;
            btnAutenticarPV.Text = "Autenticar";
            btnAutenticarPV.TextColor = Color.Black;
            btnAutenticarPV.UseVisualStyleBackColor = false;
            btnAutenticarPV.Click += btnAutenticarPV_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 114);
            label2.Name = "label2";
            label2.Size = new Size(155, 18);
            label2.TabIndex = 2;
            label2.Text = "NOMBRE VOTANTE";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(199, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 50);
            label1.Name = "label1";
            label1.Size = new Size(146, 22);
            label1.TabIndex = 0;
            label1.Text = "CONTRASEÑA:";
            // 
            // PantallaVotacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "PantallaVotacion";
            Text = "PantallaVotacion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private CPresentacion.Boton btnAutenticarPV;
        private CPresentacion.Boton btnVotarPV;
        private CPresentacion.Boton btnSalirPV;
    }
}