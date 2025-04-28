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
    public partial class PantallaModificarVotacion : Form
    {
        private static int Id { get; set; }
        public PantallaModificarVotacion()
        {
            InitializeComponent();
        }

        private async void PantallaModificarVotacion_Load(object sender, EventArgs e)
        {
            await CargarElecciones();
            DataGridViewButtonColumn eliminarColumn = (DataGridViewButtonColumn)dgvListadoEleccion.Columns["Eliminar"];
            eliminarColumn.Text = "Eliminar";
            eliminarColumn.UseColumnTextForButtonValue = true;
        }
        private async Task CargarElecciones()
        {
            try
            {
                var elecciones = await Negocio.CasosDeUso.Eleccion.ObtenerTodo();
                dgvListadoEleccion.DataSource = elecciones;

                dgvListadoEleccion.Columns["Votos"].Visible = false;
                dgvListadoEleccion.Columns["Listas"].Visible = false;
                dgvListadoEleccion.Columns["PersonaElecciones"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las elecciones: {ex.Message}");
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListadoEleccion.Columns["Id"].DisplayIndex = 0;
            dgvListadoEleccion.Columns["NombreEleccion"].DisplayIndex = 1;
            dgvListadoEleccion.Columns["DescripcionEleccion"].DisplayIndex = 2;
            dgvListadoEleccion.Columns["CantidadListas"].DisplayIndex = 3;
            dgvListadoEleccion.Columns["FechaInicioEleccion"].DisplayIndex = 4;
            dgvListadoEleccion.Columns["FechaFinEleccion"].DisplayIndex = 5;
            dgvListadoEleccion.Columns["Eliminar"].DisplayIndex = 11;

        }

        private void btnVolverMV_Click(object sender, EventArgs e)
        {
            MenuAdministrador menuAdministrador = new MenuAdministrador();
            menuAdministrador.Show();
            this.Hide();
        }

        private async void dgvListadoEleccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbNombreEleccion.Text = dgvListadoEleccion.CurrentRow.Cells[2].Value.ToString();
                tbDescripcionEleccion.Text = dgvListadoEleccion.CurrentRow.Cells[3].Value.ToString();
                tbCantidadListas.Text = dgvListadoEleccion.CurrentRow.Cells[4].Value.ToString();
                dtFechafin.Text = dgvListadoEleccion.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (e.ColumnIndex == dgvListadoEleccion.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el Id de la fila seleccionada
                int id = (int)dgvListadoEleccion.Rows[e.RowIndex].Cells["Id"].Value;

                // Confirmar la eliminación con el usuario
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Eliminar el registro en la base de datos
                    await Negocio.CasosDeUso.Eleccion.Borrar(id);

                    // Volver a cargar los datos en el DataGridView
                    await CargarElecciones();
                }
            }
        }

        private void dgvListadoEleccion_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dgvListadoEleccion.Rows[e.RowIndex].Cells["Id"].Value);
            tbNombreEleccion.Text = dgvListadoEleccion.Rows[e.RowIndex].Cells[1].Value == DBNull.Value ? "" : dgvListadoEleccion.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbDescripcionEleccion.Text = dgvListadoEleccion.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? "" : dgvListadoEleccion.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbCantidadListas.Text = dgvListadoEleccion.Rows[e.RowIndex].Cells[3].Value == DBNull.Value ? "" : dgvListadoEleccion.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtFechafin.Text = dgvListadoEleccion.Rows[e.RowIndex].Cells[5].Value == DBNull.Value ? "" : dgvListadoEleccion.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private async void btModificar_Click(object sender, EventArgs e)
        {
            if (Id != -1) // Asegúrate de que hay un votante seleccionado
            {
                // Obtenemos los datos modificados desde los TextBox
                var eleccionModificarDTO = new Shared.Dtos.Eleccion.ModificarDTO
                {
                    NombreEleccion = tbNombreEleccion.Text,
                    DescripcionEleccion = tbDescripcionEleccion.Text,
                    CantidadListas = int.Parse(tbCantidadListas.Text),
                    FechaFinEleccion = DateTime.Parse(dtFechafin.Text),
                };

                try
                {
                    // Llamamos al método de negocio para actualizar el votante
                    await Negocio.CasosDeUso.Eleccion.Modificar(Id, eleccionModificarDTO);

                    // Confirmación de la modificación
                    MessageBox.Show("La elección ha sido modificado con éxito.");

                    // Recargar la lista de votantes para ver los cambios
                    await CargarElecciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar la elección: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una elección para modificar.");
            }
        }

        private async void btnBuscarME_Click(object sender, EventArgs e)
        {
            string textoBusqueda = tbBuscarElecciones.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un nombre o un ID para buscar.");
                return;
            }

            try
            {
                // Intenta convertir el texto de búsqueda a un número para buscar por ID
                if (int.TryParse(textoBusqueda, out int idBusqueda))
                {
                    // Buscar por ID
                    var resultadoPorId = await Negocio.CasosDeUso.Eleccion.obtenerPorId(idBusqueda);
                    if (resultadoPorId != null)
                    {
                        dgvListadoEleccion.DataSource = new List<Shared.Entities.Eleccion> { resultadoPorId };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una eleccion con ese ID.");
                        dgvListadoEleccion.DataSource = null;
                    }
                }
                else
                {
                    // Buscar por nombre
                    var resultadosPorNombre = await Negocio.CasosDeUso.Eleccion.obtenerPorNombre(textoBusqueda);
                    if (resultadosPorNombre != null && resultadosPorNombre.Any())
                    {
                        dgvListadoEleccion.DataSource = resultadosPorNombre;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron elecciones con ese nombre.");
                        dgvListadoEleccion.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private async void btRefrescar_Click(object sender, EventArgs e)
        {
            tbBuscarElecciones.Clear();
            await CargarElecciones();
        }
    }
}
