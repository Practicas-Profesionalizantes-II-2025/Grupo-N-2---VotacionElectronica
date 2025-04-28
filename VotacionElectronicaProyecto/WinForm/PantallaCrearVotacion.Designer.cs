namespace WinForm
{
    partial class PantallaCrearVotacion
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
            TBNombreVotacion = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            TBDescripcionEleccion = new TextBox();
            DTFechaFin = new DateTimePicker();
            label4 = new Label();
            DTFechaInicio = new DateTimePicker();
            label3 = new Label();
            TBCantidadListas = new TextBox();
            label2 = new Label();
            btnAceptarCV = new CPresentacion.Boton();
            btnSalirCV = new CPresentacion.Boton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TBNombreVotacion
            // 
            TBNombreVotacion.Location = new Point(54, 49);
            TBNombreVotacion.Name = "TBNombreVotacion";
            TBNombreVotacion.Size = new Size(205, 23);
            TBNombreVotacion.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 24);
            label1.Name = "label1";
            label1.Size = new Size(193, 22);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la votación:";
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TBDescripcionEleccion);
            panel1.Controls.Add(DTFechaFin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(DTFechaInicio);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TBCantidadListas);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TBNombreVotacion);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(148, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 215);
            panel1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(54, 90);
            label5.Name = "label5";
            label5.Size = new Size(183, 22);
            label5.TabIndex = 9;
            label5.Text = "Descripción votación:";
            // 
            // TBDescripcionEleccion
            // 
            TBDescripcionEleccion.Location = new Point(54, 110);
            TBDescripcionEleccion.Name = "TBDescripcionEleccion";
            TBDescripcionEleccion.Size = new Size(205, 23);
            TBDescripcionEleccion.TabIndex = 8;
            // 
            // DTFechaFin
            // 
            DTFechaFin.Location = new Point(298, 140);
            DTFechaFin.Name = "DTFechaFin";
            DTFechaFin.Size = new Size(200, 23);
            DTFechaFin.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(338, 115);
            label4.Name = "label4";
            label4.Size = new Size(97, 22);
            label4.TabIndex = 6;
            label4.Text = "Fecha Fin:";
            // 
            // DTFechaInicio
            // 
            DTFechaInicio.Location = new Point(298, 70);
            DTFechaInicio.Name = "DTFechaInicio";
            DTFechaInicio.Size = new Size(200, 23);
            DTFechaInicio.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(338, 45);
            label3.Name = "label3";
            label3.Size = new Size(116, 22);
            label3.TabIndex = 4;
            label3.Text = "Fecha Inicio:";
            // 
            // TBCantidadListas
            // 
            TBCantidadListas.Location = new Point(54, 172);
            TBCantidadListas.Name = "TBCantidadListas";
            TBCantidadListas.Size = new Size(205, 23);
            TBCantidadListas.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 151);
            label2.Name = "label2";
            label2.Size = new Size(156, 22);
            label2.TabIndex = 2;
            label2.Text = "Cantidad de listas:";
            // 
            // btnAceptarCV
            // 
            btnAceptarCV.BackColor = SystemColors.ActiveBorder;
            btnAceptarCV.BackgroundColor = SystemColors.ActiveBorder;
            btnAceptarCV.BorderColor = Color.Black;
            btnAceptarCV.BorderRadius = 40;
            btnAceptarCV.BorderSize = 1;
            btnAceptarCV.FlatAppearance.BorderSize = 0;
            btnAceptarCV.FlatStyle = FlatStyle.Flat;
            btnAceptarCV.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptarCV.ForeColor = Color.Black;
            btnAceptarCV.Location = new Point(347, 356);
            btnAceptarCV.Margin = new Padding(3, 2, 3, 2);
            btnAceptarCV.Name = "btnAceptarCV";
            btnAceptarCV.Size = new Size(152, 34);
            btnAceptarCV.TabIndex = 6;
            btnAceptarCV.Text = "Aceptar";
            btnAceptarCV.TextColor = Color.Black;
            btnAceptarCV.UseVisualStyleBackColor = false;
            btnAceptarCV.Click += btnAceptarCV_Click;
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
            btnSalirCV.Location = new Point(671, 26);
            btnSalirCV.Margin = new Padding(3, 2, 3, 2);
            btnSalirCV.Name = "btnSalirCV";
            btnSalirCV.Size = new Size(95, 34);
            btnSalirCV.TabIndex = 7;
            btnSalirCV.Text = "Salir";
            btnSalirCV.TextColor = Color.Black;
            btnSalirCV.UseVisualStyleBackColor = false;
            btnSalirCV.Click += btnSalirCV_Click;
            // 
            // PantallaCrearVotacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalirCV);
            Controls.Add(btnAceptarCV);
            Controls.Add(panel1);
            Name = "PantallaCrearVotacion";
            Text = "PantallaCrearVotacion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TBNombreVotacion;
        private Label label1;
        private Panel panel1;
        private Label label3;
        private TextBox TBCantidadListas;
        private Label label2;
        private DateTimePicker DTFechaFin;
        private Label label4;
        private DateTimePicker DTFechaInicio;
        private CPresentacion.Boton btnAceptarCV;
        private CPresentacion.Boton btnSalirCV;
        private TextBox TBDescripcionEleccion;
        private Label label5;
    }
}