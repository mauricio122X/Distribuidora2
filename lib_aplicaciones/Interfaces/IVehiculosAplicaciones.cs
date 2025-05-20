using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IVehiculosAplicacion
    {
        void Configurar(string StringConexion);
        List<Vehiculos> PorCodigo(Vehiculos? entidad);
        List<Vehiculos> Listar();
        Vehiculos? Guardar(Vehiculos? entidad);
        Vehiculos? Modificar(Vehiculos? entidad);
        Vehiculos? Borrar(Vehiculos? entidad);
    }
}