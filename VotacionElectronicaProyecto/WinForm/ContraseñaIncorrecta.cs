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
    public partial class ContraseñaIncorrecta : Form
    {
        public ContraseñaIncorrecta()
        {
            InitializeComponent();
        }


        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            PantallaVotacion pantallaVotacion = new PantallaVotacion();
            pantallaVotacion.Show();
            this.Hide();
        }

    }
}
