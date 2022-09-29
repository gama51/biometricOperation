using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TestServices.ServicioBiometrico;
using IiritechMono;
using Camara;
using System.Runtime.Serialization.Json;



namespace TestServices
{
    public partial class CaptureDevice : Form
    {
        public CaptureDevice()
        {
            InitializeComponent();
            cbxCameraDevice.Enabled = false;
            cbxResolution.Enabled = false;
        }
        string path = "";
        byte[] imageToSend;
        IritechMono IrisMonoCam = new IritechMono();
        MediaCamera webcam = new MediaCamera();
        delegate void ChangePicture(byte[] imageBytes);
        public void PictureChangeIamage(byte[] imagesbyte)
        {
            using (MemoryStream ms = new MemoryStream(imagesbyte))
            {
                Image img = Bitmap.FromStream(ms);
                pictureBox1.Image = img;
                imageToSend = new byte[imagesbyte.Length];
                imagesbyte.CopyTo(imageToSend,0);
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Respuesta rs = new Respuesta();
            OperacioBiometricaClient opb = new OperacioBiometricaClient();
            opb.InnerChannel.OperationTimeout = new TimeSpan(0, 5, 0);
            byte[] bytefromfile = null;
            OperacionesComunesTipoArchivo TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
            OperacionesComunesFormatoArchivo formato = OperacionesComunesFormatoArchivo.JPG;
            if (cbxMuestra.SelectedIndex > -1)
            {
                if (cbxMuestra.SelectedItem.ToString() == "Rostro")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IrisIZ")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_IZ;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IirisDR")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_ID; ;
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de Muestra");
                return;
            }
            if (cbxTipo.SelectedIndex > -1)
            {
                if (cbxTipo.SelectedItem.ToString() == "Plantilla")
                {
                    formato = OperacionesComunesFormatoArchivo.PLANTILLA;
                    bytefromfile = File.ReadAllBytes(path);
                }
                else if (cbxTipo.SelectedItem.ToString() == "Imagen")
                {
                    formato = OperacionesComunesFormatoArchivo.JPG;

                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    Image imgs = Image.FromFile(path);
                    //    imgs.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    bytefromfile = new byte[ms.ToArray().Length];
                    //    ms.ToArray().CopyTo(bytefromfile, 0);
                    //}
                    bytefromfile = new byte[imageToSend.Length];
                    imageToSend.CopyTo(bytefromfile, 0);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de archivo");
                return;
            }
            rs = opb.Identifiacion(bytefromfile, formato, TipoMuestra);
            if (rs.Resultado)
            {
                MessageBox.Show(rs.Sujeto.NoIdentificacion);
            }
            else
            {
                string tempex = "";
                foreach (string er in rs.Errores)
                {
                    tempex += "|" + er;
                }
                MessageBox.Show(tempex);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            Respuesta rs = new Respuesta();
            OperacioBiometricaClient opb = new OperacioBiometricaClient();
            opb.InnerChannel.OperationTimeout = new TimeSpan(0, 5, 0);
            byte[] bytefromfile = null;
            mSujeto ss = new mSujeto();
            if (txtid.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Por favor digite una identificación");
                return;
            }
            ss.NoIdentificacion = txtid.Text;
            OperacionesComunesTipoArchivo TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
            OperacionesComunesFormatoArchivo formato = OperacionesComunesFormatoArchivo.JPG;
            if (cbxMuestra.SelectedIndex > -1)
            {
                if (cbxMuestra.SelectedItem.ToString() == "Rostro")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IrisIZ")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_IZ;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IirisDR")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_ID; ;
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de Muestra");
                return;
            }
            if (cbxTipo.SelectedIndex > -1)
            {
                if (cbxTipo.SelectedItem.ToString() == "Plantilla")
                {
                    formato = OperacionesComunesFormatoArchivo.PLANTILLA;
                    bytefromfile = File.ReadAllBytes(path);
                }
                else if (cbxTipo.SelectedItem.ToString() == "Imagen")
                {
                    formato = OperacionesComunesFormatoArchivo.JPG;
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    Image imgs = Image.FromFile(path);
                    //    imgs.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    bytefromfile = new byte[ms.ToArray().Length];
                    //    ms.ToArray().CopyTo(bytefromfile, 0);
                    //}
                    bytefromfile = new byte[imageToSend.Length];
                    imageToSend.CopyTo(bytefromfile, 0);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de archivo");
                return;
            }

            rs = opb.Enrollar(bytefromfile, JsonSerializer(ss), formato, TipoMuestra);


            if (!rs.Resultado)
            {
                string tempex = "";
                foreach (string er in rs.Errores)
                {
                    tempex += "|" + er;
                }
                MessageBox.Show(tempex + " => " + rs.Sujeto!=null?rs.Sujeto.NoIdentificacion:"");
            } else
            {
                MessageBox.Show("El sujeto se ha enrolado correctamente");

            }

        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {

            Respuesta rs = new Respuesta();
            byte[] bytefromfile = null;
            OperacioBiometricaClient opb = new OperacioBiometricaClient();
            opb.InnerChannel.OperationTimeout = new TimeSpan(0, 5, 0);


            mSujeto ss = new mSujeto();
            if (txtid.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Por favor digite una identificación");
                return;
            }
            ss.NoIdentificacion = txtid.Text;
            OperacionesComunesTipoArchivo TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
            OperacionesComunesFormatoArchivo formato = OperacionesComunesFormatoArchivo.JPG;
            if (cbxMuestra.SelectedIndex > -1)
            {
                if (cbxMuestra.SelectedItem.ToString() == "Rostro")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.ROSTRO;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IrisIZ")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_IZ;
                }
                else if (cbxMuestra.SelectedItem.ToString() == "IirisDR")
                {
                    TipoMuestra = OperacionesComunesTipoArchivo.IRIS_ID; ;
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de Muestra");
                return;
            }
            if (cbxTipo.SelectedIndex > -1)
            {
                if (cbxTipo.SelectedItem.ToString() == "Plantilla")
                {
                    formato = OperacionesComunesFormatoArchivo.PLANTILLA;
                    bytefromfile = File.ReadAllBytes(path);
                }
                else if (cbxTipo.SelectedItem.ToString() == "Imagen")
                {
                    formato = OperacionesComunesFormatoArchivo.JPG;
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    Image imgs = Image.FromFile(path);
                    //    imgs.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    bytefromfile = new byte[ms.ToArray().Length];
                    //    ms.ToArray().CopyTo(bytefromfile, 0);
                    //}
                    bytefromfile = new byte[imageToSend.Length];
                    imageToSend.CopyTo(bytefromfile,0);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de archivo");
                return;
            }
            rs = opb.Verificar(bytefromfile, JsonSerializer(ss), formato, TipoMuestra);

            if (!rs.Resultado)
            {
                string tempex = "";
                foreach (string er in rs.Errores)
                {
                    tempex += "|" + er;
                }
                MessageBox.Show(tempex);
            }
            else
            {
                MessageBox.Show(rs.Resultado.ToString());
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CaptureDevice_Load(object sender, EventArgs e)
        {
            IrisMonoCam.StreamIamages += IrisMonoCam_StreamIamages;
            webcam.StreamIamages += Webcam_StreamIamages;
        }

        private void Webcam_StreamIamages(object sender, MediaCamera.StreamIamagesEventArgs e)
        {
            ChangePicture changeimage = new ChangePicture(PictureChangeIamage);
            pictureBox1.Invoke(changeimage, e.imageresult);
        }

        private void IrisMonoCam_StreamIamages(object sender, IritechMono.StreamIamagesEventArgs e)
        {
            ChangePicture changeimage=new ChangePicture(PictureChangeIamage);
            pictureBox1.Invoke(changeimage, e.imageresult);

        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (cbxDevice.SelectedIndex > -1)
            {
                if (cbxDevice.SelectedItem.ToString() == "IrisMono")
                {
                    if (btnCapturar.Text == "Capturar")
                    {

                        try
                        {
                            btnCapturar.Text = "Detener";
                            IrisMonoCam.StartCapturing();

                        }
                        catch (Exception ex)
                        {
                            btnCapturar.Text = "Capturar";
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            btnCapturar.Text = "Capturar";
                            IrisMonoCam.stopCapturing();
                        }
                        catch (Exception ex)
                        {
                            btnCapturar.Text = "Deneter";
                            MessageBox.Show(ex.ToString());
                        }

                    }
                }
                else if (cbxDevice.SelectedItem.ToString() == "Camara")
                {

                    if (btnCapturar.Text == "Capturar")
                    {
                        if (cbxCameraDevice.SelectedIndex < 0)
                        {
                            MessageBox.Show("Por favor seleccione una cámara");
                            return;
                        }
                        if (cbxResolution.SelectedIndex < 0)
                        {
                            MessageBox.Show("Por favor seleccione una resolusión");
                            return;
                        }

                        try
                        {
                            btnCapturar.Text = "Detener";
                            webcam.StartCapturing(cbxCameraDevice.SelectedIndex,cbxResolution.SelectedIndex);                            

                        }
                        catch (Exception ex)
                        {
                            btnCapturar.Text = "Capturar";
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            btnCapturar.Text = "Capturar";
                            webcam.StopCaturing();
                        }
                        catch (Exception ex)
                        {
                            btnCapturar.Text = "Deneter";
                            MessageBox.Show(ex.ToString());
                        }

                    }

                }
                else if (cbxDevice.SelectedItem.ToString() == "Archivo")
                {
                    if (cbxTipo.SelectedIndex > -1)
                    {
                        Stream myStream = null;
                        OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        openFileDialog1.InitialDirectory = "c:\\";
                        openFileDialog1.Filter = "All files (*.*)|*.*";
                        openFileDialog1.FilterIndex = 2;
                        openFileDialog1.RestoreDirectory = true;
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if ((myStream = openFileDialog1.OpenFile()) != null)
                                {

                                    using (myStream)
                                    {
                                        path = openFileDialog1.FileName;
                                        if (cbxTipo.SelectedItem.ToString() == "Imagen")
                                        {
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                myStream.CopyTo(ms);
                                                PictureChangeIamage(ms.ToArray());
                                            }
                                            //pictureBox1.Image = Image.FromStream(myStream);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Platilla cargarda");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {

                        MessageBox.Show("Por favor seleccione un tipo de archivo");
                    }


                }
            }
            else {
                MessageBox.Show("Por favor seleccione un dispositivo");
            }
        }

        private void cbxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCameraDevice.Enabled = false;
            cbxCameraDevice.SelectedIndex = -1;
            cbxCameraDevice.Items.Clear();
            if (cbxDevice.SelectedItem.ToString() == "Archivo")
            {
                btnCapturar.Text = "Cargar";
                cbxTipo.SelectedIndex = -1;

            }
            else if (cbxDevice.SelectedItem.ToString() == "IrisMono")
            {
                btnCapturar.Text = "Capturar";
                cbxTipo.SelectedItem = "Imagen";
            }
            else if (cbxDevice.SelectedItem.ToString() == "Camara")
            {
                btnCapturar.Text = "Capturar";
                cbxTipo.SelectedItem = "Imagen";
                
                foreach (Device cam in webcam.VideoDevices)
                {
                    cbxCameraDevice.Items.Add(cam.Name);
                }
                if (cbxCameraDevice.Items.Count > 0)
                {
                    cbxCameraDevice.Enabled = true;
                    cbxCameraDevice.SelectedIndex = 0;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbxCameraDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxResolution.Items.Clear();            
            if (cbxCameraDevice.SelectedIndex > -1)
            {
                foreach (Resolutions cam in webcam.GetResolutions(cbxCameraDevice.SelectedIndex))
                {
                    cbxResolution.Items.Add(cam.Name);
                }
                cbxResolution.Enabled = true;
                cbxResolution.SelectedIndex = 0;
            }
            else {
                cbxResolution.Enabled = false;
            }
        }

        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
    }
}
