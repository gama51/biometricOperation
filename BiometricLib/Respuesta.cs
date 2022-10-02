using System;
using System.Runtime.InteropServices;

namespace BiometricLib
{
    [Guid("FC896FC5-2A87-4991-83BE-A52A9F609371"),
    ClassInterface(ClassInterfaceType.AutoDual),
    ComSourceInterfaces(typeof(IRespuesta))]
    [ComVisible(true)]
    [ProgId("BiometricLib.Respuesta")]
    public class Respuesta : IRespuesta
    {
        public bool Result { get ; set ; }
        public int Score { get; set; }
        public string Error { get; set; }
    }
}
