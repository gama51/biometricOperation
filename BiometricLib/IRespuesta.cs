using System.Runtime.InteropServices;

namespace BiometricLibV2
{

    [Guid("169BE316-8660-40D0-955A-1DCABD078079"),
        InterfaceType(ComInterfaceType.InterfaceIsDual)]    
    [ComVisible(true)]
    public interface IRespuesta
    {
        bool Result { set; get; }
        int Score { set; get; }
        string Error { set; get; }
    }
}
