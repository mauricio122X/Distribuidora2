using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class DocumentosAplicacion : IDocumentosAplicacion
    {
        private IConexion? IConexion = null;
        private IAuditoriasAplicacion? iAuditoriasAplicacion = null;

        public DocumentosAplicacion(IConexion iConexion , IAuditoriasAplicacion iAuditoriasAplicacion )
        {
            this.IConexion = iConexion;
            this.iAuditoriasAplicacion = iAuditoriasAplicacion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        //Metodo Borrar que recibe la entidad(Docuemntos) y el ID del usuario log
        public Documentos? Borrar(Documentos? entidad, int usuario)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Documentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            //Cuando se elimina la entidad(Documentos) se crea la Auditoria
            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Borrar",
            });
            return entidad;
        }

        public Documentos? Guardar(Documentos? entidad, int usuario)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos
            
            this.IConexion!.Documentos!.Add(entidad);
            this.IConexion.SaveChanges();

            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Nuevo",
            });

            return entidad;
        }

        public List<Documentos> Listar()
        {
            return this.IConexion!.Documentos!.Take(20)
                .Include(x => x._Empresas)
                .Include(x => x._Bodegas)
                .Include(x => x._Productos)
                .ToList();
        }

        public List<Documentos> PorCodigo(Documentos? entidad)
        {
            return this.IConexion!.Documentos!
                .Where(x => x.Tipo_Movimiento!.Contains(entidad!.Tipo_Movimiento!))
                .Include(x => x._Empresas)
                .Include(x => x._Bodegas)
                .Include(x => x._Productos)
                .ToList();
        }

        public Documentos? Modificar(Documentos? entidad, int usuario)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Documentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            // Cuando se Modifique una entidad Documento va a crear una Auditoria
            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Modificar",
            });
            return entidad;
        }
    }
}
