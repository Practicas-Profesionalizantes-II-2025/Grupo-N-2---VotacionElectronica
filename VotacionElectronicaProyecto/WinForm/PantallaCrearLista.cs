using Microsoft.Identity.Client;
using Negocio.CasosDeUso;
using Shared.Entities;
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
    public partial class PantallaCrearLista : Form
    {
        private static int IdL { get; set; }
        private static int IdE { get; set; }
        public PantallaCrearLista(int Id, int IdEleccion)
        {
            InitializeComponent();
            IdL = Id;
            IdE = IdEleccion;
        }

        private async void FormVotantes_Load(object sender, EventArgs e)
        {
            await CargarCandidatos();                                                                                        
            DataGridViewButtonColumn eliminarColumn = (DataGridViewButtonColumn)DGListaCandidatos.Columns["Eliminar"];
            eliminarColumn.Text = "Eliminar";
            eliminarColumn.UseColumnTextForButtonValue = true;
        }
        private async Task CargarCandidatos()
        {
            try
            {
                var candidatos = await Negocio.CasosDeUso.Candidatos.ObtenerTodo();

                var candidatosFiltrados = candidatos.Where(c => c.IdLista == IdL).ToList();

                DGListaCandidatos.DataSource = candidatosFiltrados;

                DGListaCandidatos.Columns["IdLista"].Visible = false;
                DGListaCandidatos.Columns["Lista"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los candidatos: {ex.Message}");
            }
        }
        private async void btnAgregarCL_Click(object sender, EventArgs e)
        {
            try
            {
                var candidatosDTO = new Shared.Dtos.Candidatos.CrearDTO
                {
                    NombreCandidato = TBIntegrante.Text,
                    PuestoCandidato = TBPuesto.Text,
                    IdLista = IdL
                    
                };

                await Negocio.CasosDeUso.Candidatos.Crear(candidatosDTO);

                // Volver a cargar los datos en el DataGridView después de agregar
                await CargarCandidatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGListaCandidatos.Columns["Id"].DisplayIndex = 0;
            DGListaCandidatos.Columns["NombreCandidato"].DisplayIndex = 1;
            DGListaCandidatos.Columns["PuestoCandidato"].DisplayIndex = 2;
            DGListaCandidatos.Columns["Eliminar"].DisplayIndex = 7;
        }
        private async void DGListaCandidatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica si la celda que se hizo clic es la columna de eliminar
                if (e.ColumnIndex == DGListaCandidatos.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    // Obtener el Id de la fila seleccionada
                    int id = (int)DGListaCandidatos.Rows[e.RowIndex].Cells["Id"].Value;

                    // Confirmar la eliminación con el usuario
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                                         "Confirmar eliminación",
                                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Eliminar el registro en la base de datos
                        await Negocio.CasosDeUso.Candidatos.Borrar(id);

                        // Volver a cargar los datos en el DataGridView
                        await CargarCandidatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelarCL_Click(object sender, EventArgs e)
        {
            PantallaCrearVotacion pvotacion = new PantallaCrearVotacion();
            pvotacion.Show();
            this.Hide();
        }

        private async void btnConfirmarCL_Click(object sender, EventArgs e)
        {
            var listaDTO = new Shared.Dtos.Lista.ModificarDTO
            {
                NombreLista = TBNombreLista.Text,
                DescripcionLista = TBNombreLista.Text,

            };

            await Negocio.CasosDeUso.Lista.Modificar(IdL,listaDTO);


            var asignarlistaDTO = new Shared.Dtos.Eleccion.AsignarListaDTO
            {
                EleccionId = IdE,
                ListaId = IdL,
                Descripcion = "Asignado"
                
            };

            await Negocio.CasosDeUso.Eleccion.AsignarLista(asignarlistaDTO);
            MenuAdministrador madmi = new MenuAdministrador();
            madmi.Show();
            this.Hide();
        }

        private void DGListaCandidatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdL = Convert.ToInt32(DGListaCandidatos.Rows[e.RowIndex].Cells["Id"].Value);
            TBNombreLista.Text = DGListaCandidatos.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? "" : DGListaCandidatos.Rows[e.RowIndex].Cells[2].Value.ToString();
            TBIntegrante.Text = DGListaCandidatos.Rows[e.RowIndex].Cells[3].Value == DBNull.Value ? "" : DGListaCandidatos.Rows[e.RowIndex].Cells[3].Value.ToString();
            TBPuesto.Text = DGListaCandidatos.Rows[e.RowIndex].Cells[4].Value == DBNull.Value ? "" : DGListaCandidatos.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }
    }
}
