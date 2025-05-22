using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Vehiculos
    {
        [Key] public int ID { get; set; }
        public string? Placa { get; set; }
        public string? Tipo { get; set; }
        public int? Capacidad { get; set; }
        public string? Imagen { get; set; }

        //public List<Vehiculos_Documentos>? VehiculosDocumentos { get; set; }



    }//Fin Clase Vehiculos
}
