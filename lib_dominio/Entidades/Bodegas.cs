using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Bodegas
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad_Max { get; set; }

        //public List<Empleados>? BodegasEmpleados { get; set; }
        //public List<Documentos>? BodegasDocumentos { get; set; }
    }// Fin Clase Bodegas
}
