using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IBodegasPresentacion
    {
        Task<List<Bodegas>> Listar();
        Task<List<Bodegas>> PorCodigo(Bodegas? entidad);
        Task<Bodegas?> Guardar(Bodegas? entidad);
        Task<Bodegas?> Modificar(Bodegas? entidad);
        Task<Bodegas?> Borrar(Bodegas? entidad);
    }
}