using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.CasosDeUso;

namespace WinForm
{
    public partial class PantallaAltaVotante : Form
    {
        public PantallaAltaVotante()
        {
            InitializeComponent();
        }

        private async void btnRegistrarAV_Click(object sender, EventArgs e)
        {
            try
            {
                var personaDTO = new Shared.Dtos.Persona.CrearDTO
                {
                    NombrePersona = TBNombre.Text,
                    NroIdentificacionPersona = TBNumero.Text,
                    ApellidoPersona = TBApellido.Text,
                    TipoDocumentoPersona = CBDocumento.Text,
                    ContraseniaPersona = "nulo"

                };

                // Llamar al caso de uso para crear el votante (en la capa de negocio)
                await Persona.Crear(personaDTO);
                var PersonaContra = await Negocio.CasosDeUso.Persona.ObtenerPorNombre(TBNombre.Text);
                string Contra = PersonaContra[0].ContraseniaPersona;

                PantallaCrearContrasenia pantallaCrearContrasenia = new(TBNombre.Text, Contra);
                pantallaCrearContrasenia.Show();

                // Cerrar la pantalla de registro
                this.Close();
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnCancelarAV_Click(object sender, EventArgs e)
        {
            MenuAdministrador menuAdmi = new MenuAdministrador();
            menuAdmi.Show();
            this.Hide();
        }
    }
}
        
   
