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
    public class DatosController : ApiController
    {
        public object Get(int idEstado, int idEstacion, string fch1, string fch2)
        {
            List<EstadoNumDiario> lstEstaNumDiario = new List<EstadoNumDiario>();
            lstEstaNumDiario = EstadoNumDiario.GetEstadoNumDiarioByEstacion(idEstado, idEstacion, fch1, fch2);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstaNumDiario);
            jsonserializado = string.Format("{0}\"estaciones\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;
        }
        public object GetNum(int idEstado, int idEstacion)
        {
            List<EstadoNum> lstEstaNum = new List<EstadoNum>();
            lstEstaNum = EstadoNum.GetEstacionUltimateDate(idEstado,idEstacion);
            JavaScriptSerializer serializacion = new JavaScriptSerializer();
            String jsonserializado = serializacion.Serialize(lstEstaNum);
            jsonserializado = string.Format("{0}\"estaciones\":{1}{2}", "{", jsonserializado, "}");
            object jsonObject = serializacion.Deserialize(jsonserializado, typeof(object));
            return jsonObject;    
        }
    }
}
