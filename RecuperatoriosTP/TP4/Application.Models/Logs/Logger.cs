using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.File.Text;

namespace Application.Models.Logs
{
    public class Logger
    {
        public static void LogException(string log)
        {
           // string ruta = ConfigurationManager.AppSettings["ArchivoLogs"]; ;
            FTexto<string> textF = new FTexto<string>();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory + @"\Logs";

            if(!(System.IO.Directory.Exists(baseDir)))
            {
                System.IO.Directory.CreateDirectory(baseDir);
            }

            string ruta = baseDir + @"\"+ DateTime.Now.ToString("yyyyMMddHHmmss") +"-"+ ConfigurationManager.AppSettings["ArchivoLogs"];
            textF.Save(ruta, log);
        }


    }
}
