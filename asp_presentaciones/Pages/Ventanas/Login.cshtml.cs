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
        // Estado de sesi�n del usuario
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

        // M�todo que se ejecuta al cargar la p�gina (GET)
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            
            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
               
                return;
            }
        }

        // Acci�n para limpiar los campos del formulario
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

        // Acci�n que se ejecuta al presionar el bot�n "Entrar"
        public void OnPostBtEnter()
        {
            try
            {
                // Validar campos vac�os
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }
                /////////////////////////////////////////////////////////
                var task = this.iUsuariosPresentacion!.PorCodigo(new lib_dominio.Entidades.Usuarios()
                {
                    Nombre = Email,
                    Contrase�a = Contrasena
                });
                task.Wait();
                var usuario = task.Result.FirstOrDefault();

                // Validaci�n de credenciales (m�todo simple y no seguro)
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

                // Limpiar campos despu�s de login
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        // Acci�n que se ejecuta al presionar el bot�n "Cerrar sesi�n"
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
