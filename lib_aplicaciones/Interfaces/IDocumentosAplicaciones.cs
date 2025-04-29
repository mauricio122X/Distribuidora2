using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IDocumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Documentos> PorCodigo(Documentos? entidad);
        List<Documentos> Listar();
        Documentos? Guardar(Documentos? entidad);
        Documentos? Modificar(Documentos? entidad);
        Documentos? Borrar(Documentos? entidad);
    }
}