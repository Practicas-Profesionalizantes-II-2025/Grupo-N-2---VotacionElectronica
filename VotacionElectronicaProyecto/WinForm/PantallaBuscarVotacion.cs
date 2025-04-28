using Negocio.CasosDeUso;
using Shared.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class PantallaBuscarVotacion : Form
    {
        public PantallaBuscarVotacion()
        {
            InitializeComponent();

            // Deshabilitar la generación automática de columnas
            dgvResultados.AutoGenerateColumns = false;

            // Crear y agregar columnas
            var columnaNombreLista = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre de la Lista",
                DataPropertyName = "NombreLista" // Usar el nombre del DTO
            };
            dgvResultados.Columns.Add(columnaNombreLista);

            var columnaCantidadVotos = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad de Votos",
                DataPropertyName = "TotalVotos" // Usar la cantidad de votos del DTO
            };
            dgvResultados.Columns.Add(columnaCantidadVotos);
        }

        private async void btnVerResultadosBV_Click(object sender, EventArgs e)
        {
            if (VotacionSeleccionada.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una elección.");
                return;
            }

            string nombreEleccion = VotacionSeleccionada.Text;
            var elecciones = await Negocio.CasosDeUso.Eleccion.obtenerPorNombre(nombreEleccion);
            int? idEleccion = elecciones?.FirstOrDefault()?.Id;

            if (idEleccion == null)
            {
                MessageBox.Show("No se encontró la elección seleccionada.");
                return;
            }

            var resultados = await Negocio.CasosDeUso.Resultado.ObtenerResultadosPorEleccion((int)idEleccion);
            if (resultados != null && resultados.Any())
            {
                dgvResultados.DataSource = resultados;
                dgvResultados.Refresh();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para esta elección.");
            }

        }


        private async void PantallaBuscarVotacion_Load(object sender, EventArgs e)
        {
            await CargarElecciones();
        }

        private async Task CargarElecciones()
        {
            try
            {
                // Obtener las elecciones
                var elecciones = await Negocio.CasosDeUso.Eleccion.ObtenerTodo();

                if (elecciones == null || elecciones.Count == 0)
                {
                    MessageBox.Show("No se encontraron elecciones.");
                    return;
                }

                VotacionSeleccionada.DataSource = elecciones;
                VotacionSeleccionada.DisplayMember = "NombreEleccion";
                VotacionSeleccionada.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar elecciones: {ex.Message}");
            }
        }

        private void btnVolverBV_Click(object sender, EventArgs e)
        {
            PantallaInicio pantallaInicio = new PantallaInicio();
            pantallaInicio.Show();
            this.Hide();
        }
    }
}
