using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class AuditoriasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Auditorias>? lista;
        private Auditorias? entidad;

        public AuditoriasPrueba()
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
            lista = iConexion!.Auditorias!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var usuarios = this.iConexion!.Usuarios!.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Auditorias(usuarios!)!;
            iConexion!.Auditorias!.Add(entidad!);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Accion = "Prueba-Compra";

            var entry = iConexion!.Entry<Auditorias>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Auditorias!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}




