using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace asp_presentacion.Pages.Ventanas
{
    public class DocumentosModel : PageModel
    {
        //listas que recibe para mostrar en la vista
        private IDocumentosPresentacion? iPresentacion = null;
        private IBodegasPresentacion? iBodegasPresentacion = null;
        private IEmpresasPresentacion? iEmpresasPresentacion = null;


        public DocumentosModel(IDocumentosPresentacion iPresentacion, IBodegasPresentacion iBodegasPresentacion, IEmpresasPresentacion iEmpresasPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iBodegasPresentacion = iBodegasPresentacion;
                this.iEmpresasPresentacion = iEmpresasPresentacion;
                Filtro = new Documentos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Documentos? Actual { get; set; }
        [BindProperty] public Documentos? Filtro { get; set; }
        [BindProperty] public List<Documentos>? Lista { get; set; }
        [BindProperty] public List<Bodegas>? ListBodegas { get; set; }//Lista que recibe de todas las bodegas
        [BindProperty] public List<Empresas>? ListEmpresas { get; set; }//Lista que recibe de todos los Empresas


        //cargar la pagina la reflesca para mostrar la informacion
        public virtual void OnGet() { OnPostBtRefrescar(); }
        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                Filtro!.Tipo_Movimiento = Filtro!.Tipo_Movimiento ?? "";
                //Filtro!.Materia = Filtro!.Materia ?? ""; 
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorCodigo(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private void CargarCombox()
        {
            try
            {
                var task = this.iBodegasPresentacion!.Listar(); //Llama el metodo listar de Ibodegaspresentaciones
                var task2 = this.iEmpresasPresentacion!.Listar(); //Llama el metodo listar de IDocumentosPresentaciones
                task.Wait();//Espere que se ejecute la peticion , task representa que corre de forma asincronica
                task2.Wait();//Espere que se ejecute la peticion , task representa que corre de forma asincronica
                ListBodegas = task.Result; //Guarda el resultado en la lista 
                ListEmpresas = task2.Result; //Guarda el resultado en la lista
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar; //Asigna la accion en editar para abrir el menu
                Actual = new Documentos();//Para crear un objeto nuevo
                CargarCombox();//carga la lista de las tablas relacionadas 
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();//llama al metodo refrescar
                Accion = Enumerables.Ventanas.Editar;//asigna la accion de editar para abrir el formulario
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);//Busca la entidad que se quiere modificar
                CargarCombox();//carga las listas relacionadas
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
                Accion = Enumerables.Ventanas.Editar;
                Task<Documentos>? task = null;
                if (Actual!.ID == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
