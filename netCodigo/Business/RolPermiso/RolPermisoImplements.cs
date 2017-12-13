using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.RolPermisosEntity;



namespace Business.RolPermiso
{
    public class RolPermisoImplements
    {
        private FlotillasEntities iContext;

        public RolPermisoImplements()
        {
            iContext = new FlotillasEntities();
        }

        /*public RolPermisoEntity ConsultaRolPermiso(decimal idRol,string vin)
        {
            RolPermisoEntity rolPermosoEntity = new RolPermisoEntity();
            List<SEL_PERMISOS_SP_Result> EntidadPermisos = new List<SEL_PERMISOS_SP_Result>();
            EntidadPermisos = iContext.SEL_PERMISOS_SP(idRol,vin).ToList();

            foreach (SEL_PERMISOS_SP_Result item in EntidadPermisos)
            {
                switch (item.nombreCatalogo.ToString())
                {
                    case "economicoInt":
                        rolPermosoEntity.EconomicoInt = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdEconomicoInt = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValEconomicoInt = item.valor.ToString();
                        break;
                    case "economicoExt":
                        rolPermosoEntity.EconomicoExt = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdEconomicoExt = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValEconomicoExt = item.valor.ToString();
                        break;
                    case "placaFoto":
                        rolPermosoEntity.PlacaFoto = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdPlacaFoto = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValPlacaFoto = item.valor.ToString();
                        break;
                    case "placaNumero":
                        rolPermosoEntity.PlacaNumero = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdPlacaNumero = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValPlacaNumero = item.valor.ToString();
                        break;
                    case "equipamientoVehicular":
                        rolPermosoEntity.EquipamientoVehicular = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdEquipamientoVehicular = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValEquipamientoVehicular = item.valor.ToString();
                        break;
                    case "acuseRecibo":
                        rolPermosoEntity.AcuseRecibo = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdAcuseRecibo = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValAcuseRecibo = item.valor.ToString();
                        break;
                    case "acuseEntrega":
                        rolPermosoEntity.AcuseEntrega = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdAcuseEntrega = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValAcuseEntrega = item.valor.ToString();
                        break;
                    case "tarjetaCirculacion":
                        rolPermosoEntity.TarjetaCirculacion = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdTarjetaCirculacion = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValTarjetaCirculacion = item.valor.ToString();
                        break;
                    case "gps":
                        rolPermosoEntity.GPS = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdGPS = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValGPS = item.valor.ToString();
                        break;
                    case "domicilioEntrega":
                        rolPermosoEntity.DomicilioEntrega = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdDomicilioEntrega = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValDomicilioEntrega = item.valor.ToString();
                        break;
                    case "polizaSeguros":
                        rolPermosoEntity.PolizaSeguros = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdPolizaSeguros = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValPolizaSeguros = item.valor.ToString();
                        break;
                    case "permisoEspecial":
                        rolPermosoEntity.PermisoEspecial = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdPermisoEspecial = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValPermisoEspecial = item.valor.ToString();
                        break;
                    case "fechaEntrega":
                        rolPermosoEntity.FechaEntrega = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFechaEntrega = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFechaEntrega = item.valor.ToString();
                        break;
                    case "recibidoPor":
                        rolPermosoEntity.RecibidoPor = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdRecibidoPor = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValRecibidoPor = item.valor.ToString();
                        break;
                    case "fotoFrente":
                        rolPermosoEntity.FotoFrente = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFotoFrente = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFotoFrente = item.valor.ToString();
                        break;
                    case "fotoTrasera":
                        rolPermosoEntity.FotoTrasera  = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFotoTrasera = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFotoTrasera = item.valor.ToString();
                        break;
                    case "fotoCostadoIzq":
                        rolPermosoEntity.FotoCostadoIzq = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFotoCostadoIzq = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFotoCostadoIzq = item.valor.ToString();
                        break;
                    case "fotoCostadoDerecho":
                        rolPermosoEntity.FotoCostadoDerecho = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFotoCostadoDerecho = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFotoCostadoDerecho = item.valor.ToString();
                        break;
                    case "verificacion":
                        rolPermosoEntity.Verificacion = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdVerificacion = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValVerificacion = item.valor.ToString();
                        break;
                    case "factura":
                        rolPermosoEntity.Factura = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFactura = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFactura = item.valor.ToString();
                        break;
                    case "tenencia":
                        rolPermosoEntity.Tenencia = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdTenencia = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValTenencia = item.valor.ToString();
                        break;
                    case "fechaRecibido":
                        rolPermosoEntity.FechaRecibido = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdFechaRecibido = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValFechaRecibido = item.valor.ToString();
                        break;
                    case "otros":
                        rolPermosoEntity.Otros = Convert.ToBoolean(item.permiso);
                        rolPermosoEntity.IdOtros = Convert.ToInt32(item.idCatalogo);
                        rolPermosoEntity.ValOtros = item.valor.ToString();
                        break;                      
                }
            }
            return rolPermosoEntity; 
        }*/

    }
}
