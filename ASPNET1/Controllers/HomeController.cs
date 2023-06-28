using ASPNET1.Models;
using ASPNET1.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNET1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioDelimitado servicioDelimitado2;
        private readonly ServicioUnico servicioUnico2;
        private readonly ServicioTransitorio servicioTransitorio2;

        //public HomeController(ILogger<HomeController> logger, RepositorioProyectos repositorioProyectos) antes de la inyeccion por dependencia por interfaces
        public HomeController(
                              ILogger<HomeController> logger, 
                              IRepositorioProyectos repositorioProyectos,
                               ServicioDelimitado servicioDelimitado,
                               ServicioUnico servicioUnico,
                               ServicioTransitorio servicioTransitorio,


                                  ServicioDelimitado servicioDelimitado2,
                                   ServicioUnico servicioUnico2,
                                   ServicioTransitorio servicioTransitorio2
                                )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado2 = servicioDelimitado2;
            this.servicioUnico2 = servicioUnico2;
            this.servicioTransitorio2 = servicioTransitorio2;
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

            //var guidViewModel = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado.ObtenerGuid,
            //    Transitorio = servicioTransitorio.ObtenerGuid,
            //    Unico = servicioUnico.ObtenerGuid
            //};


            //var guidViewModel2 = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado2.ObtenerGuid,
            //    Transitorio = servicioTransitorio2.ObtenerGuid,
            //    Unico = servicioUnico2.ObtenerGuid
            //};

            _logger.LogTrace("Este es un mensaje de trace"); //logger nos permite categorizar nuestros mensajes en 6 niveles: critical, error, warning, information, debug, trace
                                                                 //si se quere confgurar estos mensajes en el appsettings.development.json

            _logger.LogDebug("Este es un mensaje de debug");
            _logger.LogInformation("Este es un mensaje de information");
            _logger.LogWarning("Este es un mensaje de warning");
            _logger.LogError("Este es un mensaje de error");
            _logger.LogCritical("Este es un mensaje de critical");
            var modelo = new HomeIndexViewModel() {
                Proyectos = proyectos,
                //EjemploGUID_1 = guidViewModel,
                //EjemploGUID_2 = guidViewModel2,
            }; 
            

            return View(/*persona*/modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }
 
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            //return View();
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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