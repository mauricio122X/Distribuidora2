using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio_Compra { get; set; }
        public int? Cant_Embase { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio_Venta { get; set; }
        public int? Stock { get; set; }

        //public List<Productos_Documentos>? ProductosDocumentos { get; set; }


    }//Fin Clase Productos
}
