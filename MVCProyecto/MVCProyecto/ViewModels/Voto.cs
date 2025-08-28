namespace MVCProyecto.ViewModels
{
    public class Voto
    {
        public DateTime FechaVoto { get; set; }
        public DateTime HoraVoto { get; set; }

        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }

        public int ListaId { get; set; }
        public Lista Lista { get; set; }
        public int? ResultadoId { get; set; } // Hacerlo nullable
        public Resultado Resultado { get; set; }
    }
}
