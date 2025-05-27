

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        [Key] public int ID { get; set; }
        public int ID_Rol{ get; set; }
        public string? Nombre { get; set; }

        [ForeignKey("ID_Rol")]
        public Roles? _Rol { get; set; }
    }
}
