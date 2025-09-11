namespace MVCProyecto.ViewModels
{
    public class EleccionLista
    {
        public int IdEleccion { get; set; }
        public int IdLista { get; set; }

        public string DescripcionEleccionLista { get; set; }
        public Eleccion Eleccion { get; set; }
        public Lista Lista { get; set; }
    }
}
