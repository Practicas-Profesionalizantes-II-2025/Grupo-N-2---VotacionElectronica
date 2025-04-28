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
    public partial class PantallaSalirdelSistema : Form
    {
        public PantallaSalirdelSistema()
        {
            InitializeComponent();
        }

        private void btnAceptarSS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancelarSS_Click(object sender, EventArgs e)
        {
            PantallaInicio pantallaInicio = new PantallaInicio();
            this.Close();
            pantallaInicio.Show();
        }
    }
}
