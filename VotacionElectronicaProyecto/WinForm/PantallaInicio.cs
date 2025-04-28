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
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void btnVotacion_Click(object sender, EventArgs e)
        {
            PantallaVotacion pVotacion = new PantallaVotacion();
            pVotacion.Show();
            this.Hide();
        }

        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            MenuConfiguracion mAdministrador = new MenuConfiguracion();
            mAdministrador.Show();
            this.Hide();
        }

        private void btnSalirPI_Click(object sender, EventArgs e)
        {
            PantallaSalirdelSistema pSalirSistema = new PantallaSalirdelSistema();
            pSalirSistema.Show();
            this.Hide();
        }

        private void buttonVerResultados_Click(object sender, EventArgs e)
        {
            PantallaBuscarVotacion pantallaBuscarVotacion = new PantallaBuscarVotacion();
            pantallaBuscarVotacion.Show();
            this.Hide();
        }
    }
}
