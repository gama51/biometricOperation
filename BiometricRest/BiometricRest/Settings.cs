using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BiometricRest
{
    public class Settings
    {
        public static string Path = WebConfigurationManager.AppSettings["Path"];

        public static string Cert= WebConfigurationManager.AppSettings["Cert"];
        public static int TipoDeFirma = Convert.ToInt32(WebConfigurationManager.AppSettings["TipoDeFirma"]);
        public static int PaginaFirma = Convert.ToInt32(WebConfigurationManager.AppSettings["PaginaFirma"]);
        public static double AnchoFirma = Convert.ToDouble(WebConfigurationManager.AppSettings["AnchoFirma"]);
        public static double AltoFirma = Convert.ToDouble(WebConfigurationManager.AppSettings["AltoFirma"]);
        public static double PPP = Convert.ToDouble(WebConfigurationManager.AppSettings["ppp"]);
        public static double PosXFirma = Convert.ToDouble(WebConfigurationManager.AppSettings["XvalFirma"]);
        public static double PosYFirma = Convert.ToDouble(WebConfigurationManager.AppSettings["YvalFirma"]);
        public static double SheetHigh = Convert.ToDouble(WebConfigurationManager.AppSettings["AltoHoja"]);
        public static int TipoImagenFirma = Convert.ToInt32(WebConfigurationManager.AppSettings["TipoImagenFirma"]);    
        public static string NombreCampoFirma = WebConfigurationManager.AppSettings["NombreCampoFirma"];
        public static bool ColocaTitulosFirma = Convert.ToBoolean(WebConfigurationManager.AppSettings["ColocaTitulosFirma"]);
        public static string EncabezadoFirma = WebConfigurationManager.AppSettings["EncabezadoFirma"];
        public static double TamanoFuenteTiempo = Convert.ToDouble(WebConfigurationManager.AppSettings["TamanoFuenteTiempo"]);
        public static double TamanoFuenteTitulo1 = Convert.ToDouble(WebConfigurationManager.AppSettings["TamanoFuenteTitulo1"]);
        public static double TamanoFuenteTitulo2 = Convert.ToDouble(WebConfigurationManager.AppSettings["TamanoFuenteTitulo2"]);
        public static double TamanoFuenteDescripcion = Convert.ToDouble(WebConfigurationManager.AppSettings["TamanoFuenteDescripcion"]);
        public static string NombreCertificado = WebConfigurationManager.AppSettings["NombreCertificado"];
        public static string RazonFirma = WebConfigurationManager.AppSettings["RazonFirma"];
        public static string ServidorEstampadodetiempo = WebConfigurationManager.AppSettings["ServidorEstampadodetiempo"];
        public static bool FileDebug = Convert.ToBoolean(WebConfigurationManager.AppSettings["FileDebug"]);
    }
}