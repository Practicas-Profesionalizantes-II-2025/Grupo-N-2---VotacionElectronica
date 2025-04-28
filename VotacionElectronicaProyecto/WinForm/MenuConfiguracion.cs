using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MenuConfiguracion : Form
    {
        public MenuConfiguracion()
        {
            InitializeComponent();
        }

        private void btnIngresarMC_Click(object sender, EventArgs e)
        {
            string contraseñaCorrecta = "admi1234";
            if (txtContraseña.Text == contraseñaCorrecta)
            {
                MessageBox.Show("Acceso concedido");
                MenuAdministrador menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }

        }

        private void btnSalirMC_Click(object sender, EventArgs e)
        {
            PantallaInicio pantallaInicio = new PantallaInicio();
            pantallaInicio.Show();
            this.Hide();
        }
        private void BtnMostrar_MouseDown(object sender, MouseEventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false; // Mostrar la contraseña en texto plano
        }

        // Evento cuando se suelta el botón (ocultar contraseña)
        private void BtnMostrar_MouseUp(object sender, MouseEventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true; // Volver a mostrar la contraseña con asteriscos
        }

    }
}
