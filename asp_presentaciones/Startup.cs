using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<IBodegasPresentacion, BodegasPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<IBodegasPresentacion, BodegasPresentacion>();
            services.AddScoped<IDocumentosPresentacion, DocumentosPresentacion>();
            services.AddScoped<IEmpresasPresentacion, EmpresasPresentacion>();
            services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
            services.AddScoped<IProductos_DocumentosPresentacion, Productos_DocumentosPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddScoped<IVehiculos_DocumentosPresentacion, Vehiculos_DocumentosPresentacion>();
            services.AddScoped<IVehiculosPresentacion, VehiculosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}