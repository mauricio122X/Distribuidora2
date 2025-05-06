

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        [Key] public int ID { get; set; }
        public int ID_Usuario { get; set; }
        public string? Accion { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("ID_Usuario")]
        public Usuarios? _Usuario { get; set; }
    }
}
