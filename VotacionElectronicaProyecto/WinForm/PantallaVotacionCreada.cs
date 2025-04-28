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
    public partial class PantallaVotacionCreada : Form
    {
        public PantallaVotacionCreada()
        {
            InitializeComponent();
        }

        private void btnConfirmarVC_Click(object sender, EventArgs e)
        {
            PantallaCrearVotacion pcrear = new PantallaCrearVotacion();
            pcrear.Show();
            this.Close();
        }
    }
}
