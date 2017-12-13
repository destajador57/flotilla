using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Business.Utilidades;
using DataAccess.Model;

namespace Business.Bitacora
{
    public class BitacoraImplements
    {

        private FlotillasEntities iContext;

        public BitacoraImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        public decimal InsertaBitacora(decimal idUsuario, string vin, string accion, decimal idDocumento)
        {
            return Convert.ToDecimal(iContext.INS_BITACORA_SP(idUsuario, vin, accion, idDocumento)); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }
         
        public List<SEL_BITACORA_SP_Result> ConsultaBitacora(decimal idDocumento, string vin)
        {
            return iContext.SEL_BITACORA_SP(vin,idDocumento).ToList();
        }

    }
}
