namespace TestServices
{
    partial class CaptureDevice
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.cbxMuestra = new System.Windows.Forms.ComboBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.cbxCameraDevice = new System.Windows.Forms.ComboBox();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(57, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(54, 423);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(236, 423);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(75, 23);
            this.btnVerificar.TabIndex = 3;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(136, 423);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(107, 347);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(204, 20);
            this.txtid.TabIndex = 6;
            // 
            // cbxMuestra
            // 
            this.cbxMuestra.FormattingEnabled = true;
            this.cbxMuestra.Items.AddRange(new object[] {
            "Rostro",
            "IrisIZ",
            "IrisDR"});
            this.cbxMuestra.Location = new System.Drawing.Point(107, 377);
            this.cbxMuestra.Name = "cbxMuestra";
            this.cbxMuestra.Size = new System.Drawing.Size(204, 21);
            this.cbxMuestra.TabIndex = 7;
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Imagen",
            "Plantilla"});
            this.cbxTipo.Location = new System.Drawing.Point(124, 101);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(119, 21);
            this.cbxTipo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Muestra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo Dato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Dispositivo";
            // 
            // cbxDevice
            // 
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Items.AddRange(new object[] {
            "Camara",
            "IrisMono",
            "Archivo"});
            this.cbxDevice.Location = new System.Drawing.Point(124, 12);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(197, 21);
            this.cbxDevice.TabIndex = 11;
            this.cbxDevice.SelectedIndexChanged += new System.EventHandler(this.cbxDevice_SelectedIndexChanged);
            // 
            // btnCapturar
            // 
            this.btnCapturar.Location = new System.Drawing.Point(246, 100);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(75, 23);
            this.btnCapturar.TabIndex = 13;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // cbxCameraDevice
            // 
            this.cbxCameraDevice.FormattingEnabled = true;
            this.cbxCameraDevice.Items.AddRange(new object[] {
            "Imagen",
            "Plantilla"});
            this.cbxCameraDevice.Location = new System.Drawing.Point(124, 44);
            this.cbxCameraDevice.Name = "cbxCameraDevice";
            this.cbxCameraDevice.Size = new System.Drawing.Size(197, 21);
            this.cbxCameraDevice.TabIndex = 14;
            this.cbxCameraDevice.SelectedIndexChanged += new System.EventHandler(this.cbxCameraDevice_SelectedIndexChanged);
            // 
            // cbxResolution
            // 
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Items.AddRange(new object[] {
            "Imagen",
            "Plantilla"});
            this.cbxResolution.Location = new System.Drawing.Point(124, 73);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(197, 21);
            this.cbxResolution.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Camara";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Resolución";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CaptureDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 462);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxResolution);
            this.Controls.Add(this.cbxCameraDevice);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxDevice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.cbxMuestra);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CaptureDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestFace";
            this.Load += new System.EventHandler(this.CaptureDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.ComboBox cbxMuestra;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.ComboBox cbxCameraDevice;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

