using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.RolPermisosEntity;
using Business.buscarPdf;



namespace Business.Nodo
{
    public class NodoImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public NodoImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }
        
        /// <summary>
        /// obtiene una lista de fases por perfil a partir del idUsuario
        /// </summary>
        /// <param name="idUsuario"></param>        
        /// <returns></returns>
        /// 
        public List<SEL_FASE_PERMISO_SP_Result> GetFasePermiso(int idUsuario)
        {
            return iContext.SEL_FASE_PERMISO_SP(idUsuario).ToList();
        }

        

        /// <summary>
        /// obtiene una lista de documentos mediante la fase y por perfil a partir del idUsuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idFase"></param> 
        /// <returns></returns>
        /// 
        public List<SEL_DOCFASE_PERMISO_SP_Result> GetDocFasePermiso(int idUsuario, int idFase)
        {
            return iContext.SEL_DOCFASE_PERMISO_SP(idUsuario, idFase).ToList();
        }

        /// <summary>
        /// obtiene una lista de permisos mediante el idrol
        /// </summary>
        /// <param name="idRol"></param> 
        /// <param name="vin"></param>
        /// <param name="idUsuario"></param> 
        /// <returns></returns>
        ///
        public List<SEL_PERMISOS_SP_Result> getRolPermiso(int idRol, string vin)
        {
            return iContext.SEL_PERMISOS_SP(idRol, vin).ToList();
        }

        //Carga Factura

        public Business.buscarPdf.Documento getPdf(string vin)
        {
            Business.buscarPdf.Service1 algo = new Service1();
            Business.buscarPdf.Documento docPdf = new buscarPdf.Documento();
            docPdf = algo.BuscaFacturasXVin(vin);
            return docPdf;
        }
       

    }
}
