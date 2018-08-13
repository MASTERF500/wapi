using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaAlertas.Business;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WAPI3.Controllers
{
    public class SearchController : ApiController
    {
        public object Get(int edo)
        {
            List<Estacion> lstEstcion = new List<Estacion>();
            lstEstcion = Estacion.GetEstacionesDesfase(edo);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstcion);
            jsonserializado = string.Format("{0}\"info\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
        public object GetByEstado(int edo,string fecha)
        {
            List<Estacion> lstEstcion = new List<Estacion>();
            lstEstcion = Estacion.GetEstacionesDesfaseByEstado(edo, fecha);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstcion);
            jsonserializado = string.Format("{0}\"info\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
    }
}
