using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StatRub_v1
{
    public class WaterMark : TextBox
    {
        private string WtMark;
        public string Watermark
        {
            get { return WtMark; }
            set { WtMark = value; SetWatermark(); } // May change this
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWin, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string Param);
        private void SetWatermark()
        {
            const int EM_SETCUEBANNER = 0x1501;
            if (Handle != null)
                SendMessage(Handle, EM_SETCUEBANNER, 0, WtMark);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWatermark();
        }
    }
}

