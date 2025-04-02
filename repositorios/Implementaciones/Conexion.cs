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
<<<<<<< HEAD
        public DbSet<Productos>? Productos { get; set; }

=======
      
>>>>>>> 7aede729b05dd5054f80a83349c5e034c9a0c160
    }

}
