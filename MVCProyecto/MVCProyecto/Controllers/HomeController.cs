using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models;
using MVCProyecto.ViewModels;

namespace MVCProyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Obtenemos el rol del usuario desde la sesión
            var rol = HttpContext.Session.GetString("Rol");
            var items = new List<MenuItemViewModel>();

            if (rol == "Administrador")
            {
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Elecciones",
                    Descripcion = "Gestionar elecciones existentes",
                    Controller = "Eleccion",
                    Action = "ListaEleccion",
                    Icono = "bi bi-ballot"
                });
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Listas",
                    Descripcion = "Asignar y administrar listas",
                    Controller = "Lista",
                    Action = "ListaLista",
                    Icono = "bi bi-people"
                });
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Candidatos",
                    Descripcion = "Asignar y administrar candidatos",
                    Controller = "Candidatos",
                    Action = "ListaCandidatos",
                    Icono = "bi bi-people"
                });
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Personas",
                    Descripcion = "Ver y crear personas",
                    Controller = "Persona",
                    Action = "ListaPersonas",
                    Icono = "bi bi-person-badge"
                });
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Resultados",
                    Descripcion = "Visualizar resultados de elecciones",
                    Controller = "Resultado",
                    Action = "Index",
                    Icono = "bi bi-bar-chart"
                });
            }
            else if (rol == "Votante")
            {
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Resultados",
                    Descripcion = "Visualizar resultados de elecciones",
                    Controller = "Resultado",
                    Action = "Index",
                    Icono = "bi bi-bar-chart"
                });
                items.Add(new MenuItemViewModel
                {
                    Titulo = "Emitir voto",
                    Descripcion = "Participa en la elección",
                    Controller = "Votos",
                    Action = "Emitir",
                    Icono = "bi bi-check2-square"
                });
            }

            var menu = new MenuViewModel { Items = items };
            return View(menu);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



