namespace WinForm
{
    partial class MenuAdministrador
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
            BotonModificarVotacion = new Button();
            BotonCrearNuevaVotacion = new Button();
            BotonModificarVotante = new Button();
            BotonAgregarVotante = new Button();
            pictureBox1 = new PictureBox();
            btnSalirMA = new CPresentacion.Boton();
            BtnEleccion = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BotonModificarVotacion
            // 
            BotonModificarVotacion.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BotonModificarVotacion.Location = new Point(200, 240);
            BotonModificarVotacion.Name = "BotonModificarVotacion";
            BotonModificarVotacion.Size = new Size(408, 31);
            BotonModificarVotacion.TabIndex = 4;
            BotonModificarVotacion.Text = "Modificar Votación";
            BotonModificarVotacion.UseVisualStyleBackColor = true;
            BotonModificarVotacion.Click += BotonModificarVotacion_Click;
            // 
            // BotonCrearNuevaVotacion
            // 
            BotonCrearNuevaVotacion.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BotonCrearNuevaVotacion.Location = new Point(200, 192);
            BotonCrearNuevaVotacion.Name = "BotonCrearNuevaVotacion";
            BotonCrearNuevaVotacion.Size = new Size(408, 31);
            BotonCrearNuevaVotacion.TabIndex = 3;
            BotonCrearNuevaVotacion.Text = "Crear Nueva Votación";
            BotonCrearNuevaVotacion.UseVisualStyleBackColor = true;
            BotonCrearNuevaVotacion.Click += BotonCrearNuevaVotacion_Click;
            // 
            // BotonModificarVotante
            // 
            BotonModificarVotante.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BotonModificarVotante.Location = new Point(200, 143);
            BotonModificarVotante.Name = "BotonModificarVotante";
            BotonModificarVotante.Size = new Size(408, 31);
            BotonModificarVotante.TabIndex = 2;
            BotonModificarVotante.Text = "Modificar Votante";
            BotonModificarVotante.UseVisualStyleBackColor = true;
            BotonModificarVotante.Click += BotonModificarVotante_Click;
            // 
            // BotonAgregarVotante
            // 
            BotonAgregarVotante.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BotonAgregarVotante.Location = new Point(200, 95);
            BotonAgregarVotante.Name = "BotonAgregarVotante";
            BotonAgregarVotante.Size = new Size(408, 31);
            BotonAgregarVotante.TabIndex = 1;
            BotonAgregarVotante.Text = "Agregar Nuevo Votante ";
            BotonAgregarVotante.UseVisualStyleBackColor = true;
            BotonAgregarVotante.Click += BotonAgregarVotante_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(153, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(505, 289);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnSalirMA
            // 
            btnSalirMA.BackColor = SystemColors.ActiveBorder;
            btnSalirMA.BackgroundColor = SystemColors.ActiveBorder;
            btnSalirMA.BorderColor = Color.Black;
            btnSalirMA.BorderRadius = 40;
            btnSalirMA.BorderSize = 1;
            btnSalirMA.FlatAppearance.BorderSize = 0;
            btnSalirMA.FlatStyle = FlatStyle.Flat;
            btnSalirMA.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirMA.ForeColor = Color.Black;
            btnSalirMA.Location = new Point(561, 324);
            btnSalirMA.Margin = new Padding(3, 2, 3, 2);
            btnSalirMA.Name = "btnSalirMA";
            btnSalirMA.Size = new Size(90, 28);
            btnSalirMA.TabIndex = 7;
            btnSalirMA.Text = "Salir";
            btnSalirMA.TextColor = Color.Black;
            btnSalirMA.UseVisualStyleBackColor = false;
            btnSalirMA.Click += btnSalirMA_Click;
            // 
            // BtnEleccion
            // 
            BtnEleccion.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnEleccion.Location = new Point(200, 284);
            BtnEleccion.Name = "BtnEleccion";
            BtnEleccion.Size = new Size(408, 31);
            BtnEleccion.TabIndex = 8;
            BtnEleccion.Text = "Asignar Personas a Eleccion";
            BtnEleccion.UseVisualStyleBackColor = true;
            BtnEleccion.Click += BtnEleccion_Click;
            // 
            // MenuAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnEleccion);
            Controls.Add(btnSalirMA);
            Controls.Add(BotonAgregarVotante);
            Controls.Add(BotonModificarVotante);
            Controls.Add(BotonCrearNuevaVotacion);
            Controls.Add(BotonModificarVotacion);
            Controls.Add(pictureBox1);
            Name = "MenuAdministrador";
            Text = "MenuAdministrador";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button BotonModificarVotacion;
        private Button BotonCrearNuevaVotacion;
        private Button BotonModificarVotante;
        private Button BotonAgregarVotante;
        private PictureBox pictureBox1;
        private CPresentacion.Boton btnSalirMA;
        private Button BtnEleccion;
    }
}