using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class PermisosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Permisos>? lista;
        private Permisos? entidad;

        public PermisosPrueba()
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
            lista = iConexion!.Permisos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var roles = this.iConexion!.Roles!.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Permisos(roles!)!;
            iConexion!.Permisos!.Add(entidad!);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Nombre = "Prueba - Nombre";

            var entry = iConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Permisos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}