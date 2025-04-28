using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Dtos;
using Negocio.CasosDeUso;
using WinForm;

namespace WinForm
{
    public partial class PantallaCrearVotacion : Form
    {
        public PantallaCrearVotacion()
        {
            InitializeComponent();
        }

        private async void btnAceptarCV_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar la fecha de inicio y fin
                if (DTFechaInicio.Value >= DTFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el DTO con los datos ingresados en el formulario
                int cantidadListas = 0;
                if (!int.TryParse(TBCantidadListas.Text, out cantidadListas))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para la cantidad de listas.");
                    return;
                }

                var eleccionDTO = new Shared.Dtos.Eleccion.CrearDTO
                {
                    NombreEleccion = TBNombreVotacion.Text,
                    DescripcionEleccion = TBDescripcionEleccion.Text,
                    CantidadListas = cantidadListas,
                    FechaInicioEleccion = DTFechaInicio.Value,
                    FechaFinEleccion = DTFechaFin.Value,
                };

                // Llamar al caso de uso para crear la elección
                await Eleccion.Crear(eleccionDTO);
                var eleccionesBuscadas = await Negocio.CasosDeUso.Eleccion.obtenerPorNombre(TBNombreVotacion.Text);
                int idEleccion = eleccionesBuscadas[0].Id;

                // Verifica si se encontraron elecciones
                if (eleccionesBuscadas == null || eleccionesBuscadas.Count == 0)
                {
                    MessageBox.Show("No se encontraron elecciones con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var listaBlancoDTO = new Shared.Dtos.Lista.CrearDTO
                {
                    NombreLista = "Voto en Blanco",
                    DescripcionLista = "Voto Blanco",
                };
                await Lista.Crear(listaBlancoDTO);

                var listablanco = await Negocio.CasosDeUso.Lista.obtenerPorNombre(listaBlancoDTO.NombreLista);
                int idBlanco = listablanco.LastOrDefault().Id;
                var asignarlistaDTO = new Shared.Dtos.Eleccion.AsignarListaDTO
                {
                    EleccionId = idEleccion,
                    ListaId = idBlanco,
                    Descripcion = "Asignado"

                };

                await Negocio.CasosDeUso.Eleccion.AsignarLista(asignarlistaDTO);
                // Mostrar la pantalla de creación de listas tantas veces como se especificó
                for (int i = 0; i < cantidadListas; i++)
                {
                    var listaDTO = new Shared.Dtos.Lista.CrearDTO
                    {
                        NombreLista = "A",
                        DescripcionLista = "a",
                    };
                    await Lista.Crear(listaDTO);

                    var listas = await Negocio.CasosDeUso.Lista.obtenerPorNombre(listaDTO.NombreLista);
                    PantallaCrearLista pListas = new PantallaCrearLista(listas.Last().Id,idEleccion);
                    pListas.ShowDialog(); // Muestra el dialogo y espera a que se cierre
                }

                // Mostrar un mensaje de éxito o una nueva pantalla si es necesario
                MessageBox.Show("Elección creada y listas agregadas correctamente.");
                PantallaVotacionCreada pantallaVotacionCreada = new PantallaVotacionCreada();
                pantallaVotacionCreada.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje
                MessageBox.Show($"Error: {ex.Message}\n\nDetalles: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para salir y regresar al menú
        private void btnSalirCV_Click(object sender, EventArgs e)
        {
            MenuAdministrador madmin = new MenuAdministrador();
            madmin.Show();
            this.Hide();
        }


        
    }
}