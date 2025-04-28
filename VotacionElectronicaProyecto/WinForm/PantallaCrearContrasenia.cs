
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace WinForm
{
    public partial class PantallaCrearContrasenia : Form
    {
        public PantallaCrearContrasenia(string nombreIngresado, string Contraseña)
        {
            InitializeComponent();

            lblNombre.Text = $"Votante: {nombreIngresado}";

            lblContrasenia.Text = Contraseña;


        }

        private void btnAceptarCG_Click(object sender, EventArgs e)
        {
            PantallaAltaVotante pAlta = new PantallaAltaVotante();
            this.Hide();
            pAlta.Show();
        }
    }
}
