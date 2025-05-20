using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IBodegasAplicacion
    {
        void Configurar(string StringConexion);
        List<Bodegas> PorCodigo(Bodegas? entidad);
        List<Bodegas> Listar();
        Bodegas? Guardar(Bodegas? entidad);
        Bodegas? Modificar(Bodegas? entidad);
        Bodegas? Borrar(Bodegas? entidad);
    }
}