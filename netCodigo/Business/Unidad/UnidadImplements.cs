using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Business.Unidad
{
    public class UnidadImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public UnidadImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        /// <summary>
        /// inserta una nueva unidad
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="idLicitacion"></param>
        /// <param name="economicoInt"></param>
        /// <param name="accesorios"></param>
        /// <param name="domicilioEntrega"></param>
        /// <returns></returns>
        /// 
        public decimal InsertaUnidad(DataAccess.Model.Unidad unidad)
        {
            return Convert.ToDecimal(iContext.INS_UNIDAD_SP(unidad.vin, unidad.idLicitacion, unidad.economicoInt, unidad.domicilioEntrega));
        }

        /// <summary>
        /// obtiene una unidad a partir del vin
        /// </summary>
        /// <param name="vin"></param>        
        /// <returns></returns>
        /// 
        public SEL_UNIDAD_SP_Result GetUnidad(string vin)
        {
            return iContext.SEL_UNIDAD_SP(vin).FirstOrDefault();
        }

        /// <summary>
        /// Actualiza propiedades de la unidad con su vin
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="economicoExt"></param> 
        /// <param name="placa"></param> 
        /// <param name="poliza"></param> 
        /// <param name="tenencia"></param> 
        /// <param name="verificacion"></param> 
        /// <param name="permisoEspecial"></param> 
        /// <returns></returns>
        /// 
        public decimal UpdateUnidad(DataAccess.Model.Unidad unidad)
        {
            return iContext.UPD_UNIDAD_SP(unidad.vin, unidad.economicoExt, unidad.placa, unidad.poliza, unidad.tenencia, unidad.verificacion, unidad.permisoEspecial);
        }

        /// <summary>
        /// Seleccionar datos de encabezado de la unidad por su vin
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public SEL_UNIDAD_ENCABEZADO_SP_Result GetUnidadEncabezado(string vin)
        {
            return iContext.SEL_UNIDAD_ENCABEZADO_SP(vin).FirstOrDefault();
        }

        /// <summary>
        /// Actualiza o inserta un documento de la unidad(VIN)
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="idDocumento"></param>
        /// <param name="valor"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public string ActualizaUnidad(string vin, decimal idDocumento, string valor, decimal idUsuario)
        {
            return iContext.UPD_UNIDAD_PROPIEDAD_SP(vin, idDocumento, valor, idUsuario).FirstOrDefault(); // UPD_UNIDAD_PROPIEDAD_SP
        }

        /// <summary>
        /// Actualiza el estatus de la unidad de una licitación determinada
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="idLicitacion"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        public decimal ActualizaEstatusLicVIN(string vin, decimal idLicitacion, string estatus)
        {
            return iContext.UPD_ESTATUS_LICITACION_SP(vin, idLicitacion, estatus);
        }

        /// <summary>
        /// Obtiene la lista de documen tos por rol
        /// </summary>
        /// <returns></returns>
        public List<SEL_ROL_DOCUMENTO_SP_Result> getRolDocumento()
        {
            return iContext.SEL_ROL_DOCUMENTO_SP().ToList();
        }

        /// <summary>
        /// Se elimina elemento de unidad propiedad
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="idDocumento"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public string DeleteUnidadPropiedad(string vin, decimal idDocumento, string valor, decimal consecutivo)
        {
            return iContext.DEL_UNIDAD_PROPIEDAD_SP(vin, idDocumento, valor, consecutivo).FirstOrDefault();
        }

        /// <summary>
        /// Obtiene la lista de documentos por idDocumento
        /// </summary>
        /// <returns></returns>
        public List<SEL_LISTA_DOCUMENTOS_SP_Result> getListaDocumentos(string vin, decimal idDocumento)
        {
            return iContext.SEL_LISTA_DOCUMENTOS_SP(vin, idDocumento).ToList();
        }

        /// <summary>
        /// Insertar datos en Lista Documentos
        /// </summary>
        /// <returns></returns>
        //public List<INS_LISTA_DOCUMENTOS_SP_Result> InsertListaDocumentos(string vin, decimal idDocumento)
        //{
        //    return iContext.SEL_LISTA_DOCUMENTOS_SP(vin, idDocumento).ToList();
        //}
    }
}