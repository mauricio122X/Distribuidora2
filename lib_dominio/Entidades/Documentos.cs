using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Documentos
    {
        public int ID { get; set; }
        public string? Tipo_Movimiento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ID_Bodega { get; set; }
        public decimal? Valor { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Empleados { get; set; }

        //public List<Vehiculos_Documentos>? vehiculosDocumentos { get; set; }
       // public List<Productos_Documentos>? ProductosDocumentos { get; set; }

        [ForeignKey("Bodegas")]
        public Bodegas? _Bodegas { get; set; }
        [ForeignKey("Empresas")]
        public Empresas? _Empresas { get; set; }
    }//Fin clase documentoss
}
