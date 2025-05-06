using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        [Key] public int ID { get; set; }
        public string? Carnet { get; set; }
        public string? Nombre { get; set; }
        public int ID_Rol { get; set; }
        public int ID_Bodega { get; set; }

        //Objetos relacionados
        [ForeignKey("ID_Rol")]
        public Roles? _Roles { get; set; }
        [ForeignKey("ID_Bodega")]
        public Bodegas? _Bodegas { get; set; }
    }//Fin clase empleados
}
