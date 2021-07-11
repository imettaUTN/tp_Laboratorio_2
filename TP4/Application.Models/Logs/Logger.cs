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

            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\"+ DateTime.Now.ToString("yyyyMMddHHmmss") +"-"+ ConfigurationManager.AppSettings["ArchivoLogs"];
            textF.Save(ruta, log);
        }


    }
}
