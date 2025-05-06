using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lib_repositorios.Implementaciones
{
    //Cuando no se encuentre la cadena de conexion en tiempo de diseño(migraciones) utilice esta clase para crearlo
    public class ConexionFactory : IDesignTimeDbContextFactory<Conexion>
    {
        public Conexion CreateDbContext(string[] args)
        {
            var connectionString = "Server=GATO;Database=DB_Distribuidora;Integrated Security=True;TrustServerCertificate=True;";
            return new Conexion(connectionString); //Crea e instancia el stringconexion 
        }
    }
}
