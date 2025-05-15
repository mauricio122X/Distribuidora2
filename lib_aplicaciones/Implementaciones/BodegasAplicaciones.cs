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
        //Asignar la cadena de conexion de la DB 
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        //Elimina una bodega
        public Bodegas? Borrar(Bodegas? entidad)
        {
            if (entidad == null)//si no existe la entidad
                throw new Exception("lbFaltaInformacion");//throw new Exception sirve para lanzar una excepcion

            if (entidad!.ID == 0)//si no se mando el ID
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Bodegas!.Remove(entidad);//Elimina la entidad de la DB
            this.IConexion.SaveChanges();//Guarda los cambios en la DB
            return entidad;
        }

        public Bodegas? Guardar(Bodegas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)//Si ya tiene ID no lo guarda
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Bodegas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Bodegas> Listar()
        {
            return this.IConexion!.Bodegas!.Take(20).ToList();//Lista los primeros 20 registros
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

            if (entidad!.ID == 0)//Si tiene un id 0 significa que la entidad no se guardo(Nose asigno ID)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Bodegas>(entidad);//Indica que esta entidad se va a modificar
            entry.State = EntityState.Modified; //Indica que todos los campos de la entidad se modificaron
            this.IConexion.SaveChanges();//Guarda todos los cambios en la DB
            return entidad;
        }
    }
}
