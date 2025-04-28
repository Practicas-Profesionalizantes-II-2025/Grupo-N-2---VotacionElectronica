namespace WinForm
{
    partial class PantallaAltaVotante
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
            label10 = new Label();
            label9 = new Label();
            TBNumero = new TextBox();
            label8 = new Label();
            CBDocumento = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            validacion1 = new Label();
            TBApellido = new TextBox();
            TBNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancelarAV = new CPresentacion.Boton();
            label1 = new Label();
            btnRegistrarAV = new CPresentacion.Boton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(TBNumero);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(CBDocumento);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(validacion1);
            panel1.Controls.Add(TBApellido);
            panel1.Controls.Add(TBNombre);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(116, 66);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(459, 207);
            panel1.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(313, 171);
            label10.Name = "label10";
            label10.Size = new Size(100, 14);
            label10.TabIndex = 13;
            label10.Text = "Hasta 8 caracteres";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(339, 112);
            label9.Name = "label9";
            label9.Size = new Size(25, 29);
            label9.TabIndex = 12;
            label9.Text = "*";
            // 
            // TBNumero
            // 
            TBNumero.Location = new Point(237, 146);
            TBNumero.Margin = new Padding(3, 2, 3, 2);
            TBNumero.Name = "TBNumero";
            TBNumero.Size = new Size(187, 23);
            TBNumero.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Modern No. 20", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(237, 112);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 10;
            label8.Text = "Número :";
            // 
            // CBDocumento
            // 
            CBDocumento.FormattingEnabled = true;
            CBDocumento.Items.AddRange(new object[] { "DNI", "Libreta de Enrolamiento" });
            CBDocumento.Location = new Point(24, 146);
            CBDocumento.Margin = new Padding(3, 2, 3, 2);
            CBDocumento.Name = "CBDocumento";
            CBDocumento.Size = new Size(169, 23);
            CBDocumento.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Modern No. 20", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 111);
            label7.Name = "label7";
            label7.Size = new Size(175, 25);
            label7.TabIndex = 8;
            label7.Text = "Tipo Documento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(306, 51);
            label6.Name = "label6";
            label6.Size = new Size(106, 14);
            label6.TabIndex = 7;
            label6.Text = "Hasta 20 caracteres";
            // 
            // validacion1
            // 
            validacion1.AutoSize = true;
            validacion1.BackColor = Color.Transparent;
            validacion1.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            validacion1.Location = new Point(306, 92);
            validacion1.Name = "validacion1";
            validacion1.Size = new Size(106, 14);
            validacion1.TabIndex = 6;
            validacion1.Text = "Hasta 20 caracteres";
            // 
            // TBApellido
            // 
            TBApellido.Location = new Point(178, 67);
            TBApellido.Margin = new Padding(3, 2, 3, 2);
            TBApellido.Name = "TBApellido";
            TBApellido.Size = new Size(246, 23);
            TBApellido.TabIndex = 5;
            // 
            // TBNombre
            // 
            TBNombre.Location = new Point(178, 26);
            TBNombre.Margin = new Padding(3, 2, 3, 2);
            TBNombre.Name = "TBNombre";
            TBNombre.Size = new Size(246, 23);
            TBNombre.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(142, 22);
            label5.Name = "label5";
            label5.Size = new Size(25, 29);
            label5.TabIndex = 3;
            label5.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(150, 67);
            label4.Name = "label4";
            label4.Size = new Size(25, 29);
            label4.TabIndex = 2;
            label4.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 67);
            label3.Name = "label3";
            label3.Size = new Size(136, 29);
            label3.TabIndex = 1;
            label3.Text = "Apellido/s :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Modern No. 20", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 22);
            label2.Name = "label2";
            label2.Size = new Size(128, 29);
            label2.TabIndex = 0;
            label2.Text = "Nombre/s :";
            // 
            // btnCancelarAV
            // 
            btnCancelarAV.BackColor = SystemColors.ActiveBorder;
            btnCancelarAV.BackgroundColor = SystemColors.ActiveBorder;
            btnCancelarAV.BorderColor = Color.Black;
            btnCancelarAV.BorderRadius = 45;
            btnCancelarAV.BorderSize = 1;
            btnCancelarAV.FlatAppearance.BorderSize = 0;
            btnCancelarAV.FlatStyle = FlatStyle.Flat;
            btnCancelarAV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarAV.ForeColor = Color.Black;
            btnCancelarAV.Location = new Point(150, 284);
            btnCancelarAV.Margin = new Padding(3, 2, 3, 2);
            btnCancelarAV.Name = "btnCancelarAV";
            btnCancelarAV.Size = new Size(159, 35);
            btnCancelarAV.TabIndex = 4;
            btnCancelarAV.Text = "Cancelar";
            btnCancelarAV.TextColor = Color.Black;
            btnCancelarAV.UseVisualStyleBackColor = false;
            btnCancelarAV.Click += btnCancelarAV_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Modern No. 20", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 20);
            label1.Name = "label1";
            label1.Size = new Size(498, 35);
            label1.TabIndex = 1;
            label1.Text = "REGISTRAR NUEVO VOTANTE";
            // 
            // btnRegistrarAV
            // 
            btnRegistrarAV.BackColor = SystemColors.ActiveBorder;
            btnRegistrarAV.BackgroundColor = SystemColors.ActiveBorder;
            btnRegistrarAV.BorderColor = Color.Black;
            btnRegistrarAV.BorderRadius = 45;
            btnRegistrarAV.BorderSize = 1;
            btnRegistrarAV.FlatAppearance.BorderSize = 0;
            btnRegistrarAV.FlatStyle = FlatStyle.Flat;
            btnRegistrarAV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarAV.ForeColor = Color.Black;
            btnRegistrarAV.Location = new Point(381, 284);
            btnRegistrarAV.Margin = new Padding(3, 2, 3, 2);
            btnRegistrarAV.Name = "btnRegistrarAV";
            btnRegistrarAV.Size = new Size(159, 35);
            btnRegistrarAV.TabIndex = 5;
            btnRegistrarAV.Text = "Registrar";
            btnRegistrarAV.TextColor = Color.Black;
            btnRegistrarAV.UseVisualStyleBackColor = false;
            btnRegistrarAV.Click += btnRegistrarAV_Click;
            // 
            // PantallaAltaVotante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(700, 338);
            Controls.Add(btnRegistrarAV);
            Controls.Add(btnCancelarAV);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PantallaAltaVotante";
            Text = "PantallaAltaVotante";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TBNombre;
        private Label label5;
        private Label validacion1;
        private TextBox TBApellido;
        private Label label7;
        private Label label6;
        private Label label8;
        private ComboBox CBDocumento;
        private Label label9;
        private TextBox TBNumero;
        private Label label10;
        private CPresentacion.Boton btnCancelarAV;
        private CPresentacion.Boton btnRegistrarAV;
    }
}