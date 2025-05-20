using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IVehiculos_DocumentosPresentacion
    {
        Task<List<Vehiculos_Documentos>> Listar();
        Task<List<Vehiculos_Documentos>> PorCodigo(Vehiculos_Documentos? entidad);
        Task<Vehiculos_Documentos?> Guardar(Vehiculos_Documentos? entidad);
        Task<Vehiculos_Documentos?> Modificar(Vehiculos_Documentos? entidad);
        Task<Vehiculos_Documentos?> Borrar(Vehiculos_Documentos? entidad);
    }
}