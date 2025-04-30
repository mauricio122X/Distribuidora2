using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IVehiculos_DocumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Vehiculos_Documentos> PorCodigo(Vehiculos_Documentos? entidad);
        List<Vehiculos_Documentos> Listar();
        Vehiculos_Documentos? Guardar(Vehiculos_Documentos? entidad);
        Vehiculos_Documentos? Modificar(Vehiculos_Documentos? entidad);
        Vehiculos_Documentos? Borrar(Vehiculos_Documentos? entidad);
    }
}