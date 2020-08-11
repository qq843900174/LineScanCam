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
    public class LineScanCam
    {
        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>(); // 图像缓存列表

    }
}
