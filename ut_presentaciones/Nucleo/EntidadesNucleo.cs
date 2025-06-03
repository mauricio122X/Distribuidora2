using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Bodegas? Bodegas()
        {
            var entidad = new Bodegas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Capacidad_max = 100;
           
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
            entidad.Imagen = null;
            return entidad;
        }


        public static Vehiculos? Vehiculos()
        {
            var entidad = new Vehiculos();
            entidad.Placa = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Tipo = "Camioneta";
            entidad.Capacidad = 100;
            entidad.Imagen = null;

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

        public static Documentos? Documentos(Bodegas bodegas, Empresas empresas, Productos productos)
        {
            var entidad = new Documentos();
            entidad.Codigo = "Pruebas - Codigo";
            entidad.Tipo_Movimiento = "Pruebas-Venta";
            entidad.Fecha = DateTime.Now;
            entidad.ID_Bodega = bodegas.ID;
            entidad.Valor = 100;
            entidad.Cantidad = 200;
            entidad.Estado = "Pruebas - Estado";
            entidad.ID_Empresa = empresas.ID;
            entidad.ID_Producto = productos.ID;

            return entidad;
        }


        public static Usuarios? Usuarios(Bodegas bodegas, Roles roles)
        {
            var entidad = new Usuarios();
            entidad.Carnet = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Nombre = "prueba-Nombre";
            entidad.Contraseña = "Pruebas - Contraseña";
            entidad.ID_Rol = roles.ID;
            entidad.ID_Bodega = bodegas.ID;
            entidad.Imagen = null;

            return entidad;
        }


        public static Vehiculos_Documentos? Vehiculos_Documentos(Documentos documentos, Vehiculos vehiculos)
        {
            var entidad = new Vehiculos_Documentos();
            entidad.ID_Documentos = documentos.ID;
            entidad.ID_Vehiculos = vehiculos.ID;

            return entidad;
        }

        public static Auditorias? Auditorias(Usuarios usuarios)
        {
            var entidad = new Auditorias();
            entidad.Accion = "Pruebas-Venta";
            entidad.Fecha = DateTime.Now;
            entidad.ID_Usuario = usuarios.ID;

            return entidad;
        }

        public static Permisos? Permisos(Roles roles)
        {
            var entidad = new Permisos();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.ID_Rol = roles.ID;

            return entidad;
        }
    }
}