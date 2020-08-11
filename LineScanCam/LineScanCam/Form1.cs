using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

using LineScanCam;
using HalconDotNet;
using ThridLibray;


namespace LineScanCamDemo
{
    public partial class Form1 : Form
    {
        private LineScanCamera m_LineCam;
        private Thread m_ThreadLive;        // 显示线程
        private bool m_IsLive;              // 线程控制变量
        private bool m_IsExitLive;
        private HObject m_ImageObj;

        private bool m_TriMode;

        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>(); // 图像缓存列表

        Mutex m_mutex = new Mutex();        // 锁，保证多线程安全

        public Form1()
        {
            InitializeComponent();
            m_LineCam = new LineScanCamera();
            m_ThreadLive = null;
            m_IsLive = false;
            m_IsExitLive = false;
            m_TriMode = false;
            m_ImageObj = new HObject();
            HOperatorSet.GenEmptyObj(out m_ImageObj);

            buttonOpenCam.Enabled = true;
            buttonCloseCam.Enabled = false;
            checkBoxAsync.Enabled = false;
            checkBoxAsync.Checked = false;
            buttonStartLive.Enabled = false;
            buttonStopLive.Enabled = false;
            buttonSoftTriggerGrab.Enabled = false;
            buttonAdaptShow.Enabled = false;
            buttonPercent100Show.Enabled = false;
            buttonTriggerMode.Enabled = false;

            buttonSetParam.Enabled = false;
            buttonGetParam.Enabled = false;
            comboBoxPixelFormat.Enabled = false;
            comboBoxPixelFormat.Items.Add("Mono8");
            comboBoxPixelFormat.Items.Add("Mono10");
            comboBoxPixelFormat.Items.Add("Mono10Packed");
            comboBoxPixelFormat.SelectedIndex = -1;
            trackBarImageWidth.Enabled = false;
            trackBarImageWidth.SetRange(32, 2048);
            textBoxImageWidth.Enabled = false;
            textBoxImageWidth.Text = "";
            trackBarImageHeight.Enabled = false;
            trackBarImageHeight.SetRange(32, 57343);
            textBoxImageHeight.Enabled = false;
            textBoxImageHeight.Text = "";
            checkBoxEnableLineRate.Enabled = false;
            checkBoxEnableLineRate.Checked = false;
            trackBarLineRate.Enabled = false;
            trackBarLineRate.SetRange(100, 58323);
            textBoxLineRate.Enabled = false;
            textBoxLineRate.Text = "";
            trackBarExposureTime.Enabled = false;
            trackBarExposureTime.SetRange(8, 100000);
            textBoxExposureTime.Enabled = false;
            textBoxExposureTime.Text = "";
            trackBarGain.Enabled = false;
            trackBarGain.SetRange(1, 6);
            textBoxGain.Enabled = false;
            textBoxGain.Text = "";
            trackBarGamma.Enabled = false;
            trackBarGamma.SetRange(0, 4);
            textBoxGamma.Enabled = false;
            textBoxGamma.Text = "";
        }

        // 设备对象 
        private IDevice m_dev;

        // 相机打开回调 
        private void OnCameraOpen(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                buttonOpenCam.Enabled = false;
                buttonCloseCam.Enabled = true;
                checkBoxAsync.Enabled = true;
                buttonStartLive.Enabled = true;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonAdaptShow.Enabled = true;
                buttonPercent100Show.Enabled = true;
                buttonTriggerMode.Enabled = true;

                buttonSetParam.Enabled = true;
                buttonGetParam.Enabled = true;
                comboBoxPixelFormat.Enabled = true;
                trackBarImageWidth.Enabled = true;
                textBoxImageWidth.Enabled = true;
                trackBarImageHeight.Enabled = true;
                textBoxImageHeight.Enabled = true;
                checkBoxEnableLineRate.Enabled = true;
                trackBarLineRate.Enabled = true;
                textBoxLineRate.Enabled = true;
                trackBarExposureTime.Enabled = true;
                textBoxExposureTime.Enabled = true;
                trackBarGain.Enabled = true;
                textBoxGain.Enabled = true;
                trackBarGamma.Enabled = true;
                textBoxGamma.Enabled = true;
            }));
        }

        // 相机关闭回调 
        private void OnCameraClose(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                buttonOpenCam.Enabled = true;
                buttonCloseCam.Enabled = false;
                checkBoxAsync.Enabled = false;
                buttonStartLive.Enabled = false;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonAdaptShow.Enabled = false;
                buttonPercent100Show.Enabled = false;
                buttonTriggerMode.Enabled = false;

                buttonSetParam.Enabled = false;
                buttonGetParam.Enabled = false;
                comboBoxPixelFormat.Enabled = false;
                trackBarImageWidth.Enabled = false;
                textBoxImageWidth.Enabled = false;
                trackBarImageHeight.Enabled = false;
                textBoxImageHeight.Enabled = false;
                checkBoxEnableLineRate.Enabled = false;
                trackBarLineRate.Enabled = false;
                textBoxLineRate.Enabled = false;
                trackBarExposureTime.Enabled = false;
                textBoxExposureTime.Enabled = false;
                trackBarGain.Enabled = false;
                textBoxGain.Enabled = false;
                trackBarGamma.Enabled = false;
                textBoxGamma.Enabled = false;
            }));
        }

        // 相机丢失回调 
        private void OnConnectLoss(object sender, EventArgs e)
        {
            m_dev.ShutdownGrab();
            m_dev.Dispose();
            m_dev = null;

            this.Invoke(new Action(() =>
            {
                buttonOpenCam.Enabled = true;
                buttonCloseCam.Enabled = false;
                checkBoxAsync.Enabled = false;
                buttonStartLive.Enabled = false;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonAdaptShow.Enabled = false;
                buttonPercent100Show.Enabled = false;
                buttonTriggerMode.Enabled = false;

                buttonSetParam.Enabled = false;
                buttonGetParam.Enabled = false;
                comboBoxPixelFormat.Enabled = false;
                trackBarImageWidth.Enabled = false;
                textBoxImageWidth.Enabled = false;
                trackBarImageHeight.Enabled = false;
                textBoxImageHeight.Enabled = false;
                checkBoxEnableLineRate.Enabled = false;
                trackBarLineRate.Enabled = false;
                textBoxLineRate.Enabled = false;
                trackBarExposureTime.Enabled = false;
                textBoxExposureTime.Enabled = false;
                trackBarGain.Enabled = false;
                textBoxGain.Enabled = false;
                trackBarGamma.Enabled = false;
                textBoxGamma.Enabled = false;

            }));
        }

        // 码流数据回调 
        private void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            m_mutex.WaitOne();
            m_frameList.Add(e.GrabResult.Clone());
            m_mutex.ReleaseMutex();
        }

        private void WriteCamParam()
        {
            if (m_LineCam != null)
            {
                try
                {
                    string pixelFormat;
                    pixelFormat = comboBoxPixelFormat.SelectedItem.ToString();

                    int imageWidth;
                    imageWidth = int.Parse(textBoxImageWidth.Text);

                    int imageHeight;
                    imageHeight = int.Parse(textBoxImageHeight.Text);

                    bool lineRateEnable;
                    lineRateEnable = checkBoxEnableLineRate.Checked;

                    double lineRate;
                    lineRate = double.Parse(textBoxLineRate.Text);

                    double exposureTime;
                    exposureTime = double.Parse(textBoxExposureTime.Text);

                    double gainRaw;
                    gainRaw = double.Parse(textBoxGain.Text);

                    double gamma;
                    gamma = double.Parse(textBoxGamma.Text);

                    if (
                        m_LineCam.SetImagePixelFormat(pixelFormat) &&
                        m_LineCam.SetIntegerParam("Width", imageWidth) &&
                        m_LineCam.SetIntegerParam("Height", imageHeight) &&
                        m_LineCam.SetAcquisitionLineRateEnable(lineRateEnable) &&
                        m_LineCam.SetFloatParameter("AcquisitionLineRate", lineRate) &&
                        m_LineCam.SetFloatParameter("ExposureTime", exposureTime) &&
                        m_LineCam.SetFloatParameter("GainRaw", gainRaw) &&
                        m_LineCam.SetFloatParameter("Gamma", gamma)
                        )
                    {
                        comboBoxPixelFormat.SelectedIndex = comboBoxPixelFormat.FindString(pixelFormat);

                        trackBarImageWidth.Value = imageWidth;
                        textBoxImageWidth.Text = imageWidth.ToString();

                        trackBarImageHeight.Value = imageHeight;
                        textBoxImageHeight.Text = imageHeight.ToString();

                        checkBoxEnableLineRate.Checked = lineRateEnable;

                        trackBarLineRate.Value = (int)lineRate;
                        textBoxLineRate.Text = lineRate.ToString("f2");

                        trackBarExposureTime.Value = (int)exposureTime;
                        textBoxExposureTime.Text = exposureTime.ToString("f2");

                        trackBarGain.Value = (int)gainRaw;
                        textBoxGain.Text = gainRaw.ToString("f2");

                        trackBarGamma.Value = (int)gamma;
                        textBoxGamma.Text = gamma.ToString("f2");

                    }
                    else
                    {
                        MessageBox.Show("参数写入失败!");

                        return;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("参数写入失败!\r\n" + e.Message);
                    return;
                }

                MessageBox.Show("参数写入成功!");
            }

            return;
        }

        private void ReadCamParam()
        {
            if (m_dev != null)
            {
                string pixelFormat;
                int imageWidth;
                int imageHeight;
                bool lineRateEnable;
                double lineRate;
                double exposureTime;
                double gainRaw;
                double gamma;

                if (
                    m_LineCam.GetImagePixelFormat(out pixelFormat) &&
                    m_LineCam.GetIntegerParam("Width", out imageWidth) &&
                    m_LineCam.GetIntegerParam("Height", out imageHeight) &&
                    m_LineCam.GetAcquisitionLineRateEnable(out lineRateEnable) &&
                    m_LineCam.GetFloatParameter("AcquisitionLineRate", out lineRate) &&
                    m_LineCam.GetFloatParameter("ExposureTime", out exposureTime) &&
                    m_LineCam.GetFloatParameter("GainRaw", out gainRaw) &&
                    m_LineCam.GetFloatParameter("Gamma", out gamma)
                    )
                {
                    comboBoxPixelFormat.SelectedIndex = comboBoxPixelFormat.FindString(pixelFormat);

                    trackBarImageWidth.Value = imageWidth;
                    textBoxImageWidth.Text = imageWidth.ToString();

                    trackBarImageHeight.Value = imageHeight;
                    textBoxImageHeight.Text = imageHeight.ToString();

                    checkBoxEnableLineRate.Checked = lineRateEnable;

                    trackBarLineRate.Value = (int)lineRate;
                    textBoxLineRate.Text = lineRate.ToString("f2");

                    trackBarExposureTime.Value = (int)exposureTime;
                    textBoxExposureTime.Text = exposureTime.ToString("f2");

                    trackBarGain.Value = (int)gainRaw;
                    textBoxGain.Text = gainRaw.ToString("f2");

                    trackBarGamma.Value = (int)gamma;
                    textBoxGamma.Text = gamma.ToString("f2");

                }
                else
                {
                    MessageBox.Show("参数读取失败!");
                }
            }

            return;
        }

        private IntPtr ArrayToIntptr(byte[] source)
        {
            if (source == null)
                return IntPtr.Zero;

            byte[] da = source;
            IntPtr ptr = Marshal.AllocHGlobal(da.Length);
            Marshal.Copy(da, 0, ptr, da.Length);
            return ptr;
        }

        private void FreeIntptr(IntPtr freePtr)
        {
            if (freePtr == IntPtr.Zero)
            {
                return;
            }

            Marshal.FreeHGlobal(freePtr);
            freePtr = IntPtr.Zero;

            return;
        }

        private bool m_IsMagnify = false;
        private double m_Factor = 1.0;
        private int m_MouseX0 = 0;
        private int m_MouseY0 = 0;
        private int m_MouseX1 = 0;
        private int m_MouseY1 = 0;

        private void Image_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!hWindowControlImage.ClientRectangle.Contains(e.Location))
            {
                return;
            }

            if (m_ImageObj.CountObj() <= 0)
            {
                return;
            }

            //Min--0.1 Max--2.0
            if (e.Delta > 0)//Up
            {
                m_Factor += 0.1;
            }
            else//Down
            {
                m_Factor -= 0.1;
            }

            if (m_Factor < 0.1)
            {
                m_Factor = 0.1;
            }
            if (m_Factor > 2.0)
            {
                m_Factor = 2.0;
            }

            HTuple ImgW = 0, ImgH = 0, ScaledW = 0, ScaledH = 0;
            HOperatorSet.GetImageSize(m_ImageObj, out ImgW, out ImgH);
            ScaledW = ImgW * m_Factor;
            ScaledH = ImgH * m_Factor;
            if (ScaledW > hWindowControlImage.Size.Width || ScaledH > hWindowControlImage.Size.Height)
            {
                m_IsMagnify = true;
            }
            else
            {
                m_IsMagnify = false;
            }

            hWindowControlImage.HalconWindow.ClearWindow();
            if (!m_IsMagnify)
            {
                SetPart();
            }

            DispZoomImage(m_Factor, m_ImageObj);

            return;
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (!hWindowControlImage.ClientRectangle.Contains(e.Location))
            {
                return;
            }

            if (!m_IsMagnify)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                m_MouseX0 = e.Location.Y;
                m_MouseY0 = e.Location.X;
            }

            return;
        }

        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (!hWindowControlImage.ClientRectangle.Contains(e.Location))
            {
                return;
            }

            if (!m_IsMagnify)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                int row1 = 0, col1 = 0, row2 = 0, col2 = 0;
                double dbRowMove = 0.0, dbColMove = 0.0;

                if (m_MouseX0 == 0 || m_MouseY0 == 0)
                {
                    return;
                }

                m_MouseX1 = e.Location.Y;
                m_MouseY1 = e.Location.X;
                dbRowMove = m_MouseX0 - m_MouseX1;//计算光标在X轴拖动的距离
                dbColMove = m_MouseY0 - m_MouseY1;//计算光标在Y轴拖动的距离

                hWindowControlImage.HalconWindow.GetPart(out row1, out col1, out row2, out col2);//计算HWindow控件在当前状态下显示图像的位置
                hWindowControlImage.HalconWindow.SetPart((int)(row1 + dbRowMove), (int)(col1 + dbColMove),
                    (int)(row2 + dbRowMove), (int)(col2 + dbColMove));//根据拖动距离调整HWindows控件显示图像的位置

                hWindowControlImage.HalconWindow.ClearWindow();
                DispZoomImage(m_Factor, m_ImageObj);
            }

            return;
        }

        private bool CalculateAdaptFactor(HObject SrcObj, out double Factor, out bool Resize)
        {
            Factor = 1.0;
            Resize = false;

            if (SrcObj.CountObj() <= 0)
            {
                return false;
            }

            m_IsMagnify = false;

            HTuple Width, Height;
            double imageFactor = 1.0;

            HOperatorSet.GetImageSize(SrcObj, out Width, out Height);

            int w = hWindowControlImage.Size.Width;
            int h = hWindowControlImage.Size.Height;

            if (Width <= w && Height <= h)
            {
                Resize = false;
            }
            else
            {
                Resize = true;

                if (Width > w && Height > h)
                {
                    double ratioW = 0.0, ratioH = 0.0;
                    ratioW = double.Parse((w - 2).ToString()) / double.Parse(Width.ToString());
                    ratioH = double.Parse((h - 2).ToString()) / double.Parse(Height.ToString());
                    if (ratioW < ratioH)
                    {
                        imageFactor = ratioW;
                    }
                    else
                    {
                        imageFactor = ratioH;
                    }
                }
                else if (Width > w && Height <= h)
                {
                    imageFactor = double.Parse((w - 2).ToString()) / double.Parse(Width.ToString());
                }
                else if (Height > h && Width <= w)
                {
                    imageFactor = double.Parse((h - 2).ToString()) / double.Parse(Height.ToString());
                }
            }
            Factor = imageFactor;
            Factor = Math.Round(Factor, 2);

            return true;
        }

        private void SetPart()
        {
            int row, col;

            int w = hWindowControlImage.Size.Width;
            int h = hWindowControlImage.Size.Height;

            col = int.Parse(w.ToString()) - 2;
            row = int.Parse(h.ToString()) - 2;
            hWindowControlImage.HalconWindow.SetPart(0, 0, row, col);
            hWindowControlImage.HalconWindow.SetLineWidth(1.0);

            return;
        }

        private void DispImage(HObject DrawObj)
        {
            if (DrawObj.CountObj() <= 0)
            {
                return;
            }

            hWindowControlImage.HalconWindow.DispObj(DrawObj);

            return;
        }

        private void DispZoomImage(double Factor, HObject SrcObj)
        {
            HObject DrawObj;

            if (Factor <= 0.0 || Factor >= 4.0)
            {
                return;
            }

            if (SrcObj.CountObj() <= 0)
            {
                return;
            }

            HOperatorSet.ZoomImageFactor(SrcObj, out DrawObj, Factor, Factor, "bicubic");

            hWindowControlImage.HalconWindow.DispObj(DrawObj);

            return;
        }

        private void PaintImageWindow(HObject DrawObj)
        {
            if (DrawObj.CountObj() <= 0)
            {
                return;
            }

            //            hWindowControlImage.HalconWindow.ClearWindow();
            //             SetPart();
            // 
            //             double factor = 0.0;
            //             bool isResize = false;
            //             if (!CalculateAdaptFactor(DrawObj, out factor, out isResize))
            //             {
            //                 return;
            //             }
            // 
            //             if (isResize)
            //             {
            //                 DispZoomImage(factor, DrawObj);
            //             }
            //             else
            //             {
            //                 DispImage(DrawObj);
            //             }

            hWindowControlImage.HalconWindow.ClearWindow();
            if (!m_IsMagnify)
            {
                SetPart();
            }
            DispZoomImage(m_Factor, DrawObj);

            return;
        }


        private delegate void EnableBtnShow();

        private void EnableBtn()
        {
            if (this.Visible)
            {
                checkBoxAsync.Enabled = true;
                buttonStartLive.Enabled = true;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonSetParam.Enabled = true;
                buttonGetParam.Enabled = true;
            }

            return;
        }

        private void Thread_Live()
        {
            bool isGetting = false;

            if (m_LineCam == null)
            {
                m_IsLive = false;

                if (this.InvokeRequired)
                {
                    this.Invoke(new EnableBtnShow(EnableBtn));
                }

                return;
            }

            while (true)
            {
                if (!m_IsLive)
                {
                    break;
                }

                if (!isGetting)
                {
                    isGetting = true;

                    bool ok = false;
                    byte[] getImagePtr;
                    //int ImageW, ImageH;
                    HTuple getImageW, getImageH;
                    //IntPtr pData;

                    if (m_frameList.Count == 0)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    
                    // 图像队列取最新帧 
                    m_mutex.WaitOne();
                    IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
                    m_frameList.Clear();
                    m_mutex.ReleaseMutex();

                    // 主动调用回收垃圾 
                    GC.Collect();

                    int nRGB = RGBFactory.EncodeLen(frame.Width, frame.Height, false);
                    IntPtr pData = Marshal.AllocHGlobal(nRGB);
                    Marshal.Copy(frame.Image, 0, pData, frame.ImageSize);
                    

                    /*
                    IntPtr ImagePtr = IntPtr.Zero;
                    ImagePtr = ArrayToIntptr(getImagePtr);
                    if (ImagePtr == IntPtr.Zero)
                    {
                        break;
                    }
                    */
                    /*
                    if(!m_LineCam.GrabImage(out pData,out ImageW,out ImageH))
                    {
                        MessageBox.Show("采流取图失败！");
                        return;
                    }
                    */

                    HObject showImageObj;
                    HOperatorSet.GenImage1Extern(out showImageObj, "byte", frame.Width, frame.Height, (HTuple)pData, 0);
                    //FreeIntptr(ImagePtr);

                    HOperatorSet.CopyImage(showImageObj, out m_ImageObj);

                    HOperatorSet.GetImageSize(m_ImageObj,out getImageW,out getImageH);
                    HOperatorSet.SetPart(hWindowControlImage.HalconWindow, 0, 0, getImageH, getImageW);
                    HOperatorSet.DispImage(m_ImageObj, hWindowControlImage.HalconWindow);

                    //PaintImageWindow(m_ImageObj);

                    GC.Collect();
                }

                isGetting = false;

                Thread.Sleep(10);
            }

            m_IsLive = false;
            m_IsExitLive = true;

            if (this.InvokeRequired)
            {
                this.Invoke(new EnableBtnShow(EnableBtn));
            }

            return;
        }

        private bool StartLive()
        {
            if (m_LineCam != null)
            {
                m_IsLive = false;

                string strAcqMode, strAcqModeGet;
                bool lineRateEnable, GetlineRateEnable;

                strAcqMode = "Continuous";
                lineRateEnable = checkBoxAsync.Checked;

                if(!m_LineCam.GetAcquisitionLineRateEnable(out GetlineRateEnable))
                {
                    return false;
                }
                else if(GetlineRateEnable != lineRateEnable)
                {
                    if(!m_LineCam.SetAcquisitionLineRateEnable(lineRateEnable))
                    {
                        return false;
                    }
                }

                if (!m_LineCam.GetAcquisitionMode(out strAcqModeGet))
                {
                    return false;
                }
                else if (strAcqModeGet != strAcqMode)
                {
                    if (!m_LineCam.SetAcquisitionMode(strAcqMode))//连续采集
                    {
                        return false;
                    }
                }

                /*
                if (!m_LineCam.StreamGrab())
                {
                    return false;
                }
                */

                m_dev.StreamGrabber.SetBufferCount(8);
                // 注册码流回调事件 
                // register grab event callback 
                m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                // 开启码流 
                // start grabbing 
                if (!m_dev.GrabUsingGrabLoopThread())
                {
                    MessageBox.Show("开启码流失败！");
                    return false;
                }

                //启动取流线程
                m_IsLive = true;
                m_ThreadLive = new Thread(Thread_Live);
                m_ThreadLive.IsBackground = true;
                m_ThreadLive.Start();

                return true;
            }

            return false;
        }

        private bool StartSoftTriggerLive()
        {
            if (m_LineCam != null)
            {
                m_IsLive = true;
                string strAcqMode, strAcqModeGet;
                bool lineRateEnable, GetlineRateEnable;

                strAcqMode = "Continuous";
                lineRateEnable = checkBoxAsync.Checked;

                //SetTriggerMode("On");

                if (!m_LineCam.GetAcquisitionLineRateEnable(out GetlineRateEnable))
                {
                    return false;
                }
                else if (GetlineRateEnable != lineRateEnable)
                {
                    if (!m_LineCam.SetAcquisitionLineRateEnable(lineRateEnable))
                    {
                        return false;
                    }
                }

                if (!m_LineCam.GetAcquisitionMode(out strAcqModeGet))
                {
                    return false;
                }
                else if (strAcqModeGet != strAcqMode)
                {
                    if (!m_LineCam.SetAcquisitionMode(strAcqMode))//连续采集
                    {
                        return false;
                    }
                }
                /*
                if (!m_LineCam.StreamGrab())
                {
                    return false;
                }
                */
                m_dev.StreamGrabber.SetBufferCount(8);
                // 注册码流回调事件 
                // register grab event callback 
                m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                // 开启码流 
                // start grabbing 
                if (!m_dev.GrabUsingGrabLoopThread())
                {
                    MessageBox.Show("开启码流失败！");
                    return false;
                }
                return true;
            }

            return false;
        }

        private void StopLive()
        {
            try
            {
                if (m_LineCam != null && m_IsLive)
                {
                    m_IsLive = false;
                    if (this.Visible)
                    {
                        buttonCloseCam.Enabled = true;
                        buttonOpenCam.Enabled = false;
                        checkBoxAsync.Enabled = true;
                        buttonStartLive.Enabled = true;
                        buttonStopLive.Enabled = false;
                        buttonSetParam.Enabled = true;
                        buttonGetParam.Enabled = true;
                        buttonSoftTriggerGrab.Enabled = false;
                        buttonTriggerMode.Enabled = true;
                    }

                    //if (!m_LineCam.StopStreamGrab())
                    //{
                    //    return;
                    //}
                    m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调
                    m_dev.ShutdownGrab();                                       // 停止码流
                    return;
                }
                else
                {
                    throw new InvalidOperationException("设备不存在!");
                }
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
            return;
        }

        private bool SoftTriggerGrabImage()
        {
            try
            {
                if (m_dev != null && m_IsLive)
                {
                    //发送软触发信号
                    m_dev.ExecuteSoftwareTrigger();

                    byte[] getImagePtr;
                    int getImageW, getImageH;
                    HObject getImageObj;

                    // 图像队列取最新帧 
                    // always get the latest frame in list 
                    m_mutex.WaitOne();
                    IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
                    m_frameList.Clear();
                    m_mutex.ReleaseMutex();

                    // 主动调用回收垃圾 
                    // call garbage collection 
                    GC.Collect();

                    int nRGB = RGBFactory.EncodeLen(frame.Width, frame.Height, false);
                    IntPtr pData = Marshal.AllocHGlobal(nRGB);
                    Marshal.Copy(frame.Image, 0, pData, frame.ImageSize);

                    HOperatorSet.GenImage1Extern(out getImageObj, "byte", frame.Width, frame.Height, (HTuple)pData, 0);
                    HOperatorSet.CopyImage(getImageObj, out m_ImageObj);

                    FreeIntptr(pData);
                    //添加图像适应窗口
                    HOperatorSet.SetPart(hWindowControlImage.HalconWindow, 0, 0, frame.Height, frame.Width);
                    HOperatorSet.DispImage(m_ImageObj, hWindowControlImage.HalconWindow);

                    //添加保存图片
                    HTuple MSecond, Second, Minute, Hour, Day, YDay, Month, Year = new HTuple();
                    HOperatorSet.GetSystemTime(out MSecond, out Second, out Minute, out Hour,
                                                out Day, out YDay, out Month, out Year);

                    HTuple Path, Filename = "";
                    HTuple DirExist;
                    //Path = Application.StartupPath;
                    Path = Application.StartupPath + "/" + "Images" + "/" + Month.TupleString("d") + "-" + Day.TupleString("d") + "/";

                    HOperatorSet.FileExists(Path, out DirExist);
                    if (!DirExist)
                        HOperatorSet.MakeDir(Path);

                    Filename = ((((((Path + (Hour.TupleString("d"))) + "时") + (Minute.TupleString("d"))) + "分") + 
                                            (Second.TupleString("d"))) + "秒"+(MSecond.TupleString("d")) + "毫秒") + ".bmp";
                    HOperatorSet.WriteImage(m_ImageObj, "bmp", 0, Filename);
                    //PaintImageWindow(m_ImageObj);

                    GC.Collect();
                }
                return true;
            }
            catch (Exception exception)
            {
                GC.Collect();
                Catcher.Show(exception);
            }


            return false;
        }

        private void buttonOpenCam_Click(object sender, EventArgs e)
        {
            if (m_LineCam != null)
            {                
                m_dev = m_LineCam.OpenCam();
                if(m_dev == null)
                {
                    buttonOpenCam.Enabled = true;
                    return;
                }
                // 注册连接事件 
                m_dev.CameraOpened += OnCameraOpen;
                m_dev.ConnectionLost += OnConnectLoss;
                m_dev.CameraClosed += OnCameraClose;

                buttonOpenCam.Enabled = false;
                buttonCloseCam.Enabled = true;
                checkBoxAsync.Enabled = true;
                buttonStartLive.Enabled = true;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonAdaptShow.Enabled = true;
                buttonPercent100Show.Enabled = true;
                buttonTriggerMode.Enabled = true;

                buttonSetParam.Enabled = true;
                buttonGetParam.Enabled = true;
                comboBoxPixelFormat.Enabled = true;
                trackBarImageWidth.Enabled = true;
                textBoxImageWidth.Enabled = true;
                trackBarImageHeight.Enabled = true;
                textBoxImageHeight.Enabled = true;
                checkBoxEnableLineRate.Enabled = true;
                trackBarLineRate.Enabled = true;
                textBoxLineRate.Enabled = true;
                trackBarExposureTime.Enabled = true;
                textBoxExposureTime.Enabled = true;
                trackBarGain.Enabled = true;
                textBoxGain.Enabled = true;
                trackBarGamma.Enabled = true;
                textBoxGamma.Enabled = true;
                //设置相机通用参数
                ReadCamParam();
            }

            return;
        }

        private void buttonCloseCam_Click(object sender, EventArgs e)
        {
            if (m_LineCam != null)
            {
                bool ok = false;
                ok = m_LineCam.CloseCam();
                if (!ok)
                {
                    return;
                }
            }
            return;
        }

        private void buttonStartLive_Click(object sender, EventArgs e)
        {
            if (m_dev != null)
            {
                if (m_TriMode == true)
                {
                    if (StartSoftTriggerLive())
                    {
                        buttonSoftTriggerGrab.Enabled = true;
                        checkBoxAsync.Enabled = false;
                        buttonStartLive.Enabled = false;
                        buttonStopLive.Enabled = true;
                        buttonSetParam.Enabled = false;
                        buttonGetParam.Enabled = false;
                        buttonTriggerMode.Enabled = false;
                    }
                }
                else
                {
                    if (StartLive())
                    {
                        buttonSoftTriggerGrab.Enabled = false;
                        checkBoxAsync.Enabled = false;
                        buttonStartLive.Enabled = false;
                        buttonStopLive.Enabled = true;
                        buttonSetParam.Enabled = false;
                        buttonGetParam.Enabled = false;
                        buttonTriggerMode.Enabled = false;
                    }
                }
            }

            return;
        }

        private void buttonStopLive_Click(object sender, EventArgs e)
        {
            if (m_LineCam != null)
            {
                StopLive();
            }
            return;
        }

        private void buttonSoftTriggerGrab_Click(object sender, EventArgs e)
        {
            if (m_dev != null)
            {
                checkBoxAsync.Enabled = false;
                buttonStartLive.Enabled = false;
                buttonStopLive.Enabled = false;
                buttonSoftTriggerGrab.Enabled = false;
                buttonSetParam.Enabled = false;
                buttonGetParam.Enabled = false;

                if (!SoftTriggerGrabImage())
                {
                    checkBoxAsync.Enabled = false;
                    buttonStartLive.Enabled = false;
                    buttonStopLive.Enabled = true;
                    buttonSoftTriggerGrab.Enabled = true;
                    buttonSetParam.Enabled = false;
                    buttonGetParam.Enabled = false;

                    return;
                }

                checkBoxAsync.Enabled = false;
                buttonStartLive.Enabled = false;
                buttonStopLive.Enabled = true;
                buttonSoftTriggerGrab.Enabled = true;
                buttonSetParam.Enabled = false;
                buttonGetParam.Enabled = false;
            }
            else
            {
                throw new InvalidOperationException("设备不存在");
            }

            return;
        }

        private void buttonAdaptShow_Click(object sender, EventArgs e)
        {
            if (m_ImageObj.CountObj() <= 0)
            {
                return;
            }

            double tmpFactor = 1.0;
            bool tmpResize = false;

            if (!CalculateAdaptFactor(m_ImageObj, out tmpFactor, out tmpResize))
            {
                return;
            }

            hWindowControlImage.HalconWindow.ClearWindow();
            SetPart();

            if (tmpResize)
            {
                DispZoomImage(tmpFactor, m_ImageObj);
            }
            else
            {
                DispImage(m_ImageObj);
            }

            return;
        }

        private void buttonPercent100Show_Click(object sender, EventArgs e)
        {
            if (m_ImageObj.CountObj() <= 0)
            {
                return;
            }

            bool tmpResize = false;
            HTuple w = 0, h = 0;
            HObject Percent100_Obj;

            m_Factor = 1.0;
            HOperatorSet.GenEmptyObj(out Percent100_Obj);
            HOperatorSet.ZoomImageFactor(m_ImageObj, out Percent100_Obj, m_Factor, m_Factor, "bicubic");
            HOperatorSet.GetImageSize(Percent100_Obj, out w, out h);
            if (w > hWindowControlImage.Width || h > hWindowControlImage.Height)
            {
                tmpResize = true;
                m_IsMagnify = true;
            }
            else
            {
                tmpResize = false;
                m_IsMagnify = false;
            }

            hWindowControlImage.HalconWindow.ClearWindow();
            SetPart();

            if (tmpResize)
            {
                DispZoomImage(m_Factor, m_ImageObj);
            }
            else
            {
                DispImage(m_ImageObj);
            }

            return;
        }

        //关闭窗口前发生
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_dev != null)
            {
                m_dev.Dispose();
                m_dev = null;
            }
            base.OnClosed(e);
        }

        private void buttonSetParam_Click(object sender, EventArgs e)
        {
            WriteCamParam();
            return;
        }

        private void buttonGetParam_Click(object sender, EventArgs e)
        {
            ReadCamParam();

            return;
        }

        #region 设置滚动条位置写入TextBox
        private void trackBarImageWidth_Scroll(object sender, EventArgs e)
        {
            textBoxImageWidth.Text = trackBarImageWidth.Value.ToString();
        }

        private void trackBarImageHeight_Scroll(object sender, EventArgs e)
        {
            textBoxImageHeight.Text = trackBarImageHeight.Value.ToString();
        }

        private void trackBarLineRate_Scroll(object sender, EventArgs e)
        {
            textBoxLineRate.Text = Math.Round(Convert.ToDouble(trackBarLineRate.Value), 2).ToString("f2");
        }

        private void trackBarExposureTime_Scroll(object sender, EventArgs e)
        {
            textBoxExposureTime.Text = Math.Round(Convert.ToDouble(trackBarExposureTime.Value), 2).ToString("f2");
        }

        private void trackBarGain_Scroll(object sender, EventArgs e)
        {
            textBoxGain.Text = Math.Round(Convert.ToDouble(trackBarGain.Value), 2).ToString("f2");
        }

        private void trackBarGamma_Scroll(object sender, EventArgs e)
        {
            textBoxGamma.Text = Math.Round(Convert.ToDouble(trackBarGamma.Value), 2).ToString("f2");
        }


        #endregion

        private void buttonTriggerMode_Click(object sender, EventArgs e)
        {
            if (m_dev != null)
            {
                if (m_TriMode == false)
                {
                    m_TriMode = true;
                    buttonTriggerMode.Text = "触发模式：Off";
                }
                else
                {
                    m_TriMode = false;
                    buttonTriggerMode.Text = "触发模式：On";
                }
            }
        }

    }
}
