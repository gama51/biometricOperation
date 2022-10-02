using System.Runtime.InteropServices;

namespace BiometricLib
{

    [Guid("2D8E08D5-3FF8-4C24-834F-D75FA7D16554"),
        InterfaceType(ComInterfaceType.InterfaceIsDual)]    
    [ComVisible(true)]
    public interface IRespuesta
    {
        bool Result { set; get; }
        int Score { set; get; }
        string Error { set; get; }
    }
}
