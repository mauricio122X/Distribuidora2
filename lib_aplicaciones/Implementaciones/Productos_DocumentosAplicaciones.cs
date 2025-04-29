using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Productos_DocumentosAplicacion : IProductos_DocumentosAplicacion
    {
        private IConexion? IConexion = null;

        public Productos_DocumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Productos_Documentos? Borrar(Productos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Productos_Documentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos_Documentos? Guardar(Productos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Productos_Documentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos_Documentos> Listar()
        {
            return this.IConexion!.Productos_Documentos!.Take(20).ToList();
        }

        public List<Productos_Documentos> PorCodigo(Productos_Documentos? entidad)
        {
            return this.IConexion!.Productos_Documentos!
                .Where(x => x.Cantidad!.Equals(entidad!.Cantidad!))
                .ToList();
        }

        public Productos_Documentos? Modificar(Productos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Productos_Documentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
