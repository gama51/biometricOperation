using System;
using System.Runtime.InteropServices;

namespace BiometricLibV2
{

    [Guid("B55E7960-A8EE-44B3-BE1B-47129CCEB6BE"), 
        InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IOpereacionBiometrica
    {
        string Verify(string fingerTemplate1Bs64, string fingerTemplate2Bs64);

        string Verify(byte[] fingerTemplate1, byte[] fingerTemplate2);

        void init(int licencingPort = 5000, string licensingAddress = "/local", bool licenseMode = true, int humbralAceptacion = 76);

        void release();
    }
}
