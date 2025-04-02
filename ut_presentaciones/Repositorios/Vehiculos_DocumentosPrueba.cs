using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
using lib_dominio.Entidades;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class Vehiculos_DocumentosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Vehiculos_Documentos>? lista;
        private Vehiculos_Documentos? entidad;

        public Vehiculos_DocumentosPrueba()
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
            lista = iConexion!.Vehiculos_Documentos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            var documento = this.iConexion.Documentos.FirstOrDefault(x => x.ID == 1);
            var vehiculo = this.iConexion.Vehiculos.FirstOrDefault(x => x.ID == 1);
            entidad = EntidadesNucleo.Vehiculos_Documentos(documento, vehiculo)!;
            iConexion!.Vehiculos_Documentos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Cantidad = 1;

            var entry = iConexion!.Entry<Vehiculos_Documentos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Vehiculos_Documentos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}