namespace MVCProyecto.ViewModels
{
    public class PersonaEleccion
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }
        public bool Autorizada { get; set; } = true;
    }
}
