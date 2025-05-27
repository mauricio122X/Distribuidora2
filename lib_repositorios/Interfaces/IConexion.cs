using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;


namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Bodegas>? Bodegas { get; set; }  
        DbSet<Productos>? Productos { get; set; }
        DbSet<Vehiculos>? Vehiculos { get; set; }
        DbSet<Documentos>? Documentos { get; set; }
        DbSet<Vehiculos_Documentos>? Vehiculos_Documentos { get; set; }
        DbSet<Empresas>? Empresas { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }




        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }

}