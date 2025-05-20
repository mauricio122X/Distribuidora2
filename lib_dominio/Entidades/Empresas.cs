

using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Empresas
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? NIT { get; set; }
        public string? Tipo { get; set; }
        public string? Telefono { get; set; }

        //public List<Documentos>? EmpresasDocumentos { get; set; }

    }//Fin clase Empresas
}
