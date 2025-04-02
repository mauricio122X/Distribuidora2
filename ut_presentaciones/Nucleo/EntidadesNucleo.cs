using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Bodegas? Bodegas()
        {
            var entidad = new Bodegas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Capacidad_Max = 100;
           
            return entidad;
        }

        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Precio_Compra = 100;
            entidad.Cantidad_Embase = 10;
            entidad.Descripcion = "Descripcion Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Precio_Venta = 200;
            entidad.Stock = 10;
            return entidad;
        }

        public static Vehiculos? Vehiculos()
        {
            var entidad = new Vehiculos();
            entidad.Placa = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Tipo = "Camioneta";
            entidad.Capacidad = 100;

            return entidad;
        }


        
    }
}