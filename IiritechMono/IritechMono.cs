using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iddk2000DotNet;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace IiritechMono
{
    public class IritechMono
    {
        private IrisCamera camera = new IrisCamera();

        public class StreamIamagesEventArgs : EventArgs
        {
            public byte[] imageresult { get; set; }
        }
        public event EventHandler<StreamIamagesEventArgs> StreamIamages;
       
        protected virtual void OnStreamIamages(StreamIamagesEventArgs e)
        {
            EventHandler<StreamIamagesEventArgs> handler = StreamIamages;
            if (handler != null)
            {
                handler(this, e);
            }

        }
        public IritechMono()
        {
            camera.capturingCallback = new IDDKCAPTUREPROC(CapturingCallback);
            

        }
        private static Image CreateBitmap8bits(byte[] pRawBuffer, int nWidth, int nHeight)
        {
            if (pRawBuffer == null || pRawBuffer.Length == 0)
            {
                return null;
            }

            Bitmap bmpBitmap = new Bitmap(nWidth, nHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            ColorPalette pal = bmpBitmap.Palette;
            //Create custome palette
            for (int i = 0; i <= 255; i++)
            {
                pal.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmpBitmap.Palette = pal;
            BitmapData bmpData;
            bmpData = bmpBitmap.LockBits(new Rectangle(0, 0, bmpBitmap.Width, bmpBitmap.Height), ImageLockMode.WriteOnly, bmpBitmap.PixelFormat);
            Marshal.Copy(pRawBuffer, 0, bmpData.Scan0, pRawBuffer.Length);
            bmpBitmap.UnlockBits(bmpData);
            return bmpBitmap;
        }

        public void CapturingCallback(Object param, List<IddkImage> images, IddkCaptureStatus captureStatus, IddkResult captureError)
        {
            
            try
            {
                if (captureError != IddkResult.OK)
                {
                    /* Process for error which will cause capturing process stopped */
                    return;
                }
                /* Capture process has finished with the best iris images were captured 
                and store in the device.*/
                else if (captureStatus == IddkCaptureStatus.Complete)
                {                    
                    /* Get best iris images */
                    images = camera.GetResultImage(IddkImageKind.K2, /*VGA image*/
                                                   IddkImageFormat.MonoRaw);                  
                }
                else if (captureStatus == IddkCaptureStatus.Capturing)
                {
                    /* Eye has been detected. */
                }
                else if (captureStatus == IddkCaptureStatus.Abort)
                {
                    /* Capture process has been aborted by either:
                     * - StopCapture was called
                     * - No iris detected
                     */
                    camera.StopCapturing();
                }

                //images will be null if streamImage is not enabled by device configuration
                if (images != null)
                {
                    /* Monocular Device: only one image returned */
                    if (images.Count == 1)
                    {
                        /*Process for stream image with unknown eye side.*/
                        if (images[0] != null)
                        {
                            Image result=CreateBitmap8bits(images[0].ImageData, images[0].ImageWidth, images[0].ImageHeight);
                            StreamIamagesEventArgs args = new StreamIamagesEventArgs();
                            using (MemoryStream ms = new MemoryStream())
                            {

                                result.Save(ms, ImageFormat.Bmp);
                                args.imageresult = new byte[ms.ToArray().Length];
                                ms.ToArray().CopyTo(args.imageresult, 0);
                                
                            }
                            OnStreamIamages(args);

                        }
                    }
                    /*
                    * Binocular Device: The list always contains 2 elements regardless 
                    * there is only one sensor is streaming 
                    * which is specified by eyeSubtype (IddkEyeSubtype.Right or
                    * IddkEyeSubtype.Left) in StartCapture.
                    */
                    else if (images.Count == 2)
                    {
                        /* Check if the image data of right eye is available */

                        if (images[0] != null)
                        {
                            /* Process for right eye */
                        }
                        /* Check if the image data of left eye is available */
                        if (images[1] != null)
                        {
                            /* Process for left eye */
                        }
                    }
                }

            }
            catch (System.Exception e)
            {
                throw new Exception("Error", e);
            }
        }

        public void StartCapturing()
        {

            try
            {
                
                    camera.StartCapturing();
                 
            }
            catch (IriException ex)
            {
                throw new IriException("error",ex);
                
            }



        }
        public void stopCapturing()
        {

            try
            {

                camera.StopCapturing();

            }
            catch (IriException ex)
            {
                throw new IriException("error", ex);

            }


        }
    }
}
