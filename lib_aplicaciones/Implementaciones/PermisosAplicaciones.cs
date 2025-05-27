using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion? IConexion = null;

        public PermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Permisos? Borrar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Guardar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Listar()
        {
            return this.IConexion!.Permisos!.Take(20)
                .Include(x=>x._Rol)
                .ToList();
        }
        public Permisos? BuscarIdRol(int rol)
        {
            //revisar
            return this.IConexion!.Permisos!.FirstOrDefault(x => x.ID_Rol!.Equals(rol));
        }
        public List<Permisos> PorCodigo(Permisos? entidad)
        {
            return this.IConexion!.Permisos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Include(x => x._Rol)
                .ToList();
        }

        public Permisos? Modificar(Permisos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}