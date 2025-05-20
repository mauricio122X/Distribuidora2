using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace lib_dominio.Entidades
{
    public class Productos_Documentos
    {
        [Key] public int ID { get; set; }
        public int ID_Documentos { get; set; }
        public int ID_Productos { get; set; }
        public int? Cantidad { get; set; }

        [ForeignKey("ID_Documentos")]
        public Documentos? _Documentos { get; set; }
        [ForeignKey("ID_Productos")]
        public Productos? _Productos { get; set; }
    }
}
