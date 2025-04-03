using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using lib_repositorios.Interfaces;


namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Bodegas>? Bodegas { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Vehiculos>? Vehiculos { get; set; }
        public DbSet<Documentos>? Documentos { get; set; }
        public DbSet<Vehiculos_Documentos>? Vehiculos_Documentos { get; set; }
        public DbSet<Productos_Documentos>? Productos_Documentos { get; set; }
        public DbSet<Empresas>? Empresas { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Roles>? Roles { get; set; }


    }

}
