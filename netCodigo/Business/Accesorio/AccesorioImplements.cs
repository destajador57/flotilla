using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;


namespace Business.Accesorio
{
   public class AccesorioImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public AccesorioImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        public decimal InsertaAccesorio(decimal? idUnidad, decimal? idAccesorio)
        {
            return Convert.ToDecimal(iContext.INS_ACCESORIO_SP(idUnidad,idAccesorio).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        public decimal BorraAccesorio(decimal? idUnidadAccesorio)
        {
            return Convert.ToDecimal(iContext.DEL_ACCESORIO_SP(idUnidadAccesorio).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        public decimal InsertaAccesorioOtros(decimal? idUnidad, string descripcion)
        {
            return Convert.ToDecimal(iContext.INS_ACCESORIO_OTROS_SP(idUnidad, descripcion).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        public decimal BorraAccesorioOtro(decimal? idUnidadAccesorioOtro)
        {
            return Convert.ToDecimal(iContext.DEL_ACCESORIO_OTROS_SP(idUnidadAccesorioOtro).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        public List<SEL_ACCESORIO_SP_Result> ConsultaAccesorio(decimal? idUnidad)
        {
            return iContext.SEL_ACCESORIO_SP(idUnidad).ToList(); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        

    }
}
