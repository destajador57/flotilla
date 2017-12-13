using System.Collections.Generic;
using System.Linq;
using DataAccess.Model;
using System;

namespace Business.Usuario
{
    public class UsuarioImplements
    {
        //Objeto de contexto EF
        private FlotillasEntities iContext;

        public UsuarioImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        /// <summary>
        /// registra al usuario en estado pendiente
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public decimal  RegistraUsuarioPendiente(int rol,string nombreCompleto,string email,string password)
        {
            return Convert.ToDecimal(iContext.INS_USUARIO_PENDIENTE_SP(rol, nombreCompleto, email, password).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        /// <summary>
        /// pone al usuario em estado Activo
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public decimal ActivaUsuario(int idUsuario)
        {
            return Convert.ToDecimal(iContext.UPD_USUARIO_ACTIVO_SP(idUsuario).FirstOrDefault()); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }

        /// <summary>
        /// Valida que el usuario exista en la BD
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns>SEL_VALIDAR_USUARIO_SP_Result</returns>
        public SEL_VALIDAR_USUARIO_SP_Result ValidaUsuario(string usuario, string password)
        {
            return iContext.SEL_VALIDAR_USUARIO_SP(usuario,password).FirstOrDefault();
        }
        /// <summary>
        /// Valida que el usuario exista en la BD
        /// </summary>
        /// <param name="usuario"></param>
        public SEL_VALIDAR_USUARIO_URL_SP_Result ValidaUsuarioUrl(string usuario)
        {
            return iContext.SEL_VALIDAR_USUARIO_URL_SP(usuario).FirstOrDefault();
        }
    }
}