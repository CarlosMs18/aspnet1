using ASPNET1.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//INYECCION DE DEPENDENCIAS PROPIA , PRINCIPIO SOLID
builder.Services.AddTransient<RepositorioProyectos>();

//INYECCION DE DEENDENDICAS POR INTERFACES
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();//esto significa  que cuando una clase como por ejemplo 
                //home controller pida una instancia de IRepositorioProyecto(INTERFACE) se le enviara una sintancia del RepositorioProyectos(clase)
                   //sin embargo als clases que piden eso no sabran eso
builder.Services.AddTransient<ServicioTransitorio>();
builder.Services.AddScoped<ServicioDelimitado>();
builder.Services.AddSingleton<ServicioUnico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //significa que por defecto si no ponemos nada ira a controlador home
                                            //en conclusion lo que quiere deicr es que si en la ruta no ponemos nada por defecto ira al home/index
                                            //si no ponemos nada el controlador ira al home y la accion al index lo cual renderiza el home

app.Run();
