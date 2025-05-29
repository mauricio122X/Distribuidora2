using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lib_presentaciones.Interfaces;
using lib_dominio.Entidades;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.WebSockets;
using lib_presentaciones.Implementaciones;
namespace asp_presentacion.Pages
{
    /// <summary>
    /// ////////////////////////
    /// </summary>
    public class IndexModel : PageModel
    {
        // Estado de sesión del usuario
        public bool EstaLogueado = false;

        //// Propiedades vinculadas al formulario
        //[BindProperty]
        //public string? Email { get; set; }

        //[BindProperty]
        //public string? Contrasena { get; set; }

        //private IUsuariosPresentacion? iUsuariosPresentacion = null;
        //public IndexModel(IUsuariosPresentacion iUsuariosPresentacion)
        //{
        //    try
        //    {
        //        this.iUsuariosPresentacion = iUsuariosPresentacion;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

        //// Método que se ejecuta al cargar la página (GET)
        //public void OnGet()
        //{
        //    var variable_session = HttpContext.Session.GetString("Usuario");

        //    if (!string.IsNullOrEmpty(variable_session))
        //    {
        //        EstaLogueado = true;
        //        return;
        //    }
        //}

        //// Acción para limpiar los campos del formulario
        //public void OnPostBtClean()
        //{
        //    try
        //    {
        //        Email = string.Empty;
        //        Contrasena = string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

        //// Acción que se ejecuta al presionar el botón "Entrar"
        //public void OnPostBtEnter()
        //{
        //    try
        //    {
        //        // Validar campos vacíos
        //        if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contrasena))
        //        {
        //            OnPostBtClean();
        //            return;
        //        }
        //        /////////////////////////////////////////////////////////
        //        var task = this.iUsuariosPresentacion!.PorCodigo(new lib_dominio.Entidades.Usuarios() { 
        //            Nombre = Email,
        //            Contraseña = Contrasena
        //        });
        //        task.Wait();
        //        var usuario = task.Result.FirstOrDefault();

        //        // Validación de credenciales (método simple y no seguro)
        //        if (usuario == null)///////////
        //        {
        //            OnPostBtClean();    
        //            return;
        //        }

        //        // Usuario autenticado
        //        ViewData["Logged"] = true;
        //        HttpContext.Session.SetString("Usuario", usuario.ID.ToString()!);//Obtengo el ID del que se log
        //        EstaLogueado = true;

        //        // Limpiar campos después de login
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

        //// Acción que se ejecuta al presionar el botón "Cerrar sesión"
        //public void OnPostBtClose()
        //{
        //    try
        //    {
        //        HttpContext.Session.Clear();
        //        HttpContext.Response.Redirect("/");
        //        EstaLogueado = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}

        //Inyeccion de dependencia
        private IProductosPresentacion? iProductosPresentacion = null;
        private IEmpresasPresentacion? iEmpresasPresentacion = null;
        private IBodegasPresentacion? iBodegasPresentacion = null;
        private IDocumentosPresentacion? iDocumentosPresentacion = null;

        public IndexModel(IProductosPresentacion iProductosPresentacion, 
            IEmpresasPresentacion? iEmpresasPresentacion, 
            IBodegasPresentacion? iBodegasPresentacion,
            IDocumentosPresentacion iDocumentosPresentacion)
        {
            try
            {
                this.iProductosPresentacion = iProductosPresentacion;
                this.iEmpresasPresentacion = iEmpresasPresentacion;
                this.iBodegasPresentacion = iBodegasPresentacion;
                this.iDocumentosPresentacion = iDocumentosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            this.iEmpresasPresentacion = iEmpresasPresentacion;
            this.iBodegasPresentacion = iBodegasPresentacion;
        }

        //Productos actual selecionado
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public Documentos? Documento { get; set; }

        //Lista de las clases que tenem,os que mostrar para general un documento

        [BindProperty] public List<Productos>? Lista { get; set; }
        [BindProperty] public List<Bodegas>? ListBodegas { get; set; }

        [BindProperty] public List<Empresas>? ListEmpresas { get; set; }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }


        public virtual void OnGet() { OnPostBtRefrescar(); }
        public void OnPostBtRefrescar()
        {
            try
            {
                
                var task = this.iProductosPresentacion!.Listar();
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //Metodo que guarda la info del producto seleccionado en la variable Actual 
        public virtual void OnPostBTComprar(string data)
        {
            try
            {
                //refresca la lista de productos
                OnPostBtRefrescar();
                llenarListas();
                //Busca el producto en la lista de productos por su ID
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                var usuario = Convert.ToInt32(HttpContext.Session.GetString("Usuario"));
                Task<Documentos>? task = null;
                Documento!.Tipo_Movimiento = "Compra";
                Documento!.Fecha = DateTime.Now;
                Documento!.Valor = 1;
                if (usuario != 0)
                {
                    task = this.iDocumentosPresentacion!.Guardar(Documento!, usuario)!;
                }
                else 
                {
                    throw new ArgumentException("No tiene permiso de general un documento.");
                }
                task.Wait();
                Documento = task.Result;
                Actual = null;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        //Metodo que se encarga de llenar las listas de empresas y bodegas
        public void llenarListas() 
        {
            //Realiza el metodo listar de las interfaces de empresas y bodegas
            var task_Empresas = this.iEmpresasPresentacion!.Listar();
            var task_Bodegas = this.iBodegasPresentacion!.Listar();
            //Espera a que se completen las tareas asincronas
            task_Empresas.Wait();
            task_Bodegas.Wait();
            //Asigna los resultados a las listas de bodegas y empresas
            ListBodegas = task_Bodegas.Result;
            ListEmpresas = task_Empresas.Result;
        }
        
        //Metodo que cierra la ventana emergente de error
        public void OnPostBtCerrar()
        {
            try
            {
                 OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
