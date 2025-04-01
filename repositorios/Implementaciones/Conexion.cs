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
    }

}
