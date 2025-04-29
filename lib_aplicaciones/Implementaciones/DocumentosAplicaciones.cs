using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class DocumentosAplicacion : IDocumentosAplicacion
    {
        private IConexion? IConexion = null;

        public DocumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Documentos? Borrar(Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Documentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Documentos? Guardar(Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Documentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Documentos> Listar()
        {
            return this.IConexion!.Documentos!.Take(20).ToList();
        }

        public List<Documentos> PorCodigo(Documentos? entidad)
        {
            return this.IConexion!.Documentos!
                .Where(x => x.Tipo_Movimiento!.Contains(entidad!.Tipo_Movimiento!))
                .ToList();
        }

        public Documentos? Modificar(Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Documentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
