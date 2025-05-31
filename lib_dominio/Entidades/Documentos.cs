using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Documentos
    {
        [Key] public int ID { get; set; }
        public string? Codigo { get; set; }
        public string? Tipo_Movimiento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ID_Bodega { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public string? Estado { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Producto { get; set; }

        //public int ID_Empleados { get; set; }

        //public List<Vehiculos_Documentos>? vehiculosDocumentos { get; set; }
       // public List<Productos_Documentos>? ProductosDocumentos { get; set; }

        [ForeignKey("ID_Bodega")]
        public Bodegas? _Bodegas { get; set; }
        [ForeignKey("ID_Empresa")]
        public Empresas? _Empresas { get; set; }
        [ForeignKey("ID_Producto")]
        public Productos? _Productos { get; set; }
    }//Fin clase documentoss
}
