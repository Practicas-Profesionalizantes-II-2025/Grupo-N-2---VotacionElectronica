using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Negocio.Helper;
using Shared.Entities;

namespace WinForm
{
    public partial class PantallaVotacion : Form
    {
        private bool Autenticacion = false;
        public PantallaVotacion()
        {
            InitializeComponent();
        }

        private async void btnAutenticarPV_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBox1.Text;

                // Llamada al caso de uso para autenticar al usuario
                var persona = await Negocio.CasosDeUso.Persona.AutenticarPorContraseña(password);

                if (persona != null)
                {
                    MessageBox.Show($"Bienvenido, {persona.NombrePersona}", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label2.Text = ($"{persona.NombrePersona} ,{persona.ApellidoPersona}");
                    Session.CurrentPersona = persona;
                    Autenticacion = true;

                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta. Inténtelo de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Autenticacion = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVotarPV_Click(object sender, EventArgs e)
        {
            if (Autenticacion == true)
            {
                PantallaVotaciones pantallaVotaciones = new PantallaVotaciones();
                pantallaVotaciones.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe autenticarse primero", "Autenticación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalirPV_Click(object sender, EventArgs e)
        {
            PantallaInicio pinicio = new PantallaInicio();
            pinicio.Show();
            this.Hide();
        }
    }

}
