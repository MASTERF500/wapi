using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//Agregados
using SistemaAlertas.Business;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace WAPI3.Controllers
{
    public class EstacionController : ApiController
    {
        public object Get(int idEstado)
        {
            List<Estacion> lstEstcion = new List<Estacion>();
            lstEstcion = Estacion.GetEstaciones(idEstado);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstcion);
            jsonserializado = string.Format("{0}\"est\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
        public object GetMun(int idMunicipio)
        {
            List<Estacion> lstEstcion = new List<Estacion>();
            lstEstcion = Estacion.GetEstacionesByIdMunicipio(idMunicipio);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstcion);
            jsonserializado = string.Format("{0}\"est\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
        public object GetEstados()
        {
            List<Estado> lstEstado = new List<Estado>();
            lstEstado = Estado.GetEstados();
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstado);
            jsonserializado = string.Format("{0}\"estados\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
        public object GetMunicipios(int idEst)
        {
            List<Municipio> lstMunicipio = new List<Municipio>();
            lstMunicipio = Municipio.GetMunicipios(idEst);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstMunicipio);
            jsonserializado = string.Format("{0}\"municipios\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
    }
}
