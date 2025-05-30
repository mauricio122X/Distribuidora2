using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<Productos> PorCodigo(Productos? entidad);
        List<Productos> Listar();
        Productos? Guardar(Productos? entidad);
        Productos? Modificar(Productos? entidad);
        Productos? Borrar(Productos? entidad);
        void ModificarStock(Documentos documento);

    }
}