namespace MVCProyecto.Models.Menu
{
 
    public class HomeViewModel
    {
        public EleccionViewModel? CurrentElection { get; set; }
        public List<CandidatoViewModel> Candidates { get; set; } = new();

        // Estado del usuario
        public bool UserHasVoted { get; set; }
        public DateTime? UserVoteDate { get; set; }
    }

    public class EleccionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Propiedad calculada para saber si está activa
        public bool EstaActiva
            => DateTime.Now >= FechaInicio && DateTime.Now <= FechaFin;
    }

    public class CandidatoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Partido { get; set; }
        public string? DescripcionBreve { get; set; }
    }

}
