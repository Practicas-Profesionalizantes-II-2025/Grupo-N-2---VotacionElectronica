namespace WinForm
{
    partial class MenuConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuConfiguracion));
            panel1 = new Panel();
            button1 = new Button();
            btnSalirMC = new CPresentacion.Boton();
            btnIngresarMC = new CPresentacion.Boton();
            txtContraseña = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnSalirMC);
            panel1.Controls.Add(btnIngresarMC);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(139, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 214);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Image = Properties.Resources._147771;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(311, 124);
            button1.Name = "button1";
            button1.Size = new Size(31, 23);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
            button1.MouseDown += BtnMostrar_MouseDown;
            button1.MouseUp += BtnMostrar_MouseUp;
            // 
            // btnSalirMC
            // 
            btnSalirMC.BackColor = SystemColors.ActiveBorder;
            btnSalirMC.BackgroundColor = SystemColors.ActiveBorder;
            btnSalirMC.BorderColor = Color.Black;
            btnSalirMC.BorderRadius = 35;
            btnSalirMC.BorderSize = 1;
            btnSalirMC.FlatAppearance.BorderSize = 0;
            btnSalirMC.FlatStyle = FlatStyle.Flat;
            btnSalirMC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirMC.ForeColor = Color.Black;
            btnSalirMC.Location = new Point(431, 182);
            btnSalirMC.Margin = new Padding(3, 2, 3, 2);
            btnSalirMC.Name = "btnSalirMC";
            btnSalirMC.Size = new Size(76, 24);
            btnSalirMC.TabIndex = 5;
            btnSalirMC.Text = "Salir";
            btnSalirMC.TextColor = Color.Black;
            btnSalirMC.UseVisualStyleBackColor = false;
            btnSalirMC.Click += btnSalirMC_Click;
            // 
            // btnIngresarMC
            // 
            btnIngresarMC.BackColor = SystemColors.ActiveBorder;
            btnIngresarMC.BackgroundColor = SystemColors.ActiveBorder;
            btnIngresarMC.BorderColor = Color.Black;
            btnIngresarMC.BorderRadius = 35;
            btnIngresarMC.BorderSize = 1;
            btnIngresarMC.FlatAppearance.BorderSize = 0;
            btnIngresarMC.FlatStyle = FlatStyle.Flat;
            btnIngresarMC.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresarMC.ForeColor = Color.Black;
            btnIngresarMC.Location = new Point(354, 121);
            btnIngresarMC.Margin = new Padding(3, 2, 3, 2);
            btnIngresarMC.Name = "btnIngresarMC";
            btnIngresarMC.Size = new Size(102, 27);
            btnIngresarMC.TabIndex = 4;
            btnIngresarMC.Text = "Ingresar";
            btnIngresarMC.TextColor = Color.Black;
            btnIngresarMC.UseVisualStyleBackColor = false;
            btnIngresarMC.Click += btnIngresarMC_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(69, 124);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(272, 23);
            txtContraseña.TabIndex = 1;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(123, 50);
            label1.Name = "label1";
            label1.Size = new Size(265, 44);
            label1.TabIndex = 0;
            label1.Text = "Ingrese código de autenticación \r\nde permisos de administrador";
            // 
            // MenuConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "MenuConfiguracion";
            Text = "MenuConfiguracion";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtContraseña;
        private CPresentacion.Boton btnIngresarMC;
        private CPresentacion.Boton btnSalirMC;
        private Button button1;
    }
}