using ASPNET1.Models;

namespace ASPNET1.Servicios
{
    public class RepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Amazon",
                    Descripcion  = "E-Commerce realizado es ASP.NET CORE",
                    Link="https://amazon.com",
                    ImagenUrl = "/imagenes/amazon.png"

                },
                 new Proyecto
                {
                    Titulo = "New York Times",
                    Descripcion  = "Paginas de noticias en Angular",
                    Link="https://nytimes.com",
                    ImagenUrl = "/imagenes/nyt.png"

                },
                  new Proyecto
                {
                    Titulo = "Reddit",
                    Descripcion  = "Red social para compartir en comunidades",
                    Link="https://reddit.com",
                    ImagenUrl = "/imagenes/reddit.png"

                },
                   new Proyecto
                {
                    Titulo = "Steam",
                    Descripcion  = "Tienda en linea para comprar videojuegos",
                    Link="https://store.steampowered.com",
                    ImagenUrl = "/imagenes/steam.png"

                },
            };
        }
    }
}
