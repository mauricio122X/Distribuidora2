
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio_Compra { get; set; }
        public int? Cantidad_Embase { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio_Venta { get; set; }
        public int? Stock { get; set; }

        //public List<Productos_Documentos>? ProductosDocumentos { get; set; }



    }//Fin Clase Productos
}
