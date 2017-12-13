using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Utilidades;
using System.Web;

namespace Business.Documento
{
    public class DocumentoImplements
    {

        Utilidades.Utilidades objUtilidades = new Utilidades.Utilidades();

        public string GuardaDocumento(string VIN, Decimal IdDocumento, string RutaOrigen, string consecutivo)
        {            
            string[] arrayRuta = RutaOrigen.Split('.');
            string rutaDestino = ConfigurationManager.AppSettings["RutaDocumentos"] + "\\" + VIN;
            int UltimoElemento = arrayRuta.Count() - 1;

            try
            {
                if (!(Directory.Exists(rutaDestino)))
                    Directory.CreateDirectory(rutaDestino);

                if (Directory.Exists(rutaDestino))
                {
                    if (consecutivo == "0")
                    {
                        rutaDestino = rutaDestino + @"\" + IdDocumento + "." + arrayRuta[UltimoElemento];
                    }
                    else
                    {
                        rutaDestino = rutaDestino + @"\" + IdDocumento + "_" + consecutivo + "." + arrayRuta[UltimoElemento];
                    }

                    File.Copy(RutaOrigen, rutaDestino, true);
                }
            }
            catch (Exception ex)
            {
                objUtilidades.LogErrores(ex.Message);
            }

            return ConfigurationManager.AppSettings["DocumentosExpuestos"].ToString();
        }

        public byte[] CartaFactura(string VIN, int empresa, int sucursal, string nombre, string puesto, string idempleado, string idresponsable, string IdDocumento, string consecutivo)
        {
            byte[] pdfBytes = null;

            string[] data = new string[5] { VIN, nombre, puesto, idempleado, idresponsable };
            string rutaDestino = ConfigurationManager.AppSettings["RutaDocumentos"] + "\\" + VIN;

            if(empresa==1){
                pruebaFactura.Service1Client facturaPdf = new pruebaFactura.Service1Client();

                pdfBytes = facturaPdf.CreateReportFord(data);
            }else if(empresa==4){
                pruebaFactura.Service1Client facturaPdf = new pruebaFactura.Service1Client();

                pdfBytes = facturaPdf.CreateReportNissan(data);
            }
            else if (empresa == 5) {
                pruebaFactura.Service1Client facturaPdf = new pruebaFactura.Service1Client();

                pdfBytes = facturaPdf.CreateReportChevrolet(data);
            }
            else if (empresa == 6)
            {
                pruebaFactura.Service1Client facturaPdf = new pruebaFactura.Service1Client();

                pdfBytes = facturaPdf.CreateReportVW(data);
            }
            try
            {
                if (!(Directory.Exists(rutaDestino)))
                    Directory.CreateDirectory(rutaDestino);

                if (Directory.Exists(rutaDestino))
                {
                    if (consecutivo == "0")
                    {
                        rutaDestino = rutaDestino + @"\" + IdDocumento + ".pdf";
                    }
                    else
                    {
                        rutaDestino = rutaDestino + @"\" + IdDocumento + "_" + consecutivo + ".pdf";
                    }
                    File.WriteAllBytes(rutaDestino, pdfBytes);
                    //FileStream fs = File.Create(rutaDestino);
                    //BinaryWriter bw = new BinaryWriter(fs);
                    //File.WriteAllBytes("", pdfBytes);
                }
            }
            catch (Exception ex)
            {
                objUtilidades.LogErrores(ex.Message);
            }

            return pdfBytes;
        }
        
        

    }
}
