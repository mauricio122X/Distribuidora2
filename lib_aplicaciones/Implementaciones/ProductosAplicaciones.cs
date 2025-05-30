using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion? IConexion = null;

        public ProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos? Guardar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Listar()
        {
            return this.IConexion!.Productos!.Take(20).ToList();
        }

        public List<Productos> PorCodigo(Productos? entidad)
        {
            return this.IConexion!.Productos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Productos? Modificar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void ModificarStock(Documentos documento)
        {
            var producto = this.IConexion!.Productos!.FirstOrDefault(x => x.ID.Equals(documento.ID_Producto));

            if (documento == null )
                throw new Exception("lbFaltaInformacion");
            if (documento.Tipo_Movimiento == "Compra")
                producto!.Stock += documento.Cantidad;
            if(documento.Tipo_Movimiento == "Venta")
                if(documento.Cantidad > producto!.Stock)
                    throw new Exception("No Hay Stock Suficiente");
                else
                    producto!.Stock -= documento.Cantidad;


            var entry = this.IConexion!.Entry<Productos>(producto!);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
        }
    }
}
