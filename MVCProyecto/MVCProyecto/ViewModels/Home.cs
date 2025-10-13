namespace MVCProyecto.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> Items { get; set; } = new();
    }

    public class MenuItemViewModel
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icono { get; set; } // opcional, para un ícono en la UI
    }
}
