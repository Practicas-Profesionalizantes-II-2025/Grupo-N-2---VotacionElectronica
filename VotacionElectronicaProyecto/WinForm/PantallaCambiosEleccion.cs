using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Dtos.Eleccion;

namespace WinForm
{
    public partial class PantallaCambiosEleccion : Form
    {
        public PantallaCambiosEleccion()
        {
            InitializeComponent();
        }

        private async void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos de entrada
                if (string.IsNullOrWhiteSpace(TxtNombreEleccion.Text) || string.IsNullOrWhiteSpace(TxtDNIPersona.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la elección por nombre
                var eleccionesBuscadas = await Negocio.CasosDeUso.Eleccion.obtenerPorNombre(TxtNombreEleccion.Text);

                // Verifica si se encontraron elecciones
                if (eleccionesBuscadas == null || eleccionesBuscadas.Count == 0)
                {
                    MessageBox.Show("No se encontraron elecciones con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                // Obtener la persona por DNI
                var personaBuscada = await Negocio.CasosDeUso.Persona.ObtenerPorDni(TxtDNIPersona.Text);
                if (personaBuscada == null)
                {
                    MessageBox.Show("Persona no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                
                var asignarDto = new AsignarPersonaEleccionDTO
                {
                    EleccionId = eleccionesBuscadas[0].Id,
                    PersonaId = personaBuscada.Id,
                    Autorizada = true 
                };

                // Llama al caso de uso para asignar la persona a la elección
                await Negocio.CasosDeUso.Eleccion.AsignarPersonaEleccion(asignarDto);

                MessageBox.Show($"Persona: {personaBuscada.NombrePersona} {personaBuscada.ApellidoPersona}, asignada correctamente.", "Asignada Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDNIPersona.Clear();
                TxtNombreEleccion.Clear();
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnSalirCV_Click(object sender, EventArgs e)
        {
            MenuAdministrador menuAdministrador = new MenuAdministrador();
            menuAdministrador.Show();
            this.Close();
        }
    }
}
