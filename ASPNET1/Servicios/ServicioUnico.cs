namespace ASPNET1.Servicios
{
    public class ServicioUnico
    {
        public ServicioUnico() //addtransient singleton solo se ejecuta cuando instanciamos el servicio y en subsiguientes operaciones
                        //siempre se utilizara la misma instancia
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; private set; } //por ende obtendremos la misma data del guid que tenemos aca

    }


    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; private set; }

    }




    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; private set; }

    }
}
