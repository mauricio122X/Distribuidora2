using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class VehiculosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Vehiculos>? lista;
        private Vehiculos? entidad;

        public VehiculosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            lista = iConexion!.Vehiculos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Vehiculos()!;
            iConexion!.Vehiculos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Capacidad = 10;

            var entry = iConexion!.Entry<Vehiculos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Vehiculos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}