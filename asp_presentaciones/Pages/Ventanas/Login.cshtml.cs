using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lib_presentaciones.Interfaces;
using lib_dominio.Entidades;
using lib_presentaciones.Implementaciones;
namespace asp_presentacion.Pages
{
    /// <summary>
    /// ////////////////////////
    /// </summary>
    public class LoginModel : PageModel
    {
        // Estado de sesión del usuario
        public bool EstaLogueado = false;
        //public Usuarios? UsuarioActual { get; set; }
        public List<Permisos?> ListPermisos { get; set; }


        // Propiedades vinculadas al formulario
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        private IUsuariosPresentacion? iUsuariosPresentacion = null;
        private IPermisosPresentacion? iPermisosPresentacion = null;

        public LoginModel(IUsuariosPresentacion iUsuariosPresentacion , IPermisosPresentacion iPermisosPresentacion)
        {
            try
            {
                this.iUsuariosPresentacion = iUsuariosPresentacion;
                this.iPermisosPresentacion = iPermisosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Método que se ejecuta al cargar la página (GET)
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            
            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
               
                return;
            }
        }

        // Acción para limpiar los campos del formulario
        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Acción que se ejecuta al presionar el botón "Entrar"
        public void OnPostBtEnter()
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }
                /////////////////////////////////////////////////////////
                var task = this.iUsuariosPresentacion!.PorCodigo(new lib_dominio.Entidades.Usuarios()
                {
                    Nombre = Email,
                    Contraseña = Contrasena
                });
                task.Wait();
                var usuario = task.Result.FirstOrDefault();

                // Validación de credenciales (método simple y no seguro)
                if (usuario == null)///////////
                {
                    OnPostBtClean();
                    return;
                }
                //Busca los permisos que tenga el usuario log
                var permisos = this.iPermisosPresentacion!.BuscarIdRol(usuario!.ID_Rol);
                //Los guarda en ListaPermisos
                ListPermisos = permisos!.Result;

                // Usuario autenticado
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", usuario.ID.ToString()!);//Obtengo el ID del que se log
                // guarda los permisos en formarto json de forma de contesto, esto para no estar buscando los permisos
                HttpContext.Session.SetString("Permisos", JsonConversor.ConvertirAString(ListPermisos));
                EstaLogueado = true;

                // Limpiar campos después de login
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Acción que se ejecuta al presionar el botón "Cerrar sesión"
        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
