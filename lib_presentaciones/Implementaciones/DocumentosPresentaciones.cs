using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class DocumentosPresentacion : IDocumentosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Documentos>> Listar()
        {
            var lista = new List<Documentos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Documentos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Documentos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Documentos>> PorCodigo(Documentos? entidad)
        {
            var lista = new List<Documentos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Documentos/PorCodigo");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Documentos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Documentos?> Guardar(Documentos? entidad, int usuario)
        {
            if (entidad!.ID != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Usuario"] = usuario;//Guardo el Dicionario Usuario

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Documentos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Documentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Documentos?> Modificar(Documentos? entidad, int usuario)
        {
            if (entidad!.ID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Usuario"] = usuario;//Guardo el Dicionario Usuario

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Documentos/Modificar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Documentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
        //Metodod Borrar que recibe la entidad(Docuemntos) y el ID del usuario log
        public async Task<Documentos?> Borrar(Documentos? entidad, int usuario)
        {
            if (entidad!.ID == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;//Guardo el Dicionario Entidades
            datos["Usuario"] = usuario;//Guardo el Dicionario Usuario

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Documentos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Documentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}