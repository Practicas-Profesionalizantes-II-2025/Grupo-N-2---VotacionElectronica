namespace WinForm
{
    partial class PantallaVotacionCreada
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
            label1 = new Label();
            panel1 = new Panel();
            btnConfirmarVC = new CPresentacion.Boton();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(136, 78);
            label1.Name = "label1";
            label1.Size = new Size(176, 29);
            label1.TabIndex = 0;
            label1.Text = "Todos los datos";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConfirmarVC);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(178, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(446, 258);
            panel1.TabIndex = 1;
            // 
            // btnConfirmarVC
            // 
            btnConfirmarVC.BackColor = SystemColors.ActiveBorder;
            btnConfirmarVC.BackgroundColor = SystemColors.ActiveBorder;
            btnConfirmarVC.BorderColor = Color.Black;
            btnConfirmarVC.BorderRadius = 40;
            btnConfirmarVC.BorderSize = 1;
            btnConfirmarVC.FlatAppearance.BorderSize = 0;
            btnConfirmarVC.FlatStyle = FlatStyle.Flat;
            btnConfirmarVC.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmarVC.ForeColor = Color.Black;
            btnConfirmarVC.Location = new Point(151, 170);
            btnConfirmarVC.Margin = new Padding(3, 2, 3, 2);
            btnConfirmarVC.Name = "btnConfirmarVC";
            btnConfirmarVC.Size = new Size(150, 44);
            btnConfirmarVC.TabIndex = 2;
            btnConfirmarVC.Text = "Confirmar";
            btnConfirmarVC.TextColor = Color.Black;
            btnConfirmarVC.UseVisualStyleBackColor = false;
            btnConfirmarVC.Click += btnConfirmarVC_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Modern No. 20", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(111, 107);
            label2.Name = "label2";
            label2.Size = new Size(229, 29);
            label2.TabIndex = 3;
            label2.Text = "han sido ingresados";
            // 
            // PantallaVotacionCreada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "PantallaVotacionCreada";
            Text = "PantallaVotacionCreada";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private CPresentacion.Boton btnConfirmarVC;
    }
}