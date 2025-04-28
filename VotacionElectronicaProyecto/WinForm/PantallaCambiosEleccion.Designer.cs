namespace WinForm
{
    partial class PantallaCambiosEleccion
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
            TxtDNIPersona = new TextBox();
            TxtNombreEleccion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BtnAsignar = new Button();
            btnSalirCV = new CPresentacion.Boton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(256, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(268, 345);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TxtDNIPersona
            // 
            TxtDNIPersona.Location = new Point(332, 137);
            TxtDNIPersona.Name = "TxtDNIPersona";
            TxtDNIPersona.Size = new Size(110, 23);
            TxtDNIPersona.TabIndex = 1;
            // 
            // TxtNombreEleccion
            // 
            TxtNombreEleccion.Location = new Point(329, 219);
            TxtNombreEleccion.Name = "TxtNombreEleccion";
            TxtNombreEleccion.Size = new Size(117, 23);
            TxtNombreEleccion.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(314, 106);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 3;
            label1.Text = "Nro Identificacion Persona";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(338, 186);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre Eleccion";
            // 
            // BtnAsignar
            // 
            BtnAsignar.Location = new Point(344, 290);
            BtnAsignar.Name = "BtnAsignar";
            BtnAsignar.Size = new Size(92, 35);
            BtnAsignar.TabIndex = 5;
            BtnAsignar.Text = "Asignar";
            BtnAsignar.UseVisualStyleBackColor = true;
            BtnAsignar.Click += BtnAsignar_Click;
            // 
            // btnSalirCV
            // 
            btnSalirCV.BackColor = SystemColors.ActiveBorder;
            btnSalirCV.BackgroundColor = SystemColors.ActiveBorder;
            btnSalirCV.BorderColor = Color.Black;
            btnSalirCV.BorderRadius = 40;
            btnSalirCV.BorderSize = 1;
            btnSalirCV.FlatAppearance.BorderSize = 0;
            btnSalirCV.FlatStyle = FlatStyle.Flat;
            btnSalirCV.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirCV.ForeColor = Color.Black;
            btnSalirCV.Location = new Point(684, 21);
            btnSalirCV.Margin = new Padding(3, 2, 3, 2);
            btnSalirCV.Name = "btnSalirCV";
            btnSalirCV.Size = new Size(95, 34);
            btnSalirCV.TabIndex = 8;
            btnSalirCV.Text = "Volver";
            btnSalirCV.TextColor = Color.Black;
            btnSalirCV.UseVisualStyleBackColor = false;
            btnSalirCV.Click += btnSalirCV_Click;
            // 
            // PantallaCambiosEleccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalirCV);
            Controls.Add(BtnAsignar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtNombreEleccion);
            Controls.Add(TxtDNIPersona);
            Controls.Add(pictureBox1);
            Name = "PantallaCambiosEleccion";
            Text = "PantallaCambiosEleccion";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox TxtDNIPersona;
        private TextBox TxtNombreEleccion;
        private Label label1;
        private Label label2;
        private Button BtnAsignar;
        private CPresentacion.Boton btnSalirCV;
    }
}