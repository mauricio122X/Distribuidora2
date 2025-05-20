using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using lib_repositorios.Interfaces;
using System.Collections.Generic;


namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        public Conexion()
        {

        }
        public Conexion(string stringConexion)
        {
            this.StringConexion = stringConexion;
        }
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
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }



    }

}
