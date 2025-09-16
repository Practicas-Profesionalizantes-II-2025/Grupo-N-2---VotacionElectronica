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
            var menu = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel
                    {
                        Titulo = "Elecciones",
                        Descripcion = "Gestionar elecciones existentes",
                        Controller = "Eleccion",
                        Action = "ListaEleccion",
                        Icono = "bi bi-ballot"
                    },
                    new MenuItemViewModel
                    {
                        Titulo = "Listas",
                        Descripcion = "Asignar y administrar listas",
                        Controller = "ListaLista",
                        Action = "Index",
                        Icono = "bi bi-people"
                    },
                    new MenuItemViewModel
                    {
                        Titulo = "Personas",
                        Descripcion = "Ver y crear personas",
                        Controller = "Persona",
                        Action = "ListaPersonas",
                        Icono = "bi bi-person-badge"
                    },
                    new MenuItemViewModel
                    {
                        Titulo = "Resultados",
                        Descripcion = "Visualizar resultados de elecciones",
                        Controller = "Resultado",
                        Action = "Index",
                        Icono = "bi bi-bar-chart"
                    }
                }
            };

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



