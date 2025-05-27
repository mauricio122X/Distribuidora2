using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPermisosPresentacion
    {
        Task<List<Permisos>> Listar();
        Task<List<Permisos>> PorCodigo(Permisos? entidad);
        Task<Permisos?> Guardar(Permisos? entidad);
        Task<Permisos?> Modificar(Permisos? entidad);
        Task<Permisos?> Borrar(Permisos? entidad);
        Task<Permisos?> BuscarIdUsuario(int idusuario);
    }
}