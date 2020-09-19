using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class LogHelper
    {
        private const string LOG_PATH = "~\\log\\";
        public static void WriteLog(Exception ex)
        {
            Directory.CreateDirectory(System.Web.HttpContext.Current.Request.MapPath(LOG_PATH));
            using (StreamWriter sw = File.CreateText(System.Web.HttpContext.Current.Request.MapPath(LOG_PATH + $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.log")))
            {
                sw.WriteLine($"Message: {ex.Message}");
                sw.WriteLine($"Stacktrace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    sw.WriteLine($"Inner Message: {ex.InnerException.Message}");
                    sw.WriteLine($"Inner Stacktrace: {ex.InnerException.StackTrace}");
                }
            }
        }
    }
}
