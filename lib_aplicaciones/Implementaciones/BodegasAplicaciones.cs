using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class BodegasAplicacion : IBodegasAplicacion
    {
        private IConexion? IConexion = null;

        public BodegasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Bodegas? Borrar(Bodegas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Bodegas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Bodegas? Guardar(Bodegas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Bodegas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Bodegas> Listar()
        {
            return this.IConexion!.Bodegas!.Take(20).ToList();
        }

        public List<Bodegas> PorCodigo(Bodegas? entidad)
        {
            return this.IConexion!.Bodegas!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Bodegas? Modificar(Bodegas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Bodegas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
