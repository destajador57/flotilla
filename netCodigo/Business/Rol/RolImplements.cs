using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace Business.Rol
{
   public class RolImplements
    {
        private FlotillasEntities iContext;

        public RolImplements()
        {
            //Inicializamos el contexto
            iContext = new FlotillasEntities();
        }

        public List<SEL_ROL_TODOS_SP_Result> ConsultaRol()
        {
            return iContext.SEL_ROL_TODOS_SP().ToList(); // SEL_EMPLEADO_SP(idempleado).FirstOrDefault();
        }
    }
}
