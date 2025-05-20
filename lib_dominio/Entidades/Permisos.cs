

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        [Key] public int ID { get; set; }
        public int ID_Usuario{ get; set; }

        [ForeignKey("ID_Usuario")]
        public Usuarios? _Usuario { get; set; }
    }
}
