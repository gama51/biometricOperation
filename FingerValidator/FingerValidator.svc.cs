using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GrFingerXLib;
using System.IO;
namespace FingerValidator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IFingerValidator
    {
      
        public Respuesta VerifyFinger(string idTarget, Finger fingerTarget,int threshold)
        {
            Respuesta Resp = new Respuesta();  
            try
            {
                Registraduria_8130.ReplicatClient client8130 = new Registraduria_8130.ReplicatClient();
                Registraduria_8130.SearchCandidate Sc8130 = new Registraduria_8130.SearchCandidate();
                Sc8130.m_s_OperatorId = "OPMREX01";
                Sc8130.m_s_ClientId = "A1705601";
                Sc8130.m_s_NuipNip = idTarget;
                Sc8130.m_s_NUT = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12);
                Sc8130.mv_fi_FingersToGet = new Registraduria_8130.SearchCandidate.mv_fi_FingersToGetType();
                Sc8130.mv_fi_FingersToGet.Add(fingerTarget.IdFinger.ToString());
                Sc8130.m_fpf_FingerPrintFormat = "ISO-FMR";
                Registraduria_8130.searchCandidateResponse Rp8130 = new Registraduria_8130.searchCandidateResponse();
                Rp8130 = client8130.SearchCandidate(Sc8130);

                if (Rp8130.m_ss_SearchStatus == Utils.CandidateFound)
                {
                    GrFingerXLib.GrFingerXCtrl igrf = new GrFingerXCtrl();
                    igrf.Initialize();
                    int contextid = 0;
                    int score = 0;
                    int Compthreshold = threshold==0?20:threshold;//(int)GRConstants.GR_MAX_THRESHOLD;
                    int rotation = (int)GRConstants.GR_ROT_MAX;
                    int lg2 = (int)GRConstants.GR_MAX_SIZE_TEMPLATE;
                    int cxt = igrf.CreateContext(ref contextid);
                    string tem = fingerTarget.Template;
                    object sd = (object)tem;
                    //sbyte sc=igrf.IsBase64Encoding(ref sd,lg2);
                    Array m = fingerTarget.Template.ToArray();

                    byte[] sourceTarget = Convert.FromBase64String(fingerTarget.Template);
                   //Encoding ec = Encoding.GetEncoding(fingerTarget.Template);
                    File.WriteAllBytes(Environment.CurrentDirectory + "\\testTemp.txt",sourceTarget);
                    byte[] isoSource = new byte[(int)GRConstants.GR_MAX_SIZE_TEMPLATE];
                    Array arraySource = sourceTarget.ToArray();
                    Array isoArray = isoSource.ToArray();
                    Array candidateArray = Rp8130.FingerPrintData[0].mv_b_FingerPrintData.ToArray();
                    string candiatebs64=Convert.ToBase64String(Rp8130.FingerPrintData[0].mv_b_FingerPrintData);
                    int convertionResponce = igrf.ConvertTemplate(ref arraySource, ref isoArray, ref lg2, contextid, (int)GrFingerXLib.GRConstants.GR_FORMAT_ISO);
                    Array isoarray_result=new byte[lg2];
                    Array.Copy(isoArray, 0, isoarray_result,0 ,lg2);
                    


                    string tempiso = Convert.ToBase64String((byte[])isoarray_result);

                    if (convertionResponce == 0)
                    {
                        //int rs2 = igrf.GetVerifyParameters(ref Compthreshold, ref rotation, contextid);
                        int rs3 = igrf.SetIdentifyParameters(Compthreshold, rotation, contextid);
                        int verifyResponse = igrf.Verify(ref isoarray_result, ref candidateArray, ref score, contextid);
                        Resp.Score = score;
                        Resp.Operation = "Verification";
                        if (verifyResponse != 1)
                        {
                            Resp.State = false;
                            
                        }else
                        {
                           
                            Resp.State = true;
                        }

                        Resp.CodeComparation=verifyResponse;

                        

                    }
                    else 
                    {
                        Resp.State = false;
                        Resp.Operation = "ConvertionToISO";
                        Resp.CodeComparation = convertionResponce;
                    
                    }
                    int cxd = igrf.DestroyContext(contextid);
                    igrf.Finalize();

                }
                else 
                {
                    Utils.resultStatus outstatus=Utils.resultStatus.UnknownError;
                    Resp.State = false;
                    Resp.Operation = "FindCandidate";
                    if(Enum.TryParse(Rp8130.m_ss_SearchStatus, out outstatus))
                    {
                        Resp.CodeStatusRequest=(int)outstatus;
                    }
                    Resp.CodeDescriptionRequest = Rp8130.m_ss_SearchStatus;
                
                }
                
                //Hacer validacion

                


            }
            catch (Exception ex)
            {
                Resp.State = false;
                Resp.Operation = "FindCandidate";
                Resp.CodeStatusRequest=-999;
                Resp.CodeDescriptionRequest = ex.ToString();
            
            }
            ///validar 
            return Resp;
            
           
        }
    }
}
