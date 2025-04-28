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
    public partial class MenuAdministrador : Form
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void BotonAgregarVotante_Click(object sender, EventArgs e)
        {
            PantallaAltaVotante pAltaVotante = new PantallaAltaVotante();
            pAltaVotante.Show();
            this.Hide();
        }

        private void btnSalirMA_Click(object sender, EventArgs e)
        {
            MenuConfiguracion menuConfiguracion = new MenuConfiguracion();
            menuConfiguracion.Show();
            this.Hide();
        }

        private void BotonModificarVotante_Click(object sender, EventArgs e)
        {
            ModificarVotantescs modificarVotantescs = new ModificarVotantescs();
            modificarVotantescs.Show();
            this.Hide();
        }

        private void BotonCrearNuevaVotacion_Click(object sender, EventArgs e)
        {
            PantallaCrearVotacion pantallaCrearVotacion = new PantallaCrearVotacion();
            pantallaCrearVotacion.Show();
            this.Hide();
        }

        private void BotonModificarVotacion_Click(object sender, EventArgs e)
        {
            PantallaModificarVotacion modificarvot = new PantallaModificarVotacion();
            modificarvot.Show();
            this.Hide();
        }

        private void BtnEleccion_Click(object sender, EventArgs e)
        {
            PantallaCambiosEleccion pantallaCambiosEleccion = new PantallaCambiosEleccion();
            pantallaCambiosEleccion.Show();
            this.Hide();
        }
    }
}
