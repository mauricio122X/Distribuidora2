using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;


namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Bodegas>? Bodegas { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }

}
