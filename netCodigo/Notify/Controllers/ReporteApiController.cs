using Business.Reporte;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Central.Controllers
{
    public class ReporteApiController : ApiController
    {
        private ReporteImplements iReporte;

        public ReporteApiController()
        {
            iReporte = new ReporteImplements();
        }

        /// <summary>
        /// Obtener la lista de sincronizaciones por rango de fechas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":// Activa Usuario
                    var ConsultaHistorial = iReporte.HistorialSincronizacion(DateTime.Parse(parameters[1].ToString()), DateTime.Parse(parameters[2].ToString()).AddHours(23).AddMinutes(59).AddSeconds(59));
                    return Request.CreateResponse<IEnumerable<SEL_SINCRONIZACION_MAESTRO_DETALLE_SP_Result>>(HttpStatusCode.OK, ConsultaHistorial);
                case "2":// Activa Usuario
                    var ConsultaDetalle = iReporte.DetalleSincronizacion(Convert.ToDecimal(parameters[1].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_DETALLE_SINCRONIZACION_SP_Result>>(HttpStatusCode.OK, ConsultaDetalle);
                case "3":// Reporte Documentos
                    var ReporteDocumentos = iReporte.ReporteDocumento(Convert.ToDecimal(parameters[1].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_REPORTE_DOCUMENTO_SP_Result>>(HttpStatusCode.OK, ReporteDocumentos);
                case "4":// Lista Clientes
                    var ListaClientes = iReporte.Clientes();
                    return Request.CreateResponse<IEnumerable<SEL_CLIENTES_SP_Result>>(HttpStatusCode.OK, ListaClientes);
                case "5":// Reporte Documentos Totales
                    var ReporteDocumentosTotales = iReporte.ReporteDocumentosTotales(int.Parse(parameters[1].ToString()));
                    return Request.CreateResponse<IEnumerable<SEL_REPORTE_DOCUMENTO_TOTAL_SP_Result>>(HttpStatusCode.OK, ReporteDocumentosTotales);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Guardar información de sincronización por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(string id)
        {
            var parameters = id.Split('|');
            switch (parameters[0])
            {
                case "1":
                    var insertaSincronizacion = iReporte.InsertaSincronizacion(Convert.ToDecimal(parameters[1].ToString()), parameters[2].ToString());
                    return Request.CreateResponse<Decimal>(HttpStatusCode.OK, insertaSincronizacion);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }
    }
}
