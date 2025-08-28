namespace MVCProyecto.ViewModels
{
    public class Candidatos
    {
        public const int LengthNombreCandidato = 30;
        public const int LengthPuestoCandidato = 20;
        public string NombreCandidato { get; set; }

        public string PuestoCandidato { get; set; }

        public int IdLista { get; set; }
        public Lista Lista { get; set; }
    }
}
