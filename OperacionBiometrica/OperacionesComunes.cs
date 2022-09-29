using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperacionBiometrica
{
    public class OperacionesComunes
    {
        /// <summary>
        /// Tipos de datos bimetricos sortados.
        /// </summary>
        public enum TipoArchivo
        {
            ROSTRO,
            IRIS_IZ,
            IRIS_ID,
        }
        /// <summary>
        /// Formatos de imagen soportados
        /// </summary>
        public enum FormatoArchivo
        {
            PLANTILLA,
            BMP,
            JPG,
            PNG,
            TIFF,



        }
    }
}