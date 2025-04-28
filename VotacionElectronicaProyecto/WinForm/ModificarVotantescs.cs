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
    public partial class ModificarVotantescs : Form
    {
        private static int Id { get; set; }

        public ModificarVotantescs()
        {
            InitializeComponent();
            Id = -1;
        }
        private async void FormVotantes_Load(object sender, EventArgs e)
        {
            await CargarVotantes();
            dgvListaVotantes.Columns["Eliminar"].DisplayIndex = dgvListaVotantes.Columns.Count - 1; // Cambiar el orden de la columna "Eliminar" al final                                                                                         // Asegurarse de que la columna es del tipo DataGridViewButtonColumn
            DataGridViewButtonColumn eliminarColumn = (DataGridViewButtonColumn)dgvListaVotantes.Columns["Eliminar"];
            eliminarColumn.Text = "Eliminar";
            eliminarColumn.UseColumnTextForButtonValue = true;

        }
        private async Task CargarVotantes()
        {
            try
            {
                var votantes = await Negocio.CasosDeUso.Persona.ObtenerTodo();
                dgvListaVotantes.DataSource = votantes; // Asigna la lista de votantes al DataGridView

                dgvListaVotantes.Columns["PersonaElecciones"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los votantes: {ex.Message}");
            }
        }

        private void btnVolverMV_Click(object sender, EventArgs e)
        {
            MenuAdministrador menuAdministrador = new MenuAdministrador();
            menuAdministrador.Show();
            this.Hide();
        }

        private async void dgvListaVotantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbNroIdentificacion.Text = dgvListaVotantes.CurrentRow.Cells[2].Value.ToString();
                tbNombre.Text = dgvListaVotantes.CurrentRow.Cells[3].Value.ToString();
                tbApellido.Text = dgvListaVotantes.CurrentRow.Cells[4].Value.ToString();
                tbContrasenia.Text = dgvListaVotantes.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (e.ColumnIndex == dgvListaVotantes.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el Id de la fila seleccionada
                int id = (int)dgvListaVotantes.Rows[e.RowIndex].Cells["Id"].Value;

                // Confirmar la eliminación con el usuario
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Eliminar el registro en la base de datos
                    await Negocio.CasosDeUso.Persona.Borrar(id);

                    // Volver a cargar los datos en el DataGridView
                    await CargarVotantes();
                }
            }
        }
        private void dgvListaVotantes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dgvListaVotantes.Rows[e.RowIndex].Cells["Id"].Value);
            tbNroIdentificacion.Text = dgvListaVotantes.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? "" : dgvListaVotantes.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbNombre.Text = dgvListaVotantes.Rows[e.RowIndex].Cells[3].Value == DBNull.Value ? "" : dgvListaVotantes.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbApellido.Text = dgvListaVotantes.Rows[e.RowIndex].Cells[4].Value == DBNull.Value ? "" : dgvListaVotantes.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbContrasenia.Text = dgvListaVotantes.Rows[e.RowIndex].Cells[5].Value == DBNull.Value ? "" : dgvListaVotantes.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private async void btModificar_Click(object sender, EventArgs e)
        {
            if (Id != -1) // Asegúrate de que hay un votante seleccionado
            {
                // Obtenemos los datos modificados desde los TextBox
                var personaModificarDTO = new Shared.Dtos.Persona.ModificarDTO
                {
                    NombrePersona = tbNombre.Text,
                    ApellidoPersona = tbApellido.Text,
                    ContraseniaPersona = tbContrasenia.Text
                };

                try
                {
                    // Llamamos al método de negocio para actualizar el votante
                    await Negocio.CasosDeUso.Persona.Modificar(Id, personaModificarDTO);

                    // Confirmación de la modificación
                    MessageBox.Show("El votante ha sido modificado con éxito.");

                    // Recargar la lista de votantes para ver los cambios
                    await CargarVotantes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el votante: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un votante para modificar.");
            }
        }

        private async void btnBuscarMV_Click(object sender, EventArgs e)
        {
            string textoBusqueda = tbBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un nombre o un ID para buscar.");
                return;
            }

            try
            {
                if (int.TryParse(textoBusqueda, out int idBusqueda))
                {
                    // Buscar por ID
                    var resultadoPorId = await Negocio.CasosDeUso.Persona.ObtenerPorId(idBusqueda);
                    if (resultadoPorId != null)
                    {
                        dgvListaVotantes.DataSource = new List<Shared.Entities.Persona> { resultadoPorId };
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un votante con ese ID.");
                        dgvListaVotantes.DataSource = null;
                    }
                }
                else
                {
                    // Buscar por nombre
                    var resultadosPorNombre = await Negocio.CasosDeUso.Persona.ObtenerPorNombre(textoBusqueda);
                    if (resultadosPorNombre != null && resultadosPorNombre.Any())
                    {
                        dgvListaVotantes.DataSource = resultadosPorNombre;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron votantes con ese nombre.");
                        dgvListaVotantes.DataSource = null;
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
            tbBuscar.Clear();
            await CargarVotantes();
        }
    }

}
