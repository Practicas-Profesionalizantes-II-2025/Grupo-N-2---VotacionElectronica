using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Helper;
using Shared.Entities;

namespace WinForm
{
    public partial class PantallaVotarLista : Form
    {
        private int ID { get; set; }
        private int IDLista { get; set; }


        public PantallaVotarLista(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private async void PantallaVotarLista_Load(object sender, EventArgs e)
        {
            try
            {

                // Obtener las elecciones

                var listas = await Negocio.CasosDeUso.Eleccion.ObtenerListasPorEleccion(ID);

                if (listas == null || listas.Count == 0)
                {
                    MessageBox.Show("No se encontraron elecciones.");
                    return;
                }

                Listas.DataSource = listas;
                Listas.DisplayMember = "NombreLista";
                Listas.ValueMember = "Id";
                CargarCandidatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar elecciones: {ex.Message}");
            }

        }

        private async void BtnVotarVL_Click(object sender, EventArgs e)
        {
            try
            {


                var ListaElegida = await Negocio.CasosDeUso.Lista.obtenerPorNombre(Listas.Text);
                int IDLista = ListaElegida[0].Id;
                var voto = new Shared.Dtos.Voto.CrearDTO
                {
                    EleccionId = ID,
                    ListaId = IDLista
                };
                await Negocio.CasosDeUso.Voto.RegistrarVoto(voto);
                MessageBox.Show("Voto creado con exito.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Voto Hecho incorrectamente", "Intentelo de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task CargarCandidatos()
        {
            var ListaElegida = await Negocio.CasosDeUso.Lista.obtenerPorNombre(Listas.Text);
            if (ListaElegida != null)
            {


                int IDLista = ListaElegida[0].Id;
                try
                {
                    var candidatos = await Negocio.CasosDeUso.Candidatos.ObtenerTodo();

                    var candidatosFiltrados = candidatos.Where(c => c.IdLista == IDLista).ToList();

                    DGLista.DataSource = candidatosFiltrados;
                    DGLista.Columns["IdLista"].Visible = false;
                    DGLista.Columns["Lista"].Visible = false;
                    label1.Text = ListaElegida[0].NombreLista;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los candidatos: {ex.Message}");
                }
            }
        }
        private void DGLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGLista.Columns["Id"].DisplayIndex = 0;
            DGLista.Columns["NombreCandidato"].DisplayIndex = 1;
            DGLista.Columns["PuestoCandidato"].DisplayIndex = 2;
        }

        private void Listas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCandidatos();
        }

        private void btnVolverVL_Click(object sender, EventArgs e)
        {
            PantallaVotaciones PVotaciones = new PantallaVotaciones();
            PVotaciones.Show();
            this.Hide();
        }

        private async void btnVotoBlancoVL_Click(object sender, EventArgs e)
        {
            string Blanco = "Voto en Blanco";
            var ListaId = await Negocio.CasosDeUso.Lista.obtenerPorNombre(Blanco);
            int BlancoId = ListaId[0].Id;
            try
            {
                var voto = new Shared.Dtos.Voto.CrearDTO
                {
                    EleccionId = ID,
                    ListaId = BlancoId
                };
                await Negocio.CasosDeUso.Voto.RegistrarVoto(voto);
                MessageBox.Show("Voto en blanco registrado correctamente.");
            }
            catch
            {
                MessageBox.Show("Error al registrar el voto en blanco.");
            }

        }
    }
}
