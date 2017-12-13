using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busqueda
{
    public class FlotillaImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public FlotillaImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        /// <summary>
        /// Búsqueda de la flotilla por número de factura o vin
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="vin"></param>
        /// <returns>SEL_BUSQUEDA_FLOTILLA_SP_Result</returns>
        public List<SEL_BUSQUEDA_FLOTILLA_SP_Result> BusquedaFlotilla(string factura, string vin, string placa, string licitacion)
        {
            return iContext.SEL_BUSQUEDA_FLOTILLA_SP(factura, vin, placa, licitacion).ToList();
        }

        public List<SEL_LICITACION_APP_SP_Result> LicitacionApp()
        {
            return iContext.SEL_LICITACION_APP_SP().ToList();
        }
        public List<SEL_PERSONA_PUESTO_SP_Result> GetPersona(int idpersona)
        {
            return iContext.SEL_PERSONA_PUESTO_SP(idpersona).ToList();
        }
    }
}
