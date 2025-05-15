using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IProductos_DocumentosPresentacion
    {
        Task<List<Productos_Documentos>> Listar();
        Task<List<Productos_Documentos>> PorCodigo(Productos_Documentos? entidad);
        Task<Productos_Documentos?> Guardar(Productos_Documentos? entidad);
        Task<Productos_Documentos?> Modificar(Productos_Documentos? entidad);
        Task<Productos_Documentos?> Borrar(Productos_Documentos? entidad);
    }
}