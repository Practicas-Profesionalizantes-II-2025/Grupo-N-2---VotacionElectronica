using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.CasosDeUso;
using Negocio.Contract;
using Negocio.Helper;
using Negocio.Implementations;

namespace WinForm
{
    public partial class PantallaVotaciones : Form
    {
        public PantallaVotaciones()
        {
            InitializeComponent();
            label1.Text = Session.CurrentPersona.NroIdentificacionPersona;
        }


        private void botonSalir_Click(object sender, EventArgs e)
        {
            Session.CurrentPersona = null;
            PantallaInicio pantallaInicio = new PantallaInicio();
            pantallaInicio.Show();
            this.Hide();
        }


        private async void PantallaVotaciones_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener las elecciones

                var elecciones = await Negocio.CasosDeUso.Persona.ObtenerEleccionesAutorizadas(Session.CurrentPersona.NroIdentificacionPersona);

                if (elecciones == null || elecciones.Count == 0)
                {
                    MessageBox.Show("No se encontraron elecciones.");
                    return;
                }
                var eleccionesFiltradas = elecciones.Where(eleccion => eleccion.NombreEleccion != "Voto en Blanco").ToList();
                CBVotacion.DataSource = eleccionesFiltradas;
                CBVotacion.DisplayMember = "NombreEleccion";
                CBVotacion.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar elecciones: {ex.Message}");
            }

        }

        private async void btnVotarPV_Click(object sender, EventArgs e)
        {
            var VotacionCB = await Negocio.CasosDeUso.Eleccion.obtenerPorNombre(CBVotacion.Text);
            int IdVotacion = VotacionCB[0].Id;
            PantallaVotarLista pantallaVotarLista = new PantallaVotarLista(IdVotacion);
            pantallaVotarLista.Show();
            this.Hide();
        }
    }
}
