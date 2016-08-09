using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BayticTest
{
    public partial class FormMain : Form
    {
        #region MainTimer
        Timer MainTimer = new Timer();
        void InitMainTimer()
        {
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 16;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimerTick);
        }
        #endregion
    }
}
