using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AForge;
using AForge.Video;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Imaging;
using System.IO;

namespace Camara
{
    

    public class MediaCamera
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;
        delegate void dlSources();
        bool threadstate = true;
        VideoSourcePlayer Source;
        private List<Device> _VideoDevices;
        public class StreamIamagesEventArgs : EventArgs
        {
            public byte[] imageresult { get; set; }
        }
        public event EventHandler<StreamIamagesEventArgs> StreamIamages;
        Thread threadImage;
        protected virtual void OnStreamIamages(StreamIamagesEventArgs e)
        {
            EventHandler<StreamIamagesEventArgs> handler = StreamIamages;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        public List<Device> VideoDevices
        {
            get
            {
                _VideoDevices = new List<Device>();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                // add all devices to combo
                for (int i=0;i<videoDevices.Count;i++)
                {
                    FilterInfo info = videoDevices[i];
                    _VideoDevices.Add(new Device(0, info.Name) { MonikerString = info.MonikerString });
                }
                return _VideoDevices;
            }

            set
            {
                _VideoDevices = value;
            }
        }

        public MediaCamera()
        {
            // enumerate video devices

            
        }
        public void StartCapturing(int indexSelectDev, int indexResolution)
        {
            Source = new VideoSourcePlayer();
            videoDevice = new VideoCaptureDevice(videoDevices[indexSelectDev].MonikerString);
            videoDevice.VideoResolution = videoDevice.VideoCapabilities[indexResolution];
            Source.VideoSource = videoDevice;
            Source.Start();
            threadstate = true;
            threadImage = new Thread(getImageinThread);            
            threadImage.Start();
                    
        }
        public void StopCaturing()
        {
            if (Source != null)
            {
                Source.Stop();
                threadstate = false;
                //threadImage.Abort();
            }

        }
        public void sourcerefresh()
        {
            System.Drawing.Image Resultimage = null;
            Resultimage = Source.GetCurrentVideoFrame();
            if (Resultimage != null)
            {
                StreamIamagesEventArgs args = new StreamIamagesEventArgs();
                using (MemoryStream ms = new MemoryStream())
                {
                    Resultimage.Save(ms, ImageFormat.Jpeg);
                    args.imageresult = new byte[ms.ToArray().Length];
                    ms.ToArray().CopyTo(args.imageresult, 0);

                }
                OnStreamIamages(args);
            }
            //System.Threading.Thread.Sleep(100);
            Source.Refresh();


        }
        public void getImageinThread()
        {
            
            while (threadstate)
            {
                dlSources ds = new dlSources(sourcerefresh);
                Source.Invoke(ds);
               
            }
        }

        public List<Resolutions> GetResolutions(int indexSelecDev)
        {
            List<Resolutions> result = new List<Resolutions>();
            videoDevice = new VideoCaptureDevice(videoDevices[indexSelecDev].MonikerString);
            videoCapabilities = videoDevice.VideoCapabilities;
            for (int i=0;i<videoCapabilities.Length;i++)
            {
                VideoCapabilities capabilty = videoCapabilities[i];
                result.Add(new Resolutions(i, string.Format("{0} x {1}", capabilty.FrameSize.Width, capabilty.FrameSize.Height)));
                
            }
            return result;

        }
        
    }
}
