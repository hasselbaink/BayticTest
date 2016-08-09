using System.ComponentModel;
using BayticTest;
using System.Drawing;

namespace System.Windows.Forms
{
    public class MyButton : Button
    {
        public bool Downed = false;
        public ControlCtrl MyControl;
        float FS = 1;
        public float FontSize { get { return FS; } set { FS = value; } }

        public void Init() {
            MyControl.SetSizeEvent += SetSize;
            this.MouseDown += DownF;
            this.MouseLeave += End;
            this.MouseUp += End;
        }

        void End(object sender, EventArgs e)
        {
            Downed = false;
        }

        void DownF(object sender, MouseEventArgs e)
        {
            Downed = true;
        }

        void SetSize() {
            float FontS = (Size.Height/1.7f-5) * FontSize;
            this.Font = new Font(this.Font.Name, (FontS > 0) ? FontS : 0.001f, FontStyle.Regular);
        }

        public static implicit operator bool(MyButton b){
            return b.Downed;
        }
    }

    public class MyLabel : Label
    {
        public ControlCtrl MyControl;
        float FS = 1;
        public float FontSize { get { return FS; } set { FS = value; } }

        public void Init()
        {
            MyControl.SetSizeEvent += SetSize;
        }

        void SetSize()
        {
            float FontS = (Size.Height / 1.7f - 5) * FontSize;
            this.Font = new Font(this.Font.Name, (FontS > 0) ? FontS : 0.001f, FontStyle.Regular);
        }
    }

    public class Texture : PictureBox
    {
        public ControlCtrl MyControl;
    }
}