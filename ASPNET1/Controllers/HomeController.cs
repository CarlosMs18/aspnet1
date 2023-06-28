using ASPNET1.Models;
using ASPNET1.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNET1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositorioProyectos repositorioProyectos;

        public HomeController(ILogger<HomeController> logger, RepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            ViewBag.Nombre = "Carlos Melgarejo 2";//Datos dinamicos para que sea renderizado en el html


            //var persona = new Persona()
            //{
            //    Nombre = "Carlos Melgarejo",
            //    Edad = 27
            //};

            /*return View("Index","Carlos Melgarejo");*/ // significa buscame una vista con el mismo nombre que esta en la accion
                                                         // si cambiamos de nombre en el index podemos poner un nombre en particular
            //var repositorioProyectos = new RepositorioProyectos(); // YA NO ES NECESARIO USAR PQ ESTAMOS USANDO LA INYECCION DE DEPENDENCIAS
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos }; 
            

            return View(/*persona*/modelo);
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