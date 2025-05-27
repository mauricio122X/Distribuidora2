using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IDocumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Documentos> PorCodigo(Documentos? entidad);
        List<Documentos> Listar();
        Documentos? Guardar(Documentos? entidad, int usuario);
        Documentos? Modificar(Documentos? entidad, int usuario);
        Documentos? Borrar(Documentos? entidad, int usuario); // Se manda el objeto(Documentos) a borrar y el ID del usuario log
    }
}