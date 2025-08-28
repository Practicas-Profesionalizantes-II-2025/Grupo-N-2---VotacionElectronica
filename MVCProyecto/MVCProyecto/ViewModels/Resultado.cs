namespace MVCProyecto.ViewModels
{
    public class Resultado
    {
        public int EleccionId { get; set; } // Agregar esta propiedad para referenciar a Eleccion
        public Eleccion Eleccion { get; set; }
        public int CantidadVotos { get; set; }
        public ICollection<Voto> Votos { get; set; }
    }
}
