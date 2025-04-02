using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class EmpleadosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Empleados>? lista;
        private Empleados? entidad;

        public EmpleadosPrueba()
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
            lista = iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var bodega = this.iConexion.Bodegas.FirstOrDefault(x => x.ID == 1);
            var rol = this.iConexion.Roles.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Empleados(bodega, rol)!;
            iConexion!.Empleados!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Nombre = "Prueba-nombre2";

            var entry = iConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Empleados!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}