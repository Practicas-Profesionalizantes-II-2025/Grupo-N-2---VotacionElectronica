namespace WinForm
{
    partial class PantallaCrearLista
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
            DGListaCandidatos = new DataGridView();
            Eliminar = new DataGridViewButtonColumn();
            btnAgregarCL = new CPresentacion.Boton();
            TBPuesto = new TextBox();
            label4 = new Label();
            TBIntegrante = new TextBox();
            label3 = new Label();
            TBNombreLista = new TextBox();
            label1 = new Label();
            labelListas = new Label();
            btnConfirmarCL = new CPresentacion.Boton();
            btnCancelarCL = new CPresentacion.Boton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaCandidatos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(DGListaCandidatos);
            panel1.Controls.Add(btnAgregarCL);
            panel1.Controls.Add(TBPuesto);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TBIntegrante);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TBNombreLista);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(134, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 248);
            panel1.TabIndex = 2;
            // 
            // DGListaCandidatos
            // 
            DGListaCandidatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGListaCandidatos.Columns.AddRange(new DataGridViewColumn[] { Eliminar });
            DGListaCandidatos.Location = new Point(23, 124);
            DGListaCandidatos.Margin = new Padding(3, 2, 3, 2);
            DGListaCandidatos.Name = "DGListaCandidatos";
            DGListaCandidatos.RowHeadersWidth = 51;
            DGListaCandidatos.Size = new Size(497, 109);
            DGListaCandidatos.TabIndex = 12;
            DGListaCandidatos.CellContentClick += DGListaCandidatos_CellContentClick;
            DGListaCandidatos.DataBindingComplete += dataGridView1_DataBindingComplete;
            DGListaCandidatos.RowHeaderMouseClick += DGListaCandidatos_RowHeaderMouseClick;
            // 
            // Eliminar
            // 
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Name = "Eliminar";
            // 
            // btnAgregarCL
            // 
            btnAgregarCL.BackColor = SystemColors.ActiveBorder;
            btnAgregarCL.BackgroundColor = SystemColors.ActiveBorder;
            btnAgregarCL.BorderColor = Color.Black;
            btnAgregarCL.BorderRadius = 35;
            btnAgregarCL.BorderSize = 1;
            btnAgregarCL.FlatAppearance.BorderSize = 0;
            btnAgregarCL.FlatStyle = FlatStyle.Flat;
            btnAgregarCL.ForeColor = Color.Black;
            btnAgregarCL.Location = new Point(364, 27);
            btnAgregarCL.Margin = new Padding(3, 2, 3, 2);
            btnAgregarCL.Name = "btnAgregarCL";
            btnAgregarCL.Size = new Size(144, 25);
            btnAgregarCL.TabIndex = 11;
            btnAgregarCL.Text = "Agregar Integrante";
            btnAgregarCL.TextColor = Color.Black;
            btnAgregarCL.UseVisualStyleBackColor = false;
            btnAgregarCL.Click += btnAgregarCL_Click;
            // 
            // TBPuesto
            // 
            TBPuesto.Location = new Point(281, 88);
            TBPuesto.Name = "TBPuesto";
            TBPuesto.Size = new Size(205, 23);
            TBPuesto.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(281, 66);
            label4.Name = "label4";
            label4.Size = new Size(63, 22);
            label4.TabIndex = 6;
            label4.Text = "Puesto";
            // 
            // TBIntegrante
            // 
            TBIntegrante.Location = new Point(53, 88);
            TBIntegrante.Name = "TBIntegrante";
            TBIntegrante.Size = new Size(205, 23);
            TBIntegrante.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(54, 65);
            label3.Name = "label3";
            label3.Size = new Size(94, 22);
            label3.TabIndex = 4;
            label3.Text = "Integrante";
            // 
            // TBNombreLista
            // 
            TBNombreLista.Location = new Point(54, 39);
            TBNombreLista.Name = "TBNombreLista";
            TBNombreLista.Size = new Size(205, 23);
            TBNombreLista.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 16);
            label1.Name = "label1";
            label1.Size = new Size(160, 22);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la lista:";
            // 
            // labelListas
            // 
            labelListas.AutoSize = true;
            labelListas.Font = new Font("Modern No. 20", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelListas.Location = new Point(344, 37);
            labelListas.Name = "labelListas";
            labelListas.Size = new Size(124, 50);
            labelListas.TabIndex = 9;
            labelListas.Text = "Lista";
            // 
            // btnConfirmarCL
            // 
            btnConfirmarCL.BackColor = SystemColors.ActiveBorder;
            btnConfirmarCL.BackgroundColor = SystemColors.ActiveBorder;
            btnConfirmarCL.BorderColor = Color.Black;
            btnConfirmarCL.BorderRadius = 35;
            btnConfirmarCL.BorderSize = 1;
            btnConfirmarCL.FlatAppearance.BorderSize = 0;
            btnConfirmarCL.FlatStyle = FlatStyle.Flat;
            btnConfirmarCL.ForeColor = Color.Black;
            btnConfirmarCL.Location = new Point(429, 376);
            btnConfirmarCL.Margin = new Padding(3, 2, 3, 2);
            btnConfirmarCL.Name = "btnConfirmarCL";
            btnConfirmarCL.Size = new Size(124, 28);
            btnConfirmarCL.TabIndex = 12;
            btnConfirmarCL.Text = "Confirmar";
            btnConfirmarCL.TextColor = Color.Black;
            btnConfirmarCL.UseVisualStyleBackColor = false;
            btnConfirmarCL.Click += btnConfirmarCL_Click;
            // 
            // btnCancelarCL
            // 
            btnCancelarCL.BackColor = SystemColors.ActiveBorder;
            btnCancelarCL.BackgroundColor = SystemColors.ActiveBorder;
            btnCancelarCL.BorderColor = Color.Black;
            btnCancelarCL.BorderRadius = 35;
            btnCancelarCL.BorderSize = 1;
            btnCancelarCL.FlatAppearance.BorderSize = 0;
            btnCancelarCL.FlatStyle = FlatStyle.Flat;
            btnCancelarCL.ForeColor = Color.Black;
            btnCancelarCL.Location = new Point(251, 376);
            btnCancelarCL.Margin = new Padding(3, 2, 3, 2);
            btnCancelarCL.Name = "btnCancelarCL";
            btnCancelarCL.Size = new Size(124, 28);
            btnCancelarCL.TabIndex = 13;
            btnCancelarCL.Text = "Cancelar";
            btnCancelarCL.TextColor = Color.Black;
            btnCancelarCL.UseVisualStyleBackColor = false;
            btnCancelarCL.Click += btnCancelarCL_Click;
            // 
            // PantallaCrearLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_sistema;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelarCL);
            Controls.Add(btnConfirmarCL);
            Controls.Add(labelListas);
            Controls.Add(panel1);
            Name = "PantallaCrearLista";
            Text = "PantallaCrearLista";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaCandidatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox TBPuesto;
        private Label label4;
        private TextBox TBIntegrante;
        private Label label3;
        private TextBox TBNombreLista;
        private Label label1;
        private Label labelListas;
        private CPresentacion.Boton btnAgregarCL;
        private CPresentacion.Boton btnConfirmarCL;
        private CPresentacion.Boton btnCancelarCL;
        private DataGridView DGListaCandidatos;
        private DataGridViewButtonColumn Eliminar;
    }
}