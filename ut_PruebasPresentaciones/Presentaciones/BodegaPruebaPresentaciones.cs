using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_dominio.Entidades;
using lib_presentaciones;
using ut_PruebasPresentaciones.Nucleo;
using lib_dominio.Nucleo;

namespace ut_presentaciones.Repositorios
{
    [TestClass]
    public class BodegasPrueba
    {

        private Comunicaciones? Comunicaciones;
        private List<Bodegas>? lista;
        private Bodegas? entidad;

        public BodegasPrueba()
        {
           
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
            var lista = new List<Bodegas>();
            var datos = new Dictionary<string, object>();

            Comunicaciones = new Comunicaciones();
            datos = Comunicaciones.ConstruirUrl(datos, "Bodegas/Listar");
            var respuesta = Comunicaciones!.Ejecutar(datos);
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Bodegas()!;

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            Comunicaciones = new Comunicaciones();
            datos = Comunicaciones.ConstruirUrl(datos, "Bodegas/Guardar");
            var respuesta = Comunicaciones!.Ejecutar(datos);

            return true;
        }

        public bool Modificar()
        {
            entidad = EntidadesNucleo.Bodegas(); 
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            Comunicaciones = new Comunicaciones();
            datos = Comunicaciones.ConstruirUrl(datos, "Bodegas/Modificar");
            var respuesta =  Comunicaciones!.Ejecutar(datos);

            return true;
        }

        public bool Borrar()
        {
            entidad = EntidadesNucleo.Bodegas();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            Comunicaciones = new Comunicaciones();
            datos = Comunicaciones.ConstruirUrl(datos, "Bodegas/Borrar");
            var respuesta = Comunicaciones!.Ejecutar(datos);
            return true;
        }
    }
}