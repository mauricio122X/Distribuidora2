using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class DocumentosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Documentos>? lista;
        private Documentos? entidad;

        public DocumentosPrueba()
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
            lista = iConexion!.Documentos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var bodega = this.iConexion.Bodegas.FirstOrDefault(x => x.ID == 1);
            var empresa = this.iConexion.Empresas.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Documentos(bodega, empresa)!;
            iConexion!.Documentos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Tipo_Movimiento = "Prueba-Compra";

            var entry = iConexion!.Entry<Documentos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Documentos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}