using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Bodegas
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad_Max { get; set; }

        //public List<Empleados>? BodegasEmpleados { get; set; }
        //public List<Documentos>? BodegasDocumentos { get; set; }
    }// Fin Clase Bodegas
}
