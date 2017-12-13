using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilidades
{
   public class Utilidades
    {
        public void LogErrores(string error)
        {
            error = error + " Fecha: " + DateTime.Now.ToString();
            string fileName = ConfigurationManager.AppSettings["LogErrores"];

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.Flush();
            writer.Close();
            writer.Dispose();

            File.AppendAllText(fileName, error + Environment.NewLine);

        }
    }
}
