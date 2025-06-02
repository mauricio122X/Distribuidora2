using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace asp_presentaciones.Pages.Ventanas
{
    public class PedidosModel : PageModel
    {
        IVehiculos_DocumentosPresentacion? iVehiculos_DocumentosPresentacion = null;
        IDocumentosPresentacion? iDocumentosPresentacion = null;
        IVehiculosPresentacion? iVehiculosPresentacion = null;
        IEmpresasPresentacion? iEmpresasPresentacion= null;

        //Metodo constructor que recibe la interfaz de la presentacion(Inyecion de dependencias)
        public PedidosModel(IVehiculos_DocumentosPresentacion iVehiculos_DocumentosPresentacion,
            IEmpresasPresentacion? iEmpresasPresentacion,
            IDocumentosPresentacion iDocumentosPresentacion,
            IVehiculosPresentacion iVehiculosPresentacion)
        {
            try
            {
                this.iVehiculos_DocumentosPresentacion = iVehiculos_DocumentosPresentacion;
                this.iEmpresasPresentacion = iEmpresasPresentacion;
                this.iDocumentosPresentacion = iDocumentosPresentacion;
                this.iVehiculosPresentacion = iVehiculosPresentacion;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            this.iEmpresasPresentacion = iEmpresasPresentacion;
        }
        [BindProperty] public Vehiculos_Documentos? Actual { get; set; }
        [BindProperty] public Documentos? Documento { get; set; }
        [BindProperty] public List<Vehiculos_Documentos>? Lista { get; set; }
        [BindProperty] public List<Documentos>? ListDocumentos { get; set; }
        [BindProperty] public List<Vehiculos>? ListVehiculos { get; set; }


        [BindProperty] public List<Empresas>? ListEmpreas { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {

                //if (Filtro!._Usuarios == null)
                //{
                //    Filtro._Usuarios = new Usuarios();
                //}
                //Filtro!._Usuarios!.Carnet = Filtro!._Usuarios.Carnet ?? "";
                //Filtro!._Usuarios!.Nombre = Filtro!._Usuarios.Nombre ?? "";
                var task = this.iVehiculos_DocumentosPresentacion!.Listar();
                task.Wait();
                Lista = task.Result;
                CargarCombox();
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
                var task = this.iEmpresasPresentacion!.Listar(); //Llama el metodo listar de Ibodegaspresentaciones
                var task2 = this.iVehiculosPresentacion!.Listar();
                var task3= this.iDocumentosPresentacion!.Listar();
                //Espere que se ejecute la peticion , task representa que corre de forma asincronica
                task.Wait();
                task2.Wait();
                task3.Wait();
                //Guarda el resultado en la lista
                ListEmpreas = task.Result;
                ListDocumentos = task3.Result;
                ListVehiculos = task2.Result;
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
                Task<Vehiculos_Documentos>? task = null;

                task = this.iVehiculos_DocumentosPresentacion!.Guardar(Actual!)!;
           
                task.Wait();    
                Actual = task.Result;
                OnPostBtRefrescar();
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
                var usuario = Convert.ToInt32(HttpContext.Session.GetString("Usuario"));

                if (usuario == 0)
                {
                    throw new ArgumentException("No tiene permiso de crear.");
                }
                OnPostBtRefrescar();//llama al metodo refrescar
                Actual = Lista!.FirstOrDefault(x => x.ID.ToString() == data);//Busca la entidad que se quiere modificar
                //Guarda en documentos la informacion asocidada del documentos relacionado con la tabla
                Documento = Actual!._Documentos;
                CargarCombox();//carga las listas relacionadas
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificarDocumentos()
        {
            try
            {
                var usuario = Convert.ToInt32(HttpContext.Session.GetString("Usuario"));

                if (usuario == 0) 
                {
                    throw new ArgumentException("No tiene permiso de crear.");
                }

                Task<Documentos>? task = null;
                task = this.iDocumentosPresentacion!.Modificar(Documento ,usuario )!;

                task.Wait();
                Documento = task.Result;
                //Actual = task.Result;
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
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
        
}
