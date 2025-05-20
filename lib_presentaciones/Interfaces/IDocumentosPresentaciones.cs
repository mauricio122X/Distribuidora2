using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IDocumentosPresentacion
    {
        Task<List<Documentos>> Listar();
        Task<List<Documentos>> PorCodigo(Documentos? entidad);
        Task<Documentos?> Guardar(Documentos? entidad);
        Task<Documentos?> Modificar(Documentos? entidad);
        Task<Documentos?> Borrar(Documentos? entidad);
    }
}