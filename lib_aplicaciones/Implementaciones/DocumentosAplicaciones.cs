using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class DocumentosAplicacion : IDocumentosAplicacion
    {
        //Inyectamos las dependencias necesarias para la aplicacion Documentos
        private IConexion? IConexion = null;
        private IAuditoriasAplicacion? iAuditoriasAplicacion = null;
        private IUsuariosAplicacion? iUsuariosAplicacion = null;
        private IPermisosAplicacion? iPermisosAplicacion = null;
        private IProductosAplicacion? iProductosAplicacion = null;


        // Constructor que recibe las dependencias necesarias para la aplicacion Documentos
        public DocumentosAplicacion(IConexion iConexion , 
            IAuditoriasAplicacion iAuditoriasAplicacion, 
            IPermisosAplicacion iPermisosAplicacion,
            IUsuariosAplicacion iUsuariosAplicacion,
            IProductosAplicacion iProductosAplicacion)
        {
            this.IConexion = iConexion;
            this.iAuditoriasAplicacion = iAuditoriasAplicacion;
            this.iPermisosAplicacion = iPermisosAplicacion;
            this.iUsuariosAplicacion = iUsuariosAplicacion;
            this.iProductosAplicacion = iProductosAplicacion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        //Metodo Borrar que recibe la entidad(Docuemntos) y el ID del usuario log
        public Documentos? Borrar(Documentos? entidad, int usuario)
        {
            // Verifica si el usuario tiene permisos para borrar
            var objUsuario = this.iUsuariosAplicacion!.BuscarID(usuario);
            var permiso = this.iPermisosAplicacion!.BuscarIdRol(objUsuario!.ID_Rol);
            //Busca si algun permiso cumple la condicion si no(!) entra al if
            if (permiso == null || !permiso!.Any(x =>x.Nombre == "Borrar"))
            {
                throw new Exception("No tiene Permiso de borrar");
            }
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Documentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            //Cuando se elimina la entidad(Documentos) se crea la Auditoria
            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Borrar",
            });
            return entidad;
        }

        public Documentos? Guardar(Documentos? entidad, int usuario)
        {
            var objUsuario = this.iUsuariosAplicacion!.BuscarID(usuario);
            var permiso = this.iPermisosAplicacion!.BuscarIdRol(objUsuario!.ID_Rol);
            //Busca si algun permiso cumple la condicion si no(!) entra al if
            if (permiso == null || !permiso!.Any(x => x.Nombre == "Guardar"))
                throw new Exception("No tiene Permiso de guardar");
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.ID != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos
            //Modifica el stock de producto dependiendo de compra o venta
            this.iProductosAplicacion!.ModificarStock(entidad);
            //Calcula el precio total de documento dependiendo si fue compra o venta
            CalcularPrecio(entidad);            

            this.IConexion!.Documentos!.Add(entidad);
            this.IConexion.SaveChanges();

            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Nuevo",
            });

            return entidad;
        }

        public List<Documentos> Listar()
        {
            return this.IConexion!.Documentos!.Take(20)
                .Include(x => x._Empresas)
                .Include(x => x._Bodegas)
                .Include(x => x._Productos)
                .ToList();
        }

        public List<Documentos> PorCodigo(Documentos? entidad)
        {   
            return this.IConexion!.Documentos!
                .Where(x => x.Tipo_Movimiento!.Contains(entidad!.Tipo_Movimiento!))
                .Include(x => x._Empresas)
                .Include(x => x._Bodegas)
                .Include(x => x._Productos)
                .ToList();
        }

        public Documentos? Modificar(Documentos? entidad, int usuario)
        {
            var objUsuario = this.iUsuariosAplicacion!.BuscarID(usuario);
            var permiso = this.iPermisosAplicacion!.BuscarIdRol(objUsuario!.ID_Rol);
            if (permiso == null || !permiso!.Any(x => x.Nombre == "Modificar"))

            {
                throw new Exception("No tiene Permiso de mpdificar");
            }
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.ID == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Documentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            // Cuando se Modifique una entidad Documento va a crear una Auditoria
            this.iAuditoriasAplicacion!.Guardar(new Auditorias()
            {
                ID_Usuario = usuario,
                Fecha = DateTime.Now,
                Accion = "Modificar",
            });
            return entidad;
        }

        //Metodo que calcula el valor total de la compra o venta segun documentos
        public Documentos? CalcularPrecio(Documentos? entidad) 
        {
            if(entidad == null)
                throw new Exception("lbFaltaInformacion");
            var producto = this.IConexion!.Productos!.FirstOrDefault(x => x.ID == entidad.ID_Producto);
            if(entidad.Tipo_Movimiento == "Venta")
                entidad.Valor = entidad.Cantidad * producto!.Precio_Venta;
            if (entidad.Tipo_Movimiento == "Compra")
                entidad.Valor = entidad.Cantidad * producto!.Precio_Compra;

            return entidad;
        }
    }
}
