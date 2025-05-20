using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        // Estado de sesi�n del usuario
        public bool EstaLogueado = false;

        // Propiedades vinculadas al formulario
        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

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

                // Validaci�n de credenciales (m�todo simple y no seguro)
                if ("admin.123" != Email + "." + Contrasena)
                {
                    OnPostBtClean();    
                    return;
                }

                // Usuario autenticado
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;

                // Limpiar campos despu�s de login
                OnPostBtClean();
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
