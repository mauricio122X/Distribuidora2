using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IProductos_DocumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Productos_Documentos> PorCodigo(Productos_Documentos? entidad);
        List<Productos_Documentos> Listar();
        Productos_Documentos? Guardar(Productos_Documentos? entidad);
        Productos_Documentos? Modificar(Productos_Documentos? entidad);
        Productos_Documentos? Borrar(Productos_Documentos? entidad);
    }
}