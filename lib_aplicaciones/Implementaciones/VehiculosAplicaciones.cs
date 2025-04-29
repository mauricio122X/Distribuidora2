using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class VehiculosAplicacion : IVehiculosAplicacion
    {
        private IConexion? IConexion = null;

        public VehiculosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Vehiculos? Borrar(Vehiculos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Vehiculos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos? Guardar(Vehiculos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Vehiculos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Vehiculos> Listar()
        {
            return this.IConexion!.Vehiculos!.Take(20).ToList();
        }

        public List<Vehiculos> PorCodigo(Vehiculos? entidad)
        {
            return this.IConexion!.Vehiculos!
                .Where(x => x.Tipo!.Contains(entidad!.Tipo!))
                .ToList();
        }

        public Vehiculos? Modificar(Vehiculos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Vehiculos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
