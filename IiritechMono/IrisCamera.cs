using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iddk2000DotNet;

namespace IiritechMono
{
    public class IrisCamera
    {

        public enum ImageQuality
        {
            BAD,
            SUFFICIENT,
            GOOD
        };
        public const float VERIFICATION_THRESHOLD = 1.1f;
        private Iddk2000APIs device = new Iddk2000APIs();
        public IDDKCAPTUREPROC capturingCallback;
        private bool isGalleryLoaded = false;
        private bool isDeviceOpened = false;

        /*
        *	This function demonstrates how to access to an attached device. 
        *	1) Asks user for the connection type between host and device (UART or USB)
        *	2) If it is USB connection:
        *	   - Set SDK configuration for USB connection type by a call to SetSdkConfig()
        *	   - Scan devices for list of descriptions of attached devices by a call to ScanDevices()
        *	   - Open a device with the description returned from ScanDevices by a call to OpenDevice()
        *	  If it is UART connection:
        *	   - Ask user for the baudrate and flow control values to communicate with device. These values must be
        *	     the same with values in device configuration.
        *	   - Set SDK configuration for UART connection type and UART configuration values by a call to SetSdkConfig()
        *	   - Ask user for the COM port, for ex: COM3, to open the device
        *	   - Open the device with a given COM port by a call to OpenDevice()
        * 
        */
        public void OpenDevice()
        {
            IddkResult ret = IddkResult.OK;
            IddkConfig config = new IddkConfig();
            List<string> deviceDescs = new List<string>();
            string selectedDeviceDesc = string.Empty;

            ret = Iddk2000APIs.GetSdkConfig(config);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }

            config.CommStd = IddkCommStd.Usb; // for this sample choose USB as communication standard
            /* Clear current capture section and exit any available administrator login */
            config.ResetOnOpenDevice = true;

            /*Set new configuration*/
            ret = Iddk2000APIs.SetSdkConfig(config);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }

            if (config.CommStd == IddkCommStd.Usb)
            {
                ret = Iddk2000APIs.ScanDevices(deviceDescs);
                if (ret != IddkResult.OK)
                {
                    HandleError(ret);
                }

                if (deviceDescs.Count <= 0)
                {
                    throw new IriException("No IriTech devices found !");
                }

                selectedDeviceDesc = deviceDescs[0];
            }
            else /* UART */
            {
                selectedDeviceDesc = "COM1"; /*COM port name*/
            }

            ret = device.OpenDevice(selectedDeviceDesc);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }
        }

        /*
         *	This function just close device in a safe way. It supports other functions in this
         *	sample code. 
         */
        public void CloseDevice()
        {
            device.CloseDevice(); // ignore return code
            isDeviceOpened = false;
        }

        /*
         * Get best quality image after capture finished
         */
        public List<IddkImage> GetResultImage(IddkImageKind imgKind,
                                              IddkImageFormat imgFormat)
        {
            byte noCompress = 100;
            List<IddkImage> images = new List<IddkImage>();
            IddkResult ret = device.GetResultImage(imgKind,
                                                   imgFormat,
                                                   noCompress,
                                                   images);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }
            return images;
        }

        public void StartCapturing()
        {
            try
            {
                if (!isDeviceOpened)
                {
                    OpenDevice();
                    isDeviceOpened = true;
                }
            }
            catch (IriException e)
            {
                CloseDevice();
                throw;
            }

            /* Parameters for capturing */
            IddkCaptureMode captureMode = IddkCaptureMode.TimeBased;
            IddkQualityMode qualityMode = IddkQualityMode.Normal;
            IddkEyeSubtype eyeSubtype = IddkEyeSubtype.Unknown;
            //bool streamMode = true;
            bool autoLeds = true;
            int iCount = 3;

            /* Other params */
            IddkResult ret = IddkResult.OK;
            IddkInteger imageWidth = new IddkInteger();
            IddkInteger imageHeight = new IddkInteger();
            IddkDeviceConfig deviceConfig = new IddkDeviceConfig();
            List<IddkIrisQuality> qualities = new List<IddkIrisQuality>();

            /* We have to init camera first */
            ret = device.InitCamera(imageWidth, imageHeight);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }

            /* Now, we capture user's eyes */
            /* Note that streamFormat and compressionRatio just works with UART in StartCapture */
            ret = device.StartCapture(captureMode, iCount, qualityMode,
                                    IddkCaptureOperationMode.AutoCapture,
                                    eyeSubtype, autoLeds, capturingCallback, null);

            if (ret != IddkResult.OK)
            {
                /* Remember to deinit camera */
                device.DeinitCamera();
                HandleError(ret);
            }
        }

        public void StopCapturing()
        {
            device.StopCapture();
            /* Remember to deinit camera */
            device.DeinitCamera();
        }

       

      

        /*
         * 	This function check quality of the current capture image
         * 	forEnrollment == true: the image is for enrollment, otherwise it is for matching.
         */
        public ImageQuality GetImageQuality(bool forEnrollment)
        {
            List<IddkIrisQuality> qualities = new List<IddkIrisQuality>();
            IddkResult ret = device.GetResultQuality(qualities);
            if (ret != IddkResult.OK &&
                ret != IddkResult.SE_LeftFrameUnqualified &&
                ret != IddkResult.SE_RightFrameUnqualified)
            {
                HandleError(ret);
            }

            if (forEnrollment)
            {
                /* For enrollment, total score and usable area should be greater than 70 */
                if (qualities[0].TotalScore < 50 && qualities[0].UsableArea < 50 &&
                    (qualities.Count == 1 || qualities[1].TotalScore < 50 && qualities[1].UsableArea < 50))
                { // bad quality image
                    return ImageQuality.BAD;
                }
                else if (qualities[0].TotalScore > 70 && qualities[0].UsableArea > 70 &&
                         (qualities.Count == 1 || qualities[1].TotalScore < 70 && qualities[1].UsableArea < 70))
                { // good quality image
                    return ImageQuality.GOOD;
                }
                else // sufficient for enrollment but encourage to recapture
                {
                    return ImageQuality.SUFFICIENT;
                }
            }
            else
            {
                /* For matching, total score and usable area should be greater than 30 */
                if (qualities[0].TotalScore < 30 && qualities[0].UsableArea < 30 &&
                    (qualities.Count == 1 || qualities[1].TotalScore < 30 && qualities[1].UsableArea < 30))
                { // bad quality image
                    return ImageQuality.BAD;
                }
                else // sufficient for matching
                {
                    return ImageQuality.GOOD;
                }
            }
        }

        /*
         * Clear the image and template of the last capture
         */
        public void ClearCapture()
        {
            device.ClearCapture(IddkEyeSubtype.Unknown);
        }
        /* LoadGallery() does 2 things:
         * - Initialize device's template gallery (in short, gallery). To enroll successful gallery
         *   to be initialized beforehand.
         * - Load templates from device permanent storage ( see Iddk2000APIs.CommitGallery() )
         *   to the template gallery (for this sample, these templates are ignored)
         */
        public List<string> LoadGallery()
        {
            IddkResult ret = IddkResult.OK;
            List<string> enrolleeIds = new List<string>();
            IddkInteger numberEnrolees = new IddkInteger();
            IddkInteger numberUsedSlots = new IddkInteger();
            IddkInteger numberMaxSlots = new IddkInteger();

            ret = device.LoadGallery(enrolleeIds, numberEnrolees, numberUsedSlots, numberMaxSlots);
            if (ret != IddkResult.OK)
            {
                HandleError(ret);
            }

            isGalleryLoaded = true;
            return enrolleeIds;
        }
        #region Helper functions

        void HandleError(IddkResult ret, String message)
        {
            /* Communication error!!! Many results for this.
		     * Next function may be failed too
		     * if we do not recover the communication from this error.
             * We are simply closing device for open later.
		     */
            if (ret == IddkResult.DeviceIOFailed ||
                ret == IddkResult.DeviceIOTimeout ||
                ret == IddkResult.DeviceIODataInvalid)
            {
                CloseDevice();
            }

            if (message == null)
            {
                message = Enum.GetName(typeof(IddkResult), ret);
            }
            throw new IriException(message, ret);
        }

        void HandleError(IddkResult ret)
        {
            string message = Enum.GetName(typeof(IddkResult), ret);
            HandleError(ret, message);
        }

        #endregion
    }
}
