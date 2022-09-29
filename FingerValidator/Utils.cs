using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FingerValidator
{
    public class Utils
    {
        
            public const string CandidateNotFound="CandidateNotFound";
            public const string CandidateFound ="CandidateFound";
            public const string CandidateFoundPartialFingers ="CandidateFoundPartialFingers";
            public const string CandidateNotAuthorizedByAge ="CandidateNotAuthorizedByAge";
            public const string CandidateFoundInvalidFingers ="CandidateFoundInvalidFingers";
            public const string Errorwhilesavingtransaction ="Errorwhilesavingtransaction";
            public const string InvalidOperatorId ="InvalidOperatorId";
            public const string OperatorDisabled ="OperatorDisabled";
            public const string InvalidNut ="InvalidNut";
            public const string InvalidNuipNip ="InvalidNuipNip";
            public const string InvalidFingerId ="InvalidFingerId";
            public const string FingerDataNotEnough ="FingerDataNotEnough";
            public const string InvalidClientId ="InvalidClientId";
            public const string ClientDisabled ="ClientDisabled";
            public const string InvalidFingerPrintFormat ="InvalidFingerPrintFormat";
            public const string FingerPrintFormatNotAuthorized ="FingerPrintFormatNotAuthorized";
            public const string InvalidClientOperatorLink ="InvalidClientOperatorLink";
            public const string ClientOperatorLinkDisabled ="ClientOperatorLinkDisabled";
            public const string InactiveAgreement ="InactiveAgreement";
            public const string ExpiredAgreement ="ExpiredAgreement";
            public const string FingerPrintNotFound ="FingerPrintNotFound";
            public const string FingerPrintConvertError ="FingerPrintConvertError";
            public const string FingerPrintConvertToISOError ="FingerPrintConvertToISOError";
            public const string FingerPrintConvertToANSIError ="FingerPrintConvertToANSIError";
            public const string CommunicationError ="CommunicationError";
            public const string DataBaseError ="DataBaseError";
            public const string UnknownError ="UnknownError";
       
        public enum resultStatus
        {
            CandidateNotFound=0,
            CandidateFound=1,
            CandidateFoundPartialFingers=2,
            CandidateNotAuthorizedByAge=3,
            CandidateFoundInvalidFingers=4,
            Errorwhilesavingtransaction=13,
            InvalidOperatorId=110,
            OperatorDisabled=111,
            InvalidNut=120,
            InvalidNuipNip=130,
            InvalidFingerId=140,
            FingerDataNotEnough=142,
            InvalidClientId=150,
            ClientDisabled=151,
            InvalidFingerPrintFormat=160,
            FingerPrintFormatNotAuthorized=162,
            InvalidClientOperatorLink=170,
            ClientOperatorLinkDisabled=171,
            InactiveAgreement=172,
            ExpiredAgreement=173,
            FingerPrintNotFound=200,
            FingerPrintConvertError=250,
            FingerPrintConvertToISOError=260,
            FingerPrintConvertToANSIError=270,
            CommunicationError=830,
            DataBaseError=940,
            UnknownError=999,
        }


    }
}