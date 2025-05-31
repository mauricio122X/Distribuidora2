using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Vehiculos_Documentos
    {
        [Key] public int ID { get; set; }
        public int ID_Documentos { get; set; }
        public int ID_Vehiculos { get; set; }

        [ForeignKey("ID_Documentos")]
        public Documentos? _Documentos { get; set; }
        [ForeignKey("ID_Vehiculos")]
        public Vehiculos? _Vehiculos { get; set; }

    }
}
