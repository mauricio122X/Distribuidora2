using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        // Estado de sesión del usuario
        public bool EstaLogueado = false;

        // Propiedades vinculadas al formulario
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

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

                // Validación de credenciales (método simple y no seguro)
                if ("admin.123" != Email + "." + Contrasena)
                {
                    OnPostBtClean();    
                    return;
                }

                // Usuario autenticado
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;

                // Limpiar campos después de login
                OnPostBtClean();
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
