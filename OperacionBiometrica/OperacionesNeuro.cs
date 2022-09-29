using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Neurotec;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Images;
using Neurotec.Licensing;
using Neurotec.IO;
using System.Data;

using System.Text;




namespace OperacionBiometrica
{
    public class OperacionesNeuro
    {
        private static OperacionesNeuro _instancia=null;
        private static bool EstadoDelicencias = false;
        static string Components = ConfigurationManager.AppSettings["Licencias"];
        private NBiometricClient ClienteBiometrico;
        /// <summary>
        /// Puerto del servidor de licnecias de Neuro.
        /// </summary>
        private int Port = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoServidorNeuro"]);
        /// <summary>
        /// Dircción Ip del servidor de Neuro.
        /// </summary>
        private string Address = ConfigurationManager.AppSettings["IpServidorNeuro"];
        
        public static OperacionesNeuro Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new OperacionesNeuro();
                }
                return _instancia;
            }
        }
        private OperacionesNeuro()
        {
            if (!EstadoDelicencias)
            {
                ObtenerLicencias();
                inicializarCliente();
            }
            
        }
        private void inicializarCliente()
        {
            ClienteBiometrico = new NBiometricClient();
            ClienteBiometrico.RemoteConnections.Clear();            
            ClienteBiometrico.RemoteConnections.AddToCluster(ConfigurationManager.AppSettings["NeuroServer"], Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"]), Convert.ToInt32(ConfigurationManager.AppSettings["PuertoServidorMatch"]));                    
            ClienteBiometrico.MatchingThreshold = Convert.ToInt32(ConfigurationManager.AppSettings["HumbralAceptacion"]);
            ClienteBiometrico.MatchingFirstResultOnly = Convert.ToBoolean(ConfigurationManager.AppSettings["MatchingFirstResultOnly"]);//true;
            ClienteBiometrico.MatchingMaximalResultCount = Convert.ToInt32(ConfigurationManager.AppSettings["MatchingMaximalResultCount"]);//5
            ClienteBiometrico.MatchingWithDetails = Convert.ToBoolean(ConfigurationManager.AppSettings["MatchingWithDetails"]);//
            ClienteBiometrico.MaximalThreadCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaximalThreadCount"]); //4;
            ClienteBiometrico.FacesMaximalYaw = Convert.ToInt32(ConfigurationManager.AppSettings["FacesMaximalYaw"]); //15
            ClienteBiometrico.FacesMaximalRoll = Convert.ToInt32(ConfigurationManager.AppSettings["FacesMaximalRoll"]); //15
            ClienteBiometrico.FacesQualityThreshold = Convert.ToByte(Convert.ToInt32(ConfigurationManager.AppSettings["FacesQualityThreshold"])); //10

            ClienteBiometrico.LocalOperations = NBiometricOperations.All;
            ClienteBiometrico.BiometricTypes = NBiometricType.All;
            ClienteBiometrico.Initialize();

        }
        /// <summary>
        /// Obtiene las licencias de nero necesarias para la operación.
        /// </summary>
        /// <returns></returns>
        private void  ObtenerLicencias()
        {            
            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (NLicense.ObtainComponents(Address, Port, component))
                    {
                        EstadoDelicencias = true;

                    }
                    else
                    {
                        EstadoDelicencias = false;
                    }

                }                
            
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtner licencias de Neuro", ex);
                   
            }
        }

        public Respuesta Enrolar(mSujeto NeuroSujeto,OperacionesComunes.FormatoArchivo tipodato,Byte[] datos,OperacionesComunes.TipoArchivo tipo)
        {
            Respuesta respuestaEnrolamiento = new Respuesta();
            List<mSujeto> identificados = null;
            this.Identificar(tipodato, datos, tipo,out identificados);
            if (identificados.Count <= 0)
            {

                if (NeuroSujeto != null)
                {
                    if (datos != null)
                    {
                        NSubject Sujeto = new NSubject();
                        NImage img;
                        NFinger Finger;
                        NIris Iris;
                        NTemplate _NTemplate;
                        byte[] Template;
                      
                        switch (tipo)
                        {
                            case OperacionesComunes.TipoArchivo.ROSTRO:
                                if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                                {
                                   Sujeto.SetTemplate(byteaTemplateNeuro(datos));
                                }
                                else
                                {
                                    NFace face = new NFace { Image = byteaImagenNeuro(datos) };
                                 
                                    Sujeto.Faces.Add(face);
                                }
                                Sujeto.Id = NeuroSujeto.NoIdentificacion + "+R";
                                break;
                            case OperacionesComunes.TipoArchivo.IRIS_ID:
                                if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                                {
                                    Sujeto.SetTemplate(byteaTemplateNeuro(datos));
                                }
                                else
                                {
                                    NIris irisd = new NIris { Image = byteaImagenNeuro(datos) };                                   
                                    Sujeto.Irises.Add(irisd);
                                }
                                Sujeto.Id = NeuroSujeto.NoIdentificacion + "+ID";
                                break;
                            case OperacionesComunes.TipoArchivo.IRIS_IZ:
                                if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                                {
                                    Sujeto.SetTemplate(byteaTemplateNeuro(datos));
                                }
                                else
                                {
                                    NIris irisi = new NIris { Image = byteaImagenNeuro(datos) };                                    
                                    Sujeto.Irises.Add(irisi);
                                }
                                Sujeto.Id = NeuroSujeto.NoIdentificacion + "+IZ";
                                break;

                        }
                

                        NBiometricTask createTemplate = ClienteBiometrico.CreateTask(NBiometricOperations.CreateTemplate, Sujeto);
                        ClienteBiometrico.PerformTask(createTemplate);
                        NBiometricStatus estado_tarea = createTemplate.Status;
                        NBiometricTask proceso = ClienteBiometrico.CreateTask(NBiometricOperations.Enroll, Sujeto);
                        ClienteBiometrico.PerformTask(proceso);
                        estado_tarea = proceso.Status;
                        if (estado_tarea == NBiometricStatus.Ok)
                        {
                            respuestaEnrolamiento.Resultado = true;
                        }
                        else
                        {
                            respuestaEnrolamiento.Resultado = false;
                            respuestaEnrolamiento.Errores.Add(estado_tarea.ToString());

                        }

                    }
                }
                else
                {
                    throw new ArgumentException("El parametro NeuroID no puede ser vacio");
                }
            }
            else
            {
                respuestaEnrolamiento = new Respuesta() { Resultado = false };
                respuestaEnrolamiento.Errores.Add("El usuario ya se encuentra en la base de datos");
                respuestaEnrolamiento.Sujeto = identificados[0];               
                
            }
            return respuestaEnrolamiento;
        }

        public Respuesta Identificar(OperacionesComunes.FormatoArchivo tipodato, Byte[] datos, OperacionesComunes.TipoArchivo tipo, out List<mSujeto> identificados)
        {

            Respuesta respuestaIdentificaicon = new Respuesta();
            identificados = new List<mSujeto>();
            if (datos != null)
            {
                NSubject sujeto = new NSubject();
                NImage img;
                NFinger Finger;
                NIris Iris;
                NTemplate _NTemplate;
                byte[] Template;
               
                    switch (tipo)
                    {
                        case OperacionesComunes.TipoArchivo.ROSTRO:
                        if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                        {
                            sujeto.SetTemplate(byteaTemplateNeuro(datos));
                        }
                        else
                        {
                            NFace face = new NFace { Image = byteaImagenNeuro(datos) };
                            sujeto.Faces.Add(face);
                        }
                            break;
                        case OperacionesComunes.TipoArchivo.IRIS_ID:
                        case OperacionesComunes.TipoArchivo.IRIS_IZ:
                        if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                        {
                            sujeto.SetTemplate(byteaTemplateNeuro(datos));
                        }
                        else
                        {
                            NIris irisd = new NIris { Image = byteaImagenNeuro(datos) };
                            sujeto.Irises.Add(irisd);
                        }
                            break;
                    }
                
                NBiometricTask creattemlate= ClienteBiometrico.CreateTask(NBiometricOperations.CreateTemplate , sujeto);
                ClienteBiometrico.PerformTask(creattemlate);
                NBiometricStatus estado_tarea = creattemlate.Status;
                NBiometricTask proceso = ClienteBiometrico.CreateTask(NBiometricOperations.Identify, sujeto);
                ClienteBiometrico.PerformTask(proceso);
                estado_tarea = proceso.Status;
                if (NBiometricStatus.MatchNotFound != estado_tarea)
                {
                    if (sujeto.MatchingResults.Count > 0)
                    {
                        var Results = sujeto.MatchingResults;

                        var GetMax = (from a in sujeto.MatchingResults
                                      select a).Max(row => row.Score);

                        var GetSubject = from a in sujeto.MatchingResults
                                         where a.Score == GetMax
                                         select a.Id;


                        foreach (string a in GetSubject)
                        {
                            identificados.Add(new mSujeto(a));
                        }
                        respuestaIdentificaicon.Resultado = true;
                        respuestaIdentificaicon.Sujeto = identificados[0];
                        
                    }
                 
                }
                else
                {
                    respuestaIdentificaicon.Resultado = false;
                    respuestaIdentificaicon.Errores.Add(estado_tarea.ToString());
                }

            }
            return respuestaIdentificaicon;
        
        }
        public Respuesta Verify(mSujeto NeuroSujeto, OperacionesComunes.FormatoArchivo tipodato,  Byte[] datos, OperacionesComunes.TipoArchivo tipo)
        {
            Respuesta respuestaerificacion = new Respuesta();

            if (NeuroSujeto != null)
            {
                if (datos != null)
                {
                    NSubject Sujeto1 = new NSubject();

                    NImage img;
                    NFinger Finger;
                    NIris Iris;
                    NTemplate _NTemplate;
                    byte[] Template;


                    switch (tipo)
                    {
                        case OperacionesComunes.TipoArchivo.ROSTRO:
                            if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                            {
                                Sujeto1.SetTemplate(byteaTemplateNeuro(datos));
                            }
                            else
                            {
                                NFace face = new NFace { Image = byteaImagenNeuro(datos) };                               
                                Sujeto1.Faces.Add(face);                                
                            }
                            Sujeto1.Id = NeuroSujeto.NoIdentificacion + "+R";
                            break;
                        case OperacionesComunes.TipoArchivo.IRIS_ID:
                            if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                            {
                                Sujeto1.SetTemplate(byteaTemplateNeuro(datos));
                            }
                            else
                            {
                                NIris irisd = new NIris { Image = byteaImagenNeuro(datos) };                               
                                Sujeto1.Irises.Add(irisd);
                                
                            }
                            Sujeto1.Id = NeuroSujeto.NoIdentificacion + "+ID";
                            break;
                        case OperacionesComunes.TipoArchivo.IRIS_IZ:
                            if (OperacionesComunes.FormatoArchivo.PLANTILLA == tipodato)
                            {
                                Sujeto1.SetTemplate(byteaTemplateNeuro(datos));
                            }
                            else
                            {
                                NIris irisi = new NIris { Image = byteaImagenNeuro(datos) };
                                
                                Sujeto1.Irises.Add(irisi);
                            }
                            Sujeto1.Id = NeuroSujeto.NoIdentificacion + "+IZ";
                            break;
                    }          
                    NBiometricTask creattemlate = ClienteBiometrico.CreateTask(NBiometricOperations.CreateTemplate, Sujeto1);
                    ClienteBiometrico.PerformTask(creattemlate);
                    NBiometricStatus estado_tarea = creattemlate.Status;
                    NBiometricTask proceso = ClienteBiometrico.CreateTask(NBiometricOperations.Verify, Sujeto1);
                    ClienteBiometrico.PerformTask(proceso);
                    estado_tarea = proceso.Status;
                    if (estado_tarea == NBiometricStatus.Ok)
                    {
                        respuestaerificacion.Resultado = true;
                    }
                    else
                    {
                        respuestaerificacion.Resultado = false;
                        respuestaerificacion.Errores.Add(estado_tarea.ToString());

                    }

                }
            }
            else
            {
                throw new ArgumentException("El parametro NeuroID no puede ser vacio");
            }

            return respuestaerificacion;

        }

        private NImage byteaImagenNeuro(byte[] Imagen)
        {
            NImage nimgagen = null;
            NMemoryStream nmemorystream = new NMemoryStream(Imagen);
            nimgagen = NImage.FromStream(nmemorystream);               
            return nimgagen;
        }
        private NTemplate byteaTemplateNeuro(byte[] Template)
        {
            NTemplate temp = new NTemplate(Template);
            return temp;

        }
        
    }
}