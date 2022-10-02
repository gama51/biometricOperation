using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Standards;
using Neurotec.Licensing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BiometricLib
{

    [Guid("E7D34FF7-4BB1-482F-9F00-CDE93E0CCF8F"),
    ClassInterface(ClassInterfaceType.AutoDual),
    ComSourceInterfaces(typeof(IOpereacionBiometrica))]
    [ComVisible(true)]
    [ProgId("BiometricLib.OperacionBiometrica")]
    public class OperacionBiometrica : IOpereacionBiometrica
    {

        public static bool _estadoDelicencias = false;
        public bool EsatdoLicencias{ get { return _estadoDelicencias; } }
        static string Components = "FingerClient,FingerMatcher";

        private NBiometricClient _clienteBiometrico;

        private int LicencingPort = 5000;
        private string LicensingAddress = "/local";
        private int HumbralAceptacion = 94;
        private int MaximalThreadCount = 4;
        private bool LicenseMode = true;
        private List<License> _currentLicense;

        /*public static OperacionBiometrica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new OperacionBiometrica();
                }
                return _instancia;
            }
        }*/

        public OperacionBiometrica()
        {



        }

        public void init(int licencingPort = 5000, string licensingAddress = "/local", bool licenseMode = true, int humbralAceptacion = 76)
        {
            LicencingPort = licencingPort;
            LicensingAddress = licensingAddress;
            HumbralAceptacion = humbralAceptacion;
            MaximalThreadCount = 4;
            LicenseMode = licenseMode;
           

            _currentLicense = new List<License>();
          //  if (!_estadoDelicencias)
           // {
                ObtenerLicencias();
               
            //}
            //if (_clienteBiometrico == null)
            //{
                inicializarCliente();
            //}

        }
        private void inicializarCliente()
        {
            _clienteBiometrico = new NBiometricClient();
            _clienteBiometrico.MatchingThreshold = HumbralAceptacion;
            _clienteBiometrico.MatchingFirstResultOnly = true;
            _clienteBiometrico.MaximalThreadCount = MaximalThreadCount;
            _clienteBiometrico.LocalOperations = NBiometricOperations.All;
            _clienteBiometrico.BiometricTypes = NBiometricType.All;
            _clienteBiometrico.Initialize();

        }

        private void ObtenerLicencias()
        {
            try
            {
                if (NLicenseManager.TrialMode != LicenseMode)
                {
                    NLicenseManager.TrialMode = LicenseMode;
                }
            }
            catch { }

            try
            {
               
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (NLicense.Obtain(LicensingAddress, LicencingPort, component))
                    {

                        _estadoDelicencias = true;

                    }
                    else
                    {
                        _estadoDelicencias = false;

                    }
                    _currentLicense.Add(new License() { Name = component, status = _estadoDelicencias });

                }
                if (!_estadoDelicencias)
                    throw new Exception("No se pudieron obetener todas las licencias ->" + JsonConvert.SerializeObject(_currentLicense));

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtner licencias", ex);

            }
        }

        private void ReleaseLicencias()
        {
            try
            {

                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.Release(component);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al liberar licencias", ex);

            }
            
        }
        public string Verify(string fingerTemplate1Bs64, string fingerTemplate2Bs64)
        {
            var finger1 = Convert.FromBase64String(fingerTemplate1Bs64);
            var finger2 = Convert.FromBase64String(fingerTemplate2Bs64);
            return Verify(finger1, finger2);
        }

        public string Verify(byte[] fingerTemplate1, byte[] fingerTemplate2)
        {


            IRespuesta resp = new Respuesta();


            NSubject subject1 = new NSubject();
            NSubject subject2 = new NSubject();

            FMRecord fiRecordValue1 = new FMRecord(fingerTemplate1, BdifStandard.Iso);
            FMRecord fiRecordValue2 = new FMRecord(fingerTemplate2, BdifStandard.Iso);

            subject1.SetTemplate(fiRecordValue1);
            subject2.SetTemplate(fiRecordValue2);
            if (!IsSubjectValid(subject1))
            {
                resp.Result = false;
                resp.Score = 0;
                resp.Error = "Subject 1 is invalid";
                return JsonConvert.SerializeObject(resp);
            }
            if (!IsSubjectValid(subject1))
            {
                resp.Result = false;
                resp.Score = 0;
                resp.Error = "Subject 2 is invalid";
                return JsonConvert.SerializeObject(resp);

            }

            var status = _clienteBiometrico.Verify(subject1, subject2);
            if (status == NBiometricStatus.Ok)
            {
                resp.Result = true;
                resp.Score = subject1.MatchingResults[0].Score;
            }
            else
            {
                resp.Result = false;
                resp.Score = 0;
                resp.Error = status.ToString();

            }
            _clienteBiometrico.Dispose();
            ReleaseLicencias();
            return JsonConvert.SerializeObject(resp);
        }

        private bool IsSubjectValid(NSubject subject)
        {
            return subject != null && (subject.Status == NBiometricStatus.Ok
                || subject.Status == NBiometricStatus.MatchNotFound
                || subject.Status == NBiometricStatus.None && subject.GetTemplateBuffer() != null);
        }

    }
}
