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

        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Salario = 100;

            return entidad;
        }

        public static Empresas? Empresas()
        {
            var entidad = new Empresas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Direccion = "calle 1";
            entidad.NIT = "123";
            entidad.Tipo = "Cliente";
            entidad.Telefono = "123456";

            return entidad;
        }

        public static Documentos? Documentos(Bodegas Bodegas , Empresas Empresas)
        {
            var entidad = new Documentos();
            entidad.Tipo_Movimiento = "Pruebas-Venta";
            entidad.ID_Bodega = Bodegas.ID;
            entidad.Valor = 100;
            entidad.Fecha = DateTime.Now;   
            entidad.ID_Empresa = Empresas.ID;

            return entidad; 
        }

        public static Empleados? Empleados(Bodegas Bodegas, Roles Roles)
        {
            var entidad = new Empleados();
            entidad.Carnet = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Nombre = "prueba-Nombre";
            entidad.ID_Rol = Roles.ID;
            entidad.ID_Bodega = Bodegas.ID;

            return entidad;
        }



    }
}