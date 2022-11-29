using System;
using System.Runtime.InteropServices;

namespace BiometricLib
{

    [Guid("1A7BEC2D-AA58-485A-AC8E-CB630B40F06B"), 
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
