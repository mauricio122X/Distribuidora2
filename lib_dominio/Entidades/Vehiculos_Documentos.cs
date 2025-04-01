using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Vehiculos_Documentos
    {
        public int ID { get; set; }
        public int ID_Documentos { get; set; }
        public int ID_Vehiculos { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("Documentos")]
        public Documentos? _Documentos { get; set; }
        [ForeignKey("Vehiculos")]
        public Vehiculos? _Vehiculos { get; set; }

    }
}
