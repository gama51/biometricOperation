using System;
using System.Runtime.InteropServices;

namespace BiometricLibV2
{
    [Guid("190ED73B-63D4-4F20-84AA-A76BF4E41E6F"),
        ClassInterface(ClassInterfaceType.AutoDual),
    ComSourceInterfaces(typeof(IRespuesta))]
    [ComVisible(true)]
    [ProgId("BiometricLibV2.Respuesta")]
    public class Respuesta : IRespuesta
    {
        public bool Result { get ; set ; }
        public int Score { get; set; }
        public string Error { get; set; }
    }
}
