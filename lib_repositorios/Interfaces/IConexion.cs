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
        DbSet<Productos_Documentos>? Productos_Documentos { get; set; }
        DbSet<Empresas>? Empresas { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Roles>? Roles { get; set; }



        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }

}