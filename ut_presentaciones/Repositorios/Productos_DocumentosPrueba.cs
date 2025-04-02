using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class Productos_DocumentosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Productos_Documentos>? lista;
        private Productos_Documentos? entidad;

        public Productos_DocumentosPrueba()
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
            lista = iConexion!.Productos_Documentos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var documento = this.iConexion.Documentos.FirstOrDefault(x => x.ID == 1);
            var producto = this.iConexion.Productos.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Productos_Documentos(documento, producto)!;
            iConexion!.Productos_Documentos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Cantidad = 1;

            var entry = iConexion!.Entry<Productos_Documentos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Productos_Documentos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}