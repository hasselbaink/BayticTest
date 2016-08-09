using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BayticTest
{
    public partial class FormMain : Form
    {
        public static FormMain MainForm;
        public static Vector2 StartMFSize;

        #region InitGlobalSizeCtrl
        void InitGlobalSizeCtrl() {
            MainForm = this;
            StartMFSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
        }
        #endregion

        public FormMain()
        {
            InitializeComponent();
            InitMainTimer();
            InitGlobalSizeCtrl();
            this.KeyUp += AnyKeyUp;
            this.KeyDown += AnyKeyDown;
            Game.Init();
        }

        void AnyKeyDown(object sender, KeyEventArgs e)
        {
            IO.KeyDown(e.KeyCode);
        }

        void AnyKeyUp(object sender, KeyEventArgs e)
        {
            IO.KeyUp(e.KeyCode);
        }

        void MainTimerTick(object sender, EventArgs e)
        {
            Game.FixedUpdate();
        }
    }
}