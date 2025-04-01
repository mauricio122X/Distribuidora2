using lib_dominio.Entidades;

namespace ut_Bodegas.Nucleo
{
    public class EntidadBodegas
    {
        public static Bodegas? Bodegas()
        {
            var entidad = new Bodegas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Capacidad_Max = 100;
            return entidad;
        }
    }
}
