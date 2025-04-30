using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Vehiculos_DocumentosAplicacion : IVehiculos_DocumentosAplicacion
    {
        private IConexion? IConexion = null;

        public Vehiculos_DocumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Vehiculos_Documentos? Borrar(Vehiculos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Vehiculos_Documentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos_Documentos? Guardar(Vehiculos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Vehiculos_Documentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Vehiculos_Documentos> Listar()
        {
            return this.IConexion!.Vehiculos_Documentos!.Take(20).ToList();
        }

        public List<Vehiculos_Documentos> PorCodigo(Vehiculos_Documentos? entidad)
        {
            return this.IConexion!.Vehiculos_Documentos!
                .Where(x => x.Cantidad!.Equals(entidad!.Cantidad!))
                .ToList();
        }

        public Vehiculos_Documentos? Modificar(Vehiculos_Documentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Vehiculos_Documentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
