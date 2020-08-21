namespace LineScanCamDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenCam = new System.Windows.Forms.Button();
            this.buttonCloseCam = new System.Windows.Forms.Button();
            this.buttonSoftTriggerGrab = new System.Windows.Forms.Button();
            this.buttonStartLive = new System.Windows.Forms.Button();
            this.buttonStopLive = new System.Windows.Forms.Button();
            this.checkBoxAsync = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxGamma = new System.Windows.Forms.TextBox();
            this.textBoxGain = new System.Windows.Forms.TextBox();
            this.textBoxExposureTime = new System.Windows.Forms.TextBox();
            this.textBoxLineRate = new System.Windows.Forms.TextBox();
            this.trackBarGamma = new System.Windows.Forms.TrackBar();
            this.trackBarGain = new System.Windows.Forms.TrackBar();
            this.textBoxImageHeight = new System.Windows.Forms.TextBox();
            this.trackBarExposureTime = new System.Windows.Forms.TrackBar();
            this.checkBoxEnableLineRate = new System.Windows.Forms.CheckBox();
            this.trackBarLineRate = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBarImageHeight = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxImageWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarImageWidth = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPixelFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSetParam = new System.Windows.Forms.Button();
            this.buttonGetParam = new System.Windows.Forms.Button();
            this.buttonAdaptShow = new System.Windows.Forms.Button();
            this.buttonPercent100Show = new System.Windows.Forms.Button();
            this.hWindowControlImage = new HalconDotNet.HWindowControl();
            this.buttonTriggerMode = new System.Windows.Forms.Button();
            this.comboBoxTriggerSource = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposureTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenCam
            // 
            this.buttonOpenCam.Location = new System.Drawing.Point(513, 13);
            this.buttonOpenCam.Name = "buttonOpenCam";
            this.buttonOpenCam.Size = new System.Drawing.Size(124, 52);
            this.buttonOpenCam.TabIndex = 1;
            this.buttonOpenCam.Text = "打开";
            this.buttonOpenCam.UseVisualStyleBackColor = true;
            this.buttonOpenCam.Click += new System.EventHandler(this.buttonOpenCam_Click);
            // 
            // buttonCloseCam
            // 
            this.buttonCloseCam.Location = new System.Drawing.Point(513, 84);
            this.buttonCloseCam.Name = "buttonCloseCam";
            this.buttonCloseCam.Size = new System.Drawing.Size(124, 52);
            this.buttonCloseCam.TabIndex = 1;
            this.buttonCloseCam.Text = "关闭";
            this.buttonCloseCam.UseVisualStyleBackColor = true;
            this.buttonCloseCam.Click += new System.EventHandler(this.buttonCloseCam_Click);
            // 
            // buttonSoftTriggerGrab
            // 
            this.buttonSoftTriggerGrab.Location = new System.Drawing.Point(513, 388);
            this.buttonSoftTriggerGrab.Name = "buttonSoftTriggerGrab";
            this.buttonSoftTriggerGrab.Size = new System.Drawing.Size(124, 52);
            this.buttonSoftTriggerGrab.TabIndex = 1;
            this.buttonSoftTriggerGrab.Text = "软触发拍照";
            this.buttonSoftTriggerGrab.UseVisualStyleBackColor = true;
            this.buttonSoftTriggerGrab.Click += new System.EventHandler(this.buttonSoftTriggerGrab_Click);
            // 
            // buttonStartLive
            // 
            this.buttonStartLive.Location = new System.Drawing.Point(513, 193);
            this.buttonStartLive.Name = "buttonStartLive";
            this.buttonStartLive.Size = new System.Drawing.Size(124, 52);
            this.buttonStartLive.TabIndex = 1;
            this.buttonStartLive.Text = "开始取流";
            this.buttonStartLive.UseVisualStyleBackColor = true;
            this.buttonStartLive.Click += new System.EventHandler(this.buttonStartLive_Click);
            // 
            // buttonStopLive
            // 
            this.buttonStopLive.Location = new System.Drawing.Point(513, 258);
            this.buttonStopLive.Name = "buttonStopLive";
            this.buttonStopLive.Size = new System.Drawing.Size(124, 52);
            this.buttonStopLive.TabIndex = 1;
            this.buttonStopLive.Text = "停止取流";
            this.buttonStopLive.UseVisualStyleBackColor = true;
            this.buttonStopLive.Click += new System.EventHandler(this.buttonStopLive_Click);
            // 
            // checkBoxAsync
            // 
            this.checkBoxAsync.AutoSize = true;
            this.checkBoxAsync.Location = new System.Drawing.Point(513, 155);
            this.checkBoxAsync.Name = "checkBoxAsync";
            this.checkBoxAsync.Size = new System.Drawing.Size(89, 19);
            this.checkBoxAsync.TabIndex = 2;
            this.checkBoxAsync.Text = "异步采集";
            this.checkBoxAsync.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "像素格式:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTriggerSource);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxGamma);
            this.groupBox1.Controls.Add(this.textBoxGain);
            this.groupBox1.Controls.Add(this.textBoxExposureTime);
            this.groupBox1.Controls.Add(this.textBoxLineRate);
            this.groupBox1.Controls.Add(this.trackBarGamma);
            this.groupBox1.Controls.Add(this.trackBarGain);
            this.groupBox1.Controls.Add(this.textBoxImageHeight);
            this.groupBox1.Controls.Add(this.trackBarExposureTime);
            this.groupBox1.Controls.Add(this.checkBoxEnableLineRate);
            this.groupBox1.Controls.Add(this.trackBarLineRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trackBarImageHeight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxImageWidth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.trackBarImageWidth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxPixelFormat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 246);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线阵相机参数";
            // 
            // textBoxGamma
            // 
            this.textBoxGamma.Location = new System.Drawing.Point(528, 125);
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.Size = new System.Drawing.Size(76, 25);
            this.textBoxGamma.TabIndex = 6;
            // 
            // textBoxGain
            // 
            this.textBoxGain.Location = new System.Drawing.Point(528, 72);
            this.textBoxGain.Name = "textBoxGain";
            this.textBoxGain.Size = new System.Drawing.Size(76, 25);
            this.textBoxGain.TabIndex = 6;
            // 
            // textBoxExposureTime
            // 
            this.textBoxExposureTime.Location = new System.Drawing.Point(528, 24);
            this.textBoxExposureTime.Name = "textBoxExposureTime";
            this.textBoxExposureTime.Size = new System.Drawing.Size(76, 25);
            this.textBoxExposureTime.TabIndex = 6;
            // 
            // textBoxLineRate
            // 
            this.textBoxLineRate.Location = new System.Drawing.Point(215, 182);
            this.textBoxLineRate.Name = "textBoxLineRate";
            this.textBoxLineRate.Size = new System.Drawing.Size(76, 25);
            this.textBoxLineRate.TabIndex = 6;
            // 
            // trackBarGamma
            // 
            this.trackBarGamma.Location = new System.Drawing.Point(394, 125);
            this.trackBarGamma.Name = "trackBarGamma";
            this.trackBarGamma.Size = new System.Drawing.Size(127, 56);
            this.trackBarGamma.TabIndex = 5;
            this.trackBarGamma.Scroll += new System.EventHandler(this.trackBarGamma_Scroll);
            // 
            // trackBarGain
            // 
            this.trackBarGain.Location = new System.Drawing.Point(394, 72);
            this.trackBarGain.Name = "trackBarGain";
            this.trackBarGain.Size = new System.Drawing.Size(127, 56);
            this.trackBarGain.TabIndex = 5;
            this.trackBarGain.Scroll += new System.EventHandler(this.trackBarGain_Scroll);
            // 
            // textBoxImageHeight
            // 
            this.textBoxImageHeight.Location = new System.Drawing.Point(215, 103);
            this.textBoxImageHeight.Name = "textBoxImageHeight";
            this.textBoxImageHeight.Size = new System.Drawing.Size(76, 25);
            this.textBoxImageHeight.TabIndex = 6;
            // 
            // trackBarExposureTime
            // 
            this.trackBarExposureTime.Location = new System.Drawing.Point(394, 24);
            this.trackBarExposureTime.Name = "trackBarExposureTime";
            this.trackBarExposureTime.Size = new System.Drawing.Size(127, 56);
            this.trackBarExposureTime.TabIndex = 5;
            this.trackBarExposureTime.Scroll += new System.EventHandler(this.trackBarExposureTime_Scroll);
            // 
            // checkBoxEnableLineRate
            // 
            this.checkBoxEnableLineRate.AutoSize = true;
            this.checkBoxEnableLineRate.Location = new System.Drawing.Point(91, 147);
            this.checkBoxEnableLineRate.Name = "checkBoxEnableLineRate";
            this.checkBoxEnableLineRate.Size = new System.Drawing.Size(59, 19);
            this.checkBoxEnableLineRate.TabIndex = 2;
            this.checkBoxEnableLineRate.Text = "开启";
            this.checkBoxEnableLineRate.UseVisualStyleBackColor = true;
            // 
            // trackBarLineRate
            // 
            this.trackBarLineRate.Location = new System.Drawing.Point(82, 182);
            this.trackBarLineRate.Name = "trackBarLineRate";
            this.trackBarLineRate.Size = new System.Drawing.Size(127, 56);
            this.trackBarLineRate.TabIndex = 5;
            this.trackBarLineRate.Scroll += new System.EventHandler(this.trackBarLineRate_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "伽马:";
            // 
            // trackBarImageHeight
            // 
            this.trackBarImageHeight.Location = new System.Drawing.Point(81, 103);
            this.trackBarImageHeight.Name = "trackBarImageHeight";
            this.trackBarImageHeight.Size = new System.Drawing.Size(127, 56);
            this.trackBarImageHeight.TabIndex = 5;
            this.trackBarImageHeight.Scroll += new System.EventHandler(this.trackBarImageHeight_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "增益:";
            // 
            // textBoxImageWidth
            // 
            this.textBoxImageWidth.Location = new System.Drawing.Point(215, 57);
            this.textBoxImageWidth.Name = "textBoxImageWidth";
            this.textBoxImageWidth.Size = new System.Drawing.Size(76, 25);
            this.textBoxImageWidth.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "曝光时间:";
            // 
            // trackBarImageWidth
            // 
            this.trackBarImageWidth.Location = new System.Drawing.Point(82, 57);
            this.trackBarImageWidth.Name = "trackBarImageWidth";
            this.trackBarImageWidth.Size = new System.Drawing.Size(127, 56);
            this.trackBarImageWidth.TabIndex = 5;
            this.trackBarImageWidth.Scroll += new System.EventHandler(this.trackBarImageWidth_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "行频:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "行频使能:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "图像高度:";
            // 
            // comboBoxPixelFormat
            // 
            this.comboBoxPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPixelFormat.FormattingEnabled = true;
            this.comboBoxPixelFormat.Location = new System.Drawing.Point(91, 24);
            this.comboBoxPixelFormat.Name = "comboBoxPixelFormat";
            this.comboBoxPixelFormat.Size = new System.Drawing.Size(200, 23);
            this.comboBoxPixelFormat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "图像宽度:";
            // 
            // buttonSetParam
            // 
            this.buttonSetParam.Location = new System.Drawing.Point(20, 698);
            this.buttonSetParam.Name = "buttonSetParam";
            this.buttonSetParam.Size = new System.Drawing.Size(88, 54);
            this.buttonSetParam.TabIndex = 7;
            this.buttonSetParam.Text = "写入";
            this.buttonSetParam.UseVisualStyleBackColor = true;
            this.buttonSetParam.Click += new System.EventHandler(this.buttonSetParam_Click);
            // 
            // buttonGetParam
            // 
            this.buttonGetParam.Location = new System.Drawing.Point(549, 698);
            this.buttonGetParam.Name = "buttonGetParam";
            this.buttonGetParam.Size = new System.Drawing.Size(88, 54);
            this.buttonGetParam.TabIndex = 7;
            this.buttonGetParam.Text = "读取";
            this.buttonGetParam.UseVisualStyleBackColor = true;
            this.buttonGetParam.Click += new System.EventHandler(this.buttonGetParam_Click);
            // 
            // buttonAdaptShow
            // 
            this.buttonAdaptShow.Location = new System.Drawing.Point(20, 363);
            this.buttonAdaptShow.Name = "buttonAdaptShow";
            this.buttonAdaptShow.Size = new System.Drawing.Size(88, 29);
            this.buttonAdaptShow.TabIndex = 8;
            this.buttonAdaptShow.Text = "适合窗口";
            this.buttonAdaptShow.UseVisualStyleBackColor = true;
            this.buttonAdaptShow.Click += new System.EventHandler(this.buttonAdaptShow_Click);
            // 
            // buttonPercent100Show
            // 
            this.buttonPercent100Show.Location = new System.Drawing.Point(407, 363);
            this.buttonPercent100Show.Name = "buttonPercent100Show";
            this.buttonPercent100Show.Size = new System.Drawing.Size(88, 29);
            this.buttonPercent100Show.TabIndex = 8;
            this.buttonPercent100Show.Text = "1:1窗口";
            this.buttonPercent100Show.UseVisualStyleBackColor = true;
            this.buttonPercent100Show.Click += new System.EventHandler(this.buttonPercent100Show_Click);
            // 
            // hWindowControlImage
            // 
            this.hWindowControlImage.BackColor = System.Drawing.Color.LimeGreen;
            this.hWindowControlImage.BorderColor = System.Drawing.Color.LimeGreen;
            this.hWindowControlImage.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControlImage.Location = new System.Drawing.Point(20, 13);
            this.hWindowControlImage.Name = "hWindowControlImage";
            this.hWindowControlImage.Size = new System.Drawing.Size(475, 337);
            this.hWindowControlImage.TabIndex = 0;
            this.hWindowControlImage.WindowSize = new System.Drawing.Size(475, 337);
            this.hWindowControlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.hWindowControlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            this.hWindowControlImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Image_MouseWheel);
            // 
            // buttonTriggerMode
            // 
            this.buttonTriggerMode.Location = new System.Drawing.Point(513, 323);
            this.buttonTriggerMode.Name = "buttonTriggerMode";
            this.buttonTriggerMode.Size = new System.Drawing.Size(124, 52);
            this.buttonTriggerMode.TabIndex = 9;
            this.buttonTriggerMode.Text = "触发模式：On";
            this.buttonTriggerMode.UseVisualStyleBackColor = true;
            this.buttonTriggerMode.Click += new System.EventHandler(this.buttonTriggerMode_Click);
            // 
            // comboBoxTriggerSource
            // 
            this.comboBoxTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTriggerSource.FormattingEnabled = true;
            this.comboBoxTriggerSource.Location = new System.Drawing.Point(404, 182);
            this.comboBoxTriggerSource.Name = "comboBoxTriggerSource";
            this.comboBoxTriggerSource.Size = new System.Drawing.Size(200, 23);
            this.comboBoxTriggerSource.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(333, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "触发源:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 765);
            this.Controls.Add(this.buttonTriggerMode);
            this.Controls.Add(this.buttonPercent100Show);
            this.Controls.Add(this.buttonAdaptShow);
            this.Controls.Add(this.buttonGetParam);
            this.Controls.Add(this.buttonSetParam);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxAsync);
            this.Controls.Add(this.buttonStopLive);
            this.Controls.Add(this.buttonStartLive);
            this.Controls.Add(this.buttonSoftTriggerGrab);
            this.Controls.Add(this.buttonCloseCam);
            this.Controls.Add(this.buttonOpenCam);
            this.Controls.Add(this.hWindowControlImage);
            this.Name = "Form1";
            this.Text = "LineScan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExposureTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImageWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpenCam;
        private System.Windows.Forms.Button buttonCloseCam;
        private System.Windows.Forms.Button buttonSoftTriggerGrab;
        private System.Windows.Forms.Button buttonStartLive;
        private System.Windows.Forms.Button buttonStopLive;
        private System.Windows.Forms.CheckBox checkBoxAsync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxPixelFormat;
        private System.Windows.Forms.TextBox textBoxImageHeight;
        private System.Windows.Forms.TrackBar trackBarImageHeight;
        private System.Windows.Forms.TextBox textBoxImageWidth;
        private System.Windows.Forms.TrackBar trackBarImageWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLineRate;
        private System.Windows.Forms.CheckBox checkBoxEnableLineRate;
        private System.Windows.Forms.TrackBar trackBarLineRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGamma;
        private System.Windows.Forms.TextBox textBoxGain;
        private System.Windows.Forms.TextBox textBoxExposureTime;
        private System.Windows.Forms.TrackBar trackBarGamma;
        private System.Windows.Forms.TrackBar trackBarGain;
        private System.Windows.Forms.TrackBar trackBarExposureTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSetParam;
        private System.Windows.Forms.Button buttonGetParam;
        private System.Windows.Forms.Button buttonAdaptShow;
        private System.Windows.Forms.Button buttonPercent100Show;
        private HalconDotNet.HWindowControl hWindowControlImage;
        private System.Windows.Forms.Button buttonTriggerMode;
        private System.Windows.Forms.ComboBox comboBoxTriggerSource;
        private System.Windows.Forms.Label label9;
    }
}

