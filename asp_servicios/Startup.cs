using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //Recibimos la configuracion
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        //Este metodo se llama en el arranque de la aplicacion y registra los servicios con inyeccion de dependencias
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers(); // agrega todos los controladores del servicio
            services.AddEndpointsApiExplorer(); // agrega todos  los endpoints()
            //services.AddSwaggerGen();

            // Repositorios 
            services.AddScoped<IConexion, Conexion>();
            // Aplicaciones
            services.AddScoped<IBodegasAplicacion, BodegasAplicacion>();
            services.AddScoped<IDocumentosAplicacion, DocumentosAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IEmpresasAplicacion, EmpresasAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IVehiculosAplicacion, VehiculosAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            services.AddScoped<IProductos_DocumentosAplicacion, Productos_DocumentosAplicacion>();
            services.AddScoped<IVehiculos_DocumentosAplicacion, Vehiculos_DocumentosAplicacion>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin())); //permite que se puedan hacer peticiones desde cualquier origen a la API
        }

        //Define el comportamiento de la aplicacion en el arranque
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }
    }
}