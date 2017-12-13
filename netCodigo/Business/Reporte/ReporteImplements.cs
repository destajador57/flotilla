using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Reporte
{
    public class ReporteImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public ReporteImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        /// <summary>
        /// Obtiene el historial de sincronizaciones en un tiempo determinado
        /// </summary>
        /// <param name="fechaInicio"></param>  
        /// <param name="fechaFinal"></param>
        /// <returns></returns>
        public List<SEL_SINCRONIZACION_MAESTRO_DETALLE_SP_Result> HistorialSincronizacion(DateTime fechaInicio, DateTime fechaFinal)
        {
            return iContext.SEL_SINCRONIZACION_MAESTRO_DETALLE_SP(fechaInicio, fechaFinal).ToList();
        }

        public decimal InsertaSincronizacion(decimal idUsuario, string vin)
        {
            return Convert.ToDecimal(iContext.INS_SINCRONIZACION_MAESTRO_DETALLE_SP(idUsuario, vin));
        }

        public List<SEL_DETALLE_SINCRONIZACION_SP_Result> DetalleSincronizacion(decimal idSincronizacion) {
            return iContext.SEL_DETALLE_SINCRONIZACION_SP(idSincronizacion).ToList();
        }

        /// <summary>
        /// Obtiene el avance y total del documento por cliente
        /// </summary>
        /// <param name="idDocumento"></param>  
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public List<SEL_REPORTE_DOCUMENTO_SP_Result> ReporteDocumento(decimal idCliente)
        {
            return iContext.SEL_REPORTE_DOCUMENTO_SP(idCliente).ToList();
        }

        /// <summary>
        /// Obtiene los clientes de las licitaciones
        /// </summary>
        /// <returns></returns>
        public List<SEL_CLIENTES_SP_Result> Clientes()
        {
            return iContext.SEL_CLIENTES_SP().ToList();
        }
        /// Obtiene el avance y total del documento por licitación
        /// </summary>
        /// <param name="idLicitacion"></param>
        /// <returns></returns>
        public List<SEL_REPORTE_DOCUMENTO_TOTAL_SP_Result> ReporteDocumentosTotales(int idLicitacion)
        {
            return iContext.SEL_REPORTE_DOCUMENTO_TOTAL_SP(idLicitacion).ToList();
        }
    }
}
