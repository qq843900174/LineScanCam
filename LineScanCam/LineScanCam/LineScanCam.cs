using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

using HalconDotNet;
using ThridLibray;


namespace LineScanCam
{
    public class LineScanCamera
    {
        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>(); // 图像缓存列表
        private IDevice m_dev;                                           // 设备对象 
        Mutex m_mutex = new Mutex();        // 锁，保证多线程安全

        //构造函数
        public LineScanCamera()
        {
            m_dev = null;
        }

        // 码流数据回调 
        private void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            m_mutex.WaitOne();
            m_frameList.Add(e.GrabResult.Clone());
            m_mutex.ReleaseMutex();
        }

        public IDevice OpenCam()
        {
            try
            {
                //搜索设备
                List<IDeviceInfo> li = Enumerator.EnumerateDevices();
                if (li.Count > 0)
                {
                    // 获取搜索到的第一个设备 
                    m_dev = Enumerator.GetDeviceByIndex(0);

                    if (!m_dev.Open())
                    {
                        MessageBox.Show("连接相机失败！");
                        return null;
                    }

                    // 设置缓存个数为8（默认值为16） 
                    m_dev.StreamGrabber.SetBufferCount(8);
                }
                else
                {
                    MessageBox.Show("请连接相机！");
                    return null;
                }
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
                return m_dev;
            }
            return m_dev;
        }

        public bool CloseCam()
        {
            try
            {
                if (m_dev == null)
                {
                    throw new InvalidOperationException("设备不存在！");
                }
                m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调
                m_dev.ShutdownGrab();                                       // 停止码流 
                m_dev.Close();                                              // 关闭相机 
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
                return false;
            }
            return true;
        }

        #region 设置相机属性参数（根据不同类型）

        #region (1-5)设置图像类型的相机参数(ImagePixelFormat、TriggerMode、TriggerSelector、AcquisitionMode、TriggerSource)
        //1.设置图像像素格式
        public bool SetImagePixelFormat(string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Image Pixel Format Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取图像像素格式
        public bool GetImagePixelFormat(out string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Get Image Pixel Format Exp:" + e.Message);
                    value = "";
                    return false;
                }
                return true;
            }
            value = "";
            return false;
        }

        //2.设置触发模式
        public bool SetTriggerMode(string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Trigger Mode Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取触发模式
        public bool GetTriggerMode(out string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Get Trigger Mode Exp:" + e.Message);
                    value = "";
                    return false;
                }
                return true;
            }
            value = "";
            return false;
        }

        //3.设置触发选择(控制所选的触发器是否处于触发状态)
        public bool SetTriggerSelector(string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSelector])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Trigger Selector Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取触发选择
        public bool GetTriggerSelector(out string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSelector])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)

                {
                    MessageBox.Show("Get Trigger Selector Exp:" + e.Message);
                    value = "";
                    return false;
                }
                return true;
            }
            value = "";
            return false;
        }

        //4.设置采集模式
        public bool SetAcquisitionMode(string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.AcquisitionMode])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Acquisition Mode Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取采集模式
        public bool GetAcquisitionMode(out string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.AcquisitionMode])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)

                {
                    MessageBox.Show("Get Acquisition Mode Exp:" + e.Message);
                    value = "";
                    return false;
                }
                return true;
            }
            value = "";
            return false;
        }

        //5.设置触发源
        public bool SetTriggerSource(string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSource])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Trigger Source Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取触发源
        public bool GetTriggerSource(out string value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSource])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)

                {
                    MessageBox.Show("Get Trigger Source Exp:" + e.Message);
                    value = "";
                    return false;
                }
                return true;
            }
            value = "";
            return false;
        }
        #endregion

        #region (6-7)设置整型相机参数(Width、Height)
        public bool SetIntegerParam(string IntegerParam, int value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IIntegraParameter p = m_dev.ParameterCollection[new IntegerName(IntegerParam)])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Integer Param Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取整型相机参数
        public bool GetIntegerParam(string IntegerParam, out int value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IIntegraParameter p = m_dev.ParameterCollection[new IntegerName(IntegerParam)])
                    {
                        value = (int)p.GetValue();
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Get Integer Param Exp:" + e.Message);
                    value = 0;
                    return false;
                }
                return true;
            }
            value = 0;
            return false;
        }


        #endregion

        #region (8--11)设置浮点型相机参数(ExposureTime、GainRaw、Gamma、AcquisitionLineRate)
        public bool SetFloatParameter(string FloatParameter, double value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IFloatParameter p = m_dev.ParameterCollection[new FloatName(FloatParameter)])
                    {
                        p.SetValue(value);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Float Param Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取浮点型相机参数
        public bool GetFloatParameter(string FloatParameter, out double value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IFloatParameter p = m_dev.ParameterCollection[new FloatName(FloatParameter)])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Get Float Param Exp:" + e.Message);
                    value = 0;
                    return false;
                }
                return true;
            }
            value = 0;
            return false;
        }
        #endregion

        #region 12.设置布尔型相机参数
        //设置相机同步或异步采集
        public bool SetAcquisitionLineRateEnable(bool value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IBooleanParameter p = m_dev.ParameterCollection[new BooleanName("AcquisitionLineRateEnable")])
                    {
                        p.SetValue(value);//false是同步采集，true是异步采集
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Acquisition Line Rate Enable Exp:" + e.Message);
                    return false;
                }
                return true;
            }
            return false;
        }
        //获取相机同步或异步采集
        public bool GetAcquisitionLineRateEnable(out bool value)
        {
            if (m_dev != null)
            {
                try
                {
                    using (IBooleanParameter p = m_dev.ParameterCollection[new BooleanName("AcquisitionLineRateEnable")])
                    {
                        value = p.GetValue();
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Set Acquisition Line Rate Enable Exp:" + e.Message);
                    value = false;
                    return false;
                }
                return true;
            }
            value = false;
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #endregion

        public bool StreamGrab()
        {
            if (m_dev != null)
            { 
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
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool StopStreamGrab()
        {
            if (m_dev != null)
            {
                m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调
                m_dev.ShutdownGrab();                                       // 停止码流
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool GrabImage(out IntPtr pData, out int ImageWidth, out int ImageHeight)
        {
            if (m_dev != null)
            { 
                // 图像队列取最新帧 
                m_mutex.WaitOne();
                IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
                m_frameList.Clear();
                m_mutex.ReleaseMutex();

                // 主动调用回收垃圾 
                GC.Collect();
                int nRGB = RGBFactory.EncodeLen(frame.Width, frame.Height, false);
                pData = Marshal.AllocHGlobal(nRGB);
                Marshal.Copy(frame.Image, 0, pData, frame.ImageSize);
                ImageWidth = frame.Width;
                ImageHeight = frame.Height;
            }
            else
            {
                pData = (IntPtr)0;
                ImageWidth = 0;
                ImageHeight = 0;
                return false;
            }
            return true;
        }
    }
}
